using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class TraditionalChineseReceipt : LocalizeReceipt
    {
        public TraditionalChineseReceipt()
        {
            CharacterCode = CharacterCode.TraditionalChinese;

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
                encoding = "Big5";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics\n"), 3);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("--------------------------------\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "電子發票證明聯\n" +
                            "103年01-02月\n" +
                            "EV-99999999\n"), 2, 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014/01/15 13:00\n" +
                            "隨機碼 : 9999    總計 : 999\n" +
                            "賣方 : 99999999\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendQrCode(Encoding.GetEncoding("ASCII").GetBytes("http://www.star-m.jp/eng/index.html"), QrCodeModel.No2, QrCodeLevel.Q, 5);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換請持本聯及銷貨明細表。\n" +
                            "9999999-9999999 999999-999999 9999\n" +
                            "\n"));

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("銷貨明細表 　(銷售)\n"), AlignmentPosition.Center);

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("2014-01-15 13:00:02\n"), AlignmentPosition.Right);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "烏龍袋茶2g20入       55 x2 110TX\n" +
                            "茉莉烏龍茶2g20入     55 x2 110TX\n" +
                            "天仁觀音茶2g*20      55 x2 110TX\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "      小　 計 :              330\n" +
                            "      總   計 :              330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "--------------------------------\n" +
                            "現 金                        400\n" +
                            "      找　 零 :               70\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(" 101 發票金額 :              330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014-01-15 13:00\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換、贈品及停車兌換請持本聯。\n" +
                            "9999999-9999999 999999-999999 9999\n"));

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
                encoding = "Big5";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics\n"), 3);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------------\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "電子發票證明聯\n" +
                            "103年01-02月\n" +
                            "EV-99999999\n"), 2, 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014/01/15 13:00\n" +
                            "隨機碼 : 9999    總計 : 999\n" +
                            "賣方 : 99999999\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendQrCode(Encoding.GetEncoding("ASCII").GetBytes("http://www.star-m.jp/eng/index.html"), QrCodeModel.No2, QrCodeLevel.Q, 5);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換請持本聯及銷貨明細表。\n" +
                            "9999999-9999999 999999-999999 9999\n" +
                            "\n"));

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("銷貨明細表 　(銷售)\n"), AlignmentPosition.Center);

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("2014-01-15 13:00:02\n"), AlignmentPosition.Right);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "烏龍袋茶2g20入                55 x2 110TX\n" +
                            "茉莉烏龍茶2g20入              55 x2 110TX\n" +
                            "天仁觀音茶2g*20               55 x2 110TX\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "      小　 計 :                330\n" +
                            "      總   計 :                330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------------\n" +
                            "現 金                          400\n" +
                            "      找　 零 :                 70\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(" 101 發票金額 :                330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014-01-15 13:00\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換、贈品及停車兌換請持本聯。\n" +
                            "9999999-9999999 999999-999999 9999\n"));
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
                encoding = "Big5";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics\n"), 3);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------------\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "電子發票證明聯\n" +
                            "103年01-02月\n" +
                            "EV-99999999\n"), 2, 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014/01/15 13:00\n" +
                            "隨機碼 : 9999    總計 : 999\n" +
                            "賣方 : 99999999\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendQrCode(Encoding.GetEncoding("ASCII").GetBytes("http://www.star-m.jp/eng/index.html"), QrCodeModel.No2, QrCodeLevel.Q, 5);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換請持本聯及銷貨明細表。\n" +
                            "9999999-9999999 999999-999999 9999\n" +
                            "\n"));

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("銷貨明細表 　(銷售)\n"), AlignmentPosition.Center);

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("2014-01-15 13:00:02\n"), AlignmentPosition.Right);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "烏龍袋茶2g20入                                    55 x2 110TX\n" +
                            "茉莉烏龍茶2g20入                                  55 x2 110TX\n" +
                            "天仁觀音茶2g*20                                   55 x2 110TX\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "      小　 計 :                                    330\n" +
                            "      總   計 :                                    330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "現 金                                              400\n" +
                            "      找　 零 :                                     70\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(" 101 發票金額 :                                    330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014-01-15 13:00\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換、贈品及停車兌換請持本聯。\n" +
                            "9999999-9999999 999999-999999 9999\n"));
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
                encoding = "Big5";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics\n"), 3);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "電子發票證明聯\n" +
                            "103年01-02月\n" +
                            "EV-99999999\n"), 2, 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014/01/15 13:00\n" +
                            "隨機碼 : 9999    總計 : 999\n" +
                            "賣方 : 99999999\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendQrCode(Encoding.GetEncoding("ASCII").GetBytes("http://www.star-m.jp/eng/index.html"), QrCodeModel.No2, QrCodeLevel.Q, 5);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換請持本聯及銷貨明細表。\n" +
                            "9999999-9999999 999999-999999 9999\n" +
                            "\n"));

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("銷貨明細表 　(銷售)\n"), AlignmentPosition.Center);

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("2014-01-15 13:00:02\n"), AlignmentPosition.Right);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "烏龍袋茶2g20入                55 x2 110TX\n" +
                            "茉莉烏龍茶2g20入              55 x2 110TX\n" +
                            "天仁觀音茶2g*20               55 x2 110TX\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "      小　 計 :                330\n" +
                            "      總   計 :                330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "現 金                          400\n" +
                            "      找　 零 :                 70\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(" 101 發票金額 :                330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014-01-15 13:00\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendBarcode(Encoding.GetEncoding("ASCII").GetBytes("{BStar."), BarcodeSymbology.Code128, BarcodeWidth.Mode2, 40, true);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "商品退換、贈品及停車兌換請持本聯。\n" +
                            "9999999-9999999 999999-999999 9999\n"));
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
                encoding = "Big5";
            }

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics\n"), 3);

            builder.AppendEmphasis(false);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "電子發票證明聯\n" +
                            "103年01-02月\n" +
                            "EV-99999999\n"), 2, 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014/01/15 13:00\n" +
                            "隨機碼 : 9999    總計 : 999\n" +
                            "賣方 : 99999999\n" +
                            "\n" +
                            "商品退換請持本聯及銷貨明細表。\n" +
                            "9999999-9999999 999999-999999 9999\n" +
                            "\n"));

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("銷貨明細表 　(銷售)\n"), AlignmentPosition.Center);

            builder.AppendAlignment(Encoding.GetEncoding(encoding).GetBytes("2014-01-15 13:00:02\n"), AlignmentPosition.Right);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "烏龍袋茶2g20入             55 x2 110TX\n" +
                            "茉莉烏龍茶2g20入           55 x2 110TX\n" +
                            "天仁觀音茶2g*20            55 x2 110TX\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "      小　 計 :             330\n" +
                            "      總   計 :             330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "現 金                       400\n" +
                            "      找　 零 :              70\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(" 101 發票金額 :             330\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "2014-01-15 13:00\n" +
                            "\n" +
                            "商品退換、贈品及停車兌換請持本聯。\n" +
                            "9999999-9999999 999999-999999 9999\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_traditional_chinese)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "　　　　      Star Micronics\n" +
                    "----------------------------------------\n" +
                    "                  電子發票證明聯\n" +
                    "                  103年01-02月\n" +
                    "                  EV-99999999\n" +
                    "2014/01/15 13:00\n" +
                    "隨機碼 : 9999      總計 : 999\n" +
                    "賣　方 : 99999999\n" +
                    "\n" +
                    "商品退換請持本聯及銷貨明細表。\n" +
                    "9999999-9999999 999999-999999 9999\n" +
                    "\n" +
                    "\n" +
                    "                 銷貨明細表 　(銷售)\n" +
                    "              2014-01-15 13:00:02\n" +
                    "\n" +
                    "烏龍袋茶2g20入\t\t55 x2\t110TX\n" +
                    "茉莉烏龍茶2g20入\t55 x2\t110TX\n" +
                    "天仁觀音茶2g*20\t55 x2\t110TX\n" +
                    "        小　　計 :　　         \t    330\n" +
                    "        總　　計 :　　         \t    330\n" +
                    "----------------------------------------\n" +
                    "現　金　　　                \t    400\n" +
                    "        找　　零 :　　          \t      70\n" +
                    " 101 發票金額 :　　         \t    330\n" +
                    "2014-01-15 13:00\n" +
                    "\n" +
                    "商品退換、贈品及停車兌換請持本聯。\n" +
                    "9999999-9999999 999999-999999 9999\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "\t\t       Star Micronics\n" +
                    "------------------------------------------\n" +
                    "\t\t       電子發票證明聯\n" +
                    "\t\t       103年01-02月\n" +
                    "\t\t       EV-99999999\n" +
                    "2014/01/15 13:00\n" +
                    "隨機碼 : 9999      總計 : 999\n" +
                    "賣　方 : 99999999\n" +
                    "\n" +
                    "商品退換請持本聯及銷貨明細表。\n" +
                    "9999999-9999999 999999-999999 9999\n" +
                    "\n" +
                    "\n" +
                    "\t\t       銷貨明細表 　(銷售)\n" +
                    "\t\t\t       2014-01-15 13:00:02\n" +
                    "\n" +
                    "烏龍袋茶2g20入\t\t55 x2\t110TX\n" +
                    "茉莉烏龍茶2g20入\t55 x2\t110TX\n" +
                    "天仁觀音茶2g*20\t\t55 x2\t110TX\n" +
                    " \t\t\t小　　計 :\t\t330\n" +
                    " \t\t\t總　　計 :\t\t330\n" +
                    "------------------------------------------\n" +
                    "\t\t\t現　金\t\t\t400\n" +
                    "\t\t找　　零\t :\t\t  70\n" +
                    "\t\t101 發票金額 :\t\t330\n" +
                    "2014-01-15 13:00\n" +
                    "\n" +
                    "商品退換、贈品及停車兌換請持本聯。\n" +
                    "9999999-9999999 999999-999999 9999\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "\t\t\t\t\t        Star Micronics\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\t\t\t\t\t        電子發票證明聯\n" +
                    "\t\t\t\t\t        103年01-02月\n" +
                    "\t\t\t\t\t        EV-99999999\n" +
                    "2014/01/15 13:00\n" +
                    "隨機碼 : 9999      總計 : 999\n" +
                    "賣　方 : 99999999\n" +
                    "\n" +
                    "商品退換請持本聯及銷貨明細表。\n" +
                    "9999999-9999999 999999-999999 9999\n" +
                    "\n" +
                    "\n" +
                    "\t\t\t\t\t        銷貨明細表 　(銷售)\n" +
                    "\t\t\t\t\t\t\t\t\t        2014-01-15 13:00:02\n" +
                    "\n" +
                    "烏龍袋茶2g20入\t\t\t\t\t\t55 x2\t\t\t\t110TX\n" +
                    "茉莉烏龍茶2g20入\t\t\t\t\t55 x2\t\t\t\t110TX\n" +
                    "天仁觀音茶2g*20\t\t\t\t\t\t55 x2\t\t\t\t110TX\n" +
                    "\t\t\t小　　計 :\t\t\t\t\t\t　　                  330\n" +
                    "\t\t\t總　　計 :\t\t\t\t\t\t　　                  330\n" +
                    "---------------------------------------------------------------------------\n" +
                    "現　金\t\t\t\t\t\t\t\t\t\t　　                  400\n" +
                    "\t\t\t找　　零 :\t\t\t\t\t\t　　                    70\n" +
                    "\t\t\t101 發票金額 :\t\t\t\t\t　　                  330\n" +
                    "2014-01-15 13:00\n" +
                    "\n" +
                    "商品退換、贈品及停車兌換請持本聯。\n" +
                    "9999999-9999999 999999-999999 9999\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "          Star Micronics         \n" +
                    "---------------------------------\n" +
                    "          電子發票證明聯         \n" +
                    "           103年01-02月          \n" +
                    "           EV-99999999           \n" +
                    "2014/01/15 13:00                 \n" +
                    "隨機碼 : 9999      總計 : 999    \n" +
                    "賣　方 : 99999999                \n" +
                    "                                 \n" +
                    "商品退換請持本聯及銷貨明細表。   \n" +
                    "9999999-9999999 999999-999999    \n" +
                    "9999                             \n" +
                    "                                 \n" +
                    "                                 \n" +
                    "       銷貨明細表 　(銷售)       \n" +
                    "       2014-01-15 13:00:02       \n" +
                    "                                 \n" +
                    "烏龍袋茶2g20入     55 x2   110TX \n" +
                    "茉莉烏龍茶2g20入   55 x2   110TX \n" +
                    "天仁觀音茶2g*20    55 x2   110TX \n" +
                    "    小　　計 :　             330 \n" +
                    "    總　　計 :               330 \n" +
                    "---------------------------------\n" +
                    "現　金　　　                 400 \n" +
                    "     找　　零 :　　           70 \n" +
                    " 101 發票金額 :　　          330 \n" +
                    "2014-01-15 13:00                 \n" +
                    "                                 \n" +
                    "商品退換、                       \n" +
                    "贈品及停車兌換請持本聯。         \n" +
                    "9999999-9999999 999999-999999    \n" +
                    "9999                             \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                  Star Micronics                 \n" +
                    "-------------------------------------------------\n" +
                    "                  電子發票證明聯                 \n" +
                    "                   103年01-02月                  \n" +
                    "                   EV-99999999                   \n" +
                    "2014/01/15 13:00                                 \n" +
                    "隨機碼 : 9999      總計 : 999                    \n" +
                    "賣　方 : 99999999                                \n" +
                    "                                                 \n" +
                    "商品退換請持本聯及銷貨明細表。                   \n" +
                    "9999999-9999999 999999-999999 9999               \n" +
                    "                                                 \n" +
                    "                                                 \n" +
                    "               銷貨明細表 　(銷售)               \n" +
                    "                             2014-01-15 13:00:02 \n" +
                    "                                                 \n" +
                    "烏龍袋茶2g20入             55 x2           110TX \n" +
                    "茉莉烏龍茶2g20入           55 x2           110TX \n" +
                    "天仁觀音茶2g*20            55 x2           110TX \n" +
                    "   小　　計 :　　            330                 \n" +
                    "   總　　計 :　　            330                 \n" +
                    "-------------------------------------------------\n" +
                    "現　金　　　                 400                 \n" +
                    "     找　　零 :　　           70                 \n" +
                    " 101 發票金額 :　　          330                 \n" +
                    "2014-01-15 13:00                                 \n" +
                    "                                                 \n" +
                    "商品退換、贈品及停車兌換請持本聯。               \n" +
                    "9999999-9999999 999999-999999 9999               \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "               Star Micronics               \n" +
                    "--------------------------------------------\n" +
                    "               電子發票證明聯               \n" +
                    "                103年01-02月                \n" +
                    "                 EV-99999999                \n" +
                    "2014/01/15 13:00                            \n" +
                    "隨機碼 : 9999      總計 : 999               \n" +
                    "賣　方 : 99999999                           \n" +
                    "                                            \n" +
                    "商品退換請持本聯及銷貨明細表。              \n" +
                    "9999999-9999999 999999-999999 9999          \n" +
                    "                                            \n" +
                    "                                            \n" +
                    "             銷貨明細表 　(銷售)            \n" +
                    "                        2014-01-15 13:00:02 \n" +
                    "                                            \n" +
                    "烏龍袋茶2g20入          55 x2         110TX \n" +
                    "茉莉烏龍茶2g20入        55 x2         110TX \n" +
                    "天仁觀音茶2g*20         55 x2         110TX \n" +
                    "   小　　計 :　　       330                 \n" +
                    "   總　　計 :　　       330                 \n" +
                    "--------------------------------------------\n" +
                    "現　金　　　            400                 \n" +
                    "     找　　零 :　　      70                 \n" +
                    " 101 發票金額 :　　     330                 \n" +
                    "2014-01-15 13:00                            \n" +
                    "                                            \n" +
                    "商品退換、贈品及停車兌換請持本聯。          \n" +
                    "9999999-9999999 999999-999999 9999          \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                             Star Micronics                            \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                             電子發票證明聯                            \n" +
                    "                              103年01-02月                             \n" +
                    "                              EV-99999999                              \n" +
                    "2014/01/15 13:00                                                       \n" +
                    "隨機碼 : 9999      總計 : 999                                          \n" +
                    "賣　方 : 99999999                                                      \n" +
                    "                                                                       \n" +
                    "商品退換請持本聯及銷貨明細表。                                         \n" +
                    "9999999-9999999 999999-999999 9999                                     \n" +
                    "                                                                       \n" +
                    "                                                                       \n" +
                    "                          銷貨明細表 　(銷售)                          \n" +
                    "                                                   2014-01-15 13:00:02 \n" +
                    "                                                                       \n" +
                    "烏龍袋茶2g20入                        55 x2                      110TX \n" +
                    "茉莉烏龍茶2g20入                      55 x2                      110TX \n" +
                    "天仁觀音茶2g*20                       55 x2                      110TX \n" +
                    "   小　　計 :　　                       330                            \n" +
                    "   總　　計 :　　                       330                            \n" +
                    "-----------------------------------------------------------------------\n" +
                    "現　金　　　                            400                            \n" +
                    "     找　　零 :　　                      70                            \n" +
                    " 101 發票金額 :　　                     330                            \n" +
                    "2014-01-15 13:00                                                       \n" +
                    "                                                                       \n" +
                    "商品退換、贈品及停車兌換請持本聯。                                     \n" +
                    "9999999-9999999 999999-999999 9999                                     \n";
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
