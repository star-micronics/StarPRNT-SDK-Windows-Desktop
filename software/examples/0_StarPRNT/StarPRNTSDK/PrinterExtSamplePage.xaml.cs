using StarMicronics.StarIO;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class PrinterExtSamplePage : Page
    {
        private StarIoExtManager StarIoExtManager { get; set; }
        private ProgressBarWindow ProgressBarWindow { get; set; }

        public PrinterExtSamplePage()
        {
            InitializeComponent();

            // Your printer settings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;
            bool drawerOpenStatus = SharedInformationManager.SelectedDrawerOpenStatus;

            StarIoExtManager = new StarIoExtManager(portName, portSettings, 30000, StarIoExtManagerType.Standard);
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
            StarIoExtManager.DisconnectAsync();

            ProgressBarWindow = new ProgressBarWindow() { Title = "Refreshing..." };
            ProgressBarWindow.ShowDialog();       
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Print();
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

        private void Print()
        {
            ReceiptInformationManager receiptInfo = SharedInformationManager.ReceiptInformationManager;

            byte[] commands = PrinterSampleManager.CreateLocalizeReceiptCommands(receiptInfo);

            lock (StarIoExtManager.PortLock)
            {
                Communication.SendCommandsWithProgressBar(commands, StarIoExtManager.Port);
            }
        }
    }

}
