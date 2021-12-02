using StarMicronics.StarIOExtension;
using System.Drawing;

namespace StarPRNTSDK
{
    public abstract class LocalizeReceipt
    {
        public ReceiptInformationManager ReceiptInformationManager { get; set; }

        public CharacterCode CharacterCode { get; protected set; }

        public virtual Font RasterReceiptFont { get; protected set; }

        public PaperSize PaperSize
        {
            get
            {
                if (_PaperSize == null)
                {
                    return ReceiptInformationManager.PaperSize;
                }

                return _PaperSize;
            }
            set
            {
                _PaperSize = value;
            }
        }
        private PaperSize _PaperSize = null;

        public static LocalizeReceipt CreateLocalizeReceipt(ReceiptInformationManager receiptInformationManager)
        {
            LocalizeReceipt localizeReceipts = null;

            switch (receiptInformationManager.LanguageType)
            {
                case LanguageType.English:
                    localizeReceipts = new EnglishReceipt();
                    break;

                case LanguageType.Japanese:
                    localizeReceipts = new JapaneseReceipt();
                    break;

                case LanguageType.French:
                    localizeReceipts = new FrenchReceipt();
                    break;

                case LanguageType.Portuguese:
                    localizeReceipts = new PortugueseReceipt();
                    break;

                case LanguageType.Spanish:
                    localizeReceipts = new SpanishReceipt();
                    break;

                case LanguageType.German:
                    localizeReceipts = new GermanReceipt();
                    break;

                case LanguageType.Russian:
                    localizeReceipts = new RussianReceipt();
                    break;

                case LanguageType.SimplifiedChinese:
                    localizeReceipts = new SimplifiedChineseReceipt();
                    break;

                case LanguageType.TraditionalChinese:
                    localizeReceipts = new TraditionalChineseReceipt();
                    break;

                case LanguageType.Utf8MultiLanguage:
                    localizeReceipts = new Utf8MultiLanguageReceipt();
                    break;
            }

            localizeReceipts.ReceiptInformationManager = receiptInformationManager;

            return localizeReceipts;
        }

        public void AppendTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            switch (PaperSize.Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    Append2inchTextReceiptData(builder, utf8);
                    break;

                case PaperSizeType.ThreeInch:
                    switch (SharedInformationManager.SelectedEmulation)
                    {
                        case Emulation.EscPos:
                        case Emulation.EscPosMobile:
                            AppendEscPos3inchTextReceiptData(builder, utf8);
                            break;

                        case Emulation.StarDotImpact:
                            AppendDotImpact3inchTextReceiptData(builder, utf8);
                            break;

                        default:
                            Append3inchTextReceiptData(builder, utf8);
                            break;
                    }
                    break;

                case PaperSizeType.FourInch:
                    Append4inchTextReceiptData(builder, utf8);
                    break;
            }
        }

        public Bitmap CreateRasterReceiptImage()
        {
            Bitmap bitmap;

            switch (PaperSize.Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    bitmap = Create2inchRasterImage();
                    break;

                case PaperSizeType.ThreeInch:
                    switch (SharedInformationManager.SelectedEmulation)
                    {
                        case Emulation.EscPos:
                        case Emulation.EscPosMobile:
                            bitmap = CreateEscPos3inchRasterImage();
                            break;

                        case Emulation.StarDotImpact:
                            bitmap = CreateCouponImage();
                            break;

                        default:
                            bitmap = Create3inchRasterImage();
                            break;
                    }

                    break;

                case PaperSizeType.FourInch:
                    bitmap = Create4inchRasterImage();
                    break;
            }

            return bitmap;
        }

        /// <summary>
        /// Get source image to scale.
        /// 3inch → 2inch
        /// 4inch → 3inch
        /// 3inch → 4inch
        /// </summary>
        public Bitmap CreateScaleRasterReceiptImage()
        {
            PaperSize.Scale = true;

            Bitmap rasterImage = CreateRasterReceiptImage();

            PaperSize.Scale = false;

            return rasterImage;
        }

        public Bitmap Create2inchRasterImage()
        {
            string sourceString = Create2inchBitmapSourceText();

            Bitmap rasterImage = CreateBitmapFromString(sourceString, 96.0F, 96.0F);

            return rasterImage;
        }

        public Bitmap Create3inchRasterImage()
        {
            string sourceString = Create3inchBitmapSourceText();

            Bitmap rasterImage = CreateBitmapFromString(sourceString, 96.0F, 96.0F);

            return rasterImage;
        }

        public Bitmap CreateEscPos3inchRasterImage()
        {
            string sourceString = CreateEscPos3inchBitmapSourceText();

            Bitmap rasterImage = CreateBitmapFromString(sourceString, 96.0F, 96.0F);

            return rasterImage;
        }

        public Bitmap Create4inchRasterImage()
        {
            string sourceString = Create4inchBitmapSourceText();

            Bitmap rasterImage = CreateBitmapFromString(sourceString, 96.0F, 96.0F);

            return rasterImage;
        }

        private Bitmap CreateBitmapFromString(string sourceString, float xDpi, float yDpi)
        {
            Font printFont = RasterReceiptFont;

            StringFormat format = new StringFormat();

            float yPos = 0;
            int count = 0;
            float leftMargin = 0;
            float topMargin = 0;

            SizeF bitmapSize = CaluculateBitmapSize(sourceString, printFont, xDpi, yDpi);

            Bitmap bitmap = new Bitmap((int)bitmapSize.Width, (int)(bitmapSize.Height + topMargin));
            bitmap.SetResolution(xDpi, yDpi);
            Graphics graphics = Graphics.FromImage(bitmap);

            string[] lines = sourceString.Split('\n');
            foreach (string line in lines)
            {
                yPos = topMargin + (count * printFont.GetHeight(graphics));
                graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, format);
                count++;
            }

            graphics.Dispose();
            printFont.Dispose();

            return bitmap;
        }

        private static SizeF CaluculateBitmapSize(string sourceString, Font printFont, float xDpi, float yDpi)
        {
            SizeF stringSize = new SizeF();
            float width = 0;
            float height = 0;
            Bitmap bitmap = new Bitmap(2000, 2000);
            bitmap.SetResolution(xDpi, yDpi);
            Graphics graphics = Graphics.FromImage(bitmap);

            int count = 0;

            string[] lines = sourceString.Split('\n');
            foreach (string line in lines)
            {
                stringSize = graphics.MeasureString(line, printFont, 2000);
                if (stringSize.Width > width)
                {
                    width = stringSize.Width;
                }

                height = count * printFont.GetHeight(graphics);
                count++;
            }

            return new SizeF(width, height);
        }

        public string CreateRasterImageText()
        {
            string rasterImageText;

            switch (PaperSize.Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    rasterImageText = Create2inchBitmapSourceText();
                    break;

                case PaperSizeType.ThreeInch:
                    switch (SharedInformationManager.SelectedEmulation)
                    {
                        case Emulation.EscPos:
                        case Emulation.EscPosMobile:
                        case Emulation.StarDotImpact:
                            rasterImageText = CreateEscPos3inchBitmapSourceText();
                            break;

                        default:
                            rasterImageText = Create3inchBitmapSourceText();
                            break;
                    }
                    break;

                case PaperSizeType.FourInch:
                    rasterImageText = Create4inchBitmapSourceText();
                    break;
            }

            return rasterImageText;
        }

        public abstract void Append2inchTextReceiptData(ICommandBuilder builder, bool utf8);

        public abstract void Append3inchTextReceiptData(ICommandBuilder builder, bool utf8);

        public abstract void Append4inchTextReceiptData(ICommandBuilder builder, bool utf8);

        public abstract string Create2inchRasterReceiptText();

        public abstract string Create3inchRasterReceiptText();

        public abstract string Create4inchRasterReceiptText();

        public abstract string Create2inchBitmapSourceText();

        public abstract string Create3inchBitmapSourceText();

        public abstract string CreateEscPos3inchBitmapSourceText();

        public abstract string Create4inchBitmapSourceText();

        public abstract Bitmap CreateCouponImage();

        public abstract void AppendEscPos3inchTextReceiptData(ICommandBuilder builder, bool utf8);

        public abstract void AppendDotImpact3inchTextReceiptData(ICommandBuilder builder, bool utf8);

        public abstract void AppendTextLabelData(ICommandBuilder builder, bool utf8);

        public abstract string CreatePasteTextLabelString();

        public abstract void AppendPasteTextLabelData(ICommandBuilder builder, string pasteText, bool utf8);
    }
}
