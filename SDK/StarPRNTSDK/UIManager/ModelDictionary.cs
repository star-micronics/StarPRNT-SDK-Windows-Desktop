using StarMicronics.StarIOExtension;
using System.Collections.Generic;
using System.Linq;

namespace StarPRNTSDK
{
    internal class PrinterInfo
    {
        public Emulation Emulation { get; set; }

        public PaperSizeType DefaultPaperSize { get; set; }

        public string[] ModelName
        {
            get
            {
                return _ModelName;
            }
            set
            {
                _ModelName = value;
            }
        }
        private string[] _ModelName = (string[])Enumerable.Empty<string>();

        public string[] DeviceID
        {
            get
            {
                return _DeviceID;
            }
            set
            {
                _DeviceID = value;
            }
        }
        private string[] _DeviceID = (string[])Enumerable.Empty<string>();

        public string[] BTDeviceNamePrefix
        {
            get
            {
                return _BTDeviceNamePrefix;
            }
            set
            {
                _BTDeviceNamePrefix = value;
            }
        }
        private string[] _BTDeviceNamePrefix = (string[])Enumerable.Empty<string>();

        public string DefaultPortSettings
        {
            get
            {
                return _DefaultPortSettings;
            }
            set
            {
                _DefaultPortSettings = value;
            }
        }
        private string _DefaultPortSettings = "";

        public bool ChangeCashDrawerPolarityIsEnabled { get; set; }

        public string SimpleModelName
        {
            get
            {
                return _SimpleModelName;
            }
            set
            {
                _SimpleModelName = value;
            }
        }
        private string _SimpleModelName = "";

        public bool TextReceiptIsEnabled { get; set; }

        public bool UTF8IsEnabled { get; set; }

        public bool RasterReceiptIsEnabled { get; set; }

        public bool CJKIsEnabled { get; set; }

        public bool BlackMarkIsEnabled { get; set; }

        public bool BlackMarkDetectionIsEnabled { get; set; }

        public bool PageModeIsEnabled { get; set; }

        public bool PaperPresentStatusIsEnabled { get; set; }

        public bool AutoSwitchInterfaceIsEnabled { get; set; }

        public bool CashDrawerIsEnabled { get; set; }

        public bool BarcodeReaderIsEnabled { get; set; }

        public bool CustomerDisplayIsEnabled { get; set; }

        public bool MelodySpeakerIsEnabled { get; set; }

        public int SoundNumberDefault { get; set; }

        public int SoundVolumeDefault { get; set; }

        public int SoundVolumeMin { get; set; }

        public int SoundVolumeMax { get; set; }

        public bool ProductSerialNumberIsEnabled { get; set; }

        public int SettableUSBSerialNumberLength { get; set; }

        public bool USBSerialNumberIsEnabledDefault { get; set; }
    }

    internal class ModelDictionary
    {
        public static Dictionary<PrinterModel, PrinterInfo> ModelInformationDictionary
        {
            get
            {
                return new Dictionary<PrinterModel, PrinterInfo>()
                {
                    { PrinterModel.L200,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star SM-L200" },
                          DeviceID = new string[] {  "SM-L200 (STAR_T-001)" },
                          BTDeviceNamePrefix = new string[] {  "STAR L200-", "STAR L204-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-L200",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.L300,

                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNTL,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star SM-L300" },
                          DeviceID = new string[] {  "SM-L300 (STAR_T-001)" },
                          BTDeviceNamePrefix = new string[] {  "STAR L300-", "STAR L304-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-L300",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S210i,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPosMobile,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = (string[])Enumerable.Empty<string>(),
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "mini",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S210i",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S220i,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPosMobile,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = (string[])Enumerable.Empty<string>(),
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "mini",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S220i",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S230i,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPosMobile,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = (string[])Enumerable.Empty<string>(),
                          DeviceID = new string[] {  "SM-S230i (STAR_T-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "mini",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S230i",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.T300i,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPosMobile,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = (string[])Enumerable.Empty<string>(),
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "mini",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-T300i/T300",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.T400i,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPosMobile,
                          DefaultPaperSize = PaperSizeType.FourInch,
                          ModelName = (string[])Enumerable.Empty<string>(),
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "mini",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-T400i",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S210i_StarPRNT,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star SM-S210i" },
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S210i StarPRNT",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S220i_StarPRNT,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star SM-S220i" },
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S220i StarPRNT",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.S230i_StarPRNT,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star SM-S230i" },
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-S230i StarPRNT",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.T300i_StarPRNT,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star SM-T300i" },
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-T300i/T300 StarPRNT",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.T400i_StarPRNT,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.FourInch,
                          ModelName = new string[] { "Star SM-T400i" },
                          DeviceID = (string[])Enumerable.Empty<string>(),
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "SM-T400i StarPRNT",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = false,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 0,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.BSC10,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.EscPos,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star BSC10" },
                          DeviceID = new string[] {  "BSC10 (ESP-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "escpos",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "BSC10",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.FVP10,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarLine,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star FVP10" },
                          DeviceID = new string[] {  "FVP10 (STR_T-001)", "FVP10 (STRP-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "FVP10",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = true,
                          SoundNumberDefault = 1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.SP700,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarDotImpact,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star SP700 TearBar (SP717)", "Star SP700 Cutter (SP747)", "Star SP700 TearBar (SP712)", "Star SP700 Cutter (SP742)" },
                          DeviceID = new string[] {  "SP717 (STR-001)", "SP747 (STR-001)", "SP712 (STR-001)", "SP742 (STR-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "SP700",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = false,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = false,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.TSP650II,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarLine,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star TSP650II Cutter (TSP654II)" },
                          DeviceID = new string[] {  "TSP654 (STR_T-001)", "TSP651 (STR_T-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "TSP650II",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = true,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.TSP700II,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarLine,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star TSP700II (TSP743II)" },
                          DeviceID = new string[] {  "TSP743II (STR_T-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "TSP700II",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.TSP800II,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarLine,
                          DefaultPaperSize = PaperSizeType.FourInch,
                          ModelName = new string[] { "Star TSP800II (TSP847II)" },
                          DeviceID = new string[] {  "TSP800 (STR_R-001)", "TSP800 (STR_R-U001)", "TSP800 (STR_T-001)", "TSP800 (STR_T-E001)", "TSP800 (STR_T-U001)", "TSP800 (STR-E001)", "TSP800 (STRP-E001)", "TSP800(STRP-U001)", "TSP847II (STR_T-001)", "TSP847II (STRP-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "TSP800II",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = false,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = false,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.POP10,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star POP10" },
                          DeviceID = new string[] {  "POP10 (STR-001)" },
                          BTDeviceNamePrefix = new string[] {  "STAR mPOP-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = false,
                          SimpleModelName = "mPOP",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = true,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.MCP20,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.TwoInch,
                          ModelName = new string[] { "Star MCP21/20" },
                          DeviceID = new string[] {  "MCP20 (STR-001)", "MCP21 (STR-001)" },
                          BTDeviceNamePrefix = new string[] {  "mC-Print2-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "mC-Print2",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = true,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = true,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 16,
                          USBSerialNumberIsEnabledDefault = true
                      }
                    },

                    { PrinterModel.MCP30,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star MCP30", "Star MCP31" },
                          DeviceID = new string[] { "MCP30 (STR-001)", "MCP31 (STR-001)" },
                          BTDeviceNamePrefix = new string[] {  "mC-Print3-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "mC-Print3",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = true,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = true,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = true,
                          SoundNumberDefault = 0,
                          SoundVolumeDefault = 12,
                          SoundVolumeMax = 15,
                          SoundVolumeMin = 0,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 16,
                          USBSerialNumberIsEnabledDefault = true
                      }
                    },

                    { PrinterModel.MCL32,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star MCL32" },
                          DeviceID = new string[] { "MCL32 (STR-001)" },
                          BTDeviceNamePrefix = new string[] {  "mC-Label3-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "mC-Label3",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = true,
                          BlackMarkDetectionIsEnabled = true,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = true,
                          AutoSwitchInterfaceIsEnabled = true,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = true,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = 0,
                          SoundVolumeDefault = 12,
                          SoundVolumeMax = 15,
                          SoundVolumeMin = 0,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 16,
                          USBSerialNumberIsEnabledDefault = true
                      }
                    },

                    { PrinterModel.TSP100IV,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star TSP100" },
                          DeviceID = new string[] { "TSP143IV (STR-001)" },
                          BTDeviceNamePrefix = new string[] {  "TSP100IV-" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "TSP100IV",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = true,
                          AutoSwitchInterfaceIsEnabled = true,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = true,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = true,
                          SoundNumberDefault = 0,
                          SoundVolumeDefault = 12,
                          SoundVolumeMax = 15,
                          SoundVolumeMin = 0,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 16,
                          USBSerialNumberIsEnabledDefault = true
                      }
                    },

                    { PrinterModel.TSP100,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarGraphic,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star TSP100 Tear Bar (TSP113)", "Star TSP100 Cutter (TSP143)", "Star TSP113GT Tear Bar", "Star TSP143GT Cutter" },
                          DeviceID = new string[] { "TSP113 (STR_T-001)", "TSP143 (STR_T-001)", "TSP113GT (STR_T-001)", "TSP143GT (STR_T-001)", "TSP143IIIW (STR_T-001)", "TSP143IIILAN (STR_T-001)" },
                          BTDeviceNamePrefix = new string[] {  "TSP100-", "TSP113" },
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "TSP100",
                          TextReceiptIsEnabled = false,
                          UTF8IsEnabled = false,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = false,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = false,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = false,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = true,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 8,
                          USBSerialNumberIsEnabledDefault = false
                      }
                    },

                    { PrinterModel.BSC10II,
                      new PrinterInfo()
                      {
                          Emulation = Emulation.StarPRNT,
                          DefaultPaperSize = PaperSizeType.ThreeInch,
                          ModelName = new string[] { "Star BSC10II" },
                          DeviceID = new string[] {  "BSC10II (STR-001)" },
                          BTDeviceNamePrefix = (string[])Enumerable.Empty<string>(),
                          DefaultPortSettings = "",
                          ChangeCashDrawerPolarityIsEnabled = true,
                          SimpleModelName = "BSC10II",
                          TextReceiptIsEnabled = true,
                          UTF8IsEnabled = true,
                          RasterReceiptIsEnabled = true,
                          CJKIsEnabled = true,
                          BlackMarkIsEnabled = false,
                          BlackMarkDetectionIsEnabled = false,
                          PageModeIsEnabled = true,
                          PaperPresentStatusIsEnabled = false,
                          AutoSwitchInterfaceIsEnabled = true,
                          CashDrawerIsEnabled = true,
                          BarcodeReaderIsEnabled = false,
                          CustomerDisplayIsEnabled = false,
                          MelodySpeakerIsEnabled = false,
                          SoundNumberDefault = -1,
                          SoundVolumeDefault = -1,
                          SoundVolumeMax = -1,
                          SoundVolumeMin = -1,
                          ProductSerialNumberIsEnabled = true,
                          SettableUSBSerialNumberLength = 16,
                          USBSerialNumberIsEnabledDefault = true
                      }
                    },

                    { PrinterModel.Unknown, new PrinterInfo() },

                };
            }
        }
    }
}
