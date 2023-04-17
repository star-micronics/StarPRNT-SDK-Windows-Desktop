using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace StarPRNTSDK
{
    public class SelectedModelManager : INotifyPropertyChanged
    {
        public SelectedModelManager()
        {
            selectedModelList = new List<ModelInformation>();
            selectedPortList = new List<PortInfo>();
            selectedPaperSizeList = new List<PaperSize>();

            if (SharedInformationManager.SelectedModelManager != null)
            {
                CopyProperty(SharedInformationManager.SelectedModelManager);
            }
            else
            {
                blackMarkType = BlackMarkType.Invalid;
            }

            SharedInformationManager.SelectedModelManager = this;
        }

        private void CopyProperty(SelectedModelManager source)
        {
            SelectedModels = source.SelectedModels;

            SelectedPorts = source.SelectedPorts;

            SelectedPaperSizes = source.SelectedPaperSizes;
        }

        internal ModelInformation SelectedModel
        {
            get
            {
                while (selectedModelList.Count < 1)
                {
                    selectedModelList.Add(null);
                }

                return selectedModelList[0];
            }
            set
            {
                while (selectedModelList.Count < 1)
                {
                    selectedModelList.Add(null);
                }

                selectedModelList[0] = value;

                CallPropertyChangedEvent();
            }
        }

        internal ModelInformation[] SelectedModels
        {
            get
            {
                return selectedModelList.ToArray();
            }
            set
            {
                selectedModelList = value.ToList();

                CallPropertyChangedEvent();
            }
        }

        private List<ModelInformation> selectedModelList;

        public PortInfo SelectedPort
        {
            get
            {
                while (selectedPortList.Count < 1)
                {
                    selectedPortList.Add(null);
                }

                return selectedPortList[0];
            }
            set
            {
                while (selectedPortList.Count < 1)
                {
                    selectedPortList.Add(null);
                }

                selectedPortList[0] = value;

                CallPropertyChangedEvent();
            }
        }

        public PortInfo[] SelectedPorts
        {
            get
            {
                return selectedPortList.ToArray();
            }
            set
            {
                selectedPortList = value.ToList();

                CallPropertyChangedEvent();
            }
        }

        private List<PortInfo> selectedPortList;

        public PaperSize SelectedPaperSize
        {
            get
            {
                while (selectedPaperSizeList.Count < 1)
                {
                    selectedPaperSizeList.Add(null);
                }

                return selectedPaperSizeList[0];
            }
            set
            {
                while (selectedPaperSizeList.Count < 1)
                {
                    selectedPaperSizeList.Add(null);
                }

                selectedPaperSizeList[0] = value;

                CallPropertyChangedEvent();
            }
        }

        public PaperSize[] SelectedPaperSizes
        {
            get
            {
                return selectedPaperSizeList.ToArray();
            }
            set
            {
                selectedPaperSizeList = value.ToList();

                CallPropertyChangedEvent();
            }
        }

        private List<PaperSize> selectedPaperSizeList;

        public bool IsSelected
        {
            get
            {
                return IsSelectedModel;
            }
        }

        public bool IsUnselected
        {
            get
            {
                return !IsSelectedModel;
            }
        }

        public bool IsSelectedModel
        {
            get
            {
                return !(SelectedModel == null);
            }
        }

        public bool IsSelectedSubModel
        {
            get
            {
                if (SelectedModels.Length < 2 ||
                    SelectedModels[1] == null)
                {
                    return false;
                }

                return true;
            }
        }

        public bool IsUnselectedSubModel
        {
            get
            {
                return !IsSelectedSubModel;
            }
        }

        public bool IsExistPrinterQueue
        {
            get
            {
                StarPrintPortJobMonitor jobMonitor = new StarPrintPortJobMonitor(SelectedPort.PortName);

                return (jobMonitor.PrintQueues.Length > 0);
            }
        }

        public string SelectedModelDescription
        {
            get
            {
                return CreateSelectedModelDescription();
            }
        }

        public string SelectedSubModelDescription
        {
            get
            {
                return CreateSelectedSubModelDescription();
            }
        }

        public bool BlackMarkDetectionIsEnabled
        {
            get
            {
                return SelectedModel.BlackMarkDetectionIsEnabled;
            }
        }

        public BlackMarkType BlackMarkType
        {
            get
            {
                return GetBlackMarkType();
            }
            set
            {
                blackMarkType = value;
            }
        }

        private BlackMarkType blackMarkType;

        public bool PrinterSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return true;
            }
        }

        public bool BlackMarkSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.BlackMarkIsEnabled;
            }
        }

        public bool PageModeSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.PageModeIsEnabled;
            }
        }

        public bool PrintRedirectionSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return true;
            }
        }

        public bool HoldPrintSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.PaperPresentStatusIsEnabled;
            }
        }

        public bool AutoSwitchInterfaceSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.AutoSwitchInterfaceIsEnabled;
            }
        }

        public bool CashDrawerSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.CashDrawerIsEnabled;
            }
        }

        public bool BarcodeReaderSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.BarcodeReaderIsEnabled;
            }
        }

        public bool CustomerDisplaySampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return ModelFinder.GetCustomerDisplayIsEnabled(SelectedModel.Model, SelectedPort.PortName);
            }
        }

        public bool MelodySpeakerSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.MelodySpeakerIsEnabled;
            }
        }

        public string SoundNumberDefaultText
        {
            get
            {
                return SelectedModel.SoundNumberDefault.ToString();
            }
        }

        public int SoundNumberDefault
        {
            get
            {
                if (IsUnselected)
                {
                    return -1;
                }

                return SelectedModel.SoundNumberDefault;
            }
        }

        public Visibility SoundVolumeLabelVisibility
        {
            get
            {
                return SoundVolumeIsEnabled ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool SoundVolumeIsEnabled
        {
            get
            {
                return SoundVolumeDefault != -1 &&
                       SoundVolumeMax != -1 &&
                       SoundVolumeMin != -1;
            }
        }

        public int SoundVolumeDefault
        {
            get
            {
                if (IsUnselected)
                {
                    return -1;
                }

                return SelectedModel.SoundVolumeDefault;
            }
        }

        public int SoundVolumeMax
        {
            get
            {
                if (IsUnselected)
                {
                    return -1;
                }

                return SelectedModel.SoundVolumeMax;
            }
        }

        public int SoundVolumeMin
        {
            get
            {
                if (IsUnselected)
                {
                    return -1;
                }

                return SelectedModel.SoundVolumeMin;
            }
        }


        public bool CombinationSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return SelectedModel.BarcodeReaderIsEnabled;
            }
        }

        public bool CombinationPrinterDriverSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return IsExistPrinterQueue;
            }
        }

        public bool APISampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return true;
            }
        }

        public bool BluetoothSettingSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return ModelFinder.IsBluetoothPort(SelectedPort.PortName);
            }
        }

        public bool USBSerialNumberSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return ModelFinder.GetSetUSBSerialNumberIsEnabled(SelectedModel.Model, SelectedPort.PortName);
            }
        }

        public int SettableUSBSerialNumberLength
        {
            get
            {
                return ModelFinder.GetSettableUSBSerialNumberLength(SelectedModel.Model, SelectedPort.PortName);
            }
        }

        public bool USBSerialNumberIsEnabledDefault
        {
            get
            {
                return ModelFinder.GetUSBSerialNumberIsEnabledDefault(SelectedModel.Model, SelectedPort.PortName);
            }
        }

        public bool DeviceStatusSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return true;
            }
        }

        public bool SerialNumberSampleIsEnabled
        {
            get
            {
                if (IsUnselected)
                {
                    return false;
                }

                return ModelFinder.GetProductSerialNumberIsEnabled(SelectedModel.Model, SelectedPort.PortName, SelectedPort.ModelName);
            }
        }

        public bool TextReceiptIsEnabled
        {
            get
            {
                return SelectedModel.TextReceiptIsEnabled;
            }
        }

        public bool TextReceiptIsEnabledForPrintRedirection
        {
            get
            {
                return TextReceiptIsEnabled && IsSelectedSubModel;
            }
        }

        public Visibility TextReceiptVisibility
        {
            get
            {
                if (SharedInformationManager.SelectedLanguage.Type == LanguageType.Utf8MultiLanguage)
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
        }

        public bool TextUTF8ReceiptIsEnabled
        {
            get
            {
                if (SharedInformationManager.SelectedLanguage.Type == LanguageType.Utf8MultiLanguage)
                {
                    return SelectedModel.CJKIsEnabled;
                }

                return SelectedModel.UTF8IsEnabled;
            }
        }

        public bool TextUTF8ReceiptIsEnabledForPrintRedirection
        {
            get
            {
                return TextUTF8ReceiptIsEnabled && IsSelectedSubModel;
            }
        }

        public bool RasterReceiptIsEnabled
        {
            get
            {
                return SelectedModel.RasterReceiptIsEnabled;
            }
        }

        public bool RasterReceiptIsEnabledForPrintRedirection
        {
            get
            {
                return RasterReceiptIsEnabled && IsSelectedSubModel;
            }
        }

        public Visibility RasterReceiptVisibility
        {
            get
            {
                if (SharedInformationManager.SelectedLanguage.Type == LanguageType.Utf8MultiLanguage)
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
        }

        public bool RasterCouponIsEnabled
        {
            get
            {
                return true;
            }
        }

        public bool RasterCouponIsEnabledForPrintRedirection
        {
            get
            {
                return RasterCouponIsEnabled && IsSelectedSubModel;
            }
        }

        public Visibility RasterCouponVisibility
        {
            get
            {
                if (SharedInformationManager.SelectedLanguage.Type == LanguageType.Utf8MultiLanguage)
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
        }

        public Visibility PrintPhotoFromCameraVisibility
        {
            get
            {
                if (SharedInformationManager.SelectedLanguage.Type == LanguageType.Utf8MultiLanguage)
                {
                    return Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
        }

        public Visibility AppendixVisibility
        {
            get
            {
                return PrintPhotoFromCameraVisibility;
            }
        }

        private string CreateSelectedModelDescription()
        {
            if (!IsSelectedModel)
            {
                return "Unselected State";
            }
            else
            {
                string modelName = CreateSelectedModelName(SelectedPort);
                PortInfoManager manager = new PortInfoManager(SelectedPort);

                if (PortInfoManager.IsSerialPort(SelectedPort))
                {
                    return modelName + "\n" + SelectedPort.PortName + " ( " + SelectedModel.PortSettings + " )";
                }
                else
                {
                    return modelName + "\n" + manager.Description;
                }
            }
        }

        private string CreateSelectedSubModelDescription()
        {
            if (!IsSelectedSubModel)
            {
                return "Unselected State";
            }
            else
            {
                PortInfo subPortInfo = SelectedPorts[1];
                ModelInformation subModel = SelectedModels[1];

                string modelName = CreateSelectedModelName(subPortInfo);
                PortInfoManager manager = new PortInfoManager(subPortInfo);

                if (PortInfoManager.IsSerialPort(subPortInfo))
                {
                    return modelName + "\n" + subPortInfo.PortName + " ( " + subModel.PortSettings + " )";
                }
                else
                {
                    return modelName + "\n" + manager.Description;
                }
            }
        }

        private string CreateSelectedModelName(PortInfo target)
        {
            string modelName = "";

            if (target.ModelName.Equals(""))
            {
                modelName = SelectedModel.SimpleModelName;

                int starPRNTIndex = SelectedModel.SimpleModelName.IndexOf(" StarPRNT");

                if (starPRNTIndex > 0)
                {
                    modelName = modelName.Substring(0, starPRNTIndex);
                }
            }
            else
            {
                modelName = target.ModelName;
            }

            return modelName;
        }

        private BlackMarkType GetBlackMarkType()
        {
            BlackMarkType type = BlackMarkType.Invalid;

            if (BlackMarkDetectionIsEnabled)
            {
                type = blackMarkType;
            }

            return type;
        }

        public string[] GetSelectedPortNameAndPortSettings(int printerPriority)
        {
            if (SelectedPorts.Length < printerPriority + 1 ||
                SelectedModels.Length < printerPriority + 1)
            {
                return (string[])Enumerable.Empty<string>();
            }

            PortInfo selectedPort = SelectedPorts[printerPriority];
            ModelInformation selectedModel = SelectedModels[printerPriority];

            List<string> settingsList = new List<string>();

            settingsList.Add(selectedPort.PortName);

            settingsList.Add(selectedModel.PortSettings);

            return settingsList.ToArray();
        }

        private void CallPropertyChangedEvent()
        {
            OnPropertyChanged("SelectedModel");
            OnPropertyChanged("SelectedPort");
            OnPropertyChanged("SelectedPaperSize");
            OnPropertyChanged("IsSelected");
            OnPropertyChanged("IsUnselected");
            OnPropertyChanged("IsSelectedSubModel");
            OnPropertyChanged("IsUnselectedSubModel");
            OnPropertyChanged("SelectedModelDescription");
            OnPropertyChanged("SelectedSubModelDescription");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
