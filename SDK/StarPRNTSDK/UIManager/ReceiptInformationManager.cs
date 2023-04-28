using StarMicronics.StarIOExtension;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace StarPRNTSDK
{
    public class ReceiptInformationManager : DependencyObject
    {
        public enum ReceiptType
        {
            Text,
            TextUTF8,
            Raster,
            RasterBothScale,
            RasterScale,
            RasterCoupon,
            RasterCouponRotation90,
            TextLabel,
            Unknown
        }

        public ReceiptInformationManager()
        {
            paperSizeList = new List<PaperSize>();

            if (SharedInformationManager.ReceiptInformationManager != null)
            {
                CopyProperty(SharedInformationManager.ReceiptInformationManager);
            }
            else
            {
                Language = new Language();
                PaperSize = new PaperSize();
            }

            SharedInformationManager.ReceiptInformationManager = this;
        }

        private void CopyProperty(ReceiptInformationManager source)
        {
            Language = new Language(source.Language.Type);

            AllPaperSizes = source.AllPaperSizes;
        }

        public static readonly DependencyProperty LanguageProperty = DependencyProperty.Register("Language", typeof(Language), typeof(ReceiptInformationManager));
        public Language Language
        {
            get
            {
                if (!Dispatcher.CheckAccess())
                {
                    return (Language)Dispatcher.Invoke(
                        DispatcherPriority.Background,
                        (DispatcherOperationCallback)delegate { return GetValue(LanguageProperty); },
                        LanguageProperty);
                }
                else
                {
                    return (Language)GetValue(LanguageProperty);
                }
            }
            set
            {
                SetValue(LanguageProperty, value);
            }
        }

        public LanguageType LanguageType
        {
            get
            {
                return Language.Type;
            }
        }


        public static readonly DependencyProperty PaperSizeProperty = DependencyProperty.Register("PaperSize", typeof(PaperSize), typeof(ReceiptInformationManager));
        public PaperSize PaperSize
        {
            get
            {
                if (!Dispatcher.CheckAccess())
                {
                    return (PaperSize)Dispatcher.Invoke(
                        DispatcherPriority.Background,
                        (DispatcherOperationCallback)delegate { return GetValue(PaperSizeProperty); },
                        PaperSizeProperty);
                }
                else
                {
                    return (PaperSize)GetValue(PaperSizeProperty);
                }
            }
            set
            {
                while (paperSizeList.Count < 1)
                {
                    paperSizeList.Add(new PaperSize());
                }

                paperSizeList[0] = value;

                SetValue(PaperSizeProperty, value);
            }
        }

        public PaperSize[] AllPaperSizes
        {
            get
            {
                return paperSizeList.ToArray();
            }
            set
            {
                paperSizeList = new List<PaperSize>(value);

                if (value.Length >= 1)
                {
                    PaperSize = value[0];
                }
            }
        }

        private List<PaperSize> paperSizeList;

        public PaperSizeType PaperSizeType
        {
            get
            {
                return PaperSize.Type;
            }
        }

        public int ActualPaperSize
        {
            get
            {
                return PaperSize.ActualPaperSize;
            }
        }

        public ReceiptType Type { get; set; }

        public string Description
        {
            get
            {
                return Language.Code + " " + PaperSize.Code + " " + GetTypeDescription();
            }
        }

        public string DescriptionPaperSizeScaled
        {
            get
            {
                return Language.Code + " " + PaperSize.ScaledCode + " " + GetTypeDescription();
            }
        }


        public string DescriptionWithoutPaperSize
        {
            get
            {
                return Language.Code + " " + GetTypeDescription();
            }
        }

        public string DescriptionWithRotation
        {
            get
            {
                return Language.Code + " " + PaperSize.Code + " " + GetTypeDescription() + " (Rotation" + GetRotationDescription() + ")"; ;
            }
        }

        public BitmapConverterRotation Rotation { get; set; }

        public LocalizeReceipt LocalizeReceipt
        {
            get
            {
                return LocalizeReceipt.CreateLocalizeReceipt(this);
            }
        }

        public string PasteTex
        {
            get
            {
                return LocalizeReceipt.CreatePasteTextLabelString();
            }
        }

        private string GetTypeDescription()
        {
            string description = "";


            switch (Type)
            {
                default:
                case ReceiptType.Text:
                    description = "Text Receipt";
                    break;

                case ReceiptType.TextUTF8:
                    description = "Text Receipt (UTF8)";
                    break;

                case ReceiptType.Raster:
                    description = "Raster Receipt";
                    break;

                case ReceiptType.RasterBothScale:
                    description = "Raster Receipt (Both Scale)";
                    break;

                case ReceiptType.RasterScale:
                    description = "Raster Receipt (Scale)";
                    break;

                case ReceiptType.RasterCoupon:
                    description = "Raster Coupon";
                    break;

                case ReceiptType.RasterCouponRotation90:
                    description = "Raster Coupon (Rotation90)";
                    break;

                case ReceiptType.TextLabel:
                    description = "Text Label";
                    break;

                case ReceiptType.Unknown:
                    description = "";
                    break;
            }

            return description;
        }

        private string GetRotationDescription()
        {
            string description = "";


            switch (Rotation)
            {
                default:
                case BitmapConverterRotation.Normal:
                    description = "0";
                    break;

                case BitmapConverterRotation.Right90:
                    description = "90";
                    break;

                case BitmapConverterRotation.Rotate180:
                    description = "180";
                    break;

                case BitmapConverterRotation.Left90:
                    description = "270";
                    break;
            }

            return description;
        }
    }

    public enum LanguageType
    {
        English,
        Japanese,
        French,
        Portuguese,
        Spanish,
        German,
        Russian,
        SimplifiedChinese,
        TraditionalChinese,
        Utf8MultiLanguage,
        Unknown
    }

    public class Language
    {
        public Language()
        {
            Type = LanguageType.Unknown;
        }

        public Language(LanguageType type)
        {
            Type = type;
        }

        public LanguageType Type { get; set; }

        public string Description
        {
            get
            {
                return GetDescription();
            }
        }

        public string Code
        {
            get
            {
                return GetCode();
            }
        }

        public string GetDescription()
        {
            string description;

            switch (Type)
            {
                default:
                case LanguageType.English:
                    description = "English";
                    break;

                case LanguageType.Japanese:
                    description = "Japanese";
                    break;

                case LanguageType.French:
                    description = "French";
                    break;

                case LanguageType.Portuguese:
                    description = "Portuguese";
                    break;

                case LanguageType.Spanish:
                    description = "Spanish";
                    break;

                case LanguageType.German:
                    description = "German";
                    break;

                case LanguageType.Russian:
                    description = "Russian";
                    break;

                case LanguageType.SimplifiedChinese:
                    description = "Simplified Chinese";
                    break;

                case LanguageType.TraditionalChinese:
                    description = "Traditional Chinese";
                    break;

                case LanguageType.Utf8MultiLanguage:
                    description = "UTF8 Multi language";
                    break;

                case LanguageType.Unknown:
                    description = "";
                    break;
            }

            return description;
        }

        public string GetCode()
        {
            string code;

            switch (Type)
            {
                default:
                case LanguageType.English:
                    code = "En";
                    break;

                case LanguageType.Japanese:
                    code = "Ja";
                    break;

                case LanguageType.French:
                    code = "Fr";
                    break;

                case LanguageType.Portuguese:
                    code = "Pt";
                    break;

                case LanguageType.Spanish:
                    code = "Es";
                    break;

                case LanguageType.German:
                    code = "De";
                    break;

                case LanguageType.Russian:
                    code = "Ru";
                    break;

                case LanguageType.SimplifiedChinese:
                    code = "zh-CN";
                    break;

                case LanguageType.TraditionalChinese:
                    code = "zh-TW";
                    break;

                case LanguageType.Utf8MultiLanguage:
                    code = "CJK";
                    break;

                case LanguageType.Unknown:
                    code = "";
                    break;
            }

            return code;
        }
    }

    public enum PaperSizeType
    {
        TwoInch,
        ThreeInch,
        FourInch,
        Unknown
    }

    public class PaperSize
    {
        public PaperSize()
        {
            Type = PaperSizeType.Unknown;
        }

        public PaperSize(PaperSizeType type)
        {
            Type = type;
        }

        public PaperSizeType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;

                if (!Scale)
                {
                    notScaledType = value;
                }
            }
        }

        private PaperSizeType type;

        private PaperSizeType notScaledType;

        public string Description
        {
            get
            {
                return GetDescription();
            }
        }

        public string Code
        {
            get
            {
                return GetCode();
            }
        }

        public string ScaledCode
        {
            get
            {
                Scale = true;

                string code = GetCode();

                Scale = false;

                return code;
            }
        }

        public bool Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;

                ConvertPaperSizeType();
            }
        }

        public int ActualPaperSize
        {
            get
            {
                return GetActualPaperSize();
            }
        }

        private bool scale;

        private void ConvertPaperSizeType()
        {
            Dictionary<PaperSizeType, PaperSizeType> scaleDictionary = new Dictionary<PaperSizeType, PaperSizeType>()
            {
                { PaperSizeType.TwoInch, PaperSizeType.ThreeInch },
                { PaperSizeType.ThreeInch, PaperSizeType.FourInch },
                { PaperSizeType.FourInch, PaperSizeType.ThreeInch },
            };

            if (Scale)
            {
                Type = scaleDictionary[Type];
            }
            else
            {
                Type = notScaledType;
            }
        }

        private string GetDescription()
        {
            string description;

            switch (Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    description = "2\" (384dots)";
                    break;

                case PaperSizeType.ThreeInch:
                    description = "3\" (576dots)";
                    break;

                case PaperSizeType.FourInch:
                    description = "4\" (832dots)";
                    break;
            }

            return description;
        }

        private string GetCode()
        {
            string code;

            switch (Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    code = "2\"";
                    break;

                case PaperSizeType.ThreeInch:
                    code = "3\"";
                    break;

                case PaperSizeType.FourInch:
                    code = "4\"";
                    break;
            }

            return code;
        }

        private int GetActualPaperSize()
        {
            int paperSize;

            switch (Type)
            {
                default:
                case PaperSizeType.TwoInch:
                    paperSize = 384;
                    break;

                case PaperSizeType.ThreeInch:
                    switch (SharedInformationManager.SelectedEmulation)
                    {
                        case Emulation.EscPos:
                        case Emulation.EscPosMobile:
                            paperSize = 512;
                            break;

                        case Emulation.StarDotImpact:
                            paperSize = 210;
                            break;

                        default:
                            paperSize = 576;
                            break;
                    }
                    break;

                case PaperSizeType.FourInch:
                    paperSize = 832;
                    break;
            }

            return paperSize;
        }
    }
}
