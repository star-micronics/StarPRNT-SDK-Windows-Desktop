using StarMicronics.StarIOExtension;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class CashDrawerSampleManager
    {
        /// <summary>
        /// Sample : Opening cash drawer.
        /// </summary>
        public static void OpenCashDrawer(PeripheralChannel channel, bool checkCondition)
        {
            // Your printer emulation.
            Emulation emulation = SharedInformationManager.SelectedEmulation;

            // Create open cash darawer commands.
            byte[] commands = CashDrawerFunctions.CreateData(emulation, channel);

            // Your printer PortName and PortSettings.
            string portName = SharedInformationManager.SelectedPortName;
            string portSettings = SharedInformationManager.SelectedPortSettings;

            if (checkCondition)
            {
                // Sending commands to printer sample is "Communication.SendCommands(byte[] commands, string portName, string portSettings, int timeout)".
                Communication.SendCommandsWithProgressBar(commands, portName, portSettings, 30000);
            }
            else
            {
                // Sending commands to printer sample (do not check condition) is "Communication.SendCommandsDoNotCheckCondition(byte[] commands, string portName, string portSettings, int timeout)".
                Communication.SendCommandsDoNotCheckConditionWithProgressBar(commands, portName, portSettings, 30000);
            }
        }
    }

    public class OpenCashDrawerClickEvent : BaseCommand
    {
        public PeripheralChannel Channel { get; set; }

        public bool CheckCondition { get; set; }

        public override void Execute(object parameter)
        {
            CashDrawerSampleManager.OpenCashDrawer(Channel, CheckCondition);
        }
    }

    public partial class CashDrawerSamplePage : Page
    {
        public CashDrawerSamplePage()
        {
            InitializeComponent();
        }
    }
}
