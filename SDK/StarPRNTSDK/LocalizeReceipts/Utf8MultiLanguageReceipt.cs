using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class Utf8MultiLanguageReceipt : LocalizeReceipt
    {
        public Utf8MultiLanguageReceipt()
        {
            CharacterCode = CharacterCode.Standard;
        }

        public override void Append2inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding = "UTF-8";

            builder.AppendCodePage(CodePageType.UTF8);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("2017 / 5 / 15 AM 10:00\n"));

            builder.AppendMultiple(2, 2);

            // This function is supported by TSP650II(JP2/TW models only) with F/W version 4.0 or later and and mC-Print2/3.
            // Switch Kanji/Hangul font by specifying the font for Unicode CJK Unified Ideographs before each word.

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Japanese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("受付票 "));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.TraditionalChinese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("排號單\n"));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.SimplifiedChinese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("排号单 "));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Hangul);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("접수표\n\n"));

            builder.AppendMultiple(1, 1);

            builder.AppendCjkUnifiedIdeographFont();
            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("1\n"), 6, 6);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("--------------------------------\n"));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Japanese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("ご本人がお持ちください。\n"));
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("※紛失しないように\n"));
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("ご注意ください。\n"));
        }

        public override void Append3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding = "UTF-8";

            builder.AppendCodePage(CodePageType.UTF8);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("2017 / 5 / 15 AM 10:00\n"));

            builder.AppendMultiple(2, 2);

            // This function is supported by TSP650II(JP2/TW models only) with F/W version 4.0 or later and and mC-Print2/3.
            // Switch Kanji/Hangul font by specifying the font for Unicode CJK Unified Ideographs before each word.

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Japanese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("受付票 "));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.TraditionalChinese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("排號單\n"));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.SimplifiedChinese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("排号单 "));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Hangul);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("접수표\n\n"));

            builder.AppendMultiple(1, 1);

            builder.AppendCjkUnifiedIdeographFont();
            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("1\n"), 6, 6);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------\n"));

            builder.AppendCjkUnifiedIdeographFont(CjkUnifiedIdeographFont.Japanese);
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("ご本人がお持ちください。\n"));
            builder.Append(Encoding.GetEncoding(encoding).GetBytes("※紛失しないようにご注意ください。\n"));
        }

        public override void Append4inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            // not implemented
        }

        public override void AppendEscPos3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            // not implemented
        }

        public override void AppendDotImpact3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            // not implemented
        }

        public override Bitmap CreateCouponImage()
        {
            // not implemented
            return null;
        }

        public override string Create2inchRasterReceiptText()
        {
            // not implemented
            return null;
        }

        public override string Create3inchRasterReceiptText()
        {
            // not implemented
            return null;
        }

        public override string Create4inchRasterReceiptText()
        {
            // not implemented
            return null;
        }
        public override string Create2inchBitmapSourceText()
        {
            // not implemented
            return null;
        }


        public override string Create3inchBitmapSourceText()
        {
            // not implemented
            return null;
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            // not implemented
            return null;
        }

        public override string Create4inchBitmapSourceText()
        {
            // not implemented
            return null;
        }

        public override void AppendTextLabelData(ICommandBuilder builder, bool utf8)
        {
            // not implemented
        }

        public override string CreatePasteTextLabelString()
        {
            // not implemented
            return null;
        }

        public override void AppendPasteTextLabelData(ICommandBuilder builder, string pasteText, bool utf8)
        {
            // not implemented
        }
    }
}
