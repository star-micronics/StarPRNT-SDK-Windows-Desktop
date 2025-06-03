using StarMicronics.StarIOExtension;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class AutoSwitchInterfaceExtSamplePage : Page
    {
        private StarIoExtManager StarIoExtManager { get; set; }
        private ProgressBarWindow ProgressBarWindow { get; set; }

        public AutoSwitchInterfaceExtSamplePage()
        {
            InitializeComponent();

            // Your printer settings.
            string portSettings = SharedInformationManager.SelectedPortSettings;
            bool drawerOpenStatus = SharedInformationManager.SelectedDrawerOpenStatus;

            // Specifying AutoSwitch: for portName allows you to automatically select the interface for connecting to the printer.
            if (SharedInformationManager.SelectedModelInformation.BarcodeReaderIsEnabled)
            { 
                StarIoExtManager = new StarIoExtManager("AutoSwitch:", portSettings, 30000, StarIoExtManagerType.WithBarcodeReader);
            }
            else
            {
                StarIoExtManager = new StarIoExtManager("AutoSwitch:", portSettings, 30000, StarIoExtManagerType.Standard);

            }

            StarIoExtManager.CashDrawerOpenActiveHigh = drawerOpenStatus;
            StarIoExtManager.PrinterConnect += StarIoExtManager_PrinterConnect;
            StarIoExtManager.PrinterDisconnect += StarIoExtManager_PrinterDisconnect;
            StarIoExtManager.PrinterImpossible += StarIoExtManager_PrinterImpossible;
            StarIoExtManager.PrinterOnline += StarIoExtManager_PrinterOnline;
            StarIoExtManager.PrinterOffline += StarIoExtManager_PrinterOffline;
            StarIoExtManager.PrinterPaperReady += StarIoExtManager_PrinterPaperReady;
            StarIoExtManager.PrinterPaperNearEmpty += StarIoExtManager_PrinterPaperNearEmpty;
            StarIoExtManager.PrinterPaperEmpty += StarIoExtManager_PrinterPaperEmpty;
            StarIoExtManager.PrinterCoverOpen += StarIoExtManager_PrinterCoverOpen;
            StarIoExtManager.PrinterCoverClose += StarIoExtManager_PrinterCoverClose;
            StarIoExtManager.CashDrawerOpen += StarIoExtManager_CashDrawerOpen;
            StarIoExtManager.CashDrawerClose += StarIoExtManager_CashDrawerClose;
            StarIoExtManager.BarcodeReaderImpossible += StarIoExtManager_BarcodeReaderImpossible;
            StarIoExtManager.BarcodeReaderConnect += StarIoExtManager_BarcodeReaderConnect;
            StarIoExtManager.BarcodeReaderDisconnect += StarIoExtManager_BarcodeReaderDisconnect;
            StarIoExtManager.BarcodeDataReceive += StarIoExtManager_BarcodeDataReceive;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Step 1: Perform Bluetooth pairing and also connect to LAN to take advantage of the AutoSwitch Interface feature." + Environment.NewLine +
                            "Step 2: Connect to the printer via USB and press the OK button." + Environment.NewLine +
                            "Step 3: Disconnect the USB cable. You can automatically connect to a printer via Bluetooth or LAN interface and monitoring printer." + Environment.NewLine +
                            "Step 4: Reconnect to the printer via USB or Bluetooth. Printer is automatically connected via USB or Bluetooth.",
                            "How to test AutoSwitch Interface function", MessageBoxButton.OK);

            StarIoExtManager.ConnectAync();

            ProgressBarWindow = new ProgressBarWindow() { Title = "Connecting..." };
            ProgressBarWindow.ShowDialog();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            StarIoExtManager.DisconnectAsync();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextFromList();

            StarIoExtManager.DisconnectAsync();

            ProgressBarWindow = new ProgressBarWindow() { Title = "Refreshing..." };
            ProgressBarWindow.ShowDialog();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintReceiptAndOpenCashDrawer();
        }

        void StarIoExtManager_PrinterConnect(object sender, PrinterConnectEventArgs e)
        {
            ProgressBarWindow.Close();

            if (e.Error != null)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    statusTextBlock.Text = "Check the device. (Power and Bluetooth pairing)\nThen touch up the Refresh button.";
                    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                }));
            }
        }

        void StarIoExtManager_PrinterDisconnect(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (IsLoaded)
                {
                    StarIoExtManager.ConnectAync();
                }
            }));
        }

        void StarIoExtManager_PrinterImpossible(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Impossible.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }));
        }

        void StarIoExtManager_PrinterOnline(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Online.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            }));
        }

        void StarIoExtManager_PrinterOffline(object sender, EventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    statusTextBlock.Text = "Printer Offline.";
            //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            //}));
        }

        void StarIoExtManager_PrinterPaperReady(object sender, EventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    statusTextBlock.Text = "Printer Paper Ready.";
            //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            //}));
        }

        void StarIoExtManager_PrinterPaperNearEmpty(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Paper Near Empty.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Orange);
            }));
        }

        void StarIoExtManager_PrinterPaperEmpty(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Paper Empty.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }));
        }

        void StarIoExtManager_PrinterCoverOpen(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Printer Cover Open.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }));
        }

        void StarIoExtManager_PrinterCoverClose(object sender, EventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    statusTextBlock.Text = "Printer Cover Close.";
            //    statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            //}));
        }

        void StarIoExtManager_CashDrawerOpen(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Cash Drawer Open.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Magenta);
            }));
        }

        void StarIoExtManager_CashDrawerClose(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Cash Drawer Close.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            }));
        }

        void StarIoExtManager_BarcodeReaderImpossible(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Barcode Reader Impossible.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }));
        }

        void StarIoExtManager_BarcodeReaderConnect(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Barcode Reader Connect.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Blue);
            }));
        }

        void StarIoExtManager_BarcodeReaderDisconnect(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                statusTextBlock.Text = "Barcode Reader Disconnect.";
                statusTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            }));
        }

        void StarIoExtManager_BarcodeDataReceive(object sender, BarcodeDataReceiveEventArgs e)
        {
            byte[] data = e.Data;
            string text = Encoding.UTF8.GetString(data, 0, data.Length);

            Dispatcher.BeginInvoke(new Action(() =>
            {
                AddTextToList(text);
            }));
        }

        private void PrintReceiptAndOpenCashDrawer()
        {
            // Create receipt commands.
            Emulation emulation = SharedInformationManager.SelectedEmulation;
            LocalizeReceipt localizeReceipt = new EnglishReceipt()
            {
                PaperSize = SharedInformationManager.SelectedPaperSize
            };
            byte[] commands = PrinterFunctions.CreateRasterReceiptData(emulation, localizeReceipt);

            // Send receipts commands.
            CommunicationResult result = null;
            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                lock (StarIoExtManager.PortLock)
                {
                    result = Communication.SendCommands(commands, StarIoExtManager.Port);
                }
            });
            progressBarWindow.ShowDialog();

            // Show result.
            string resultMessage = Communication.GetCommunicationResultMessage(result) + Environment.NewLine + "PortName: ";
            if (StarIoExtManager.Port != null)
            {
                resultMessage = resultMessage + StarIoExtManager.Port.PortName;
            }
            else
            {
                resultMessage = resultMessage + "null";
            }
            MessageBox.Show(resultMessage, "Communication Result");
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
    }
}
