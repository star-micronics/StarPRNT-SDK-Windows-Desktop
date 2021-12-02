using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;

namespace StarPRNTSDK
{
    internal static class SharedInformationManager
    {
        public static SelectedModelManager SelectedModelManager { get; set; }

        public static ReceiptInformationManager ReceiptInformationManager { get; set; }

        public static DisplayFunctionManager DisplayFunctionManager { get; set; }

        public static PeripheralChannel PeripheralChannel { get; set; }

        public static bool CheckCondition { get; set; }

        public static ModelInformation SelectedModelInformation
        {
            get
            {
                return SelectedModelManager.SelectedModel;
            }
            set
            {
                SelectedModelManager.SelectedModel = value;

                SaveModelInfo(SelectedAllModelInformation);
            }
        }

        public static ModelInformation[] SelectedAllModelInformation
        {
            get
            {
                return SelectedModelManager.SelectedModels;
            }
            set
            {
                SelectedModelManager.SelectedModels = value;

                SaveModelInfo(SelectedAllModelInformation);
            }
        }

        public static MelodySpeakerModel SelectedSpeakerModel
        {
            get
            {
                MelodySpeakerModel speakerModel;

                switch (SelectedModelInformation.Model)
                {
                    default:
                    case PrinterModel.MCP30:
                    case PrinterModel.TSP100IV:
                        speakerModel = MelodySpeakerModel.MCS10;
                        break;

                    case PrinterModel.FVP10:
                        speakerModel = MelodySpeakerModel.FVP10;
                        break;
                }

                return speakerModel;
            }
        }

        public static void SetSelectedModelInformation(ModelInformation modelInformation, int printerPriority)
        {
            List<ModelInformation> modelInformationList = new List<ModelInformation>(SelectedAllModelInformation);

            while(modelInformationList.Count < printerPriority + 1)
            {
                modelInformationList.Add(null);
            }

            modelInformationList[printerPriority] = modelInformation;

            SelectedAllModelInformation = modelInformationList.ToArray();
        }

        public static PortInfo SelectedPortInfo
        {
            get
            {
                return SelectedModelManager.SelectedPort;
            }
            set
            {
                SelectedModelManager.SelectedPort = value;

                SavePortInfo(SelectedAllPortInfo);
            }
        }

        public static PortInfo[] SelectedAllPortInfo
        {
            get
            {
                return SelectedModelManager.SelectedPorts;
            }
            set
            {
                SelectedModelManager.SelectedPorts = value;

                SavePortInfo(SelectedAllPortInfo);
            }
        }

        public static void SetSelectedPortInfo(PortInfo portInfo, int printerPriority)
        {
            List<PortInfo> portInfoList = new List<PortInfo>(SelectedAllPortInfo);

            while (portInfoList.Count < printerPriority + 1)
            {
                portInfoList.Add(null);
            }

            portInfoList[printerPriority] = portInfo;

            SelectedAllPortInfo = portInfoList.ToArray();
        }

        public static Language SelectedLanguage
        {
            get
            {
                return ReceiptInformationManager.Language;
            }
            set
            {
                ReceiptInformationManager.Language = value;
            }
        }

        public static PaperSize SelectedPaperSize
        {
            get
            {
                return ReceiptInformationManager.PaperSize;
            }
            set
            {
                ReceiptInformationManager.PaperSize = value;

                SavePaperSize(SelectedAllPaperSizes);
            }
        }

        public static PaperSize[] SelectedAllPaperSizes
        {
            get
            {
                return ReceiptInformationManager.AllPaperSizes;
            }
            set
            {
                ReceiptInformationManager.AllPaperSizes = value;

                SavePaperSize(value);
            }
        }

        public static void SetSelectedPaperSize(PaperSize paperSize, int printerPriority)
        {
            List<PaperSize> paperSizeList = new List<PaperSize>(SelectedAllPaperSizes);

            while (paperSizeList.Count < printerPriority + 1)
            {
                paperSizeList.Add(null);
            }

            paperSizeList[printerPriority] = paperSize;

            SelectedAllPaperSizes = paperSizeList.ToArray();
        }

        public static BlackMarkType SelectedBlackMarkType
        {
            get
            {
                return SelectedModelManager.BlackMarkType;
            }
            set
            {
                SelectedModelManager.BlackMarkType = value;
            }
        }

        public static DisplayFunctionManager.FunctionType SelectedDisplayFunctionType
        {
            get
            {
                return DisplayFunctionManager.Type;
            }
            set
            {
                DisplayFunctionManager.Type = value;
            }
        }

        public static DisplayInternationalType SelectedDisplayInternationalType
        {
            get
            {
                return DisplayFunctionManager.SelectedInternationalType;
            }
            set
            {
                DisplayFunctionManager.SelectedInternationalType = value;
            }
        }

        public static DisplayCodePageType SelectedDisplayCodePageType
        {
            get
            {
                return DisplayFunctionManager.SelectedCodePageType;
            }
            set
            {
                DisplayFunctionManager.SelectedCodePageType = value;
            }
        }

        public static DisplayFunctionManager.FunctionType SelectedAdditionDisplayFunctionType
        {
            get
            {
                return DisplayFunctionManager.AdditionType;
            }
            set
            {
                DisplayFunctionManager.AdditionType = value;
            }
        }

        public static int SelectedDisplayFunctionDefaultPatternIndex
        {
            get
            {
                return DisplayFunctionManager.DefaultPatternIndex;
            }
        }

        public static int SelectedDisplayFunctionDefaultAdditionPatternIndex
        {
            get
            {
                return DisplayFunctionManager.DefaultAdditionPatternIndex;
            }
        }

        public static string SelectedPortName
        {
            get
            {
                return SelectedModelManager.SelectedPort.PortName;
            }
        }

        public static string SelectedPortSettings
        {
            get
            {
                return SelectedModelManager.SelectedModel.PortSettings;
            }
        }

        public static Emulation SelectedEmulation
        {
            get
            {
                return SelectedModelManager.SelectedModel.DefaultEmulation;
            }
        }

        public static LocalizeReceipt SelectedLocalizeReceipt
        {
            get
            {
                return ReceiptInformationManager.LocalizeReceipt;
            }
        }

        public static int SelectedActualPaperSize
        {
            get
            {
                return ReceiptInformationManager.PaperSize.ActualPaperSize;
            }
        }

        public static bool SelectedDrawerOpenStatus
        {
            get
            {
                return SelectedModelManager.SelectedModel.DrawerOpenStatus;
            }
        }

        public static void ReplaceSelectedModelManagerParameter(SelectedModelManager source)
        {
            SelectedModelManager.SelectedModels = source.SelectedModels;
            SelectedModelManager.SelectedPorts = source.SelectedPorts;
        }

        public static bool IsSelectedTCPPort
        {
            get
            {
                return ModelFinder.IsTCPPort(SelectedPortName);
            }
        }

        public static bool IsSelectedBluetoothPort
        {
            get
            {
                return ModelFinder.IsBluetoothPort(SelectedPortName);
            }
        }

        public static bool IsSelectedUSBPrinterClassPort
        {
            get
            {
                return ModelFinder.IsUSBPrinterClassPort(SelectedPortName);
            }
        }

        public static bool IsSelectedUSBVendorClassPort
        {
            get
            {
                return ModelFinder.IsUSBVendorClassPort(SelectedPortName);
            }
        }

        public static bool IsSelectedSerialPort
        {
            get
            {
                return ModelFinder.IsSerialPort(SelectedPortName);
            }
        }

        public static bool IsSelectedParallelPort
        {
            get
            {
                return ModelFinder.IsParallelPort(SelectedPortName);
            }
        }

        private static void SavePortInfo(PortInfo[] portInfoArray)
        {
            List<string> portNameList = new List<string>();
            List<string> macAddressList = new List<string>();
            List<string> modelNameList = new List<string>();
            List<string> usbSerialNumberList = new List<string>();

            foreach (PortInfo portInfo in portInfoArray)
            {
                if (portInfo == null)
                {
                    continue;
                }

                portNameList.Add(portInfo.PortName);
                macAddressList.Add(portInfo.MacAddress);
                modelNameList.Add(portInfo.ModelName);
                usbSerialNumberList.Add(portInfo.USBSerialNumber);
            }

            Properties.Settings.Default.PortNames = portNameList.ToArray();
            Properties.Settings.Default.MacAddresses = macAddressList.ToArray();
            Properties.Settings.Default.ModelNames = modelNameList.ToArray();
            Properties.Settings.Default.USBSerialNumbers = usbSerialNumberList.ToArray();

            Properties.Settings.Default.Save();
        }

        private static void SaveModelInfo(ModelInformation[] modelInfoArray)
        {
            List<int> selectedModelIndexList = new List<int>();
            List<string> portSettingsList = new List<string>();
            List<bool> drawerOpenStatusList = new List<bool>();

            foreach (ModelInformation modelInfo in modelInfoArray)
            {
                if (modelInfo == null)
                {
                    continue;
                }

                selectedModelIndexList.Add((int)modelInfo.Model);
                portSettingsList.Add(modelInfo.PortSettings);
                drawerOpenStatusList.Add(modelInfo.DrawerOpenStatus);
            }

            Properties.Settings.Default.SelectedModelIndexes = selectedModelIndexList.ToArray();
            Properties.Settings.Default.PortSettings = portSettingsList.ToArray();
            Properties.Settings.Default.DrawerOpenStatuses = drawerOpenStatusList.ToArray();

            Properties.Settings.Default.Save();
        }

        private static void SavePaperSize(PaperSize[] paperSizeArray)
        {
            List<int> paperSizeIndexList = new List<int>();

            foreach (PaperSize paperSize in paperSizeArray)
            {
                if (paperSize == null ||
                    paperSize.Type == PaperSizeType.Unknown)
                {
                    continue;
                }

                paperSizeIndexList.Add((int)paperSize.Type);
            }


            Properties.Settings.Default.SelectedPaperSizeIndexes = paperSizeIndexList.ToArray();

            Properties.Settings.Default.Save();
        }

        public static void RestorePreviousInfo()
        {
            if (!IsSavedAllPrinterSettings())
            {
                return;
            }

            List<PortInfo> portInfoList = new List<PortInfo>();
            List<ModelInformation> modelInformationList = new List<ModelInformation>();
            List<PaperSize> paperSizeList = new List<PaperSize>();

            for (int i = 0; i < Properties.Settings.Default.PortNames.Length; i++)
            {
                string portName = Properties.Settings.Default.PortNames[i];
                string macAddress = Properties.Settings.Default.MacAddresses[i];
                string modelName = Properties.Settings.Default.ModelNames[i];
                string usbSerialNumber = Properties.Settings.Default.USBSerialNumbers[i];
                portInfoList.Add(new PortInfo(portName, macAddress, modelName, usbSerialNumber));

                int selectedModelIndex = Properties.Settings.Default.SelectedModelIndexes[i];
                string portSettings = Properties.Settings.Default.PortSettings[i];
                bool drawerOpenStatus = Properties.Settings.Default.DrawerOpenStatuses[i];
                ModelInformation modelInformaiton = new ModelInformation((PrinterModel)Enum.ToObject(typeof(PrinterModel), selectedModelIndex));
                modelInformaiton.PortSettings = portSettings;
                modelInformaiton.DrawerOpenStatus = drawerOpenStatus;
                modelInformationList.Add(modelInformaiton);

                int papserSizeIndex = Properties.Settings.Default.SelectedPaperSizeIndexes[i];
                paperSizeList.Add(new PaperSize((PaperSizeType)Enum.ToObject(typeof(PaperSizeType), papserSizeIndex)));
            }

            SelectedAllPortInfo = portInfoList.ToArray();
            SelectedAllModelInformation = modelInformationList.ToArray();
            SelectedAllPaperSizes = paperSizeList.ToArray();
        }

        private static bool IsSavedAllPrinterSettings()
        {
            List<object[]> objectArrayList = new List<object[]>();
            objectArrayList.Add(Properties.Settings.Default.PortNames);
            objectArrayList.Add(Properties.Settings.Default.MacAddresses);
            objectArrayList.Add(Properties.Settings.Default.ModelNames);
            objectArrayList.Add(Properties.Settings.Default.USBSerialNumbers);
            objectArrayList.Add(Properties.Settings.Default.PortSettings);

            List<int[]> valueArrayList = new List<int[]>();
            valueArrayList.Add(Properties.Settings.Default.SelectedModelIndexes);
            valueArrayList.Add(Properties.Settings.Default.SelectedPaperSizeIndexes);

            List<bool[]> booleanArrayList = new List<bool[]>();
            booleanArrayList.Add(Properties.Settings.Default.DrawerOpenStatuses);

            if (Util.IsContainsNullOrEmptyArray(objectArrayList) ||
                Util.IsContainsNullOrEmptyArray(valueArrayList) ||
                Util.IsContainsNullOrEmptyArray(booleanArrayList))
            {
                return false;
            }

            if (!Util.IsEqualAllArraysLength(objectArrayList) ||
                !Util.IsEqualAllArraysLength(valueArrayList) ||
                !Util.IsEqualAllArraysLength(booleanArrayList))
            {
                return false;
            }

            if (objectArrayList[0].Length != valueArrayList[0].Length ||
                valueArrayList[0].Length != booleanArrayList[0].Length)
            {
                return false;
            }

            return true;
        }
    }
}
