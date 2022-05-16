using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.ComponentModel;
using System.Printing;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class PrinterDriverWithBarcodeReaderSamplePage : Page, INotifyPropertyChanged
    {
        private StarPrintPortJobMonitor starPrintPortJobMonitor;
        private IPort port;
        private Thread monitoringBarcodeReaderThread;
        private bool cancellationPending;
        private object lockObject;
        private Communication.PeripheralStatus barcodeReaderStatus;

        /// <summary>
        /// Sample : Setting StarPrintJobMonitor object.
        /// </summary>
        private void SetStarPrintPortJobMonitor()
        {
            // Your printer PortName.
            string portName = SharedInformationManager.SelectedPortName;

            // Create StarPrintJobMonitor object.
            starPrintPortJobMonitor = new StarPrintPortJobMonitor(portName);
            starPrintPortJobMonitor.PrintQueueJobIsAdded += OnPrintQueueJobIsAdded;         // Add called event when printer queue job is added.
            starPrintPortJobMonitor.PrintQueueJobIsRemoved += OnPrintQueueJobIsRemoved;         // Add called event when printer queue job is added.
            starPrintPortJobMonitor.PrintQueueAllJobsAreCompleted += OnPrintQueueAllJobsAreCompleted; // Add called event when printer queue all jobs are completed.
            PrinterQueueJobCount = starPrintPortJobMonitor.JobCount; // Can get current printer queue job count.

            // start printer queue job monitoring.
            starPrintPortJobMonitor.Start();

            //starPrintPortJobMonitor.Stop(); // if you would like stop monitoring job call this method.
        }

        /// <summary>
        /// Sample : Event called when printer queue job is added.
        /// When printer queue jobs exist, stop monitoring printer to complete printer queue job.
        /// </summary>
        private void OnPrintQueueJobIsAdded(object sender, object e)
        {
            PrinterQueueJobCount = starPrintPortJobMonitor.JobCount;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                // If port is used, release port.
                if (port != null)
                {
                    bool result = ShowReleasePortConfirmWindow();

                    if (result)
                    {
                        IsMonitoring = false; // Call StopMonitoringPrinterThread().
                    }
                }
            })
            );
        }

        /// <summary>
        /// Sample : Event called when printer queue  all jobs are completed.
        /// When printer queue all jobs are completed, you can monitoring printer again.
        /// </summary>
        private void OnPrintQueueAllJobsAreCompleted(object sender, object e)
        {
            PrinterQueueJobCount = starPrintPortJobMonitor.JobCount;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (port == null)
                {
                    bool result = ShowReconnectConfirmWindow();

                    if (result)
                    {
                        IsMonitoring = true; // Call StopMonitoringPrinterThread().
                    }
                }
            })
            );
        }

        /// <summary>
        /// Sample : Event called when printer queue job is removed.
        /// </summary>
        private void OnPrintQueueJobIsRemoved(object sender, object e)
        {
            PrinterQueueJobCount = starPrintPortJobMonitor.JobCount;
        }

        /// <summary>
        /// Sample : Starting monitoring barcode reader.
        /// </summary>
        public void Connect()
        {
            try
            {
                if (port == null)
                {
                    // Your printer PortName and PortSettings.
                    string portName = SharedInformationManager.SelectedPortName;
                    string portSettings = SharedInformationManager.SelectedPortSettings;

                    port = Factory.I.GetPort(portName, portSettings, 10000);

                    // First, clear barcode reader buffer.
                    ClearBarcodeReaderBuffer();
                }
            }
            catch (PortException) // Port open is failed.
            {
                DidConnectFailed();

                return;
            }

            try
            {
                if (monitoringBarcodeReaderThread == null || monitoringBarcodeReaderThread.ThreadState == ThreadState.Stopped)
                {
                    monitoringBarcodeReaderThread = new Thread(MonitoringBarcodeReader);
                    monitoringBarcodeReaderThread.Name = "MonitoringBarcodeReaderThread";
                    monitoringBarcodeReaderThread.IsBackground = true;
                    monitoringBarcodeReaderThread.Start();
                }

            }
            catch (Exception) // Start monitoring barcode reader thread is failure.
            {
                DidConnectFailed();
            }

            barcodeReaderStatus = Communication.PeripheralStatus.Invalid;
        }

        /// <summary>
        /// Sample : Stoping monitoring barcode reader.
        /// </summary>
        public void Disconnect()
        {
            bool isThreadStopped = StopMonitoringThread(); // Stop monitoring thread.

            if (isThreadStopped)
            {
                if (port != null) // Release port.
                {
                    Factory.I.ReleasePort(port);

                    port = null;
                }

                OnStopMonitoringBarcodeReader();
            }
        }

        private bool StopMonitoringThread()
        {
            if (monitoringBarcodeReaderThread == null)
            {
                return true;
            }

            bool result = false;

            try
            {
                if ((monitoringBarcodeReaderThread.ThreadState & (ThreadState.Aborted | ThreadState.Stopped)) == 0)
                {
                    cancellationPending = true;

                    if (!monitoringBarcodeReaderThread.Join(TimeSpan.FromSeconds(5)))
                    {
                        monitoringBarcodeReaderThread.Abort();

                        if (!monitoringBarcodeReaderThread.Join(TimeSpan.FromSeconds(5)))
                        {
                            throw new Exception("Stopping thread is failed.");
                        }
                    }
                }

                monitoringBarcodeReaderThread = null;

                result = true; // Success.
            }
            catch (Exception) { }

            cancellationPending = false;

            return result;
        }

        /// <summary>
        /// Sample : Monitoring barcode reader process.
        /// </summary>
        private void MonitoringBarcodeReader()
        {
            // Your printer emulation.            
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            while (!cancellationPending)
            {
                lock (lockObject)
                {
                    try
                    {
                        if (port != null)
                        {
                            CheckBarcodeReaderStatus(); // Check barcode reader status. (connect or disconnect)

                            if (barcodeReaderStatus == Communication.PeripheralStatus.Connect) // Barcode reader is connected.
                            {
                                ReadBarcodeReaderData();  // Read barcode reader data.
                            }
                        }
                    }
                    catch (PortException)
                    {
                        OnBarcodeReaderImpossible();
                    }
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Sample : Clearing barcode reader buffer.
        /// </summary>
        private void ClearBarcodeReaderBuffer()
        {
            byte[] clearBufferCommands = BcrFunctions.CreateClearBuffer();

            port.WritePort(clearBufferCommands, 0, (uint)clearBufferCommands.Length);
        }

        /// <summary>
        /// Sample : Checking barcode reader status.
        /// </summary>
        private void CheckBarcodeReaderStatus()
        {
            // Create IPeripheralConnectParser object.
            IPeripheralConnectParser parser = StarIoExt.CreateBcrConnectParser(BcrModel.POP1);

            // Usage of parser sample is "Communication.ParseDoNotCheckCondition(IPeripheralCommandParser parser, IPort port)".
            CommunicationResult result = Communication.ParseDoNotCheckCondition(parser, port);

            // Check peripheral status.
            barcodeReaderStatus = Communication.PeripheralStatus.Invalid;
            if (result.Result == Communication.Result.Success)
            {
                // Check parser property value.
                if (parser.IsConnected) // connect
                {
                    barcodeReaderStatus = Communication.PeripheralStatus.Connect;
                }
                else // disconnect
                {
                    barcodeReaderStatus = Communication.PeripheralStatus.Disconnect;
                }
            }
            else // communication error
            {
                barcodeReaderStatus = Communication.PeripheralStatus.Impossible;
            }

            switch (barcodeReaderStatus)
            {
                default:
                case Communication.PeripheralStatus.Impossible:
                    OnBarcodeReaderImpossible();
                    break;

                case Communication.PeripheralStatus.Connect:
                    OnBarcodeReaderConnect();
                    break;

                case Communication.PeripheralStatus.Disconnect:
                    OnBarcodeReaderDisconnect();
                    break;
            }
        }

        /// <summary>
        /// Sample : Reading barcode reader data.
        /// </summary>
        private void ReadBarcodeReaderData()
        {
            // Barcode reader data parser sample is in "BcrDataParser" class.
            BcrDataParser parser = new BcrDataParser();

            // Usage of parser sample is "Communication.ParseDoNotCheckCondition(IPeripheralCommandParser parser, IPort port)".
            CommunicationResult result = Communication.ParseDoNotCheckCondition(parser, port);

            if (result.Result != Communication.Result.Success)
            {
                OnBarcodeReaderImpossible();

                return;
            }

            // Check parser property value.
            byte[] barcodeData = parser.Data;

            if (barcodeData != null) // Barcode reader data is not empty.
            {
                OnBarcodeDataReceived(barcodeData);
            }
        }

        private void OnBarcodeDataReceived(byte[] receivedData)
        {
            string text = Encoding.UTF8.GetString(receivedData, 0, receivedData.Length);

            Dispatcher.BeginInvoke(new Action(() =>
            {
                AddTextToList(text);
            })
            );
        }

        private void DidConnectFailed()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = "Check the device. (Power and Bluetooth pairing)\nThen touch up the Refresh button.";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            })
            );
        }

        private void OnBarcodeReaderImpossible()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = "Barcode Reader Impossible.";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Red);

            })
            );

        }

        private void OnBarcodeReaderConnect()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = "Barcode Reader Connect.";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);

            })
            );

        }

        private void OnBarcodeReaderDisconnect()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = "Barcode Reader Disconnect.";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Red);

            })
            );
        }

        private void OnStopMonitoringBarcodeReader()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTextBlock.Text = "Monitoring Barcode Reader is stopped.";
                StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            })
            );
        }

        private void AddTextToList(string text)
        {
            string[] splittedTextArray = text.Split('\n');

            foreach (var splittedText in splittedTextArray)
            {
                if (!splittedText.Equals(""))
                {
                    string barcode = splittedText;

                    int index = splittedText.IndexOf("\r");

                    if (index != -1)
                    {
                        barcode = barcode.Substring(0, index);
                    }

                    readDataListBox.Items.Add(barcode);

                    pageScrollViewer.ScrollToBottom();
                }
            }
        }

        private void ClearTextFromList()
        {
            readDataListBox.Items.Clear();

            pageScrollViewer.ScrollToBottom();
        }

        private void PrintReceiptViaPrinterDriverWithProgressBar()
        {
            string portName = SharedInformationManager.SelectedPortName;
            PrintQueue[] printQueues = starPrintPortJobMonitor.PrintQueues;
            LocalizeReceipt localizeReceipt = SharedInformationManager.SelectedLocalizeReceipt;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                Thread thread = new Thread(
                () =>
                {
                    foreach (PrintQueue printQueue in printQueues)
                    {
                        PrinterDriverManager.PrintViaPrinterDriver(printQueue, localizeReceipt.CreateRasterImageText(), localizeReceipt.RasterReceiptFont);
                    }
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            });

            progressBarWindow.ShowDialog();

            Util.FocusMainWindow();
        }

        private void ConnectWithProgressBar()
        {
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                Connect();
            });

            progressBarWindow.ShowDialog();
        }

        private void DisconnectWithProgressBar()
        {
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Disconneting Printer...", () =>
            {
                Disconnect();
            });

            progressBarWindow.ShowDialog();
        }

        private bool isShowConfirmWindow;

        private bool ShowReleasePortConfirmWindow()
        {
            if (isShowConfirmWindow)
            {
                return false;
            }

            isShowConfirmWindow = true;

            MessageBoxResult messageBoxResult = MessageBox.Show("Port is used, so can not print via printer driver. Release port?", "Confirm", MessageBoxButton.YesNo);
            bool result = (messageBoxResult == MessageBoxResult.Yes);

            isShowConfirmWindow = false;

            return result;
        }

        private bool ShowReconnectConfirmWindow()
        {
            if (isShowConfirmWindow)
            {
                return false;
            }

            isShowConfirmWindow = true;

            MessageBoxResult messageBoxResult = MessageBox.Show("Printer driver job is completed. Start monitoring Barcode Reader?", "Confirm", MessageBoxButton.YesNo);
            bool result = (messageBoxResult == MessageBoxResult.Yes);

            isShowConfirmWindow = false;

            return result;
        }

        public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.Register("IsMonitoring", typeof(bool), typeof(PrinterDriverWithBarcodeReaderSamplePage));

        public bool IsMonitoring
        {
            get
            {
                return (bool)GetValue(IsMonitoringProperty);
            }
            set
            {
                SetValue(IsMonitoringProperty, value);

                if (value)
                {
                    ConnectWithProgressBar();
                }
                else
                {
                    DisconnectWithProgressBar();
                }

                OnPropertyChanged("IsMonitoring");
            }
        }

        public int PrinterQueueJobCount
        {
            get
            {
                return printerQueueJobCount;
            }
            set
            {
                printerQueueJobCount = value;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    jobCountTextBlock.Text = "Printer Queue Job Count : " + printerQueueJobCount.ToString();

                    if (printerQueueJobCount == 0)
                    {
                        jobCountTextBlock.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        jobCountTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                    }
                })
                );
            }
        }
        private int printerQueueJobCount;

        public PrinterDriverWithBarcodeReaderSamplePage()
        {
            InitializeComponent();

            SetStarPrintPortJobMonitor();

            statusMonitorCheckBox.DataContext = this;

            lockObject = new object();

            isShowConfirmWindow = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IsMonitoring = true;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            IsMonitoring = false;

            starPrintPortJobMonitor.Stop();
        }

        private void PrintViaPrinterDriverButton_Click(object sender, RoutedEventArgs e)
        {
            PrintReceiptViaPrinterDriverWithProgressBar();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            IsMonitoring = true;

            ClearTextFromList();
        }

        private void StatusMonitorCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox statusMonitorCheckBox = (CheckBox)sender;

            IsMonitoring = (bool)statusMonitorCheckBox.IsChecked;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
