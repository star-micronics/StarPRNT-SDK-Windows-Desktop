using StarMicronics.StarIOExtension;
using System;

namespace StarPRNTSDK
{
    public class BcrDataParser : IPeripheralCommandParser
    {
        private static readonly int HEADER_LENGTH = 6;

        public BcrDataParser()
        {
            Data = new byte[0];
        }

        public byte[] Data { get; private set; }

        public virtual ParseResult Parse(byte[] response, int responseLength)
        {
            if (responseLength < HEADER_LENGTH)
            {
                return ParseResult.Invalid;
            }

            int parseStartIndex = 0;
            int dataLength = 0;
            bool canParse = false;

            for (int i = 0; i <= responseLength - HEADER_LENGTH; i++)
            {
                if (response[i] == 0x1b &&
                    response[i + 1] == 0x1d &&
                    response[i + 2] == (byte)'B' &&
                    response[i + 3] == 0x32)
                {
                    int length = (response[i + 4] & 0xFF) + (response[i + 5] & 0xFF) * 0x100; // k = n1 + n2 * 256

                    int requiredResponseLength = i + HEADER_LENGTH + length;

                    if (requiredResponseLength <= responseLength)
                    {
                        parseStartIndex = i + HEADER_LENGTH;
                        dataLength = length;
                        canParse = true;
                    }
                }
            }

            if (!canParse)
            {
                return ParseResult.Invalid;
            }

            if (dataLength == 0) // no data
            {
                return ParseResult.Success;
            }

            byte[] receiveData = new byte[dataLength];

            Array.Copy(response, parseStartIndex, receiveData, 0, dataLength);

            Data = receiveData;

            return ParseResult.Success;
        }

        public byte[] SendCommands
        {
            get
            {
                return new byte[] { 0x1b, 0x1d, (byte)'B', 0x32 };    // Request barcode data command.
            }
        }

        public byte[] ReceiveCommands
        {
            get
            {
                return null; // no use
            }
        }
    }
}
