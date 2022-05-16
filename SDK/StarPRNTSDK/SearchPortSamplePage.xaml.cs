using StarMicronics.StarIO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public partial class SearchPortSamplePage : Page
    {
        /// <summary>
        /// Sample : Searching printer with one interface.
        /// </summary>
        private List<PortInfo> SearchPrinterWithInterfaceType(PrinterInterfaceType type)
        {
            return Factory.I.SearchPrinter(type);
        }

        /// <summary>
        /// Sample : Searching printer with all interface.
        /// </summary>
        private List<PortInfo> SearchPrinterWithAllInterface()
        {
            return Factory.I.SearchPrinter();
        }

        public List<PortInfo> SearchPrinterWithProgressBar(PrinterInterfaceType type)
        {
            List<PortInfo> portInfoList = new List<PortInfo>();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                portInfoList = SearchPrinterWithInterfaceType(type);
            });

            progressBarWindow.ShowDialog();

            return portInfoList;
        }

        public List<PortInfo> SearchPrinterWithProgressBar()
        {
            List<PortInfo> portInfoList = new List<PortInfo>();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                portInfoList = SearchPrinterWithAllInterface();
            });

            progressBarWindow.ShowDialog();

            return portInfoList;
        }

        private InterfaceInformation selectedInterface;

        public SearchPortSamplePage()
        {
            InitializeComponent();

            PrinterPriority = 0;

            SourceUri = null;
        }

        private void StartSearchPrinter(InterfaceInformation interfaceInformation)
        {
            List<PortInfo> portInfoList = new List<PortInfo>();

            switch (interfaceInformation.ManualSetting)
            {
                case InterfaceInformation.ManualSettingType.NotManually:
                    PrinterInterfaceType type = interfaceInformation.Type;
                    portInfoList = SearchPrinterWithProgressBar(type);
                    break;

                case InterfaceInformation.ManualSettingType.All:
                    portInfoList = SearchPrinterWithProgressBar();
                    break;

                case InterfaceInformation.ManualSettingType.Manual:
                    break;

            }

            portListBox.ItemsSource = PortInfoManager.CreatePortInfoManager(portInfoList.ToArray());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StartSelectSetting();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            StartSelectSetting();
        }

        private void PortListBoxItem_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            PortInfo selectedPortInfo = (PortInfo)clickedButton.Tag;

            ModelInformation selectedModelInformation = DecideModel(selectedPortInfo);

            if (selectedModelInformation == null)
            {
                return;
            }

            SetModelInformation(selectedModelInformation);

            SetPortInfo(selectedPortInfo);

            if(SourceUri == null)
            {
                Util.GoBackMainPage();
            }
            else
            {
                Util.JumpPage(SourceUri);
            }
        }

        private void StartSelectSetting()
        {
            selectedInterface = ShowSelectInterfaceWindow();

            if (selectedInterface == null)
            {
                return;
            }

            if (selectedInterface.ManualSetting == InterfaceInformation.ManualSettingType.Manual)
            {
                SetPrinterManually();
            }
            else
            {
                StartSearchPrinter(selectedInterface);
            }
        }

        private void SetPrinterManually()
        {
            string[] settings = ShowManualSettingWindow();

            if (settings == null)
            {
                return;
            }

            ModelInformation modelInformation = ShowSelectModelWindow();

            if (modelInformation == null)
            {
                return;
            }

            PaperSize selectedPaperSize = ShowSelectPaperSizeWindowIfNeed(modelInformation);

            if (selectedPaperSize == null)
            {
                return;
            }

            SetPaperSize(selectedPaperSize);

            if (modelInformation.ChangeCashDrawerPolarityIsEnabled)
            {
                bool? drawerOpenStatus = ShowSelectDrawerOpenStatusWindow();

                if (drawerOpenStatus == null)
                {
                    return;
                }

                modelInformation.DrawerOpenStatus = (bool)drawerOpenStatus;
            }
            else
            {
                modelInformation.DrawerOpenStatus = true;
            }

            string portName = settings[0];

            string portSettings = settings[1];

            modelInformation.PortSettings = portSettings;

            PortInfo portInfo = new PortInfo(portName, "", modelInformation.SimpleModelName, "");

            SetModelInformation(modelInformation);

            SetPortInfo(portInfo);

            Util.GoBackMainPage();
        }

        private ModelInformation DecideModel(PortInfo portInfo)
        {
            PrinterModel model = ModelFinder.FindPrinterModel(portInfo.ModelName);

            bool isDecideModel = false;

            if (model != PrinterModel.Unknown)
            {
                isDecideModel = ShowModelConfirmWindow(model);
            }

            ModelInformation modelInformation;

            if (isDecideModel)
            {
                modelInformation = new ModelInformation(model);
            }
            else
            {
                modelInformation = ShowSelectModelWindow();
            }

            if (modelInformation == null)
            {
                return null;
            }

            PaperSize selectedPaperSize = ShowSelectPaperSizeWindowIfNeed(modelInformation);

            if (selectedPaperSize == null)
            {
                return null;
            }

            SetPaperSize(selectedPaperSize);

            if (modelInformation.ChangeCashDrawerPolarityIsEnabled)
            {
                bool? drawerOpenStatus = ShowSelectDrawerOpenStatusWindow();

                if (drawerOpenStatus == null)
                {
                    return null;
                }

                modelInformation.DrawerOpenStatus = (bool)drawerOpenStatus;
            }
            else
            {
                modelInformation.DrawerOpenStatus = true;
            }

            if (PortInfoManager.IsSerialPort(portInfo))
            {
                string portSettings = ShowManualPortSettingsWindowForSerialPort();

                if (portSettings == null)
                {
                    return null;
                }

                modelInformation.PortSettings = portSettings;
            }

            return modelInformation;
        }

        private string[] ShowManualSettingWindow()
        {
            string[] enterSettings = new string[0];

            EnterTextWindow manualSettingWindow = new EnterTextWindow(FindResource("ManualSettingWindow") as EnterTextWindow);
            manualSettingWindow.TextBoxTexts = SharedInformationManager.SelectedModelManager.GetSelectedPortNameAndPortSettings(PrinterPriority);

            bool? result = manualSettingWindow.ShowDialog();

            if (result == true)
            {
                enterSettings = manualSettingWindow.TextBoxTexts;
            }
            else
            {
                return null;
            }

            return enterSettings;
        }

        private string ShowManualPortSettingsWindowForSerialPort()
        {
            string[] enterSettings = new string[0];

            EnterTextWindow manualSettingWindow = new EnterTextWindow(FindResource("ManualPortSettingsForSerialPortWindow") as EnterTextWindow);
            manualSettingWindow.TextBoxTexts = new string[] { "9600,n,8,1,h" };

            bool? result = manualSettingWindow.ShowDialog();

            if (result == true)
            {
                enterSettings = manualSettingWindow.TextBoxTexts;
            }
            else
            {
                return null;
            }

            return enterSettings[0];
        }

        private InterfaceInformation ShowSelectInterfaceWindow()
        {
            InterfaceInformation interfaceInformation = new InterfaceInformation();

            SelectSettingWindow selectInterfaceWindow = new SelectSettingWindow(FindResource("SelectInterfaceWindow") as SelectSettingWindow);

            bool? result = selectInterfaceWindow.ShowDialog();

            if (result == true)
            {
                interfaceInformation = selectInterfaceWindow.SelecedInterfaceType;
            }
            else
            {
                return null;
            }

            return interfaceInformation;
        }

        private bool ShowModelConfirmWindow(PrinterModel model)
        {
            ModelInformation modelInformation = new ModelInformation(model);

            MessageBoxResult result = MessageBox.Show("Is your printer " + modelInformation.SimpleModelName + "?", "Confirm", MessageBoxButton.YesNo);

            return (result == MessageBoxResult.Yes);
        }

        private ModelInformation ShowSelectModelWindow()
        {
            ModelInformation modelInformation = new ModelInformation();

            SelectSettingWindow selectModelWindow = new SelectSettingWindow(FindResource("SelectModelWindow") as SelectSettingWindow);

            bool? result = selectModelWindow.ShowDialog();

            if (result == true)
            {
                modelInformation = selectModelWindow.SelectedModel;
            }
            else
            {
                return null;
            }

            return modelInformation;
        }

        private PaperSize ShowSelectPaperSizeWindowIfNeed(ModelInformation modelInfomation)
        {
            if (PrinterPriority != 0)
            {
                return SharedInformationManager.SelectedPaperSize;
            }

            if (modelInfomation.Model == PrinterModel.SP700 || modelInfomation.Model == PrinterModel.BSC10)
            {
                return modelInfomation.DefaultPaperSize;
            }

            return ShowSelectPaperSizeWindow(modelInfomation.DefaultPaperSize.Type);
        }

        private PaperSize ShowSelectPaperSizeWindow(PaperSizeType defaultPaperSize)
        {
            PaperSize paperSize = null;

            SelectSettingWindow selectPaperSizeWindow = new SelectSettingWindow(SelectSettingWindow.Templete.PaperSize);
            selectPaperSizeWindow.SelectedIndex = (int)defaultPaperSize;

            bool? result = selectPaperSizeWindow.ShowDialog();

            if (result == true)
            {
                paperSize = selectPaperSizeWindow.SelectedPaperSize;
            }

            return paperSize;
        }

        private bool? ShowSelectDrawerOpenStatusWindow()
        {
            bool isHigh = true;

            SelectSettingWindow selectDrawerOpenStatusWindow = new SelectSettingWindow(FindResource("SelectDrawerOpenStatusWindow") as SelectSettingWindow);

            bool? result = selectDrawerOpenStatusWindow.ShowDialog();

            if (result == true)
            {
                switch (selectDrawerOpenStatusWindow.SelectedIndex)
                {
                    default:
                    case 0:
                        isHigh = true;
                        break;

                    case 1:
                        isHigh = false;
                        break;
                }
            }
            else
            {
                return null;
            }

            return isHigh;
        }

        public int PrinterPriority { get; set; }

        public Uri SourceUri { get; set; }

        private void SetModelInformation(ModelInformation modelInformation)
        {
            SharedInformationManager.SetSelectedModelInformation(modelInformation, PrinterPriority);
        }

        private void SetPortInfo(PortInfo portInfo)
        {
            SharedInformationManager.SetSelectedPortInfo(portInfo, PrinterPriority);
        }

        private void SetPaperSize(PaperSize paperSize)
        {
            SharedInformationManager.SetSelectedPaperSize(paperSize, PrinterPriority);
        }
    }
}
