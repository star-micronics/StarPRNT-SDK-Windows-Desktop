using StarMicronics.StarIO;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarPRNTSDK
{
    public partial class DeviceStatusSamplePage : Page
    {
        public DeviceStatusSamplePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sample : Getting device status.
        /// </summary>
        private StarPrinterStatus GetDeviceStatus()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            StarPrinterStatus status = null;
            CommunicationResult result = Communication.RetrieveStatus(ref status, portName, portSettings, 30000);

            if (result.Result != Communication.Result.Success)
            {
                return null;
            }

            return status;
        }

        /// <summary>
        /// Sample : Getting firmware information.
        /// </summary>
        private Dictionary<string, string> GetFirmwareInformation()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Request firmware information.
            Dictionary<string, string> firmwareInformation = new Dictionary<string, string>();
            CommunicationResult result = Communication.RequestFirmwareInformation(ref firmwareInformation, portName, portSettings, 30000);

            if (result.Result != Communication.Result.Success)
            {
                return null;
            }

            return firmwareInformation;
        }

        /// <summary>
        /// Sample : Parsing printer status object.
        /// </summary>
        private void ParsePrinterStatus(StarPrinterStatus status, bool cashDrawerOpenActiveHigh)
        {
            List<ListBoxItemWithDetail> listBoxItemList = new List<ListBoxItemWithDetail>();

            if (status == null)
            {
                deviceStatusListBox.ItemsSource = listBoxItemList.ToArray();

                return;
            }

            ListBoxItemWithDetail onlineListBoxItem = new ListBoxItemWithDetail("Online");
            ListBoxItemWithDetail coverListBoxItem = new ListBoxItemWithDetail("Cover");
            ListBoxItemWithDetail paperListBoxItem = new ListBoxItemWithDetail("Paper");
            ListBoxItemWithDetail cashDrawerListBoxItem = new ListBoxItemWithDetail("Cash Drawer");
            ListBoxItemWithDetail headTemperatureListBoxItem = new ListBoxItemWithDetail("Head Temperature");
            ListBoxItemWithDetail nonRecoverableErrorListBoxItem = new ListBoxItemWithDetail("Non Recoverable Error");
            ListBoxItemWithDetail paperCutterListBoxItem = new ListBoxItemWithDetail("Paper Cutter");
            ListBoxItemWithDetail headThermistorListBoxItem = new ListBoxItemWithDetail("Head Thermistor");
            ListBoxItemWithDetail voltageListBoxItem = new ListBoxItemWithDetail("Voltage");
            ListBoxItemWithDetail etbCounterListBoxItem = new ListBoxItemWithDetail("ETB Counter");

            if (status.Offline)
            {
                onlineListBoxItem.Detail = "Offline";
                onlineListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                onlineListBoxItem.Detail = "Online";
                onlineListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(onlineListBoxItem);


            if (status.CoverOpen)
            {
                coverListBoxItem.Detail = "Open";
                coverListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                coverListBoxItem.Detail = "Closed";
                coverListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(coverListBoxItem);

            if (status.ReceiptPaperEmpty)
            {
                paperListBoxItem.Detail = "Empty";
                paperListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else if (status.ReceiptPaperNearEmptyInner || status.ReceiptPaperNearEmptyOuter)
            {
                paperListBoxItem.Detail = "Near Empty";
                paperListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Orange);
            }
            else
            {
                paperListBoxItem.Detail = "Ready";
                paperListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(paperListBoxItem);

            if (cashDrawerOpenActiveHigh)
            {
                if (status.CompulsionSwitch)
                {
                    cashDrawerListBoxItem.Detail = "Open";
                    cashDrawerListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    cashDrawerListBoxItem.Detail = "Closed";
                    cashDrawerListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
                }
            }
            else
            {
                if (status.CompulsionSwitch)
                {
                    cashDrawerListBoxItem.Detail = "Closed";
                    cashDrawerListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
                }
                else
                {
                    cashDrawerListBoxItem.Detail = "Open";
                    cashDrawerListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
                }
            }
            listBoxItemList.Add(cashDrawerListBoxItem);

            if (status.OverTemp)
            {
                headTemperatureListBoxItem.Detail = "High";
                headTemperatureListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                headTemperatureListBoxItem.Detail = "Normal";
                headTemperatureListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(headTemperatureListBoxItem);

            if (status.UnrecoverableError)
            {
                nonRecoverableErrorListBoxItem.Detail = "Error";
                nonRecoverableErrorListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                nonRecoverableErrorListBoxItem.Detail = "Ready";
                nonRecoverableErrorListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(nonRecoverableErrorListBoxItem);

            if (status.CutterError)
            {
                paperCutterListBoxItem.Detail = "Error";
                paperCutterListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                paperCutterListBoxItem.Detail = "Ready";
                paperCutterListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(paperCutterListBoxItem);

            if (status.HeadThermistorError)
            {
                headThermistorListBoxItem.Detail = "Abnormal";
                headThermistorListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                headThermistorListBoxItem.Detail = "Normal";
                headThermistorListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(headThermistorListBoxItem);

            if (status.VoltageError)
            {
                voltageListBoxItem.Detail = "Abnormal";
                voltageListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                voltageListBoxItem.Detail = "Normal";
                voltageListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            listBoxItemList.Add(voltageListBoxItem);

            if (status.ETBAvailable)
            {
                etbCounterListBoxItem.Detail = status.ETBCounter.ToString();
                etbCounterListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
                listBoxItemList.Add(etbCounterListBoxItem);
            }

            deviceStatusListBox.ItemsSource = listBoxItemList.ToArray();
        }

        /// <summary>
        /// Sample : Parsing firmware information dictionary object.
        /// </summary>
        private void ParseFirmwareInformation(Dictionary<string, string> firmwareInformation)
        {
            List<ListBoxItemWithDetail> listBoxItemList = new List<ListBoxItemWithDetail>();
            ListBoxItemWithDetail modelNameListBoxItem = new ListBoxItemWithDetail("Model Name");
            ListBoxItemWithDetail firmwareVersionListBoxItem = new ListBoxItemWithDetail("Firmware Version");
            string modelName, firmwareVersion;

            if(firmwareInformation != null)
            {
                modelName = firmwareInformation["ModelName"];
                modelNameListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                modelName = "Unable to get F/W info from an error.";
                modelNameListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }

            modelNameListBoxItem.Detail = modelName;
            listBoxItemList.Add(modelNameListBoxItem);

            if (firmwareInformation != null)
            {
                firmwareVersion = firmwareInformation["FirmwareVersion"];
                firmwareVersionListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                firmwareVersion = "Unable to get F/W info from an error.";
                firmwareVersionListBoxItem.ForeGroundColor = new SolidColorBrush(Colors.Red);
            }

            firmwareVersionListBoxItem.Detail = firmwareVersion;
            listBoxItemList.Add(firmwareVersionListBoxItem);

            firmwareInformationListBox.ItemsSource = listBoxItemList.ToArray();
        }

        private void ReloadDeviceInformationWithProgressBar()
        {
            deviceStatusListBox.ItemsSource = null;
            firmwareInformationListBox.ItemsSource = null;

            StarPrinterStatus status = null;
            Dictionary<string, string> firmwareInformation = null;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                status = GetDeviceStatus();

                if (status == null)
                {
                    return;
                }

                Thread.Sleep(1000);

                firmwareInformation = GetFirmwareInformation();
            });

            progressBarWindow.ShowDialog();

            if (status == null && firmwareInformation == null) // Communication failure.
            {
                MessageBox.Show("Communication error", "Error");

                return;
            }

            // Parse printer status.
            ParsePrinterStatus(status, SharedInformationManager.SelectedDrawerOpenStatus);

            // Parse firmware information.
            ParseFirmwareInformation(firmwareInformation);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ReloadDeviceInformationWithProgressBar();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadDeviceInformationWithProgressBar();
        }
    }
}
