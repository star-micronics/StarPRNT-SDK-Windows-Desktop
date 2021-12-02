using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class CashDrawerExtSamplePage : Page
    {
        private StarIoExtManager StarIoExtManager { get; set; }
        private ProgressBarWindow ProgressBarWindow { get; set; }

        public CashDrawerExtSamplePage()
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
            StarIoExtManager.CashDrawerOpen += StarIoExtManager_CashDrawerOpen;
            StarIoExtManager.CashDrawerClose += StarIoExtManager_CashDrawerClose;
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

        private void OpenDrawerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenCashDrawer();
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

        private void OpenCashDrawer()
        {
            PeripheralChannel channel = SharedInformationManager.PeripheralChannel;
            bool checkCondition = SharedInformationManager.CheckCondition;

            Emulation emulation = SharedInformationManager.SelectedEmulation;
            byte[] commands = CashDrawerFunctions.CreateData(emulation, channel);

            lock (StarIoExtManager.PortLock)
            {
                if (checkCondition)
                {
                    Communication.SendCommandsWithProgressBar(commands, StarIoExtManager.Port);
                }
                else
                {
                    Communication.SendCommandsDoNotCheckConditionWithProgressBar(commands, StarIoExtManager.Port);
                }
            }
        }
    }
}
