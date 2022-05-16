using StarMicronics.StarIO;
using StarMicronics.StarIOExtension;
using System;
using System.ComponentModel;
using System.Threading;

namespace StarPRNTSDK
{
    public enum StarIoExtManagerType
    {
        Standard,
        WithBarcodeReader,
        OnlyBarcodeReader
    }

    public enum PrinterStatus
    {
        Invalid,
        Impossible,
        Online,
        Offline
    }

    public enum PrinterPaperStatus
    {
        Invalid,
        Impossible,
        Ready,
        NearEmpty,
        Empty
    }

    public enum PrinterCoverStatus
    {
        Invalid,
        Impossible,
        Open,
        Close
    }

    public enum CashDrawerStatus
    {
        Invalid,
        Impossible,
        Open,
        Close
    }

    public enum BarcodeReaderStatus
    {
        Invalid,
        Impossible,
        Connect,
        Disconnect
    }

    public class PrinterConnectEventArgs : EventArgs
    {
        public Exception Error { get; set; }
    }

    public class BarcodeDataReceiveEventArgs : EventArgs
    {
        public byte[] Data { get; set; }
    }

    public class StatusUpdateEventArgs : EventArgs
    {
        public string Status { get; set; }
    }

    public class StarIoExtManager
    {
        public IPort Port { get; private set; }
        public object PortLock
        {
            get
            {
                return _PortLock;
            }
        }
        private object _PortLock = new object();

        public string PortName { get; private set; }
        public string PortSettings { get; private set; }
        public int Timeout { get; private set; }
        public StarIoExtManagerType Type { get; private set; }
        public bool CashDrawerOpenActiveHigh
        {
            get
            {
                return _CashDrawerOpenActiveHigh;
            }
            set
            {
                _CashDrawerOpenActiveHigh = value;
            }
        }
        private bool _CashDrawerOpenActiveHigh = true;

        public PrinterStatus PrinterStatus { get; private set; }
        public PrinterPaperStatus PrinterPaperStatus { get; private set; }
        public PrinterCoverStatus PrinterCoverStatus { get; private set; }
        public CashDrawerStatus CashDrawerStatus { get; private set; }
        public BarcodeReaderStatus BarcodeReaderStatus { get; private set; }

        public event EventHandler<PrinterConnectEventArgs> PrinterConnect;
        public event EventHandler PrinterDisconnect;
        public event EventHandler PrinterImpossible;
        public event EventHandler PrinterOnline;
        public event EventHandler PrinterOffline;
        public event EventHandler PrinterPaperReady;
        public event EventHandler PrinterPaperNearEmpty;
        public event EventHandler PrinterPaperEmpty;
        public event EventHandler PrinterCoverOpen;
        public event EventHandler PrinterCoverClose;
        public event EventHandler CashDrawerOpen;
        public event EventHandler CashDrawerClose;
        public event EventHandler BarcodeReaderImpossible;
        public event EventHandler BarcodeReaderConnect;
        public event EventHandler BarcodeReaderDisconnect;
        public event EventHandler<BarcodeDataReceiveEventArgs> BarcodeDataReceive;
        public event EventHandler<StatusUpdateEventArgs> StatusUpdate;

        private BackgroundWorker MonitorWorker { get; set; }
        private bool ShouldMonitorPrinter
        {
            get
            {
                return Type == StarIoExtManagerType.Standard || Type == StarIoExtManagerType.WithBarcodeReader;
            }
        }
        private bool ShouldMonitorBarcodeReader
        {
            get
            {
                return Type == StarIoExtManagerType.WithBarcodeReader || Type == StarIoExtManagerType.OnlyBarcodeReader;
            }
        }

        public StarIoExtManager(string portName, string portSettings, int timeout, StarIoExtManagerType type)
        {
            PortName = portName;
            PortSettings = portSettings;
            Timeout = timeout;
            Type = type;
        }

        public void ConnectAync()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                Connect();
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                if (PrinterConnect != null)
                {
                    PrinterConnect.Invoke(this, new PrinterConnectEventArgs() { Error = e.Error });
                }
            };
            worker.RunWorkerAsync();
        }

        public void DisconnectAsync()
        {
            if (MonitorWorker == null)
            {
                if (PrinterDisconnect != null)
                {
                    PrinterDisconnect.Invoke(this, null);
                }

                return;
            }

            if (MonitorWorker.CancellationPending)
            {
                return;
            }

            MonitorWorker.RunWorkerCompleted += (sender, e) =>
            {
                Factory.I.ReleasePort(Port);
                Port = null;

                if (PrinterDisconnect != null)
                {
                    PrinterDisconnect.Invoke(this, null);
                }

                MonitorWorker = null;
            };
            MonitorWorker.CancelAsync();
        }

        private void Connect()
        {
            lock (this)
            {
                if (MonitorWorker != null && MonitorWorker.IsBusy)
                {
                    throw new PortException("Already connected.");
                }

                Port = Factory.I.GetPort(PortName, PortSettings, Timeout);
                ClearBarcodeReaderBufferIfNeed(Port);

                PrinterStatus = PrinterStatus.Invalid;
                PrinterPaperStatus = PrinterPaperStatus.Invalid;
                PrinterCoverStatus = PrinterCoverStatus.Invalid;
                CashDrawerStatus = CashDrawerStatus.Invalid;
                BarcodeReaderStatus = BarcodeReaderStatus.Invalid;

                MonitorWorker = new BackgroundWorker();
                MonitorWorker.DoWork += (sender, e) =>
                {
                    MonitoringPrinter();
                };
                MonitorWorker.WorkerSupportsCancellation = true;
                MonitorWorker.RunWorkerAsync();
            }
        }

        private void MonitoringPrinter()
        {
            uint lastUpdatedTime = (uint)Environment.TickCount;

            while (!MonitorWorker.CancellationPending)
            {
                lock (PortLock)
                {
                    try
                    {
                        IPort port = Factory.I.GetPort(PortName, PortSettings, Timeout);

                        if (Port != port)
                        {
                            Factory.I.ReleasePort(Port);
                            Port = port;

                            ClearBarcodeReaderBufferIfNeed(port);
                        }

                        PrinterStatus printerStatus = PrinterStatus;
                        PrinterPaperStatus printerPaperStatus = PrinterPaperStatus;
                        PrinterCoverStatus printerCoverStatus = PrinterCoverStatus;
                        CashDrawerStatus cashDrawerStatus = CashDrawerStatus;

                        CheckPrinterStatusIfNeed(port); // Check printer status.

                        CheckBarcodeReaderStatusIfNeed(port); // Check barcode reader status.

                        ReadBarcodeReaderDataIfNeed(port);  // Read barcode reader data.

                        bool statusUpdate = (printerStatus != PrinterStatus) ||
                                            (printerPaperStatus != PrinterPaperStatus) ||
                                            (printerCoverStatus != PrinterCoverStatus) ||
                                            (cashDrawerStatus != CashDrawerStatus);

                        if ((UInt32)Environment.TickCount - lastUpdatedTime >= 300000)
                        {
                            statusUpdate = true;
                        }

                        // Status is changed.
                        if (statusUpdate)
                        {
                            OnStatusUpdate();

                            lastUpdatedTime = (uint)Environment.TickCount;
                        }
                    }
                    catch (Exception)
                    {
                        if (ShouldMonitorPrinter)
                        {
                            OnPrinterImpossible();
                        }

                        if (ShouldMonitorBarcodeReader)
                        {
                            OnBarcodeReaderImpossible();
                        }

                        Factory.I.ReleasePort(Port);
                        Port = null;
                    }
                }

                Thread.Sleep(100); // Interval
            }
        }

        private void CheckPrinterStatusIfNeed(IPort port)
        {
            if (!ShouldMonitorPrinter)
            {
                return;
            }

            CheckPrinterStatus(port);
        }

        private void CheckPrinterStatus(IPort port)
        {
            StarPrinterStatus status = port.GetParsedStatus();

            if (status.Offline)
            {
                // Printer offline
                OnPrinterOffline();
            }
            else
            {
                // Printer online
                OnPrinterOnline();
            }

            if (status.ReceiptPaperEmpty)
            {
                // Paper empty
                OnPrinterPaperEmpty();
            }
            else if (status.ReceiptPaperNearEmptyInner ||
                     status.ReceiptPaperNearEmptyOuter)
            {
                // Paper near empty
                OnPrinterPaperNearEmpty();
            }
            else
            {
                // Paper ready
                OnPrinterPaperReady();
            }

            if (status.CoverOpen)
            {
                // Cover open
                OnPrinterCoverOpen();
            }
            else
            {
                // Cover close
                OnPrinterCoverClose();
            }

            if (status.CompulsionSwitch == CashDrawerOpenActiveHigh)
            {
                // Cash drawer open
                OnCashDrawerOpen();
            }
            else
            {
                // Cash drawer close
                OnCashDrawerClose();
            }
        }

        private void CheckBarcodeReaderStatusIfNeed(IPort port)
        {
            if (!ShouldMonitorBarcodeReader)
            {
                return;
            }

            CheckBarcodeReaderStatus(port);
        }

        private void CheckBarcodeReaderStatus(IPort port)
        {
            IPeripheralConnectParser parser = StarIoExt.CreateBcrConnectParser(BcrModel.POP1);

            CommunicationResult result = Communication.ParseDoNotCheckCondition(parser, port);

            if (result.Result == Communication.Result.Success)
            {
                if (parser.IsConnected)
                {
                    // Barcode reader connect
                    OnBarcodeReaderConnect();
                }
                else
                {
                    // Barcode reader disconnect
                    OnBarcodeReaderDisconnect();
                }
            }
            else
            {
                // Communication error
                throw new PortException("Communication error");
            }
        }

        private void ReadBarcodeReaderDataIfNeed(IPort port)
        {
            if (!ShouldMonitorBarcodeReader ||
                BarcodeReaderStatus != BarcodeReaderStatus.Connect)
            {
                return;
            }

            ReadBarcodeReaderData(port);
        }

        private void ReadBarcodeReaderData(IPort port)
        {
            BcrDataParser parser = new BcrDataParser();

            CommunicationResult result = Communication.ParseDoNotCheckCondition(parser, port);

            if (result.Result == Communication.Result.Success)
            {
                byte[] data = parser.Data;

                OnBarcodeDataReceive(data);
            }
            else
            {
                // Communication error
                throw new PortException("Communication error");
            }
        }

        private void ClearBarcodeReaderBufferIfNeed(IPort port)
        {
            if (!ShouldMonitorBarcodeReader)
            {
                return;
            }

            ClearBarcodeReaderBuffer(port);
        }

        private string CreateStatusCode(PrinterStatus printerStatus, PrinterPaperStatus printerPaperStatus, PrinterCoverStatus printerCoverStatus, CashDrawerStatus cashDrawerStatus)
        {
            int statusCode;

            if (printerStatus == PrinterStatus.Impossible)
            {
                statusCode = 0x08000000;
            }
            else
            {
                statusCode = 0x00000000;

                if (printerStatus == PrinterStatus.Offline)
                {
                    statusCode |= 0x08000000;
                }

                if (printerPaperStatus == PrinterPaperStatus.Empty)
                {
                    statusCode |= 0x0000000c;
                }
                else if (printerPaperStatus == PrinterPaperStatus.NearEmpty)
                {
                    statusCode |= 0x00000004;
                }

                if (printerCoverStatus == PrinterCoverStatus.Open)
                {
                    statusCode |= 0x20000000;
                }

                if (cashDrawerStatus == CashDrawerStatus.Open)
                {
                    statusCode |= 0x04000000;
                }
            }

            return String.Format("{0:x8}", statusCode);
        }

        private void ClearBarcodeReaderBuffer(IPort port)
        {
            byte[] clearBufferCommands = BcrFunctions.CreateClearBuffer();

            uint writtenLength = port.WritePort(clearBufferCommands, 0, (uint)clearBufferCommands.Length);

            if (writtenLength != (uint)clearBufferCommands.Length)
            {
                throw new PortException("WritePort failed.");
            }
        }

        private void OnPrinterOffline()
        {
            if (PrinterStatus != PrinterStatus.Offline)
            {
                if (PrinterOffline != null)
                {
                    PrinterOffline.Invoke(this, null);
                }
            }

            PrinterStatus = PrinterStatus.Offline;
        }

        private void OnPrinterOnline()
        {
            if (PrinterStatus != PrinterStatus.Online)
            {
                if (PrinterOnline != null)
                {
                    PrinterOnline.Invoke(this, null);
                }
            }

            PrinterStatus = PrinterStatus.Online;
        }

        private void OnPrinterPaperEmpty()
        {
            if (PrinterPaperStatus != PrinterPaperStatus.Empty)
            {
                if (PrinterPaperEmpty != null)
                {
                    PrinterPaperEmpty.Invoke(this, null);
                }
            }

            PrinterPaperStatus = PrinterPaperStatus.Empty;
        }

        private void OnPrinterPaperNearEmpty()
        {
            if (PrinterPaperStatus != PrinterPaperStatus.NearEmpty)
            {
                if (PrinterPaperNearEmpty != null)
                {
                    PrinterPaperNearEmpty.Invoke(this, null);
                }
            }

            PrinterPaperStatus = PrinterPaperStatus.NearEmpty;
        }

        private void OnPrinterPaperReady()
        {
            if (PrinterPaperStatus != PrinterPaperStatus.Ready)
            {
                if (PrinterPaperReady != null)
                {
                    PrinterPaperReady.Invoke(this, null);
                }
            }

            PrinterPaperStatus = PrinterPaperStatus.Ready;
        }

        private void OnPrinterCoverOpen()
        {
            if (PrinterCoverStatus != PrinterCoverStatus.Open)
            {
                if (PrinterCoverOpen != null)
                {
                    PrinterCoverOpen.Invoke(this, null);
                }
            }

            PrinterCoverStatus = PrinterCoverStatus.Open;
        }

        private void OnPrinterCoverClose()
        {
            if (PrinterCoverStatus != PrinterCoverStatus.Close)
            {
                if (PrinterCoverClose != null)
                {
                    PrinterCoverClose.Invoke(this, null);
                }
            }

            PrinterCoverStatus = PrinterCoverStatus.Close;
        }

        private void OnCashDrawerOpen()
        {
            if (CashDrawerStatus != CashDrawerStatus.Open)
            {
                if (CashDrawerOpen != null)
                {
                    CashDrawerOpen.Invoke(this, null);
                }
            }

            CashDrawerStatus = CashDrawerStatus.Open;
        }

        private void OnCashDrawerClose()
        {
            if (CashDrawerStatus != CashDrawerStatus.Close)
            {
                if (CashDrawerClose != null)
                {
                    CashDrawerClose.Invoke(this, null);
                }
            }

            CashDrawerStatus = CashDrawerStatus.Close;
        }

        private void OnBarcodeReaderConnect()
        {
            if (BarcodeReaderStatus != BarcodeReaderStatus.Connect)
            {
                if (BarcodeReaderConnect != null)
                {
                    BarcodeReaderConnect.Invoke(this, null);
                }
            }

            BarcodeReaderStatus = BarcodeReaderStatus.Connect;
        }

        private void OnBarcodeReaderDisconnect()
        {
            if (BarcodeReaderStatus != BarcodeReaderStatus.Disconnect)
            {
                if (BarcodeReaderDisconnect != null)
                {
                    BarcodeReaderDisconnect.Invoke(this, null);
                }
            }

            BarcodeReaderStatus = BarcodeReaderStatus.Disconnect;
        }

        private void OnBarcodeDataReceive(byte[] data)
        {
            if (data != null && data.Length != 0)
            {
                if (BarcodeDataReceive != null)
                {
                    BarcodeDataReceive.Invoke(this, new BarcodeDataReceiveEventArgs() { Data = data });
                }
            }
        }

        private void OnPrinterImpossible()
        {
            if (PrinterStatus != PrinterStatus.Impossible)
            {
                if (PrinterImpossible != null)
                {
                    PrinterImpossible.Invoke(this, null);
                }
            }

            PrinterStatus = PrinterStatus.Impossible;
        }

        private void OnBarcodeReaderImpossible()
        {
            if (BarcodeReaderStatus != BarcodeReaderStatus.Impossible)
            {
                if (BarcodeReaderImpossible != null)
                {
                    BarcodeReaderImpossible.Invoke(this, null);
                }
            }

            BarcodeReaderStatus = BarcodeReaderStatus.Impossible;
        }

        private void OnStatusUpdate()
        {
            string status = CreateStatusCode(PrinterStatus, PrinterPaperStatus, PrinterCoverStatus, CashDrawerStatus);

            if (status != null && status.Length != 0)
            {
                if (StatusUpdate != null)
                {
                    StatusUpdate.Invoke(this, new StatusUpdateEventArgs() { Status = status });
                }
            }
        }
    }
}
