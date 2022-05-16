using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class SimplifiedChineseReceipt : LocalizeReceipt
    {
        public SimplifiedChineseReceipt()
        {
            CharacterCode = CharacterCode.SimplifiedChinese;

            RasterReceiptFont = new Font("MS Gothic", 17);
        }

        public override void Append2inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "GB2312";

            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("STAR便利店\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("欢迎光临\n"), 2);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Unit 1906-08, 19/F,\n" +
                            "Enterprise Square 2,\n" +
                            "3 Sheung Yuet Road,\n" +
                            "Kowloon Bay, KLN\n" +
                            "\n" +
                            "Tel : (852) 2795 2335\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "货品名称           数量     价格\n" +
                            "--------------------------------\n" +
                            "\n" +
                            "罐装可乐\n" +
                            "* Coke                 1    7.00\n" +
                            "纸包柠檬茶\n" +
                            "* Lemon Tea            2   10.00\n" +
                            "热狗\n" +
                            "* Hot Dog              1   10.00\n" +
                            "薯片(50克装)\n" +
                            "* Potato Chips(50g)    1   11.00\n" +
                            "--------------------------------\n" +
                            "\n" +
                            "              总数 :       38.00\n" +
                            "              现金 :       38.00\n" +
                            "              找赎 :        0.00\n" +
                            "\n" +
                            "卡号码 Card No.       : 88888888\n" +
                            "卡余额 Remaining Val.    : 88.00\n" +
                            "机号   Device No.       : 1234F1\n" +
                            "\n" +
                            "\n" +
                            "DD/MM/YYYY  HH:MM:SS\n" +
                            "交易编号 : 88888\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "收银机 : 001  收银员 : 180\n" +
                            "\n"));

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);
        }

        public override void Append3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "GB2312";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("STAR便利店\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("欢迎光临\n"), 2);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Unit 1906-08, 19/F, Enterprise Square 2,\n" +
                            "　3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                            "\n" +
                            "Tel : (852) 2795 2335\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "货品名称   　            数量   　   价格\n" +
                            "------------------------------------------------\n" +
                            "\n" +
                            "罐装可乐\n" +
                            "* Coke                      1        7.00\n" +
                            "纸包柠檬茶\n" +
                            "* Lemon Tea                 2       10.00\n" +
                            "热狗\n" +
                            "* Hot Dog                   1       10.00\n" +
                            "薯片(50克装)\n" +
                            "* Potato Chips(50g)         1       11.00\n" +
                            "------------------------------------------------\n" +
                            "\n" +
                            "                         总数 :     38.00\n" +
                            "                         现金 :     38.00\n" +
                            "                         找赎 :      0.00\n" +
                            "\n" +
                            "卡号码 Card No.       : 88888888\n" +
                            "卡余额 Remaining Val. : 88.00\n" +
                            "机号   Device No.     : 1234F1\n" +
                            "\n" +
                            "\n" +
                            "DD/MM/YYYY  HH:MM:SS  交易编号 : 88888\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("收银机 : 001  收银员 : 180\n"));

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);
        }

        public override void Append4inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "GB2312";
            }

            //builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("STAR便利店\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("欢迎光临\n"), 2);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Unit 1906-08, 19/F, Enterprise Square 2,\n" +
                            "　3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                            "\n" +
                            "Tel : (852) 2795 2335\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "货品名称   　                      数量        　         价格\n" +
                            "----------------------------------------------------------------\n" +
                            "\n" +
                            "罐装可乐\n" +
                            "* Coke                               1                    7.00\n" +
                            "纸包柠檬茶\n" +
                            "* Lemon Tea                          2                   10.00\n" +
                            "热狗\n" +
                            "* Hot Dog                            1                   10.00\n" +
                            "薯片(50克装)\n" +
                            "* Potato Chips(50g)                  1                   11.00\n" +
                            "----------------------------------------------------------------\n" +
                            "\n" +
                            "                                   总数 :                38.00\n" +
                            "                                   现金 :                38.00\n" +
                            "                                   找赎 :                 0.00\n" +
                            "\n" +
                            "卡号码 Card No.                   : 88888888\n" +
                            "卡余额 Remaining Val.             : 88.00\n" +
                            "机号   Device No.                 : 1234F1\n" +
                            "\n" +
                            "\n" +
                            "DD/MM/YYYY  HH:MM:SS        交易编号 : 88888\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("收银机 : 001  收银员 : 180\n"));

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);
        }

        public override void AppendEscPos3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "GB2312";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("STAR便利店\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("欢迎光临\n"), 2);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Unit 1906-08, 19/F, Enterprise Square 2,\n" +
                            "　3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                            "\n" +
                            "Tel : (852) 2795 2335\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "货品名称   　        数量   　 价格\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "罐装可乐\n" +
                            "* Coke                  1      7.00\n" +
                            "纸包柠檬茶\n" +
                            "* Lemon Tea             2     10.00\n" +
                            "热狗\n" +
                            "* Hot Dog               1     10.00\n" +
                            "薯片(50克装)\n" +
                            "* Potato Chips(50g)     1     11.00\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "                   总数 :     38.00\n" +
                            "                   现金 :     38.00\n" +
                            "                   找赎 :      0.00\n" +
                            "\n" +
                            "卡号码 Card No.       : 88888888\n" +
                            "卡余额 Remaining Val. : 88.00\n" +
                            "机号   Device No.     : 1234F1\n" +
                            "\n" +
                            "\n" +
                            "DD/MM/YYYY  HH:MM:SS  交易编号 : 88888\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("收银机 : 001  收银员 : 180\n"));

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);
        }

        public override void AppendDotImpact3inchTextReceiptData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "GB2312";
            }

            //builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR便利店\n" +
                            "欢迎光临\n"), 2);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Unit 1906-08, 19/F, Enterprise Square 2,\n" +
                            "　3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                            "\n" +
                            "Tel : (852) 2795 2335\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "货品名称   　          数量  　   价格\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "罐装可乐\n" +
                            "* Coke                   1        7.00\n" +
                            "纸包柠檬茶\n" +
                            "* Lemon Tea              2       10.00\n" +
                            "热狗\n" +
                            "* Hot Dog                1       10.00\n" +
                            "薯片(50克装)\n" +
                            "* Potato Chips(50g)      1       11.00\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "                      总数 :     38.00\n" +
                            "                      现金 :     38.00\n" +
                            "                      找赎 :      0.00\n" +
                            "\n" +
                            "卡号码 Card No.       : 88888888\n" +
                            "卡余额 Remaining Val. : 88.00\n" +
                            "机号   Device No.     : 1234F1\n" +
                            "\n" +
                            "\n" +
                            "DD/MM/YYYY  HH:MM:SS  交易编号 : 88888\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("收银机 : 001  收银员 : 180\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_simplified_chinese)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "　             　STAR便利店\n" +
                    "                      欢迎光临\n" +
                    "\n" +
                    "Unit 1906-08,19/F,\n" +
                    "  Enterprise Square 2,\n" +
                    "  3 Sheung Yuet Road,\n" +
                    "  Kowloon Bay, KLN\n" +
                    "\n" +
                    "Tel: (852) 2795 2335\n" +
                    "\n" +
                    "货品名称            \t\t数量\t价格\n" +
                    "----------------------------------------\n" +
                    "罐装可乐\n" +
                    "* Coke\t\t\t1\t  7.00\n" +
                    "纸包柠檬茶\n" +
                    "* Lemon Tea\t\t2\t10.00\n" +
                    "热狗\n" +
                    "* Hot Dog\t\t\t1\t10.00\n" +
                    "薯片(50克装)\n" +
                    "* Potato Chips(50g)\t1\t11.00\n" +
                    "----------------------------------------\n" +
                    "\n" +
                    "               \t\t  总　数 :  \t38.00\n" +
                    "               \t\t  现　金 :  \t38.00\n" +
                    "               \t\t  找　赎 :   \t  0.00\n" +
                    "\n" +
                    "卡号码 Card No. :    88888888\n" +
                    "卡余额 Remaining Val. :  88.00\n" +
                    "机号　 Device No. :     1234F1\n" +
                    "\n" +
                    "DD/MM/YYYY HH:MM:SS\n" +
                    "交易编号: 88888\n" +
                    "\n" +
                    "            收银机:001  收银员:180\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "                     STAR便利店\n" +
                    "                         欢迎光临\n" +
                    "\n" +
                    "Unit 1906-08,19/F,Enterprise Square 2,\n" +
                    "3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                    "\n" +
                    "Tel: (852) 2795 2335\n" +
                    "\n" +
                    "货品名称                 数量   　  价格\n" +
                    "------------------------------------------\n" +
                    "罐装可乐\n" +
                    "* Coke\t\t\t\t1\t\t  7.00\n" +
                    "纸包柠檬茶\n" +
                    "* Lemon Tea\t\t\t2\t\t10.00\n" +
                    "热狗\n" +
                    "* Hot Dog\t\t\t1\t\t10.00\n" +
                    "薯片(50克装)\n" +
                    "* Potato Chips(50g)\t1\t\t11.00\n" +
                    "------------------------------------------\n" +
                    "\n" +
                    "\t\t\t\t      总  数 :\t38.00\n" +
                    "\t\t\t\t      现  金 :\t38.00\n" +
                    "\t\t\t\t      找  赎 :\t  0.00\n" +
                    "\n" +
                    "卡号码 Card No.      \t:     88888888\n" +
                    "卡余额 Remaining Val.:     88.00\n" +
                    "机号　 Device No.    \t:     1234F1\n" +
                    "\n" +
                    "DD/MM/YYYY   HH:MM:SS\n" +
                    "交易编号: 88888\n" +
                    "\n" +
                    "               收银机:001  收银员:180\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "　　　　　　  　　                 STAR便利店\n" +
                    "                                                       欢迎光临\n" +
                    "\n" +
                    "                             Unit 1906-08,19/F,Enterprise Square 2,\n" +
                    "                              3 Sheung Yuet Road, Kowloon Bay, KLN\n" +
                    "\n" +
                    "Tel: (852) 2795 2335\n" +
                    "\n" +
                    "货品名称\t\t                               数量\t\t\t          价格\n" +
                    "---------------------------------------------------------------------------\n" +
                    "罐装可乐\n" +
                    "* Coke \t\t\t\t\t\t\t\t1\t\t\t\t\t  7.00\n" +
                    "纸包柠檬茶\n" +
                    "* Lemon Tea\t\t\t\t\t\t\t2\t\t\t\t\t10.00\n" +
                    "热狗\n" +
                    "* Hot Dog\t\t\t\t\t\t\t1\t\t\t\t\t10.00\n" +
                    "薯片(50克装)\n" +
                    "* Potato Chips(50g)\t\t\t\t\t1\t\t\t\t\t11.00\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\n" +
                    "\t\t\t\t\t\t\t\t\t\t\t\t总　数 :\t38.00\n" +
                    "\t\t\t\t\t\t\t\t\t\t\t\t现　金 :\t38.00\n" +
                    "\t\t\t\t\t\t\t\t\t\t\t\t找　赎 :\t  0.00\n" +
                    "\n" +
                    "卡号码 Card No.\t\t:\t88888888\n" +
                    "卡余额 Remaining Val.:\t88.00\n" +
                    "机号　 Device No.\t:\t1234F1\n" +
                    "\n" +
                    "\t\tDD/MM/YYYY              HH:MM:SS          交易编号: 88888\n" +
                    "\n" +
                    "\t\t\t                   收银机:001  收银员:180\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "           STAR便利店            \n" +
                    "             欢迎光临            \n" +
                    "                                 \n" +
                    "Unit 1906-08,19/F,               \n" +
                    "  Enterprise Square 2,           \n" +
                    "  3 Sheung Yuet Road,            \n" +
                    "  Kowloon Bay, KLN               \n" +
                    "                                 \n" +
                    "Tel: (852) 2795 2335             \n" +
                    "                                 \n" +
                    "货品名称             数量   价格 \n" +
                    "---------------------------------\n" +
                    "罐装可乐                         \n" +
                    "* Coke                1     7.00 \n" +
                    "纸包柠檬茶                       \n" +
                    "* Lemon Tea           2    10.00 \n" +
                    "热狗                             \n" +
                    "* Hot Dog             1    10.00 \n" +
                    "薯片(50克装)                     \n" +
                    "* Potato Chips(50g)   1    11.00 \n" +
                    "---------------------------------\n" +
                    "                                 \n" +
                    "                 总　数 :  38.00 \n" +
                    "                 现　金 :  38.00 \n" +
                    "                 找　赎 :   0.00 \n" +
                    "                                 \n" +
                    "卡号码 Card No. :     88888888   \n" +
                    "卡余额 Remaining Val. :  88.00   \n" +
                    "机号　 Device No. :     1234F1   \n" +
                    "                                 \n" +
                    "DD/MM/YYYY HH:MM:SS              \n" +
                    "交易编号: 88888                  \n" +
                    "                                 \n" +
                    "          收银机:001  收银员:180 \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                    STAR便利店                   \n" +
                    "                     欢迎光临                    \n" +
                    "                                                 \n" +
                    "Unit 1906-08,19/F, Enterprise Square 2,          \n" +
                    "  3 Sheung Yuet Road,  Kowloon Bay, KLN          \n" +
                    "                                                 \n" +
                    "Tel: (852) 2795 2335                             \n" +
                    "                                                 \n" +
                    "货品名称                      数量          价格 \n" +
                    "-------------------------------------------------\n" +
                    "罐装可乐                                         \n" +
                    "* Coke                         1            7.00 \n" +
                    "纸包柠檬茶                                       \n" +
                    "* Lemon Tea                    2           10.00 \n" +
                    "热狗                                             \n" +
                    "* Hot Dog                      1           10.00 \n" +
                    "薯片(50克装)                                     \n" +
                    "* Potato Chips(50g)            1           11.00 \n" +
                    "-------------------------------------------------\n" +
                    "                                                 \n" +
                    "                                总　数 :   38.00 \n" +
                    "                                现　金 :   38.00 \n" +
                    "                                找　赎 :    0.00 \n" +
                    "                                                 \n" +
                    "卡号码 Card No.          :              88888888 \n" +
                    "卡余额 Remaining Val.    :                 88.00 \n" +
                    "机号　 Device No.        :                1234F1 \n" +
                    "                                                 \n" +
                    "DD/MM/YYYY        HH:MM:SS       交易编号: 88888 \n" +
                    "                                                 \n" +
                    "              收银机:001  收银员:180             \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "                 STAR便利店                 \n" +
                    "                  欢迎光临                  \n" +
                    "                                            \n" +
                    "Unit 1906-08,19/F, Enterprise Square 2,     \n" +
                    "  3 Sheung Yuet Road,  Kowloon Bay, KLN     \n" +
                    "                                            \n" +
                    "Tel: (852) 2795 2335                        \n" +
                    "                                            \n" +
                    "货品名称                   数量        价格 \n" +
                    "--------------------------------------------\n" +
                    "罐装可乐                                    \n" +
                    "* Coke                      1          7.00 \n" +
                    "纸包柠檬茶                                  \n" +
                    "* Lemon Tea                 2         10.00 \n" +
                    "热狗                                        \n" +
                    "* Hot Dog                   1         10.00 \n" +
                    "薯片(50克装)                                \n" +
                    "* Potato Chips(50g)         1         11.00 \n" +
                    "--------------------------------------------\n" +
                    "                                            \n" +
                    "                           总　数 :   38.00 \n" +
                    "                           现　金 :   38.00 \n" +
                    "                           找　赎 :    0.00 \n" +
                    "                                            \n" +
                    "卡号码 Card No.          :         88888888 \n" +
                    "卡余额 Remaining Val.    :            88.00 \n" +
                    "机号　 Device No.        :           1234F1 \n" +
                    "                                            \n" +
                    "DD/MM/YYYY     HH:MM:SS     交易编号: 88888 \n" +
                    "                                            \n" +
                    "           收银机:001  收银员:180           \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                               STAR便利店                              \n" +
                    "                                欢迎光临                               \n" +
                    "                                                                       \n" +
                    "             Unit 1906-08,19/F, Enterprise Square 2,                   \n" +
                    "                        3 Sheung Yuet Road,  Kowloon Bay, KLN          \n" +
                    "                                                                       \n" +
                    "Tel: (852) 2795 2335                                                   \n" +
                    "                                                                       \n" +
                    "货品名称                                 数量                     价格 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "罐装可乐                                                               \n" +
                    "* Coke                                    1                       7.00 \n" +
                    "纸包柠檬茶                                                             \n" +
                    "* Lemon Tea                               2                      10.00 \n" +
                    "热狗                                                                   \n" +
                    "* Hot Dog                                 1                      10.00 \n" +
                    "薯片(50克装)                                                           \n" +
                    "* Potato Chips(50g)                       1                      11.00 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                                                       \n" +
                    "                                                      总　数 :   38.00 \n" +
                    "                                                      现　金 :   38.00 \n" +
                    "                                                      找　赎 :    0.00 \n" +
                    "                                                                       \n" +
                    "卡号码 Card No.          :         88888888                            \n" +
                    "卡余额 Remaining Val.    :            88.00                            \n" +
                    "机号　 Device No.        :           1234F1                            \n" +
                    "                                                                       \n" +
                    "DD/MM/YYYY                   HH:MM:SS                  交易编号: 88888 \n" +
                    "                                                                       \n" +
                    "                         收银机:001  收银员:180                        \n";
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
