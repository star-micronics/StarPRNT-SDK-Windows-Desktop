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
    public partial class BarcodeReaderExtSamplePage : Page
    {
        private StarIoExtManager StarIoExtManager { get; set; }
        private ProgressBarWindow ProgressBarWindow { get; set; }

        public BarcodeReaderExtSamplePage()
        {
            InitializeComponent();

            // Your printer settings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            StarIoExtManager = new StarIoExtManager(portName, portSettings, 30000, StarIoExtManagerType.OnlyBarcodeReader);
            StarIoExtManager.PrinterConnect += StarIoExtManager_PrinterConnect;
            StarIoExtManager.PrinterDisconnect += StarIoExtManager_PrinterDisconnect;
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
