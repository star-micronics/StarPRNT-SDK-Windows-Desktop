using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System.Windows.Controls;

namespace StarPRNTSDK
{
    public static class DisplaySampleManager
    {
        /// <summary>
        /// Sample : Getting display status.
        /// </summary>
        public static Communication.PeripheralStatus GetDiaplayStatus(IPort port)
        {
            // Create IPeripheralConnectParser object.
            IPeripheralConnectParser parser = StarIoExt.CreateDisplayConnectParser(DisplayModel.SCD222);

            // Usage of parser sample is "Communication.ParseDoNotCheckCondition(IPeripheralCommandParser parser, IPort port)".
            CommunicationResult result = Communication.ParseDoNotCheckCondition(parser, port);

            // Check peripheral status.
            Communication.PeripheralStatus status = Communication.PeripheralStatus.Invalid;
            if (result.Result == Communication.Result.Success)
            {
                // Check parser property value.
                if (parser.IsConnected) // connect
                {
                    status = Communication.PeripheralStatus.Connect;
                }
                else // disconnect
                {
                    status = Communication.PeripheralStatus.Disconnect;
                }
            }
            else // communication error
            {
                status = Communication.PeripheralStatus.Impossible;
            }

            return status;
        }

        /// <summary>
        /// Sample : Display text.
        /// </summary>
        public static Communication.PeripheralStatus DoTextPattern(DisplayFunctionManager.TextPattern pattern, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateTextPattern(pattern);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display graphic.
        /// </summary>
        public static Communication.PeripheralStatus DoGraphicPattern(DisplayFunctionManager.GraphicPattern pattern, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateGraphicPattern(pattern);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display turn on.
        /// </summary>
        public static Communication.PeripheralStatus DoTurnOnOffPattern(bool turnOn, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateTurnOn(turnOn);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display cursor mode.
        /// </summary>
        public static Communication.PeripheralStatus DoCursorPattern(DisplayCursorMode cursorMode, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateCursorMode(cursorMode);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display contrast mode.
        /// </summary>
        public static Communication.PeripheralStatus DoContrastPattern(DisplayContrastMode contrastMode, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateContrastMode(contrastMode);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display character set international type.
        /// </summary>
        public static Communication.PeripheralStatus DoCharacterSetInternationalPattern(DisplayInternationalType internationalType, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Select character set.
            DisplayCodePageType codePageType = SharedInformationManager.SelectedDisplayCodePageType;

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateCharacterSet(internationalType, codePageType);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display character set code page type.
        /// </summary>
        public static Communication.PeripheralStatus DoCharacterSetCodePagePattern(DisplayCodePageType codePageType, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Select character set.
            DisplayInternationalType internationalType = SharedInformationManager.SelectedDisplayInternationalType;

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateCharacterSet(internationalType, codePageType);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }

        /// <summary>
        /// Sample : Display user defined character.
        /// </summary>
        public static Communication.PeripheralStatus DoUserDefinedCharacterPattern(bool set, IPort port)
        {
            // Check display status.
            Communication.PeripheralStatus status = GetDiaplayStatus(port);

            if (status != Communication.PeripheralStatus.Connect) // Display is not connected.
            {
                return status;
            }

            // Create display commands.
            byte[] displayCommands = DisplayFunctions.CreateUserDefinedCharacter(set);

            // Send display commands.
            CommunicationResult result = Communication.SendCommandsDoNotCheckCondition(displayCommands, port);

            if (result.Result != Communication.Result.Success)
            {
                return Communication.PeripheralStatus.Impossible;
            }
            else
            {
                return Communication.PeripheralStatus.Connect;
            }
        }
    }

    public partial class DisplaySamplePage : Page
    {
        public DisplaySamplePage()
        {
            InitializeComponent();
        }
    }
}
