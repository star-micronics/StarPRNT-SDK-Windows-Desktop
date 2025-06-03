using Microsoft.Win32;
using StarMicronics.StarIOExtension;
using System.Collections.Generic;
using System.Linq;

namespace StarPRNTSDK
{
    internal static class ModelFinder
    {
        public static PrinterModel FindPrinterModel(string modelName)
        {
            if (modelName.Equals(""))
            {
                return PrinterModel.Unknown;
            }

            return GetPrinterModelWithSomothingName(modelName);
        }

        public static PrinterInfo GetPrinterInfo(PrinterModel model)
        {
            return ModelDictionary.ModelInformationDictionary[model];
        }

        public static string[] GetModelName(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.ModelName;
        }

        public static PrinterModel GetPrinterModelWithSomothingName(string somethingName)
        {
            PrinterModel model = PrinterModel.Unknown;

            model = GetPrinterModelWithModelName(somethingName);

            if (model != PrinterModel.Unknown)
            {
                return model;
            }

            model = GetPrinterModelWithDeviceID(somethingName);

            if (model != PrinterModel.Unknown)
            {
                return model;
            }

            model = GetPrinterModelWithBTDeviceNamePrefix(somethingName);

            return model;
        }

        public static PrinterModel GetPrinterModelWithModelName(string modelName)
        {
            foreach (KeyValuePair<PrinterModel, PrinterInfo> pair in ModelDictionary.ModelInformationDictionary)
            {
                PrinterModel model = pair.Key;
                PrinterInfo info = pair.Value;

                List<string> refModelNameList = new List<string>(info.ModelName);

                if (refModelNameList.Contains(modelName))
                {
                    return model;
                }
            }

            return PrinterModel.Unknown;
        }

        public static PrinterModel GetPrinterModelWithDeviceID(string deviceID)
        {
            foreach (KeyValuePair<PrinterModel, PrinterInfo> pair in ModelDictionary.ModelInformationDictionary)
            {
                PrinterModel model = pair.Key;
                PrinterInfo info = pair.Value;

                string[] refDeviceID = info.DeviceID;

                if (ContainsStringUpper(refDeviceID, deviceID))
                {
                    return model;
                }
            }

            return PrinterModel.Unknown;
        }

        public static PrinterModel GetPrinterModelWithBTDeviceNamePrefix(string btDeviceNamePrefix)
        {
            foreach (KeyValuePair<PrinterModel, PrinterInfo> pair in ModelDictionary.ModelInformationDictionary)
            {
                PrinterModel model = pair.Key;
                PrinterInfo info = pair.Value;

                string[] refBTDeviceNamePrefix = info.BTDeviceNamePrefix;

                if (StartsWithUpper(btDeviceNamePrefix, refBTDeviceNamePrefix))
                {
                    return model;
                }
            }

            return PrinterModel.Unknown;
        }

        public static Emulation GetEmulation(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.Emulation;
        }

        public static PaperSize GetDefaultPaperSize(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return new PaperSize(printerInfo.DefaultPaperSize);
        }

        public static string[] GetDeviceID(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.DeviceID;
        }

        public static string[] GetBTDeviceNamePrefix(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.BTDeviceNamePrefix;
        }

        public static string GetDefaultPortSettings(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.DefaultPortSettings;
        }

        public static bool GetChangeCashDrawerPolarityIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.ChangeCashDrawerPolarityIsEnabled;
        }

        public static string GetSimpleModelName(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.SimpleModelName;
        }

        public static bool GetTextReceiptIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.TextReceiptIsEnabled;
        }

        public static bool GetUTF8IsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.UTF8IsEnabled;
        }

        public static bool GetRasterReceiptIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.RasterReceiptIsEnabled;
        }

        public static bool GetCJKIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.CJKIsEnabled;
        }

        public static bool GetBlackMarkIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.BlackMarkIsEnabled;
        }

        public static bool GetBlackMarkDetectionIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.BlackMarkDetectionIsEnabled;
        }

        public static bool GetPageModeIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.PageModeIsEnabled;
        }

        public static bool GetPaperPresentStatusIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.PaperPresentStatusIsEnabled;
        }

        public static bool GetAutoSwitchInterfaceIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.AutoSwitchInterfaceIsEnabled;
        }

        public static bool GetCashDrawerIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.CashDrawerIsEnabled;
        }

        public static bool GetBarcodeReaderIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.BarcodeReaderIsEnabled;
        }

        public static bool GetCustomerDisplayIsEnabled(PrinterModel model, string portName)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            bool isEnabled = printerInfo.CustomerDisplayIsEnabled;

            if (model == PrinterModel.TSP100)
            {
                isEnabled = IsTSP100IIIU(portName); // Not support TSP100LAN, TSP100U, TSP100GT, TSP100IIU, TSP100IIIW, TSP100IIILAN, TSP100IIIBI.
            }

            return isEnabled;
        }

        public static bool GetMelodySpeakerIsEnabled(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.MelodySpeakerIsEnabled;
        }

        public static int GetSoundNumberDefault(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.SoundNumberDefault;
        }

        public static int GetSoundVolumeDefault(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.SoundVolumeDefault;
        }

        public static int GetSoundVolumeMax(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.SoundVolumeMax;
        }

        public static int GetSoundVolumeMin(PrinterModel model)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            return printerInfo.SoundVolumeMin;
        }

        public static bool GetProductSerialNumberIsEnabled(PrinterModel model, string portName, string deviceID)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            bool isEnabled = printerInfo.ProductSerialNumberIsEnabled;

            if (model == PrinterModel.TSP100)
            {
                if (IsTCPPort(portName) && deviceID.Equals(GetSimpleModelName(PrinterModel.TSP100))) // Setting manually.
                {
                    isEnabled = true;
                }
                else
                {
                    isEnabled = IsTSP100III(portName, deviceID); // Not support TSP100LAN, TSP100U, TSP100GT, TSP100IIU.
                }
            }

            return isEnabled;
        }

        public static int GetSettableUSBSerialNumberLength(PrinterModel model, string portName)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            int length = printerInfo.SettableUSBSerialNumberLength;

            if (model == PrinterModel.TSP100)
            {
                if (!IsUSBPrinterClassPort(portName) &&
                   !IsUSBVendorClassPort(portName)) // Not USB interface
                {
                    length = 0;
                }
                else if (IsTSP100IIIU(portName))
                {
                    length = 16; // TSP100IIIU supported 16digits USB-ID.
                }
                else
                {
                    length = 8; // TSP100U, TSP100GT, TSP100IIU
                }
            }

            if (model == PrinterModel.BSC10)
            {
                if (IsTCPPort(portName)) // BSC10 LAN model
                {
                    length = 0;
                }
            }

            return length;
        }

        public static bool GetSetUSBSerialNumberIsEnabled(PrinterModel model, string portName)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            bool isEnabled = GetSettableUSBSerialNumberLength(model, portName) != 0;

            return isEnabled;
        }

        public static bool GetUSBSerialNumberIsEnabledDefault(PrinterModel model, string portName)
        {
            PrinterInfo printerInfo = GetPrinterInfo(model);

            bool isEnabledDefault = printerInfo.USBSerialNumberIsEnabledDefault;

            if (model == PrinterModel.TSP100)
            {
                isEnabledDefault = IsTSP100IIIU(portName); // TSP100LAN, TSP100U, TSP100GT, TSP100IIU, TSP100IIIW, TSP100IIILAN and TSP100IIIBI USB serial number is enabled default is off.
            }

            return isEnabledDefault;
        }

        private static bool IsTSP100III(string portName, string deviceID)
        {
            if (IsTSP100IIIW(deviceID) ||
                IsTSP100IIILAN(deviceID) ||
                IsTSP100IIIBI(portName) ||
                IsTSP100IIIU(portName)) // TSP100IIIW, TSP100IIILAN, TSP100IIIBI or TSP100IIIU
            {
                return true;
            }

            return false;
        }

        private static bool IsTSP100IIIW(string deviceID)
        {
            if (deviceID.Equals("TSP143IIIW (STR_T-001)"))
            {
                return true;
            }

            return false;
        }

        private static bool IsTSP100IIILAN(string deviceID)
        {
            if (deviceID.Equals("TSP143IIILAN (STR_T-001)"))
            {
                return true;
            }

            return false;
        }

        private static bool IsTSP100IIIBI(string portName)
        {
            if (IsBluetoothPort(portName))
            {
                return true;
            }

            return false;
        }

        private static bool IsTSP100IIIU(string portName)
        {
            if (!IsUSBPrinterClassPort(portName))
            {
                return false;
            }

            bool isTSP100IIIU = false;

            string printerQueueName = portName.Substring("USBPRN:".Length);

            string[] hardwareID = GetHardwareID(printerQueueName);

            if (hardwareID == null)
            {
                return false;
            }

            string hardwareIDRevRegion = hardwareID[0];

            string revDescription = "REV_";

            int revIndex = IndexOfUpper(hardwareIDRevRegion, revDescription);

            if (revIndex == -1)
            {
                return false;
            }

            string revNumber = hardwareIDRevRegion.Substring(revIndex + revDescription.Length, 4);

            if (CompareStringUpper(revNumber, "0300"))
            {
                isTSP100IIIU = true;
            }

            return isTSP100IIIU;
        }

        public static bool IsBluetoothPort(string portName)
        {
            return IsTargetPort(portName, "BT:");
        }

        public static bool IsTCPPort(string portName)
        {
            return IsTargetPort(portName, "TCP:");
        }

        public static bool IsUSBPrinterClassPort(string portName)
        {
            return IsTargetPort(portName, "USBPRN:");
        }

        public static bool IsUSBVendorClassPort(string portName)
        {
            return IsTargetPort(portName, "USBVEN:");
        }

        public static bool IsSerialPort(string portName)
        {
            return IsTargetPort(portName, "COM");
        }

        public static bool IsParallelPort(string portName)
        {
            return IsTargetPort(portName, "LPT");
        }

        private static bool IsTargetPort(string portName, string targetPortNamePrefix)
        {
            return portName.ToUpper().StartsWith(targetPortNamePrefix);
        }

        public static string[] GetHardwareID(string printerQueueName)
        {
            string[] hardwareID = null;

            string parentIDPrefix = GetParentIDPrefix(printerQueueName);

            if (parentIDPrefix == null)
            {
                return null;
            }

            object hardwareIDValue = GetRegistryKeyValueWithTargetUSBDevice(parentIDPrefix, "HardwareID");

            if (hardwareIDValue != null)
            {
                hardwareID = (string[])hardwareIDValue;
            }

            return hardwareID;
        }

        public static string GetParentIDPrefix(string printerQueueName)
        {
            string deviceInstanceID = GetDeviceInstanceID(printerQueueName);

            if (deviceInstanceID == null)
            {
                return null;
            }

            string parentIDPrefix = ExtractParentIDPrefix(deviceInstanceID);

            if (parentIDPrefix == null)
            {
                return null;
            }

            return parentIDPrefix;
        }

        public static string GetDeviceInstanceID(string printerQueueName)
        {
            string deviceInstanceID = null;

            string pnpDataKeyPath = @"SYSTEM\CurrentControlSet\Control\Print\Printers\" + printerQueueName + @"\PnPData";

            object registryKeyValue = GetRegistryKeyValue(Registry.LocalMachine, pnpDataKeyPath, "DeviceInstanceId");

            if (registryKeyValue != null)
            {
                deviceInstanceID = (string)registryKeyValue;
            }

            return deviceInstanceID;
        }

        public static string ExtractParentIDPrefix(string deviceInstanceID)
        {
            string parentIDPrefix = null;

            int lastIndexOfDelimiter = deviceInstanceID.LastIndexOf("\\");

            if (0 <= lastIndexOfDelimiter && lastIndexOfDelimiter + 1 <= deviceInstanceID.Length)
            {
                string tempStr = deviceInstanceID.Substring(deviceInstanceID.LastIndexOf("\\") + 1);

                lastIndexOfDelimiter = tempStr.LastIndexOf("&");

                if (0 <= lastIndexOfDelimiter)
                {
                    parentIDPrefix = tempStr.Substring(0, lastIndexOfDelimiter);
                }
            }

            return parentIDPrefix;
        }

        public static object GetRegistryKeyValueWithTargetUSBDevice(string parentIDPrefix, string targetRegistryKeyName)
        {
            object value = null;

            string usbDevicesPath = @"SYSTEM\CurrentControlSet\Enum\USB";

            string[] connectedUSBIDs = GetRegistrySubKeyNames(Registry.LocalMachine, usbDevicesPath);

            if (connectedUSBIDs.Length == 0)
            {
                return null;
            }

            foreach (string connectedUSBID in connectedUSBIDs)
            {
                string connectedUSBIDPath = usbDevicesPath + @"\" + connectedUSBID;

                string targetUSBDeviceKeyPath = GetUSBDeviceRegistryKeyPathWithParentIDPrefix(connectedUSBIDPath, parentIDPrefix);

                if (targetUSBDeviceKeyPath != null)
                {
                    value = GetRegistryKeyValue(Registry.LocalMachine, targetUSBDeviceKeyPath, targetRegistryKeyName);

                    break;
                }
            }

            return value;
        }


        public static string GetUSBDeviceRegistryKeyPathWithParentIDPrefix(string connectedUSBIDPath, string parentIDPrefix)
        {
            string targetPath = null;

            string[] connectedUSBDevices = GetRegistrySubKeyNames(Registry.LocalMachine, connectedUSBIDPath);

            foreach (string connectedUSBDevice in connectedUSBDevices)
            {
                string connectedUSBDeviceKeyPath = connectedUSBIDPath + @"\" + connectedUSBDevice;

                object registryKeyValue = GetRegistryKeyValue(Registry.LocalMachine, connectedUSBDeviceKeyPath, "ParentIdPrefix");

                if (registryKeyValue != null)
                {
                    string refParentIDPrefix = (string)registryKeyValue;

                    if (CompareStringUpper(refParentIDPrefix, parentIDPrefix))
                    {
                        targetPath = connectedUSBDeviceKeyPath;

                        break;
                    }
                }
            }

            return targetPath;
        }

        public static string[] GetRegistrySubKeyNames(RegistryKey rootKey, string registryPath)
        {
            string[] subKeyNames = (string[])Enumerable.Empty<string>();

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(registryPath);

            if (registryKey != null)
            {
                subKeyNames = registryKey.GetSubKeyNames();

                registryKey.Close();
            }

            return subKeyNames;
        }

        public static object GetRegistryKeyValue(RegistryKey rootKey, string targetKeyPath, string valueName)
        {
            object keyValue = null;

            RegistryKey registryKey = rootKey.OpenSubKey(targetKeyPath);

            if (registryKey != null)
            {
                keyValue = registryKey.GetValue(valueName);

                registryKey.Close();
            }

            return keyValue;
        }

        public static bool StartsWithUpper(string sourceStr, string[] findStrArray)
        {
            sourceStr = sourceStr.ToUpper();

            for (int i = 0; i < findStrArray.Length; i++)
            {
                findStrArray[i] = findStrArray[i].ToUpper();

                if (sourceStr.StartsWith(findStrArray[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsStringUpper(string[] sourceStrArray, string findStr)
        {
            for (int i = 0; i < sourceStrArray.Length; i++)
            {
                sourceStrArray[i] = sourceStrArray[i].ToUpper();
            }

            findStr = findStr.ToUpper();

            return sourceStrArray.Contains(findStr);
        }

        public static bool CompareStringUpper(string str1, string str2)
        {
            str1 = str1.ToUpper();
            str2 = str2.ToUpper();

            return str1.Equals(str2);
        }

        public static int IndexOfUpper(string sourceStr, string findStr)
        {
            sourceStr = sourceStr.ToUpper();
            findStr = findStr.ToUpper();

            return sourceStr.IndexOf(findStr);
        }
    }
}
