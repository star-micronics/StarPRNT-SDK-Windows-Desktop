using StarMicronics.StarIOExtension;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    public class PrinterFunctions
    {
        public static byte[] CreateTextReceiptData(Emulation emulation, LocalizeReceipt localizeReceipt, bool utf8)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            localizeReceipt.AppendTextReceiptData(builder, utf8);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateRasterReceiptData(Emulation emulation, LocalizeReceipt localizeReceipt)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            Bitmap rasterImage = localizeReceipt.CreateRasterReceiptImage();

            builder.AppendBitmap(rasterImage, false);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateScaleRasterReceiptData(Emulation emulation, LocalizeReceipt localizeReceipt, int width, bool bothScale)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            Bitmap rasterImage = localizeReceipt.CreateScaleRasterReceiptImage();

            builder.AppendBitmap(rasterImage, false, width, bothScale);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateCouponData(Emulation emulation, LocalizeReceipt localizeReceipt, int width, BitmapConverterRotation rotation)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            Bitmap rasterImage = localizeReceipt.CreateCouponImage();

            builder.AppendBitmap(rasterImage, false, width, true, rotation);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateTextBlackMarkData(Emulation emulation, LocalizeReceipt localizeReceipt, BlackMarkType type, bool utf8)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendBlackMark(type);

            localizeReceipt.AppendTextLabelData(builder, utf8);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreatePasteTextBlackMarkData(Emulation emulation, LocalizeReceipt localizeReceipt, string pasteText, bool doubleHeight, BlackMarkType type, bool utf8)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendBlackMark(type);

            if (doubleHeight)
            {
                builder.AppendMultipleHeight(2);

                localizeReceipt.AppendPasteTextLabelData(builder, pasteText, utf8);

                builder.AppendMultipleHeight(1);
            }
            else
            {
                localizeReceipt.AppendPasteTextLabelData(builder, pasteText, utf8);
            }

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateTextPageModeData(Emulation emulation, LocalizeReceipt localizeReceipt, Rectangle printRegion, BitmapConverterRotation rotation, bool utf8)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.BeginPageMode(printRegion, rotation);

            localizeReceipt.AppendTextLabelData(builder, utf8);

            builder.EndPageMode();

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateFileOpenData(Emulation emulation, string filePath, int paperSize)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            Bitmap rasterImage = (Bitmap)Image.FromFile(filePath);

            builder.AppendBitmap(rasterImage, true, paperSize, true);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static List<byte[]> CreateHoldPrintData(Emulation emulation, bool[] isHoldArray)
        {
            List<byte[]> commandList = new List<byte[]>();

            for (int i = 0; i < isHoldArray.Length; i++)
            {
                ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

                builder.BeginDocument();

                // Disable hold print controlled by printer firmware.
                builder.AppendHoldPrint(HoldPrintType.Invalid);

                if (isHoldArray[i])
                {
                    // Enable paper present status if wait paper removal before next printing.
                    builder.AppendPaperPresentStatus(PaperPresentStatusType.Valid);
                }
                else
                {
                    // Disable paper present status if do not wait paper removal before next printing.
                    builder.AppendPaperPresentStatus(PaperPresentStatusType.Invalid);
                }

                // Create commands for printing.
                builder.AppendAlignment(AlignmentPosition.Center);

                builder.Append(Encoding.ASCII.GetBytes("\n------------------------------------\n\n\n\n\n\n"));

                builder.AppendMultiple(3, 3);

                builder.Append(Encoding.ASCII.GetBytes("Page "));
                builder.Append(Encoding.ASCII.GetBytes((i+ 1).ToString()));

                builder.AppendMultiple(1, 1);

                builder.Append(Encoding.ASCII.GetBytes("\n\n\n\n\n----------------------------------\n"));

                builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

                builder.EndDocument();

                commandList.Add(builder.Commands);
            }

            return commandList;
        }
    }
}
