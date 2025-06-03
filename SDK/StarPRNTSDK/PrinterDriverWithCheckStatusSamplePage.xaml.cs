using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.ComponentModel;
using System.Printing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class PrinterDriverWithCheckStatusSamplePage : Page, INotifyPropertyChanged
    {
        public enum PrinterStatus
        {
            Invalid,
            Impossible,
            Online,
            Offline
        }

        public enum PaperStatus
        {
            Invalid,
            Ready,
            NearEmpty,
            Empty
        }

        public enum CoverStatus
        {
            Invalid,
            Open,
            Close
        }

        private StarPrintPortJobMonitor starPrintPortJobMonitor;
        private IPort port;
        private Thread monitoringPrinterThread;
        private bool cancellationPending;
        private object lockObject;
        private PrinterStatus currentPrinterStatus;
        private PaperStatus currentPaperStatus;
        private CoverStatus currentCoverStatus;

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
        /// Sample : Starting monitoring printer.
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
                }
            }
            catch (PortException) // Port open is failed.
            {
                DidConnectFailed();

                return;
            }

            try
            {
                if (monitoringPrinterThread == null || monitoringPrinterThread.ThreadState == ThreadState.Stopped)
                {
                    monitoringPrinterThread = new Thread(MonitoringPrinter);
                    monitoringPrinterThread.Name = "MonitoringPrinterThread";
                    monitoringPrinterThread.IsBackground = true;
                    monitoringPrinterThread.Start();
                }

            }
            catch (Exception) // Start monitoring printer thread is failure.
            {
                DidConnectFailed();
            }

            currentPrinterStatus = PrinterStatus.Invalid;
            currentPaperStatus = PaperStatus.Invalid;
            currentCoverStatus = CoverStatus.Invalid;
        }

        /// <summary>
        /// Sample : Stoping monitoring printer.
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

                OnStopMonitoringPrinter();
            }
        }

        private bool StopMonitoringThread()
        {
            if (monitoringPrinterThread == null)
            {
                return true;
            }

            bool result = false;

            try
            {
                if ((monitoringPrinterThread.ThreadState & (ThreadState.Aborted | ThreadState.Stopped)) == 0)
                {
                    cancellationPending = true;

                    if (!monitoringPrinterThread.Join(TimeSpan.FromSeconds(5)))
                    {
                        monitoringPrinterThread.Abort();

                        if (!monitoringPrinterThread.Join(TimeSpan.FromSeconds(5)))
                        {
                            throw new Exception("Stopping thread is failed.");
                        }
                    }
                }

                monitoringPrinterThread = null;

                result = true; // Success.
            }
            catch (Exception) { }

            cancellationPending = false;

            return result;
        }

        /// <summary>
        /// Sample : Monitoring printer process.
        /// </summary>
        private void MonitoringPrinter()
        {
            while (!cancellationPending)
            {
                lock (lockObject)
                {
                    try
                    {
                        if (port != null)
                        {
                            StarPrinterStatus status = port.GetParsedStatus();

                            CheckPrinterStatus(status); // Check printer status.

                            CheckPaperStatus(status); // Check paper status.

                            CheckCoverStatus(status); // Check cover status.
                        }
                    }
                    catch (Exception) // Printer impossible
                    {
                        OnPrinterImpossible();
                    }
                }

                Thread.Sleep(1000);
            }
        }

        private void CheckPrinterStatus(StarPrinterStatus status)
        {
            if (status.Offline) // Printer offline
            {
                OnPrinterOffline();
            }
            else                // Printer online
            {
                OnPrinterOnline();
            }
        }

        private void CheckPaperStatus(StarPrinterStatus status)
        {
            if (status.ReceiptPaperEmpty)                 // Paper empty
            {
                OnPrinterPaperEmpty();
            }
            else if (status.ReceiptPaperNearEmptyInner || // Paper near empty
                     status.ReceiptPaperNearEmptyOuter)
            {
                OnPrinterPaperNearEmpty();
            }
            else                                          // Paper ready
            {
                OnPrinterPaperReady();
            }
        }

        private void CheckCoverStatus(StarPrinterStatus status)
        {
            if (status.CoverOpen) // Cover open
            {
                OnPrinterCoverOpen();
            }
            else                  // Cover close
            {
                OnPrinterCoverClose();
            }
        }

        private void DidConnectFailed()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Check the device. (Power and Bluetooth pairing)\nThen touch up the Refresh button.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            })
            );
        }

        private void OnPrinterImpossible()
        {
            if (currentPrinterStatus != PrinterStatus.Impossible)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Printer Impossible.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                })
                );
            }

            currentPrinterStatus = PrinterStatus.Impossible;
        }

        private void OnPrinterOnline()
        {
            if (currentPrinterStatus != PrinterStatus.Online)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Printer Online.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
                })
                );
            }

            currentPrinterStatus = PrinterStatus.Online;
        }

        private void OnPrinterOffline()
        {
            if (currentPrinterStatus != PrinterStatus.Offline)
            {
                //Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    statusTextBlock.Text = "Printer Offline.";
                //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                //})
                //);
            }

            currentPrinterStatus = PrinterStatus.Offline;
        }

        private void OnPrinterPaperNearEmpty()
        {
            if (currentPaperStatus != PaperStatus.NearEmpty)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Printer Paper Near Empty.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Orange);
                })
                );
            }

            currentPaperStatus = PaperStatus.NearEmpty;
        }

        private void OnPrinterPaperEmpty()
        {
            if (currentPaperStatus != PaperStatus.Empty)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Printer Paper Empty.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                })
                );
            }

            currentPaperStatus = PaperStatus.Empty;
        }

        private void OnPrinterPaperReady()
        {
            if (currentPaperStatus != PaperStatus.Ready)
            {
                //Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    statusTextBlock.Text = "Printer Paper Ready.";
                //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
                //})
                //);
            }

            currentPaperStatus = PaperStatus.Ready;
        }

        private void OnPrinterCoverOpen()
        {
            if (currentCoverStatus != CoverStatus.Open)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Printer Cover Open.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                })
                );
            }

            currentCoverStatus = CoverStatus.Open;
        }

        private void OnPrinterCoverClose()
        {
            if (currentCoverStatus != CoverStatus.Close)
            {
                //Dispatcher.BeginInvoke(new Action(() =>
                //{
                //    statusTextBlock.Text = "Printer Cover Close.";
                //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
                //})
                //);
            }

            currentCoverStatus = CoverStatus.Close;
        }

        private void OnStopMonitoringPrinter()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Monitoring Printer Status is stopped.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            })
            );
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

            MessageBoxResult messageBoxResult = MessageBox.Show("Printer driver job is completed. Start monitoring printer status?", "Confirm", MessageBoxButton.YesNo);
            bool result = (messageBoxResult == MessageBoxResult.Yes);

            isShowConfirmWindow = false;

            return result;
        }

        public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.Register("IsMonitoring", typeof(bool), typeof(PrinterDriverWithCheckStatusSamplePage));

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

        public PrinterDriverWithCheckStatusSamplePage()
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
