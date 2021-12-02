using StarMicronics.StarIOExtension;

namespace StarPRNTSDK
{
    internal enum PrinterModel : int
    {
        L200 = 0,
        L300,
        S210i,
        S220i,
        S230i,
        T300i,
        T400i,
        S210i_StarPRNT,
        S220i_StarPRNT,
        S230i_StarPRNT,
        T300i_StarPRNT,
        T400i_StarPRNT,
        BSC10,
        FVP10,
        SP700,
        TSP650II,
        TSP700II,
        TSP800II,
        POP10,
        MCP20,
        MCP30,
        TSP100IV,
        TSP100,
        Unknown
    }

    internal class ModelInformation
    {
        public ModelInformation(PrinterModel model)
        {
            drawerOpenStatus = null;

            Model = model;
        }

        public ModelInformation() : this(PrinterModel.Unknown) { }

        public PrinterModel Model { get; set; }

        public string[] ModelName { get { return ModelFinder.GetModelName(Model); } }

        public string[] DeviceID { get { return ModelFinder.GetDeviceID(Model); } }

        public string[] BtDeviceNamePrefix { get { return ModelFinder.GetBTDeviceNamePrefix(Model); } }

        public string DefaultPortSettings { get { return ModelFinder.GetDefaultPortSettings(Model); } }

        public bool ChangeCashDrawerPolarityIsEnabled { get { return ModelFinder.GetChangeCashDrawerPolarityIsEnabled(Model); } }

        public string SimpleModelName { get { return ModelFinder.GetSimpleModelName(Model); } }

        public bool TextReceiptIsEnabled { get { return ModelFinder.GetTextReceiptIsEnabled(Model); } }

        public bool UTF8IsEnabled { get { return ModelFinder.GetUTF8IsEnabled(Model); } }

        public bool RasterReceiptIsEnabled { get { return ModelFinder.GetRasterReceiptIsEnabled(Model); } }

        public bool CJKIsEnabled { get { return ModelFinder.GetCJKIsEnabled(Model); } }

        public bool BlackMarkIsEnabled { get { return ModelFinder.GetBlackMarkIsEnabled(Model); } }

        public bool BlackMarkDetectionIsEnabled { get { return ModelFinder.GetBlackMarkDetectionIsEnabled(Model); } }

        public bool PageModeIsEnabled { get { return ModelFinder.GetPageModeIsEnabled(Model); } }

        public bool PaperPresentStatusIsEnabled { get { return ModelFinder.GetPaperPresentStatusIsEnabled(Model); } }

        public bool AutoSwitchInterfaceIsEnabled { get { return ModelFinder.GetAutoSwitchInterfaceIsEnabled(Model); } }

        public bool CashDrawerIsEnabled { get { return ModelFinder.GetCashDrawerIsEnabled(Model); } }

        public bool BarcodeReaderIsEnabled { get { return ModelFinder.GetBarcodeReaderIsEnabled(Model); } }

        public bool MelodySpeakerIsEnabled { get { return ModelFinder.GetMelodySpeakerIsEnabled(Model); } }

        public int SoundNumberDefault { get { return ModelFinder.GetSoundNumberDefault(Model); } }

        public int SoundVolumeDefault { get { return ModelFinder.GetSoundVolumeDefault(Model); } }

        public int SoundVolumeMax { get { return ModelFinder.GetSoundVolumeMax(Model); } }

        public int SoundVolumeMin { get { return ModelFinder.GetSoundVolumeMin(Model); } }

        public Emulation DefaultEmulation { get { return ModelFinder.GetEmulation(Model); } }

        public PaperSize DefaultPaperSize { get { return ModelFinder.GetDefaultPaperSize(Model); } }

        public string PortSettings
        {
            get
            {
                return GetPortSettings();
            }
            set
            {
                portSettings = value;
            }
        }

        private string portSettings;

        private string GetPortSettings()
        {
            if (portSettings == null)
            {
                return DefaultPortSettings;
            }
            else
            {
                if (!DefaultPortSettings.Equals("") && !portSettings.Contains(DefaultPortSettings))
                {
                    return portSettings + ";" + DefaultPortSettings;
                }
                else
                {
                    return portSettings;
                }
            }
        }

        public bool DrawerOpenStatus
        {
            get
            {
                return GetDrawerOpenStatus();
            }
            set
            {
                drawerOpenStatus = value;
            }
        }

        private bool? drawerOpenStatus;

        private bool GetDrawerOpenStatus()
        {
            if (drawerOpenStatus == null)
            {
                return true;
            }
            else
            {
                return (bool)drawerOpenStatus;
            }
        }
    }
}
