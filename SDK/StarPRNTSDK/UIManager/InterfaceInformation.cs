using StarMicronics.StarIO;

namespace StarPRNTSDK
{
    public class InterfaceInformation
    {
        public enum ManualSettingType
        {
            All,
            Manual,
            NotManually
        }

        public InterfaceInformation()
        {
            ManualSetting = ManualSettingType.NotManually;
        }

        public PrinterInterfaceType Type { get; set; }

        public ManualSettingType ManualSetting { get; set; }

        public string Description
        {
            get
            {
                return CreateDescription();
            }
        }

        private string CreateDescription()
        {
            if(ManualSetting == ManualSettingType.NotManually)
            {
                return CreateInterfaceTypeDescription(Type);
            }
            else
            {
                return CreateManualSettingTypeDescription(ManualSetting);
            }
        }

        private string CreateInterfaceTypeDescription(PrinterInterfaceType type)
        {
            string desctiption;

            switch(type)
            {
                default:
                case PrinterInterfaceType.USBVendorClass:
                    desctiption = "USB Vendor Class";
                    break;

                case PrinterInterfaceType.USBPrinterClass:
                    desctiption = "USB Printer Class";
                    break;

                case PrinterInterfaceType.Ethernet:
                    desctiption = "LAN";
                    break;

                case PrinterInterfaceType.Bluetooth:
                    desctiption = "Bluetooth";
                    break;

                case PrinterInterfaceType.Serial:
                    desctiption = "Serial";
                    break;

                case PrinterInterfaceType.Parallel:
                    desctiption = "Parallel";
                    break;
            }

            return desctiption;
        }

        private string CreateManualSettingTypeDescription(ManualSettingType type)
        {
            string desctiption;

            switch (type)
            {
                default:
                case ManualSettingType.All:
                    desctiption = "All";
                    break;

                case ManualSettingType.Manual:
                    desctiption = "Manual";
                    break;

                case ManualSettingType.NotManually:
                    desctiption = "Not Manually";
                    break;
            }

            return desctiption;
        }
    }
}
