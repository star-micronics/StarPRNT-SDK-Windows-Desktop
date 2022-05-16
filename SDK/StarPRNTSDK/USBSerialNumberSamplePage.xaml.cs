using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class USBSerialNumberSamplePage : Page
    {
        /// <summary>
        /// Sample : Setting USB serial number.
        /// </summary>
        private void SetUSBSerialNumber(byte[] serialNumber, bool isEnabled)
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Setting USB serial number sample is in "Communication.SetUSBSerialNumber(byte[] serialNumber, bool isEnabled, IPort port)".
            CommunicationResult result = Communication.SetUSBSerialNumberWithProgressBar(serialNumber, isEnabled, portName, portSettings, 30000);

            DidChangeUSBSerialNumberSettings(result);
        }

        /// <summary>
        /// Sample : Initializing USB serial number.
        /// </summary>
        private void InitializeUSBSerialNumber(bool isEnabled)
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Initializing USB serial number sample is in "Communication.InitializeUSBSerialNumber(bool isEnabled, IPort port)".
            CommunicationResult result = Communication.InitializeUSBSerialNumberWithProgressBar(isEnabled, portName, portSettings, 30000);

            DidChangeUSBSerialNumberSettings(result);
        }

        private void DidChangeUSBSerialNumberSettings(CommunicationResult result)
        {
            if (result.Result == Communication.Result.Success)
            {
                MessageBox.Show("To apply settings, please turn the device power OFF and ON.", "Complete");
            }
            else
            {
                Communication.ShowCommunicationResultMessage(result);
            }
        }

        public USBSerialNumberSamplePage()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ShowConfirmNewUSBConnectionMessageIfNeed())
            {
                return;
            }

            byte[] serialNumberBytes = Encoding.ASCII.GetBytes(serialNumberInputTextBox.Text);
            bool isEnabled = (bool)serialNumberIsEnabledForSetCheckBox.IsChecked;

            SetUSBSerialNumber(serialNumberBytes, isEnabled);
        }

        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ShowConfirmNewUSBConnectionMessageIfNeed())
            {
                return;
            }

            bool isEnabled = (bool)serialNumberIsEnabledForInitializeCheckBox.IsChecked;

            InitializeUSBSerialNumber(isEnabled);
        }

        private bool ShowConfirmNewUSBConnectionMessageIfNeed()
        {
            bool result = true;

            if(SharedInformationManager.IsSelectedUSBPrinterClassPort)
            {
                result = MessageBox.Show("Windows Printer Queue corresponding to your printer is changed after setting USB serial number.\nApply?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes;
            }
            else if(SharedInformationManager.IsSelectedUSBVendorClassPort)
            {
                result = MessageBox.Show("COM port corresponding to your printer is changed after setting USB serial number.\nApply?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes;
            }

            return result;
        }

        private void SerialNumberIsEnabledCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if ((bool)checkBox.IsChecked)
            {
                checkBox.Content = "Enable";
            }
            else
            {
                checkBox.Content = "Disable";
            }
        }
    }
}
