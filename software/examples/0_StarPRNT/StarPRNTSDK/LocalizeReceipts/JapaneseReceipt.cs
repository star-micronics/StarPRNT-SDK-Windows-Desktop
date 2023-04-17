using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class JapaneseReceipt : LocalizeReceipt
    {
        public JapaneseReceipt()
        {
            CharacterCode = CharacterCode.Japanese;

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
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);
            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("スター電機\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("修理報告書　兼領収書\n"), 2);

            builder.AppendEmphasis(false);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "--------------------------------\n" +
                            "発行日時：YYYY年MM月DD日HH時MM分\n" +
                            "TEL：054-347-XXXX\n" +
                            "\n" +
                            "         ｲｹﾆｼ  ｼｽﾞｺ   ｻﾏ\n" +
                            "お名前：池西　静子　様\n" +
                            "御住所：静岡市清水区七ツ新屋\n" +
                            "　　　　５３６番地\n" +
                            "伝票番号：No.12345-67890\n" +
                            "\n" +
                            "　この度は修理をご用命頂き有難うございます。\n" +
                            " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                            "\n" +
                            "品名／型名　数量　金額　備考\n" +
                            "--------------------------------\n" +
                            "制御基板　　   1 10,000  配達\n" +
                            "操作スイッチ   1  3,800  配達\n" +
                            "パネル　　　   1  2,000  配達\n" +
                            "技術料　　　   1 15,000\n" +
                            "出張費用　　   1  5,000\n" +
                            "--------------------------------\n" +
                            "\n" +
                            "             小計      \\ 35,800\n" +
                            "             内税      \\  1,790\n" +
                            "             合計      \\ 37,590\n" +
                            "\n" +
                            "　お問合わせ番号　12345-67890\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

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
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);
            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("スター電機\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("修理報告書　兼領収書\n"), 2);

            builder.AppendEmphasis(false);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------------\n" +
                            "発行日時：YYYY年MM月DD日HH時MM分\n" +
                            "TEL：054-347-XXXX\n" +
                            "\n" +
                            "           ｲｹﾆｼ  ｼｽﾞｺ   ｻﾏ\n" +
                            "　お名前：池西　静子　様\n" +
                            "　御住所：静岡市清水区七ツ新屋\n" +
                            "　　　　　５３６番地\n" +
                            "　伝票番号：No.12345-67890\n" +
                            "\n" +
                            "　この度は修理をご用命頂き有難うございます。\n" +
                            " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                            "\n" +
                            "品名／型名　          数量      金額　   備考\n" +
                            "------------------------------------------------\n" +
                            "制御基板　          　  1      10,000     配達\n" +
                            "操作スイッチ            1       3,800     配達\n" +
                            "パネル　　          　  1       2,000     配達\n" +
                            "技術料　          　　  1      15,000\n" +
                            "出張費用　　            1       5,000\n" +
                            "------------------------------------------------\n" +
                            "\n" +
                            "                            小計       \\ 35,800\n" +
                            "                            内税       \\  1,790\n" +
                            "                            合計       \\ 37,590\n" +
                            "\n" +
                            "　お問合わせ番号　　12345-67890\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

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
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);
            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            //byte[] otherBytes = Encoding.UTF8.GetBytes("スター電機\n");

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("スター電機\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("修理報告書　兼領収書\n"), 2);

            builder.AppendEmphasis(false);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "発行日時：YYYY年MM月DD日HH時MM分\n" +
                            "TEL：054-347-XXXX\n" +
                            "\n" +
                            "           ｲｹﾆｼ  ｼｽﾞｺ   ｻﾏ\n" +
                            "　お名前：池西　静子　様\n" +
                            "　御住所：静岡市清水区七ツ新屋\n" +
                            "　　　　　５３６番地\n" +
                            "　伝票番号：No.12345-67890\n" +
                            "\n" +
                            "この度は修理をご用命頂き有難うございます。\n" +
                            " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                            "\n" +
                            "品名／型名　                 数量             金額　          備考\n" +
                            "---------------------------------------------------------------------\n" +
                            "制御基板　　                   1             10,000            配達\n" +
                            "操作スイッチ                   1              3,800            配達\n" +
                            "パネル　　　                   1              2,000            配達\n" +
                            "技術料　　　                   1             15,000\n" +
                            "出張費用　　                   1              5,000\n" +
                            "---------------------------------------------------------------------\n" +
                            "\n" +
                            "                                                 小計       \\ 35,800\n" +
                            "                                                 内税       \\  1,790\n" +
                            "                                                 合計       \\ 37,590\n" +
                            "\n" +
                            "　お問合わせ番号　　12345-67890\n" +
                            "\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

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
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);
            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("スター電機\n"), 3);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("修理報告書　兼領収書\n"), 2);

            builder.AppendEmphasis(false);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "発行日時：YYYY年MM月DD日HH時MM分\n" +
                            "TEL：054-347-XXXX\n" +
                            "\n" +
                            "           ｲｹﾆｼ  ｼｽﾞｺ   ｻﾏ\n" +
                            "　お名前：池西　静子　様\n" +
                            "　御住所：静岡市清水区七ツ新屋\n" +
                            "　　　　　５３６番地\n" +
                            "　伝票番号：No.12345-67890\n" +
                            "\n" +
                            "　この度は修理をご用命頂き有難うございます。\n" +
                            " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                            "\n" +
                            "品名／型名        数量      金額　   備考\n" +
                            "------------------------------------------\n" +
                            "制御基板　          1     10,000     配達\n" +
                            "操作スイッチ        1      3,800     配達\n" +
                            "パネル　　          1      2,000     配達\n" +
                            "技術料　            1     15,000\n" +
                            "出張費用　　        1      5,000\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "                      小計       \\ 35,800\n" +
                            "                      内税       \\  1,790\n" +
                            "                      合計       \\ 37,590\n" +
                            "\n" +
                            "　お問合わせ番号　　12345-67890\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

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
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);
            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendEmphasis(true);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("スター電機\n修理報告書　兼領収書\n"), 2);

            builder.AppendEmphasis(false);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "発行日時：YYYY年MM月DD日HH時MM分\n" +
                            "TEL：054-347-XXXX\n" +
                            "\n" +
                            "        ｲｹﾆｼ  ｼｽﾞｺ  ｻﾏ\n" +
                            "　お名前：池西  静子　様\n" +
                            "　御住所：静岡市清水区七ツ新屋\n" +
                            "　　　　　５３６番地\n" +
                            "　伝票番号：No.12345-67890\n" +
                            "\n" +
                            "　この度は修理をご用命頂き有難うございます。\n" +
                            " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                            "\n" +
                            "品名／型名　     数量      金額　     備考\n" +
                            "------------------------------------------\n" +
                            "制御基板　　       1      10,000     配達\n" +
                            "操作スイッチ       1       3,800     配達\n" +
                            "パネル　　　       1       2,000     配達\n" +
                            "技術料　　　       1      15,000\n" +
                            "出張費用　　       1       5,000\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "                       小計       \\ 35,800\n" +
                            "                       内税       \\  1,790\n" +
                            "                       合計       \\ 37,590\n" +
                            "\n" +
                            "　お問合わせ番号　　12345-67890\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_japanese)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "　　　　　　スター電機\n" +
                    "　　　　修理報告書　兼領収書\n" +
                    "----------------------------------------\n" +
                    "発行日時：\n" +
                    "         YYYY年MM月DD日HH時MM分\n" +
                    "TEL：054-347-XXXX\n" +
                    "\n" +
                    "　　　　　ｲｹﾆｼ  ｼｽﾞｺ  ｻﾏ\n" +
                    "　お名前  : 池西　静子　様\n" +
                    "　御住所 : 静岡市清水区七ツ新屋\n" +
                    "　　　　　５３６番地\n" +
                    "　伝票番号：No.12345-67890\n" +
                    "\n" +
                    "　この度は修理をご用命頂き有難うございます。\n" +
                    " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                    "\n" +
                    "品名／型名\t\t数量\t\t金額\n" +
                    "----------------------------------------\n" +
                    "制御基板\t\t1\t\t10,000\n" +
                    "操作スイッチ\t\t1\t\t  3,000\n" +
                    "パネル\t\t\t1\t\t  2,000\n" +
                    "技術料\t\t1\t\t15,000\n" +
                    "出張費用\t\t1\t\t  5,000\n" +
                    "----------------------------------------\n" +
                    "\n" +
                    "　　　　　　\t    小計　¥  35,800\n" +
                    "　　　　　　\t    内税　¥    1,790\n" +
                    "　　　　　　\t    合計　¥  37,590\n" +
                    "\n" +
                    "　お問合わせ番号　　12345-67890\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "                        スター電機\n" +
                    "               修理報告書  兼領収書\n" +
                    "------------------------------------------\n" +
                    "発行日時 : \n" +
                    "        YYYY年MM月DD日HH時MM分\n" +
                    "TEL :054-347-XXXX\n" +
                    "\n" +
                    "　　　　　ｲｹﾆｼ  ｼｽﾞｺ  ｻﾏ\n" +
                    "　お名前：池西　静子　様\n" +
                    "　御住所：静岡市清水区七ツ新屋\n" +
                    "　　　　　５３６番地\n" +
                    "　伝票番号：No.12345-67890\n" +
                    "\n" +
                    "　この度は修理をご用命頂き有難うございます。\n" +
                    " 今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                    "\n" +
                    "品名／型名\t数量\t金額\t   備考\n" +
                    "------------------------------------------\n" +
                    "制御基板\t1\t\t10,000\t   配達\n" +
                    "操作スイッチ\t1\t\t  3,800\t   配達\n" +
                    "パネル\t\t1\t\t  2,000\t   配達\n" +
                    "技術料\t\t1\t\t15,000\n" +
                    "出張費用\t1\t\t  5,000\n" +
                    "------------------------------------------\n" +
                    "\n" +
                    "           \t\t\t\t小計　¥ 35,800\n" +
                    "           \t\t\t\t内税　¥   1,790\n" +
                    "           \t\t\t\t合計　¥ 37,590\n" +
                    "\n" +
                    "　お問合わせ番号　　12345-67890\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "                                                スター電機\n" +
                    "                                        修理報告書　兼領収書\n" +
                    "---------------------------------------------------------------------------\n" +
                    "発行日時：YYYY年MM月DD日HH時MM分\n" +
                    "TEL：054-347-XXXX\n" +
                    "\n" +
                    "\t\t          　　　　　ｲｹﾆｼ  ｼｽﾞｺ  ｻﾏ\n" +
                    "\t\t          　お名前：池西　静子　様\n" +
                    "\t\t          　御住所：静岡市清水区七ツ新屋\n" +
                    "\t\t          　　　　　５３６番地\n" +
                    "\t\t          　伝票番号：No.12345-67890\n" +
                    "\n" +
                    "\t\t         　この度は修理をご用命頂き有難うございます。\n" +
                    "\t\t       今後も故障など発生した場合はお気軽にご連絡ください。\n" +
                    "\n" +
                    "品名／型名\t\t\t数量\t\t\t金額\t\t備考\n" +
                    "---------------------------------------------------------------------------\n" +
                    "制御基板\t\t\t1\t\t\t\t10,000\t\t配達\n" +
                    "操作スイッチ\t\t\t1\t\t\t\t  3,800\t\t配達\n" +
                    "パネル\t\t\t\t1\t\t\t\t  2,000\t\t配達\n" +
                    "技術料\t\t\t\t1\t\t\t\t15,000\n" +
                    "出張費用\t\t\t1\t\t\t\t  5,000\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\n" +
                    "　　　　　　　　　　　　　　　　　　　　　　小計　¥ 35,800\n" +
                    "　　　　　　　　　　　　　　　　　　　　　　内税　¥   1,790\n" +
                    "　　　　　　　　　　　　　　　　　　　　　　合計　¥ 37,590\n" +
                    "\n" +
                    "　お問合わせ番号　　12345-67890\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "            スター電機           \n" +
                    "       修理報告書 兼領収書       \n" +
                    "---------------------------------\n" +
                    "発行日時：                       \n" +
                    "          YYYY年MM月DD日HH時MM分 \n" +
                    "TEL：054-347-XXXX                \n" +
                    "                                 \n" +
                    "　　　　　 ｲｹﾆｼ ｼｽﾞｺ ｻﾏ          \n" +
                    "  お名前 : 池西 静子 様          \n" +
                    "  御住所 : 静岡市清水区七ツ新屋  \n" +
                    "           ５３６番地            \n" +
                    "  伝票番号 : No.12345-67890      \n" +
                    "                                 \n" +
                    "  この度は修理をご用命頂き       \n" +
                    "  有難うございます。             \n" +
                    "  今後も故障など発生した場合は   \n" +
                    "  お気軽にご連絡ください。       \n" +
                    "                                 \n" +
                    "品名／型名        数量     金額  \n" +
                    "---------------------------------\n" +
                    "制御基板           1      10,000 \n" +
                    "操作スイッチ       1       3,000 \n" +
                    "パネル             1       2,000 \n" +
                    "技術料             1      15,000 \n" +
                    "出張費用           1       5,000 \n" +
                    "---------------------------------\n" +
                    "                                 \n" +
                    "                  小計  ¥ 35,800 \n" +
                    "                  内税  ¥  1,790 \n" +
                    "                  合計  ¥ 37,590 \n" +
                    "                                 \n" +
                    "  お問合わせ番号    12345-67890  \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                    スター電機                   \n" +
                    "               修理報告書 兼領収書               \n" +
                    "-------------------------------------------------\n" +
                    "発行日時： YYYY年MM月DD日HH時MM分                \n" +
                    "TEL：054-347-XXXX                                \n" +
                    "                                                 \n" +
                    "　　　　　 ｲｹﾆｼ ｼｽﾞｺ ｻﾏ                          \n" +
                    "　お名前 : 池西 静子 様                          \n" +
                    "　御住所 : 静岡市清水区七ツ新屋                  \n" +
                    "　　　　   ５３６番地                            \n" +
                    "　伝票番号：No.12345-67890                       \n" +
                    "                                                 \n" +
                    "  この度は修理をご用命頂き有難うございます。     \n" +
                    "  今後も故障など発生した場合は                   \n" +
                    "  お気軽にご連絡ください。                       \n" +
                    "                                                 \n" +
                    "品名／型名                数量             金額  \n" +
                    "-------------------------------------------------\n" +
                    "制御基板                   1              10,000 \n" +
                    "操作スイッチ               1               3,000 \n" +
                    "パネル                     1               2,000 \n" +
                    "技術料                     1              15,000 \n" +
                    "出張費用                   1               5,000 \n" +
                    "-------------------------------------------------\n" +
                    "                                                 \n" +
                    "　　　　　　                     小計　¥  35,800 \n" +
                    "　　                             内税　¥   1,790 \n" +
                    "　　　　　　                     合計　¥  37,590 \n" +
                    "                                                 \n" +
                    "　お問合わせ番号　　12345-67890                  \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "                 スター電機                 \n" +
                    "             修理報告書 兼領収書            \n" +
                    "--------------------------------------------\n" +
                    "発行日時： YYYY年MM月DD日HH時MM分           \n" +
                    "TEL：054-347-XXXX                           \n" +
                    "                                            \n" +
                    "　　　　　 ｲｹﾆｼ ｼｽﾞｺ ｻﾏ                     \n" +
                    "　お名前 : 池西 静子 様                     \n" +
                    "　御住所 : 静岡市清水区七ツ新屋             \n" +
                    "　　　　   ５３６番地                       \n" +
                    "　伝票番号：No.12345-67890                  \n" +
                    "                                            \n" +
                    "  この度は修理をご用命頂き                  \n" +
                    "  有難うございます。                        \n" +
                    "  今後も故障など発生した場合は              \n" +
                    "  お気軽にご連絡ください。                  \n" +
                    "                                            \n" +
                    "品名／型名             数量           金額  \n" +
                    "--------------------------------------------\n" +
                    "制御基板                1            10,000 \n" +
                    "操作スイッチ            1             3,000 \n" +
                    "パネル                  1             2,000 \n" +
                    "技術料                  1            15,000 \n" +
                    "出張費用                1             5,000 \n" +
                    "--------------------------------------------\n" +
                    "                                            \n" +
                    "　　　　　　                小計　¥  35,800 \n" +
                    "　　                        内税　¥   1,790 \n" +
                    "　　　　　                  合計　¥  37,590 \n" +
                    "                                            \n" +
                    "　お問合わせ番号　　12345-67890             \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                               スター電機                              \n" +
                    "                          修理報告書 兼領収書                          \n" +
                    "-----------------------------------------------------------------------\n" +
                    "発行日時： YYYY年MM月DD日HH時MM分                                      \n" +
                    "TEL：054-347-XXXX                                                      \n" +
                    "                                                                       \n" +
                    "　　　　　 ｲｹﾆｼ ｼｽﾞｺ ｻﾏ                                                \n" +
                    "　お名前 : 池西 静子 様                                                \n" +
                    "　御住所 : 静岡市清水区七ツ新屋                                        \n" +
                    "　　　　   ５３６番地                                                  \n" +
                    "　伝票番号：No.12345-67890                                             \n" +
                    "                                                                       \n" +
                    "  この度は修理をご用命頂き有難うございます。                           \n" +
                    "  今後も故障など発生した場合はお気軽にご連絡ください。                 \n" +
                    "                                                                       \n" +
                    "品名／型名                        数量                           金額  \n" +
                    "-----------------------------------------------------------------------\n" +
                    "制御基板                            1                           10,000 \n" +
                    "操作スイッチ                        1                            3,000 \n" +
                    "パネル                              1                            2,000 \n" +
                    "技術料                              1                           15,000 \n" +
                    "出張費用                            1                            5,000 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                                                       \n" +
                    "　　　　　　                                           小計　¥  35,800 \n" +
                    "　　                                                   内税　¥   1,790 \n" +
                    "　　　　　                                             合計　¥  37,590 \n" +
                    "                                                                       \n" +
                    "　お問合わせ番号　　12345-67890                                        \n";
        }

        public override void AppendTextLabelData(ICommandBuilder builder, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);

            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.AppendUnitFeed(20 * 2);

            builder.AppendMultipleHeight(2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("〒422-8654"));

            builder.AppendUnitFeed(64);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("静岡県静岡市駿河区中吉田20番10号"));

            builder.AppendUnitFeed(64);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("スター精密株式会社"));

            builder.AppendUnitFeed(64);

            builder.AppendMultipleHeight(1);
        }

        public override string CreatePasteTextLabelString()
        {
            return "〒422-8654\n" +
                   "静岡県静岡市駿河区中吉田20番10号\n" +
                   "スター精密株式会社";
        }

        public override void AppendPasteTextLabelData(ICommandBuilder builder, string pasteText, bool utf8)
        {
            string encoding;
            if (utf8)
            {
                encoding = "UTF-8";

                builder.AppendCodePage(CodePageType.UTF8);
            }
            else
            {
                encoding = "Shift_JIS";

                builder.AppendCodePage(CodePageType.CP932);

            }

            builder.AppendInternational(InternationalType.Japan);

            builder.AppendCharacterSpace(0);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(pasteText));

        }
    }
}
