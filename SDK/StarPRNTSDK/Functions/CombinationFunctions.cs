using StarMicronics.StarIOExtension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace StarPRNTSDK
{
    public static class CombinationFunctions
    {
        public static byte[] CreateTextReceiptData(Emulation emulation, LocalizeReceipt localizeReceipt, bool utf8)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            localizeReceipt.AppendTextReceiptData(builder, utf8);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.AppendPeripheral(PeripheralChannel.No1);

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

            builder.AppendPeripheral(PeripheralChannel.No1);

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

            builder.AppendPeripheral(PeripheralChannel.No1);

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

            builder.AppendPeripheral(PeripheralChannel.No1);

            builder.EndDocument();

            return builder.Commands;
        }
    }
}
