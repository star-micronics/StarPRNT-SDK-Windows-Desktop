using StarMicronics.StarIO;

namespace StarPRNTSDK
{
    public class BluetoothSecurityTypeManager
    {
        public BluetoothSecurityTypeManager()
        {
            Type = StarBluetoothManager.StarBluetoothSecurity.DISABLE;
        }

        public BluetoothSecurityTypeManager(StarBluetoothManager.StarBluetoothSecurity type)
        {
            Type = type;
        }

        public StarBluetoothManager.StarBluetoothSecurity Type { get; set; }

        public string Description
        {
            get
            {
                return CreateDescription();
            }
        }

        private string CreateDescription()
        {
            string description = "";

            switch (Type)
            {
                default:
                case StarBluetoothManager.StarBluetoothSecurity.DISABLE:
                    description = "Disable";
                    break;

                case StarBluetoothManager.StarBluetoothSecurity.SSP:
                    description = "SSP";
                    break;

                case StarBluetoothManager.StarBluetoothSecurity.PINCODE:
                    description = "PIN Code";
                    break;
            }

            return description;
        }
    }
}
