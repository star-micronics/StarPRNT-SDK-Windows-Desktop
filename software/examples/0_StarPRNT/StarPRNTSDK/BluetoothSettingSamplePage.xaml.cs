using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class BluetoothSettingSamplePage : Page
    {
        private StarBluetoothManager starBluetoothManager;

        /// <summary>
        /// Sample : Getting bluetooth settings flow.
        /// </summary>
        private string GetBluetoothSettings()
        {
            // First, check is printer support bluetooth feature.
            string message = CheckFirmware();

            if (message != null) // Error
            {
                return message;
            }

            // Load bluetooth settings via StarBluetoothManager object.
            message = LoadBluetoothSettings();

            if (message != null) // Error
            {
                return message;
            }

            return null; // After loading, get bluetooth settings from StarBluetoothManager object.
        }

        /// <summary>
        /// Sample : Creating StarBluetoothManager object.
        /// </summary>
        private void CreateStarBluetoothManager()
        {
            // Your printer PortName, PortSettings and Emulation.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            try
            {
                starBluetoothManager = StarBluetoothManagerFactory.GetManager(
                        portName,
                        portSettings,
                        10000,
                        emulation
                );
            }
            catch (PortException ex)
            {
                MessageBox.Show(ex.Message, "Error");

                SetAllFunctionDisable();
            }
        }

        /// <summary>
        /// Sample : Loading bluetooth settings via StarBluetoothManager object.
        /// </summary>
        private string LoadBluetoothSettings()
        {
            string message = null;

            try
            {
                starBluetoothManager.Open();

                starBluetoothManager.LoadSetting();
            }
            catch (PortException ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (starBluetoothManager.IsOpened)
                {
                    try
                    {
                        starBluetoothManager.Close();
                    }
                    catch (PortException ex)
                    {
                        message = ex.Message;
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// Sample : Getting bluetooth settings from StarBluetoothManager object.
        /// </summary>
        private void ShowBlueoothSettings()
        {
            if (starBluetoothManager.BluetoothDeviceNameCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
            {
                deviceNameListBoxItem.ControlIsEnabled = true;
                deviceNameListBoxItem.TextBoxText = starBluetoothManager.BluetoothDeviceName;
            }
            else
            {
                deviceNameListBoxItem.ControlIsEnabled = false;
            }

            if (starBluetoothManager.iOSPortNameCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
            {
                iOSPortNameListBoxItem.ControlIsEnabled = true;
                iOSPortNameListBoxItem.TextBoxText = starBluetoothManager.iOSPortName;
            }
            else
            {
                iOSPortNameListBoxItem.ControlIsEnabled = false;
            }

            if (starBluetoothManager.AutoConnectCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
            {
                autoConnectListBoxItem.ControlIsEnabled = true;
                autoConnectListBoxItem.CheckBoxIsChecked = starBluetoothManager.AutoConnect;
            }
            else
            {
                autoConnectListBoxItem.ControlIsEnabled = false;
            }

            if (starBluetoothManager.SecurityTypeCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
            {
                securityListBoxItem.ControlIsEnabled = true;
                securityListBoxItem.SelectedBluetoothSecurity = starBluetoothManager.SecurityType;
            }
            else
            {
                securityListBoxItem.ControlIsEnabled = false;
            }

            if (starBluetoothManager.PinCodeCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
            {
                changePinCodeListBoxItem.ControlIsEnabled = true;
                if(changePinCodeListBoxItem.CheckBoxIsChecked)
                {
                    newPinCodeListBoxItem.ControlIsEnabled = true;
                }
            }
            else
            {
                changePinCodeListBoxItem.ControlIsEnabled = false;
                newPinCodeListBoxItem.ControlIsEnabled = false;
            }

            changePinCodeListBoxItem.CheckBoxIsChecked = false;

            applyButton.IsEnabled = true;
        }

        /// <summary>
        /// Sample : Applying bluetooth settings via StarBluetoothManager object.
        /// </summary>
        private string ApplyBluetoothSettings()
        {
            string message = null;

            try
            {
                starBluetoothManager.Open();

                if (starBluetoothManager.BluetoothDeviceNameCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
                {
                    starBluetoothManager.BluetoothDeviceName = bluetoothDeviceName;
                }

                if (starBluetoothManager.iOSPortNameCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
                {
                    starBluetoothManager.iOSPortName = iOSPortName;
                }

                if (starBluetoothManager.SecurityTypeCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
                {
                    starBluetoothManager.SecurityType = securityType;
                }

                if (starBluetoothManager.AutoConnectCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT)
                {
                    starBluetoothManager.AutoConnect = autoConnect;
                }

                if (starBluetoothManager.SecurityTypeCapability == StarBluetoothManager.StarBluetoothSettingCapability.SUPPORT &&
                    starBluetoothManager.SecurityType == StarBluetoothManager.StarBluetoothSecurity.PINCODE &&
                    changePinCode)
                {
                    starBluetoothManager.PinCode = newPinCode;
                }

                starBluetoothManager.Apply();
            }
            catch (PortException ex)
            {
                message = ex.Message;
            }
            finally
            {
                if (starBluetoothManager.IsOpened)
                {
                    try
                    {
                        starBluetoothManager.Close();
                    }
                    catch (PortException ex)
                    {
                        message = ex.Message;
                    }
                }
            }

            return message;
        }

        private string CheckFirmware()
        {
            // Get firmware information.
            Dictionary<string, string> firmwareInformation = GetFirmwareInformation();

            if (firmwareInformation == null) // Communication error.
            {
                return "Communication error";
            }

            if (!IsSupportBluetoothSettingFeature(firmwareInformation)) // Firmware not support bluetooth setting feature.
            {
                return "This firmware version (" + firmwareInformation["FirmwareVersion"] + ") of the device does not support bluetooth setting feature.";
            }

            // Set model support pin code character and length.
            SetPinCodeFilter(firmwareInformation);

            return null;
        }

        /// <summary>
        /// Bluetooth setting feature is supported from Ver3.0 or later (SM-S210i, SM-S220i, SM-T300i/T300 and SM-T400i).
        /// Other models support from Ver1.0.
        /// </summary>
        private bool IsSupportBluetoothSettingFeature(Dictionary<string, string> firmwareInformation)
        {
            string modelName = firmwareInformation["ModelName"];
            string firmwareVersion = firmwareInformation["FirmwareVersion"];

            if (modelName.StartsWith("SM-S21") || modelName.StartsWith("SM-S22") || modelName.StartsWith("SM-T30") || modelName.StartsWith("SM-T40"))
            {
                if (float.Parse(firmwareVersion) < 3.0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Supported character and length as Device Name and iOS PortName.
        /// character:[0-9a-zA-Z;:!?#$%&,.@_-= \/*+~^[{(]})|] length:16
        /// </summary>
        private void SetDeviceNameAndiOSPortNameFilter()
        {
            string filter = "^[0-9a-zA-Z;:!?#$%&,.@_\\-= \\\\/\\*\\+~\\^\\[\\{\\(\\]\\}\\)\\|]+$";
            int length = 16;

            deviceNameListBoxItem.Filter = filter;
            iOSPortNameListBoxItem.Filter = filter;

            deviceNameListBoxItem.MaxTextLength = length;
            iOSPortNameListBoxItem.MaxTextLength = length;
        }

        /// <summary>
        /// Supported pin code character and length.
        /// SM-L200 and SM-L300 > character:[0-9] length:4
        /// Other models > character:[0-9a-zA-z] length:4 to 16
        /// </summary>
        private void SetPinCodeFilter(Dictionary<string, string> firmwareInformation)
        {
            string modelName = firmwareInformation["ModelName"];

            string filter;

            if (modelName.StartsWith("SM-L"))
            {
                filter = "^[0-9]+$";
                pinCodeLength = 4;
            }
            else
            {
                filter = "^[0-9a-zA-Z]+$";
                pinCodeLength = 16;
            }

            newPinCodeListBoxItem.Filter = filter;
            newPinCodeListBoxItem.MaxTextLength = pinCodeLength;
        }

        private Dictionary<string, string> GetFirmwareInformation()
        {
            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            // Request firmware information.
            Dictionary<string, string> firmwareInformation = null;
            CommunicationResult result = Communication.RequestFirmwareInformation(ref firmwareInformation, portName, portSettings, 30000);

            if (result.Result != Communication.Result.Success)
            {
                return null;
            }

            return firmwareInformation;
        }

        private void GetBluetoothSettingsWithProgressBar()
        {
            string errorMessage = null;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                errorMessage = GetBluetoothSettings();
            });

            progressBarWindow.ShowDialog();

            if (errorMessage == null)
            {
                ShowBlueoothSettings();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error");

                SetAllFunctionDisable();
            }
        }

        private void ApplyBluetoothSettingsWithProgressBar()
        {
            string errorMessage = null;

            LoadSettingsFromUI();

            string caption, message;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                errorMessage = ApplyBluetoothSettings();
            });

            progressBarWindow.ShowDialog();

            if (errorMessage == null)
            {
                caption = "Complete";
                message = "To apply settings, please turn the device power OFF and ON, and establish pairing again.";
            }
            else
            {
                caption = "Error";
                message = errorMessage;

                SetAllFunctionDisable();
            }

            MessageBox.Show(message, caption);
        }

        private ListBoxItemWithTextBox deviceNameListBoxItem;
        private ListBoxItemWithTextBox iOSPortNameListBoxItem;
        private ListBoxItemWithCheckBox autoConnectListBoxItem;
        private ListBoxItemWithComboBox securityListBoxItem;
        private ListBoxItemWithCheckBox changePinCodeListBoxItem;
        private ListBoxItemWithTextBox newPinCodeListBoxItem;

        private string bluetoothDeviceName;
        private string iOSPortName;
        private StarBluetoothManager.StarBluetoothSecurity securityType;
        private bool autoConnect;
        private bool changePinCode;
        private string newPinCode;
        private int pinCodeLength;

        public BluetoothSettingSamplePage()
        {
            InitializeComponent();

            CreateStarBluetoothManager();

            pinCodeLength = 0;
        }

        public bool IsValidSettings
        {
            set
            {
                applyButton.IsEnabled = value;
            }
        }

        private bool IsValidAllSettings()
        {
            return IsValidDeviceName() &&
                   IsValidiOSPortName() &&
                   IsValidAutoConnectSetting() &&
                   IsValidNewPinCode();
        }

        private bool IsValidDeviceName()
        {
            if (bluetoothDeviceName == null || bluetoothDeviceName.Length == 0)
            {
                return false;
            }

            return true; ;
        }

        private bool IsValidiOSPortName()
        {
            if (iOSPortName == null || iOSPortName.Length == 0)
            {
                return false;
            }

            return true; ;
        }

        private bool IsValidAutoConnectSetting()
        {
            StarBluetoothManager.StarDeviceType deviceType = starBluetoothManager.DeviceType;

            if (deviceType == StarBluetoothManager.StarDeviceType.StarDeviceTypeDesktopPrinter &&
                autoConnect &&
                securityType == StarBluetoothManager.StarBluetoothSecurity.PINCODE)
            {
                return false;
            }

            return true;
        }

        public bool IsValidNewPinCode()
        {
            if (changePinCode &&
                (newPinCode == null || newPinCode.Length < 4))
            {
                return false;
            }

            return true;
        }
        
        private void LoadListBoxItems()
        {
            deviceNameListBoxItem = FindResource("DeviceNameListBoxItem") as ListBoxItemWithTextBox;
            iOSPortNameListBoxItem = FindResource("iOSPortNameListBoxItem") as ListBoxItemWithTextBox;
            autoConnectListBoxItem = FindResource("AutoConnectListBoxItem") as ListBoxItemWithCheckBox;
            securityListBoxItem = FindResource("SecurityListBoxItem") as ListBoxItemWithComboBox;
            changePinCodeListBoxItem = FindResource("ChangePinCodeListBoxItem") as ListBoxItemWithCheckBox;
            newPinCodeListBoxItem = FindResource("NewPinCodeListBoxItem") as ListBoxItemWithTextBox;

            deviceNameListBoxItem.ContentChangedEvent += OnSettingChanged;
            iOSPortNameListBoxItem.ContentChangedEvent += OnSettingChanged;
            autoConnectListBoxItem.ContentChangedEvent += OnSettingChanged;
            securityListBoxItem.ContentChangedEvent += OnSettingChanged;
            changePinCodeListBoxItem.ContentChangedEvent += OnSettingChanged;
            changePinCodeListBoxItem.CheckBoxCheckedChangedEvent += OnChangePinCodeCheckedChanged;
            newPinCodeListBoxItem.ContentChangedEvent += OnSettingChanged;
            newPinCodeListBoxItem.ControlIsEnabled = false;

            BluetoothSecurityTypeManager[] bluetoothSecurities;
            if (starBluetoothManager.DeviceType == StarBluetoothManager.StarDeviceType.StarDeviceTypeDesktopPrinter)
            {
                bluetoothSecurities = new BluetoothSecurityTypeManager[] {
                    new BluetoothSecurityTypeManager(StarBluetoothManager.StarBluetoothSecurity.SSP),
                    new BluetoothSecurityTypeManager(StarBluetoothManager.StarBluetoothSecurity.PINCODE) };
            }
            else
            {  // StarDeviceTypePortablePrinter
                bluetoothSecurities = new BluetoothSecurityTypeManager[] {
                    new BluetoothSecurityTypeManager(StarBluetoothManager.StarBluetoothSecurity.PINCODE),
                    new BluetoothSecurityTypeManager(StarBluetoothManager.StarBluetoothSecurity.DISABLE) };
            }

            securityListBoxItem.BluetoothSecurities = bluetoothSecurities;
        }

        private void LoadSettingsFromUI()
        {
            bluetoothDeviceName = deviceNameListBoxItem.TextBoxText;
            iOSPortName = iOSPortNameListBoxItem.TextBoxText;
            securityType = securityListBoxItem.SelectedBluetoothSecurity;
            autoConnect = autoConnectListBoxItem.CheckBoxIsChecked;
            changePinCode = changePinCodeListBoxItem.CheckBoxIsChecked;
            newPinCode = newPinCodeListBoxItem.TextBoxText;
        }

        private void SetAllFunctionDisable()
        {
            deviceNameListBoxItem.ControlIsEnabled = false;
            iOSPortNameListBoxItem.ControlIsEnabled = false;
            securityListBoxItem.ControlIsEnabled = false;
            autoConnectListBoxItem.ControlIsEnabled = false;
            changePinCodeListBoxItem.ControlIsEnabled = false;
            newPinCodeListBoxItem.ControlIsEnabled = false;
            applyButton.IsEnabled = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadListBoxItems();

            SetDeviceNameAndiOSPortNameFilter();

            GetBluetoothSettingsWithProgressBar();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            GetBluetoothSettingsWithProgressBar();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyBluetoothSettingsWithProgressBar();
        }

        public void OnSettingChanged(object sender, EventArgs e)
        {
            LoadSettingsFromUI();

            IsValidSettings = IsValidAllSettings();
        }

        public void OnChangePinCodeCheckedChanged(object sender, EventArgs e)
        {
            ListBoxItemWithCheckBox listBoxItemWithCheckBox = (ListBoxItemWithCheckBox)sender;

            newPinCodeListBoxItem.ControlIsEnabled = listBoxItemWithCheckBox.CheckBoxIsChecked;
        }
    }
}
