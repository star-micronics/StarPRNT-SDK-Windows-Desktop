using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class CombinationExtSamplePage : Page
    {
        private StarIoExtManager StarIoExtManager { get; set; }
        private ProgressBarWindow ProgressBarWindow { get; set; }

        public CombinationExtSamplePage()
        {
            InitializeComponent();

            // Your printer settings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;
            bool drawerOpenStatus = SharedInformationManager.SelectedDrawerOpenStatus;

            StarIoExtManager = new StarIoExtManager(portName, portSettings, 30000, StarIoExtManagerType.WithBarcodeReader);
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
            ReceiptInformationManager receiptInfo = SharedInformationManager.ReceiptInformationManager;

            byte[] commands = CreateLocalizeReceiptAndOpenCashDrawerCommands(receiptInfo);

            lock (StarIoExtManager.PortLock)
            {
                Communication.SendCommandsWithProgressBar(commands, StarIoExtManager.Port);
            }
        }

        /// <summary>
        /// Sample : Creating printing receipt and open cash drawer commands.
        /// </summary>
        private byte[] CreateLocalizeReceiptAndOpenCashDrawerCommands(ReceiptInformationManager receiptInfo)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // print paper size
            int paperSize = SharedInformationManager.SelectedActualPaperSize;

            // Creating localize receipt commands sample is in "LocalizeReceipts/'Language'Receipt.cs"
            ReceiptInformationManager.ReceiptType type = receiptInfo.Type;
            LocalizeReceipt localizeReceipt = receiptInfo.LocalizeReceipt;

            byte[] commands;

            switch (type)
            {
                default:
                case ReceiptInformationManager.ReceiptType.Text:
                    commands = CombinationFunctions.CreateTextReceiptData(emulation, localizeReceipt, false);
                    break;

                case ReceiptInformationManager.ReceiptType.TextUTF8:
                    commands = CombinationFunctions.CreateTextReceiptData(emulation, localizeReceipt, true);
                    break;

                case ReceiptInformationManager.ReceiptType.Raster:
                    commands = CombinationFunctions.CreateRasterReceiptData(emulation, localizeReceipt);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterBothScale:
                    commands = CombinationFunctions.CreateScaleRasterReceiptData(emulation, localizeReceipt, paperSize, true);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterScale:
                    commands = CombinationFunctions.CreateScaleRasterReceiptData(emulation, localizeReceipt, paperSize, false);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterCoupon:
                    commands = CombinationFunctions.CreateCouponData(emulation, localizeReceipt, paperSize, BitmapConverterRotation.Normal);
                    break;

                case ReceiptInformationManager.ReceiptType.RasterCouponRotation90:
                    commands = CombinationFunctions.CreateCouponData(emulation, localizeReceipt, paperSize, BitmapConverterRotation.Right90);
                    break;
            }

            return commands;
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
