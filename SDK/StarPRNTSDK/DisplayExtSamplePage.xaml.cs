using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class DisplayExtSamplePage : Page
    {
        private IPort port;
        private Thread monitoringDisplayThread;
        private bool cancellationPending;
        private object lockObject;

        /// <summary>
        /// Sample : Starting monitoring display.
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
                if (monitoringDisplayThread == null || monitoringDisplayThread.ThreadState == ThreadState.Stopped)
                {
                    monitoringDisplayThread = new Thread(MonitoringDisplay);
                    monitoringDisplayThread.Name = "MonitoringDisplayThread";
                    monitoringDisplayThread.IsBackground = true;
                    monitoringDisplayThread.Start();
                }

                isConnect = true;
            }
            catch (Exception) // Start monitoring display thread is failure.
            {
                DidConnectFailed();
            }
        }

        /// <summary>
        /// Sample : Stoping monitoring display.
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
            }
        }

        private bool StopMonitoringThread()
        {
            if (monitoringDisplayThread == null)
            {
                return true;
            }

            bool result = false;

            try
            {
                if ((monitoringDisplayThread.ThreadState & (ThreadState.Aborted | ThreadState.Stopped)) == 0)
                {
                    cancellationPending = true;

                    if (!monitoringDisplayThread.Join(TimeSpan.FromSeconds(5)))
                    {
                        monitoringDisplayThread.Abort();

                        if (!monitoringDisplayThread.Join(TimeSpan.FromSeconds(5)))
                        {
                            throw new Exception("Stopping thread is failed.");
                        }
                    }
                }

                monitoringDisplayThread = null;

                result = true; // Success.
            }
            catch (Exception) { }

            cancellationPending = false;

            return result;
        }

        /// <summary>
        /// Sample : Monitoring display process.
        /// </summary>
        private void MonitoringDisplay()
        {
            while (!cancellationPending)
            {
                lock (lockObject)
                {
                    try
                    {
                        if (port != null)
                        {
                            // Check display status.
                            Communication.PeripheralStatus status = DisplaySampleManager.GetDiaplayStatus(port);

                            switch (status)
                            {
                                default:
                                case Communication.PeripheralStatus.Impossible:
                                    OnPrinterImpossible();
                                    break;

                                case Communication.PeripheralStatus.Connect:
                                    OnDisplayConnect();
                                    break;

                                case Communication.PeripheralStatus.Disconnect:
                                    OnDisplayDisconnect();
                                    break;

                            }
                        }
                    }
                    catch (PortException)
                    {
                        OnPrinterImpossible();
                    }
                }

                Thread.Sleep(1000);
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

        private void OnDisplayConnect()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "";
            })
            );
        }

        private void OnDisplayDisconnect()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Display Disconnect.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            })
            );
        }

        private void OnPrinterImpossible()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Impossible.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            })
            );
        }

        private Communication.PeripheralStatus CallDisplayFunction(DisplayFunctionManager.FunctionType type, int selectedIndex)
        {
            Communication.PeripheralStatus result = Communication.PeripheralStatus.Invalid;

            lock (lockObject)
            {
                switch (type)
                {
                    case DisplayFunctionManager.FunctionType.Text:
                        result = DisplaySampleManager.DoTextPattern((DisplayFunctionManager.TextPattern)Enum.ToObject(typeof(DisplayFunctionManager.TextPattern), selectedIndex), port);
                        break;

                    case DisplayFunctionManager.FunctionType.Graphic:
                        result = DisplaySampleManager.DoGraphicPattern((DisplayFunctionManager.GraphicPattern)Enum.ToObject(typeof(DisplayFunctionManager.GraphicPattern), selectedIndex), port);
                        break;

                    case DisplayFunctionManager.FunctionType.TurnOnOff:
                        bool turnOn;
                        if (selectedIndex == 0)
                        {
                            turnOn = true;
                        }
                        else
                        {
                            turnOn = false;
                        }

                        result = DisplaySampleManager.DoTurnOnOffPattern(turnOn, port);
                        break;

                    case DisplayFunctionManager.FunctionType.Cursor:
                        result = DisplaySampleManager.DoCursorPattern((DisplayCursorMode)Enum.ToObject(typeof(DisplayCursorMode), selectedIndex), port);
                        break;

                    case DisplayFunctionManager.FunctionType.Contrast:
                        result = DisplaySampleManager.DoContrastPattern((DisplayContrastMode)Enum.ToObject(typeof(DisplayContrastMode), selectedIndex), port);
                        break;

                    case DisplayFunctionManager.FunctionType.CharacterSetInternational:
                        DisplayInternationalType internationalType = (DisplayInternationalType)Enum.ToObject(typeof(DisplayInternationalType), selectedIndex);

                        result = DisplaySampleManager.DoCharacterSetInternationalPattern(internationalType, port);

                        SharedInformationManager.SelectedDisplayInternationalType = internationalType;
                        break;

                    case DisplayFunctionManager.FunctionType.CharacterSetCodePage:
                        DisplayCodePageType codePageType = (DisplayCodePageType)Enum.ToObject(typeof(DisplayCodePageType), selectedIndex);

                        result = DisplaySampleManager.DoCharacterSetCodePagePattern(codePageType, port);

                        SharedInformationManager.SelectedDisplayCodePageType = codePageType;
                        break;

                    case DisplayFunctionManager.FunctionType.UserDefinedCharacter:
                        bool set;
                        if ((DisplayFunctionManager.UserDefinedCharacterPattern)Enum.ToObject(typeof(DisplayFunctionManager.UserDefinedCharacterPattern), selectedIndex) == DisplayFunctionManager.UserDefinedCharacterPattern.Set)
                        {
                            set = true;
                        }
                        else
                        {
                            set = false;
                        }

                        result = DisplaySampleManager.DoUserDefinedCharacterPattern(set, port);
                        break;

                    default:
                        break;
                }
            }

            return result;
        }

        private void CallDisplayFunctionWithProgressBar(DisplayFunctionManager.FunctionType type, int selectedIndex)
        {
            Communication.PeripheralStatus result = Communication.PeripheralStatus.Invalid;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = CallDisplayFunction(type, selectedIndex);
            });

            progressBarWindow.ShowDialog();

            if (result != Communication.PeripheralStatus.Connect)
            {
                Communication.ShowPeripheralStatusResultMessage("Display", result);
            }
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

        private void SelectPatternComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox selectionChangedComboBox = (ComboBox)sender;

            DisplayFunctionManager.FunctionType type;

            if (selectionChangedComboBox == SelectPatternComboBox)
            {
                type = SharedInformationManager.SelectedDisplayFunctionType;
            }
            else
            {
                type = SharedInformationManager.SelectedAdditionDisplayFunctionType;
            }

            int selectedIndex = selectionChangedComboBox.SelectedIndex;

            if (isConnect && !notCallFunction && selectedIndex >= 0)
            {
                CallDisplayFunctionWithProgressBar(type, selectedIndex);
            }
        }

        private void DisplayFunction_Updated(object sender, DataTransferEventArgs e)
        {
            DisplayFunctionManager.FunctionType type = SharedInformationManager.SelectedDisplayFunctionType;

            int selectedIndex = SharedInformationManager.SelectedDisplayFunctionDefaultPatternIndex;

            if (isConnect)
            {
                CallDisplayFunctionWithProgressBar(type, selectedIndex);
            }

            notCallFunction = true;

            SelectPatternComboBox.SelectedIndex = selectedIndex;

            SelectAdditionPatternComboBox.SelectedIndex = SharedInformationManager.SelectedDisplayFunctionDefaultAdditionPatternIndex;

            notCallFunction = false;
        }

        private bool isConnect;

        private bool notCallFunction;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectWithProgressBar();

            SharedInformationManager.DisplayFunctionManager.Type = DisplayFunctionManager.FunctionType.Text;
            SharedInformationManager.DisplayFunctionManager.AdditionType = DisplayFunctionManager.FunctionType.Invalid;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DisconnectWithProgressBar();
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectWithProgressBar();
        }

        public DisplayExtSamplePage()
        {
            InitializeComponent();

            lockObject = new object();
        }
    }
}
