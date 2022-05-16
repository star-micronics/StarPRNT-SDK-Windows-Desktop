using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace StarPRNTSDK
{
    public class CommunicationResult
    {
        public Communication.Result Result { get; set; }

        public int Code { get; set; }

        public CommunicationResult()
        {
            Result = Communication.Result.ErrorUnknown;
            Code = StarResultCode.ErrorFailed;
        }
    }

    public static class Communication
    {

        public enum Result
        {
            Success,
            ErrorUnknown,
            ErrorOpenPort,
            ErrorBeginCheckedBlock,
            ErrorEndCheckedBlock,
            ErrorWritePort,
            ErrorReadPort,
        }

        public enum PeripheralStatus
        {
            Invalid,
            Impossible,
            Connect,
            Disconnect
        }

        /// <summary>
        /// Sample : Sending commands to printer with check condition.
        /// </summary>
        public static CommunicationResult SendCommands(byte[] commands, string portName, string portSettings, int timeout)
        {
            Result result = Result.ErrorUnknown;
            int code = StarResultCode.ErrorFailed;

            IPort port = null;

            try
            {
                result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                StarPrinterStatus status;

                result = Result.ErrorBeginCheckedBlock;

                status = port.BeginCheckedBlock();

                if (status.Offline)
                {
                    string message = "Printer is Offline.";

                    if (status.ReceiptPaperEmpty)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (status.CoverOpen)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.ErrorWritePort;

                uint commandsLength = (uint)commands.Length;

                uint writtenLength = port.WritePort(commands, 0, commandsLength);

                if (writtenLength != commandsLength)
                {
                    throw new PortException("WritePort failed.");
                }

                result = Result.ErrorEndCheckedBlock;

                status = port.EndCheckedBlock();

                if (status.Offline == true)
                {
                    string message = "Printer is Offline.";

                    if (status.ReceiptPaperEmpty == true)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (status.CoverOpen == true)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Sending commands to printer with check condition (Multiple Pages).
        /// </summary>
        public static CommunicationResult SendCommandsMultiplePages(List<byte[]> commandList, string portName, string portSettings, int timeout, int holdPrintTimeout, Action<int> startAction, Action<int> finishAction)
        {
            Result result = Result.ErrorUnknown;
            int code = StarResultCode.ErrorFailed;

            IPort port = null;

            try
            {
                result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                for(int i = 0; i < commandList.Count; i++)
                {
                    byte[] commands = commandList[i];

                    StarPrinterStatus status;

                    result = Result.ErrorBeginCheckedBlock;

                    port.HoldPrintTimeout = holdPrintTimeout;

                    status = port.BeginCheckedBlock();

                    if (status.Offline)
                    {
                        string message = "Printer is Offline.";

                        if (status.ReceiptPaperEmpty)
                        {
                            message += "\nPaper is Empty.";
                        }

                        if (status.CoverOpen)
                        {
                            message += "\nCover is Open.";
                        }

                        throw new PortException(message);
                    }

                    if(startAction != null)
                    {
                        startAction.Invoke(i);
                    }

                    result = Result.ErrorWritePort;

                    uint commandsLength = (uint)commands.Length;

                    uint writtenLength = port.WritePort(commands, 0, commandsLength);

                    if (writtenLength != commandsLength)
                    {
                        throw new PortException("WritePort failed.");
                    }

                    result = Result.ErrorEndCheckedBlock;

                    status = port.EndCheckedBlock();

                    if (status.Offline == true)
                    {
                        string message = "Printer is Offline.";

                        if (status.ReceiptPaperEmpty == true)
                        {
                            message += "\nPaper is Empty.";
                        }

                        if (status.CoverOpen == true)
                        {
                            message += "\nCover is Open.";
                        }

                        throw new PortException(message);
                    }

                    if (finishAction != null)
                    {
                        finishAction.Invoke(i);
                    }

                    if(i == commandList.Count - 1)
                    {
                        result = Result.Success;
                        code = StarResultCode.Succeeded;
                    }
                }
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Sending commands to printer without check condition.
        /// </summary>
        public static CommunicationResult SendCommandsDoNotCheckCondition(byte[] commands, string portName, string portSettings, int timeout)
        {
            Result result = Result.ErrorUnknown;
            int code = StarResultCode.ErrorFailed;

            IPort port = null;

            try
            {
                result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                StarPrinterStatus status;

                result = Result.ErrorWritePort;

                status = port.GetParsedStatus();

                uint commandsLength = (uint)commands.Length;

                uint writtenLength = port.WritePort(commands, 0, commandsLength);

                if (writtenLength != commandsLength)
                {
                    throw new PortException("WritePort failed.");
                }

                result = Result.ErrorWritePort;

                status = port.GetParsedStatus();

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Sending commands to printer with check condition (already open port).
        /// </summary>
        public static CommunicationResult SendCommands(byte[] commands, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                StarPrinterStatus printerStatus;

                result = Result.ErrorBeginCheckedBlock;

                printerStatus = port.BeginCheckedBlock();

                if (printerStatus.Offline)
                {
                    string message = "Printer is Offline.";

                    if (printerStatus.ReceiptPaperEmpty)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (printerStatus.CoverOpen)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.ErrorWritePort;

                uint commandsLength = (uint)commands.Length;

                uint writtenLength = port.WritePort(commands, 0, commandsLength);

                if (writtenLength != commandsLength)
                {
                    throw new PortException("WritePort failed.");
                }

                result = Result.ErrorEndCheckedBlock;

                printerStatus = port.EndCheckedBlock();

                if (printerStatus.Offline == true)
                {
                    string message = "Printer is Offline.";

                    if (printerStatus.ReceiptPaperEmpty == true)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (printerStatus.CoverOpen == true)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Sending commands to printer without check condition (already open port).
        /// </summary>
        public static CommunicationResult SendCommandsDoNotCheckCondition(byte[] commands, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                StarPrinterStatus printerStatus;

                result = Result.ErrorWritePort;

                printerStatus = port.GetParsedStatus();

                uint commandsLength = (uint)commands.Length;

                uint writtenLength = port.WritePort(commands, 0, commandsLength);

                if (writtenLength != commandsLength)
                {
                    throw new PortException("WritePort failed.");
                }

                result = Result.ErrorWritePort;

                printerStatus = port.GetParsedStatus();

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Sending commands to printer using redirection.
        /// </summary>
        public static CommunicationResult[] SendCommandsForRedirection(byte[] commands, string[] portNameArray, string[] portSettingsArray, int[] timeoutMillisArray)
        {
            List<CommunicationResult> resultList = new List<CommunicationResult>();

            // Loop sending commands process until it is succeeded.
            for (int i = 0; i < portNameArray.Length; i++)
            {
                Result result = Result.ErrorUnknown;
                int code = StarResultCode.ErrorFailed;

                IPort port = null;

                // Set target printer settings.
                string portName = portNameArray[i];
                string portSettings = portSettingsArray[i];
                int timeoutMillis = timeoutMillisArray[i];

                try
                {
                    result = Result.ErrorOpenPort;

                    port = Factory.I.GetPort(portName, portSettings, timeoutMillis);

                    result = Result.ErrorBeginCheckedBlock;

                    StarPrinterStatus status = port.BeginCheckedBlock();

                    if (status.Offline)
                    {
                        string message = "Printer is Offline.";

                        if (status.ReceiptPaperEmpty)
                        {
                            message += "\nPaper is Empty.";
                        }

                        if (status.CoverOpen)
                        {
                            message += "\nCover is Open.";
                        }

                        throw new PortException(message);
                    }

                    result = Result.ErrorWritePort;

                    uint commandsLength = (uint)commands.Length;

                    uint writtenLength = port.WritePort(commands, 0, commandsLength);

                    if (writtenLength != commandsLength)
                    {
                        throw new PortException("WritePort failed.");
                    }

                    result = Result.ErrorEndCheckedBlock;

                    status = port.EndCheckedBlock();

                    if (status.Offline == true)
                    {
                        string message = "Printer is Offline.";

                        if (status.ReceiptPaperEmpty == true)
                        {
                            message += "\nPaper is Empty.";
                        }

                        if (status.CoverOpen == true)
                        {
                            message += "\nCover is Open.";
                        }

                        throw new PortException(message);
                    }

                    result = Result.Success;
                    code = StarResultCode.Succeeded;
                }
                catch (PortException ex)
                {
                    code = ex.ErrorCode;
                }
                finally
                {
                    if (port != null)
                    {
                        Factory.I.ReleasePort(port);
                    }
                }

                resultList.Add(new CommunicationResult()
                {
                    Result = result,
                    Code = code
                });

                // Finish process if it is succeeded.
                if (result == Result.Success)
                {
                    break;
                }
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Sample : Sending commands to printer with Auto Interface Select.
        /// </summary>
        public static CommunicationResult SendCommandsWithAutoInterfaceSelect(byte[] commands, string portSettings, int timeout, out string portName)
        {
            Result result = Result.ErrorUnknown;
            int code = StarResultCode.ErrorFailed;
            portName = null;

            IPort port = null;

            try
            {
                result = Result.ErrorOpenPort;

                // Specifying AutoSwitch: for portName allows you to automatically select the interface for connecting to the printer.
                port = Factory.I.GetPort("AutoSwitch:", portSettings, timeout);

                portName = port.PortName;

                StarPrinterStatus status;

                result = Result.ErrorBeginCheckedBlock;

                status = port.BeginCheckedBlock();

                if (status.Offline)
                {
                    string message = "Printer is Offline.";

                    if (status.ReceiptPaperEmpty)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (status.CoverOpen)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.ErrorWritePort;

                uint commandsLength = (uint)commands.Length;

                uint writtenLength = port.WritePort(commands, 0, commandsLength);

                if (writtenLength != commandsLength)
                {
                    throw new PortException("WritePort failed.");
                }

                result = Result.ErrorEndCheckedBlock;

                status = port.EndCheckedBlock();

                if (status.Offline == true)
                {
                    string message = "Printer is Offline.";

                    if (status.ReceiptPaperEmpty == true)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (status.CoverOpen == true)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Retrieving printer status.
        /// </summary>
        public static CommunicationResult RetrieveStatus(ref StarPrinterStatus printerStatus, string portName, string portSettings, int timeout)
        {
            Result result = Result.ErrorUnknown;
            int code = StarResultCode.ErrorFailed;

            IPort port = null;

            try
            {
                result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = Result.ErrorReadPort;

                printerStatus = port.GetParsedStatus();

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Getting printer firmware information.
        /// </summary>
        public static CommunicationResult RequestFirmwareInformation(ref Dictionary<string, string> firmwareInformation, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                result = Result.ErrorReadPort;

                firmwareInformation = port.GetFirmwareInformation();

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Parse printer response.
        /// </summary>
        public static CommunicationResult ParseDoNotCheckCondition(IPeripheralCommandParser parser, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                result = Result.ErrorWritePort;

                StarPrinterStatus printerStatus = port.GetParsedStatus();

                byte[] commands = parser.SendCommands;

                port.WritePort(commands, 0, (uint)commands.Length);

                result = Result.ErrorReadPort;

                byte[] readBuffer = new byte[1024];
                List<byte> allReceiveData = new List<byte>();

                uint startDate = (uint)Environment.TickCount;

                while (true)
                {
                    if ((UInt32)Environment.TickCount - startDate >= 1000) // Timeout
                    {
                        throw new PortException("ReadPort timeout.");
                    }

                    Thread.Sleep(10);

                    uint receiveSize = port.ReadPort(ref readBuffer, 0, (uint)readBuffer.Length);

                    if (receiveSize == 0)
                    {
                        continue;
                    }

                    byte[] receiveData = new byte[receiveSize];
                    Array.Copy(readBuffer, 0, receiveData, 0, receiveSize);

                    allReceiveData.AddRange(receiveData);

                    if (parser.Parse(allReceiveData.ToArray(), allReceiveData.Count) == ParseResult.Success)
                    {
                        result = Result.Success;
                        code = StarResultCode.Succeeded;

                        break;
                    }
                }

            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Getting printer information.
        /// </summary>
        public static CommunicationResult GetPrinterInformation(ref string receiveInfomation, string tag, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                result = Result.ErrorWritePort;

                StarPrinterStatus printerStatus = port.GetParsedStatus();

                byte[] getInformationCommands = new byte[] { 0x1b, 0x1d, 0x29, 0x49, 0x01, 0x00, 49 }; // ESC GS ) I pL pH fn (Transmit printer information command)

                port.WritePort(getInformationCommands, 0, (uint)getInformationCommands.Length);

                result = Result.ErrorReadPort;
                string information = "";
                byte[] readBuffer = new byte[1024];
                List<byte> allReceiveData = new List<byte>();

                uint startDate = (uint)Environment.TickCount;

                while (true)
                {
                    if ((UInt32)Environment.TickCount - startDate >= 3000) // Timeout
                    {
                        throw new PortException("ReadPort timeout.");
                    }

                    uint receiveSize = port.ReadPort(ref readBuffer, 0, (uint)readBuffer.Length);

                    if (receiveSize == 0)
                    {
                        continue;
                    }

                    byte[] receiveData = new byte[receiveSize];
                    Array.Copy(readBuffer, 0, receiveData, 0, receiveSize);

                    allReceiveData.AddRange(receiveData);

                    bool receiveResponse = false;

                    int totalReceiveSize = allReceiveData.Count;

                    if (totalReceiveSize >= 2)
                    {
                        for (int i = 0; i < totalReceiveSize; i++)
                        {
                            if (allReceiveData[i] == 0x0a && // Check the footer of the command.
                               allReceiveData[i + 1] == 0x00)
                            {
                                for (int j = 0; j < totalReceiveSize - 9; j++)
                                {
                                    if (allReceiveData[j] == 0x1b &&
                                        allReceiveData[j + 1] == 0x1d &&
                                        allReceiveData[j + 2] == 0x29 &&
                                        allReceiveData[j + 3] == 0x49 &&
                                        allReceiveData[j + 4] == 0x01 &&
                                        allReceiveData[j + 5] == 0x00 &&
                                        allReceiveData[j + 6] == 49)
                                    {
                                        string responseStr = Encoding.ASCII.GetString(allReceiveData.ToArray());

                                        int infoStartIndex = j + 7;                     // information start index.
                                        int infoEndIndex = totalReceiveSize - 2; // information end index.
                                        information = responseStr.Substring(infoStartIndex, infoEndIndex - infoStartIndex); // Extract information from priinter response.

                                        receiveResponse = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (receiveResponse)
                    {
                        break;
                    }
                }

                int infomationStartIndex = information.IndexOf(tag); // Check tag.

                if (infomationStartIndex == -1)
                {
                    throw new PortException("Parse printer information failed.");
                }

                infomationStartIndex += tag.Length;

                string temp = information.Substring(infomationStartIndex);

                int informationEndIndex = temp.IndexOf(","); // Check comma.

                if (informationEndIndex == -1) // Not find comma.
                {
                    informationEndIndex = temp.Length; // End of information.
                }

                receiveInfomation = temp.Substring(0, informationEndIndex); // Parse serial number information.

                int nullIndex = receiveInfomation.IndexOf("\0"); // Check null(for clone serial number).

                if (nullIndex != -1) // Find null.
                {
                    receiveInfomation = receiveInfomation.Substring(0, nullIndex);
                }

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Getting printer serial number.
        /// </summary>
        public static CommunicationResult GetProductSerialNumber(ref string serialNumber, IPort port)
        {
            return GetPrinterInformation(ref serialNumber, "PrSrN=", port); // Find "PrSrN=" tag from printer information.
        }

        /// <summary>
        /// Sample : Setting USB serial number.
        /// </summary>
        public static CommunicationResult SetUSBSerialNumber(byte[] serialNumber, bool isEnabled, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                result = Result.ErrorWritePort;

                StarPrinterStatus printerStatus = port.GetParsedStatus();

                if (printerStatus.Offline)
                {
                    string message = "Printer is Offline.";

                    if (printerStatus.ReceiptPaperEmpty)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (printerStatus.CoverOpen)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                if (serialNumber.Length != 0)
                {
                    // Send setting USB serial number command.
                    List<byte> setUSBSerialNumberCommandList = new List<byte>();

                    setUSBSerialNumberCommandList.AddRange(new byte[] { 0x1b, 0x23, 0x23, 0x57 });

                    int fillCounts = 0;

                    if (serialNumber.Length <= 8)
                    {
                        setUSBSerialNumberCommandList.Add(0x38);
                        fillCounts = 8 - serialNumber.Length;
                    }
                    else if (serialNumber.Length <= 16)
                    {
                        setUSBSerialNumberCommandList.Add(0x10);
                        fillCounts = 16 - serialNumber.Length;
                    }

                    setUSBSerialNumberCommandList.Add(0x2c);

                    for (int i = 0; i < fillCounts; i++) // Fill in the top at '0' to be a total 8 or 16 digit.
                    {
                        setUSBSerialNumberCommandList.Add(0x30);
                    }

                    setUSBSerialNumberCommandList.AddRange(serialNumber);
                    setUSBSerialNumberCommandList.AddRange(new byte[] { 0x0a, 0x00 });

                    byte[] setUSBSerialNumberCommand = setUSBSerialNumberCommandList.ToArray();

                    port.WritePort(setUSBSerialNumberCommand, 0, (uint)setUSBSerialNumberCommand.Length);

                    Thread.Sleep(5000); // Wait for 5 seconds until printer recover from software reset.
                }

                // Send setting USB serial number is enabled command.
                byte[] setUSBSerialNumberIsEnabledCommand;
                if (isEnabled)
                {
                    setUSBSerialNumberIsEnabledCommand = new byte[] { 0x1b, 0x1d, 0x23, 0x2b, 0x43, 0x30, 0x30, 0x30, 0x32, 0x0a, 0x00,
                                                                      0x1b, 0x1d, 0x23, 0x57, 0x30, 0x30, 0x30, 0x30, 0x30, 0x0a, 0x00 }; // Enable
                }
                else
                {
                    setUSBSerialNumberIsEnabledCommand = new byte[] { 0x1b, 0x1d, 0x23, 0x2d, 0x43, 0x30, 0x30, 0x30, 0x32, 0x0a, 0x00,
                                                                      0x1b, 0x1d, 0x23, 0x57, 0x30, 0x30, 0x30, 0x30, 0x30, 0x0a, 0x00 }; // Disable
                }

                port.WritePort(setUSBSerialNumberIsEnabledCommand, 0, (uint)setUSBSerialNumberIsEnabledCommand.Length);

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        /// <summary>
        /// Sample : Initializing USB serial number.
        /// </summary>
        public static CommunicationResult InitializeUSBSerialNumber(bool isEnabled, IPort port)
        {
            Result result = Result.ErrorUnknown;
            int code;

            try
            {
                result = Result.ErrorOpenPort;

                if (port == null)
                {
                    throw new PortException("port is null.");
                }

                result = Result.ErrorWritePort;

                StarPrinterStatus printerStatus = port.GetParsedStatus();

                if (printerStatus.Offline)
                {
                    string message = "Printer is Offline.";

                    if (printerStatus.ReceiptPaperEmpty)
                    {
                        message += "\nPaper is Empty.";
                    }

                    if (printerStatus.CoverOpen)
                    {
                        message += "\nCover is Open.";
                    }

                    throw new PortException(message);
                }

                List<byte> settingCommandList = new List<byte>();

                // Send initialize USB serial number command.
                byte[] initializeUSBSerialNumberCommand = new byte[] { 0x1b, 0x23, 0x23, 0x57, 0x38, 0x2c, (byte)'?', (byte)'?', (byte)'?', (byte)'?', (byte)'?', (byte)'?', (byte)'?', (byte)'?', 0x0a, 0x00 };

                port.WritePort(initializeUSBSerialNumberCommand, 0, (uint)initializeUSBSerialNumberCommand.Length);

                Thread.Sleep(5000); // Wait for 5 seconds until printer recover from software reset.

                // Send setting USB serial number is enabled command.
                byte[] setUSBSerialNumberIsEnabledCommand;
                if (isEnabled)
                {
                    setUSBSerialNumberIsEnabledCommand = new byte[] { 0x1b, 0x1d, 0x23, 0x2b, 0x43, 0x30, 0x30, 0x30, 0x32, 0x0a, 0x00,
                                                                      0x1b, 0x1d, 0x23, 0x57, 0x30, 0x30, 0x30, 0x30, 0x30, 0x0a, 0x00 }; // Enable
                }
                else
                {
                    setUSBSerialNumberIsEnabledCommand = new byte[] { 0x1b, 0x1d, 0x23, 0x2d, 0x43, 0x30, 0x30, 0x30, 0x32, 0x0a, 0x00,
                                                                      0x1b, 0x1d, 0x23, 0x57, 0x30, 0x30, 0x30, 0x30, 0x30, 0x0a, 0x00 }; // Disable
                }

                port.WritePort(setUSBSerialNumberIsEnabledCommand, 0, (uint)setUSBSerialNumberIsEnabledCommand.Length);

                result = Result.Success;
                code = StarResultCode.Succeeded;
            }
            catch (PortException ex)
            {
                code = ex.ErrorCode;
            }

            return new CommunicationResult()
            {
                Result = result,
                Code = code
            };
        }

        public static CommunicationResult RequestFirmwareInformation(ref Dictionary<string, string> firmwareInformation, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = RequestFirmwareInformation(ref firmwareInformation, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static CommunicationResult ParseDoNotCheckCondition(IPeripheralCommandParser parser, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = ParseDoNotCheckCondition(parser, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static CommunicationResult GetProductSerialNumber(ref string serialNumber, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = GetProductSerialNumber(ref serialNumber, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static CommunicationResult SetUSBSerialNumber(byte[] serialNumber, bool isEnabled, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = SetUSBSerialNumber(serialNumber, isEnabled, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static CommunicationResult InitializeUSBSerialNumber(bool isEnabled, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = InitializeUSBSerialNumber(isEnabled, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static void SendCommandsWithProgressBarInternal(byte[] commands, IPort port, bool checkCondition, bool showResult)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                if (checkCondition)
                {
                    result = SendCommands(commands, port);
                }
                else
                {
                    result = SendCommandsDoNotCheckCondition(commands, port);
                }

            });

            progressBarWindow.ShowDialog();

            if (!showResult &&
                 result.Result == Result.Success)
            {
                return;
            }

            ShowCommunicationResultMessage(result);
        }

        public static void SendCommandsWithProgressBarInternal(byte[] commands, string portName, string portSettings, int timeout, bool checkCondition, bool showResult)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                if (checkCondition)
                {
                    result = SendCommands(commands, portName, portSettings, timeout);
                }
                else
                {
                    result = SendCommandsDoNotCheckCondition(commands, portName, portSettings, timeout);
                }

            });

            progressBarWindow.ShowDialog();

            if (!showResult &&
                 result.Result == Result.Success)
            {
                return;
            }

            ShowCommunicationResultMessage(result);
        }

        public static void SendCommandsForRedirectionWithProgressBar(byte[] commands, string[] portNameArray, string[] portSettingsArray, int[] timeoutMillisArray)
        {
            CommunicationResult[] results = (CommunicationResult[])Enumerable.Empty<CommunicationResult>(); ;

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                results = SendCommandsForRedirection(commands, portNameArray, portSettingsArray, timeoutMillisArray);

            });

            progressBarWindow.ShowDialog();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < results.Length; i++)
            {
                if (i == 0)
                {
                    builder.Append("[Destination]");
                }
                else
                {
                    builder.Append("[Backup]");
                }

                builder.Append(Environment.NewLine);
                builder.Append("Port Name : ");
                builder.Append(portNameArray[i]);
                builder.Append(" ->");
                builder.Append(Environment.NewLine);
                builder.Append(GetCommunicationResultMessage(results[i]));

                if (i != results.Length - 1)
                {
                    builder.Append(Environment.NewLine);
                    builder.Append(Environment.NewLine);
                }
            }

            MessageBox.Show(builder.ToString(), "Communication Result");
        }


        public static CommunicationResult ParseDoNotCheckConditionWithProgressBar(IPeripheralCommandParser parser, IPort port)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {

                result = ParseDoNotCheckCondition(parser, port);

            });

            progressBarWindow.ShowDialog();

            return result;
        }

        public static CommunicationResult ParseDoNotCheckConditionWithProgressBar(IPeripheralCommandParser parser, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            IPort port = null;

            try
            {
                result.Result = Result.ErrorOpenPort;

                port = Factory.I.GetPort(portName, portSettings, timeout);

                result = ParseDoNotCheckConditionWithProgressBar(parser, port);
            }
            catch (PortException ex)
            {
                result.Code = ex.ErrorCode;
            }
            finally
            {
                if (port != null)
                {
                    Factory.I.ReleasePort(port);
                }
            }

            return result;
        }

        public static CommunicationResult GetProductSerialNumberWithProgressBar(ref string serialNumber, IPort port)
        {
            CommunicationResult result = new CommunicationResult();

            string temp = "";

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = GetProductSerialNumber(ref temp, port);

            });

            progressBarWindow.ShowDialog();

            serialNumber = temp;

            return result;
        }

        public static CommunicationResult GetProductSerialNumberWithProgressBar(ref string serialNumber, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            string temp = "";

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = GetProductSerialNumber(ref temp, portName, portSettings, timeout);

            });

            progressBarWindow.ShowDialog();

            serialNumber = temp;

            return result;
        }

        public static CommunicationResult SetUSBSerialNumberWithProgressBar(byte[] serialNumber, bool isEnabled, IPort port)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = SetUSBSerialNumber(serialNumber, isEnabled, port);

            });

            progressBarWindow.ShowDialog();

            return result;
        }

        public static CommunicationResult SetUSBSerialNumberWithProgressBar(byte[] serialNumber, bool isEnabled, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = SetUSBSerialNumber(serialNumber, isEnabled, portName, portSettings, timeout);
            });

            progressBarWindow.ShowDialog();

            return result;
        }

        public static CommunicationResult InitializeUSBSerialNumberWithProgressBar(bool isEnabled, IPort port)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = InitializeUSBSerialNumber(isEnabled, port);

            });

            progressBarWindow.ShowDialog();

            return result;
        }

        public static CommunicationResult InitializeUSBSerialNumberWithProgressBar(bool isEnabled, string portName, string portSettings, int timeout)
        {
            CommunicationResult result = new CommunicationResult();

            ProgressBarWindow progressBarWindow = new ProgressBarWindow("Communicating...", () =>
            {
                result = InitializeUSBSerialNumber(isEnabled, portName, portSettings, timeout);
            });

            progressBarWindow.ShowDialog();

            return result;
        }

        public static void SendCommandsWithProgressBar(byte[] commands, string portName, string portSettings, int timeout)
        {
            SendCommandsWithProgressBarInternal(commands, portName, portSettings, timeout, true, true);
        }

        public static void SendCommandsDoNotCheckConditionWithProgressBar(byte[] commands, string portName, string portSettings, int timeout)
        {
            SendCommandsWithProgressBarInternal(commands, portName, portSettings, timeout, false, true);
        }

        public static void SendCommandsWithProgressBar(byte[] commands, IPort port)
        {
            SendCommandsWithProgressBarInternal(commands, port, true, true);
        }

        public static void SendCommandsWithProgressBar(byte[] commands, IPort port, bool showResult)
        {
            SendCommandsWithProgressBarInternal(commands, port, true, showResult);
        }

        public static void SendCommandsDoNotCheckConditionWithProgressBar(byte[] commands, IPort port)
        {
            SendCommandsWithProgressBarInternal(commands, port, false, true);
        }

        public static void SendCommandsDoNotCheckConditionWithProgressBar(byte[] commands, IPort port, bool showResult)
        {
            SendCommandsWithProgressBarInternal(commands, port, false, showResult);
        }

        public static void ShowCommunicationResultMessage(CommunicationResult result)
        {
            string resultMessage = GetCommunicationResultMessage(result);

            MessageBox.Show(resultMessage, "Communication Result");
        }

        public static void ShowPeripheralStatusResultMessage(string peripheralName, PeripheralStatus status)
        {
            string resultMessage = GetPeripheralStatusResultMessage(status);

            MessageBox.Show(peripheralName + " " + resultMessage, "Check Status");
        }

        public static string GetCommunicationResultMessage(CommunicationResult result)
        {
            StringBuilder builder = new StringBuilder();

            switch (result.Result)
            {
                case Result.Success:
                    builder.Append("Success!");
                    break;
                case Result.ErrorOpenPort:
                    builder.Append("Fail to openPort");
                    break;
                case Result.ErrorBeginCheckedBlock:
                    builder.Append("Printer is offline (BeginCheckedBlock)");
                    break;
                case Result.ErrorEndCheckedBlock:
                    builder.Append("Printer is offline (EndCheckedBlock)");
                    break;
                case Result.ErrorReadPort:
                    builder.Append("Read port error (ReadPort)");
                    break;
                case Result.ErrorWritePort:
                    builder.Append("Write port error (WritePort)");
                    break;
                default:
                case Result.ErrorUnknown:
                    builder.Append("Unknown error");
                    break;
            }

            if(result.Result != Result.Success)
            {
                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);
                builder.Append("Error code: ");
                builder.Append(result.Code.ToString());

                if(result.Code == StarResultCode.ErrorFailed)
                {
                    builder.Append(" (Failed)");
                }
                else if(result.Code == StarResultCode.ErrorInUse)
                {
                    builder.Append(" (In use)");
                }
                else if (result.Code == StarResultCode.ErrorPaperPresent)
                {
                    builder.Append(" (Paper present)");
                }
            }

            return builder.ToString();
        }

        public static string GetPeripheralStatusResultMessage(PeripheralStatus status)
        {
            string message;

            switch (status)
            {
                default:
                case PeripheralStatus.Impossible:
                    message = "Impossible";
                    break;

                case PeripheralStatus.Connect:
                    message = "Connect";
                    break;

                case PeripheralStatus.Disconnect:
                    message = "Disconnect";
                    break;

            }

            return message;
        }
    }
}
