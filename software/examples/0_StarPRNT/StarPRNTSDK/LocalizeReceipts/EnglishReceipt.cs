using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class EnglishReceipt : LocalizeReceipt
    {
        public EnglishReceipt()
        {
            CharacterCode = CharacterCode.Standard;

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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Star Clothing Boutique\n" +
                            "123 Star Road\n" +
                            "City, State 12345\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Date:MM/DD/YYYY    Time:HH:MM PM\n" +
                            "--------------------------------\n" +
                            "\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SKU         Description    Total\n" +
                            "300678566   PLAIN T-SHIRT  10.99\n" +
                            "300692003   BLACK DENIM    29.99\n" +
                            "300651148   BLUE DENIM     29.99\n" +
                            "300642980   STRIPED DRESS  49.99\n" +
                            "300638471   BLACK BOOTS    35.99\n" +
                            "\n" +
                            "Subtotal                  156.95\n" +
                            "Tax                         0.00\n" +
                            "--------------------------------\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Total     "));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("   $156.95\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "--------------------------------\n" +
                            "\n" +
                            "Charge\n" +
                            "156.95\n" +
                            "Visa XXXX-XXXX-XXXX-0123\n" +
                            "\n"));

            builder.AppendInvert(Encoding.GetEncoding(encoding).GetBytes("Refunds and Exchanges\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Within "));

            builder.AppendUnderLine(Encoding.GetEncoding(encoding).GetBytes("30 days"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(" with receipt\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "And tags attached\n" +
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Star Clothing Boutique\n" +
                            "123 Star Road\n" +
                            "City, State 12345\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Date:MM/DD/YYYY                    Time:HH:MM PM\n" +
                            "------------------------------------------------\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("SALE\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SKU               Description              Total\n" +
                            "300678566         PLAIN T-SHIRT            10.99\n" +
                            "300692003         BLACK DENIM              29.99\n" +
                            "300651148         BLUE DENIM               29.99\n" +
                            "300642980         STRIPED DRESS            49.99\n" +
                            "300638471         BLACK BOOTS              35.99\n" +
                            "\n" +
                            "Subtotal                                  156.95\n" +
                            "Tax                                         0.00\n" +
                            "------------------------------------------------\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Total                       "));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("   $156.95\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------------\n" +
                            "\n" +
                            "Charge\n" +
                            "156.95\n" +
                            "Visa XXXX-XXXX-XXXX-0123\n" +
                            "\n"));

            builder.AppendInvert(Encoding.GetEncoding(encoding).GetBytes("Refunds and Exchanges\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Within "));

            builder.AppendUnderLine(Encoding.GetEncoding(encoding).GetBytes("30 days"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(" with receipt\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "And tags attached\n" +
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Star Clothing Boutique\n" +
                            "123 Star Road\n" +
                            "City, State 12345\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Date:MM/DD/YYYY                                         Time:HH:MM PM\n" +
                            "---------------------------------------------------------------------\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("SALE\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SKU                        Description                          Total\n" +
                            "300678566                  PLAIN T-SHIRT                        10.99\n" +
                            "300692003                  BLACK DENIM                          29.99\n" +
                            "300651148                  BLUE DENIM                           29.99\n" +
                            "300642980                  STRIPED DRESS                        49.99\n" +
                            "300638471                  BLACK BOOTS                          35.99\n" +
                            "\n" +
                            "Subtotal                                                       156.95\n" +
                            "Tax                                                              0.00\n" +
                            "---------------------------------------------------------------------\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Total                                            "));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("   $156.95\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "\n" +
                            "Charge\n" +
                            "156.95\n" +
                            "Visa XXXX-XXXX-XXXX-0123\n" +
                            "\n"));

            builder.AppendInvert(Encoding.GetEncoding(encoding).GetBytes("Refunds and Exchanges\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Within "));

            builder.AppendUnderLine(Encoding.GetEncoding(encoding).GetBytes("30 days"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(" with receipt\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "And tags attached\n" +
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Star Clothing Boutique\n" +
                            "123 Star Road\n" +
                            "City, State 12345\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Date:MM/DD/YYYY              Time:HH:MM PM\n" +
                            "------------------------------------------\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("SALE \n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SKU            Description           Total\n" +
                            "300678566      PLAIN T-SHIRT         10.99\n" +
                            "300692003      BLACK DENIM           29.99\n" +
                            "300651148      BLUE DENIM            29.99\n" +
                            "300642980      STRIPED DRESS         49.99\n" +
                            "300638471      BLACK BOOTS           35.99\n" +
                            "\n" +
                            "Subtotal                            156.95\n" +
                            "Tax                                   0.00\n" +
                            "------------------------------------------\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Total                 "));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("   $156.95\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "\n" +
                            "Charge\n" +
                            "156.95\n" +
                            "Visa XXXX-XXXX-XXXX-0123\n" +
                            "\n"));

            builder.AppendInvert(Encoding.GetEncoding(encoding).GetBytes("Refunds and Exchanges\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Within "));

            builder.AppendUnderLine(Encoding.GetEncoding(encoding).GetBytes("30 days"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(" with receipt\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "And tags attached\n" +
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Star Clothing Boutique\n" +
                            "123 Star Road\n" +
                            "City, State 12345\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Date:MM/DD/YYYY              Time:HH:MM PM\n" +
                            "------------------------------------------\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("SALE \n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SKU             Description          Total\n" +
                            "300678566       PLAIN T-SHIRT        10.99\n" +
                            "300692003       BLACK DENIM          29.99\n" +
                            "300651148       BLUE DENIM           29.99\n" +
                            "300642980       STRIPED DRESS        49.99\n" +
                            "300638471       BLACK BOOTS          35.99\n" +
                            "\n" +
                            "Subtotal                            156.95\n" +
                            "Tax                                   0.00\n" +
                            "------------------------------------------\n" +
                            "Total                              $156.95\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "Charge\n" +
                            "156.95\n" +
                            "Visa XXXX-XXXX-XXXX-0123\n" +
                            "\n"));

            builder.AppendInvert(Encoding.GetEncoding(encoding).GetBytes("Refunds and Exchanges\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Within "));

            builder.AppendUnderLine(Encoding.GetEncoding(encoding).GetBytes("30 days"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(" with receipt\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                   "             Star Clothing Boutique\n" +
                   "                  123 Star Road\n" +
                   "                City, State 12345\n" +
                   "\n" +
                   "Date:MM/DD/YYYY Time:HH:MM PM\n" +
                   "----------------------------------------\n" +
                   "SALE\n" +
                   "SKU\t\tDescription\t\t    Total\n" +
                   "300678566\tPLAIN T-SHIRT\t    10.99\n" +
                   "300692003\tBLACK DENIM\t    29.99\n" +
                   "300651148\tBLUE DENIM\t    29.99\n" +
                   "300642980\tSTRIPED DRESS\t    49.99\n" +
                   "30063847   BLACK BOOTS\t    35.99\n" +
                   "\n" +
                   "Subtotal\t\t\t\t  156.95\n" +
                   "Tax\t\t\t\t\t      0.00\n" +
                   "----------------------------------------\n" +
                   "Total\t\t\t\t\t$156.95\n" +
                   "----------------------------------------\n" +
                   "\n" +
                   "Charge\n" +
                   "156.95\n" +
                   "Visa XXXX-XXXX-XXXX-0123\n" +
                   "Refunds and Exchanges\n" +
                   "Within 30 days with receipt\n" +
                   "And tags attached\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "               Star Clothing Boutique\n" +
                    "                    123 Star Road\n" +
                    "                  City, State 12345\n" +
                    "\n" +
                    "Date:MM/DD/YYYY  Time:HH:MM PM\n" +
                    "------------------------------------------\n" +
                    "SALE\n" +
                    "SKU       \t\tDescription \tTotal\n" +
                    "300678566\tPLAIN T-SHIRT \t10.99\n" +
                    "300692003\tBLACK DENIM   \t29.99\n" +
                    "300651148\tBLUE DENIM    \t29.99\n" +
                    "300642980\tSTRIPED DRESS \t49.99\n" +
                    "30063847 \t\tBLACK BOOTS   \t35.99\n" +
                    "\n" +
                    "Subtotal\t\t\t\t       156.95\n" +
                    "Tax\t\t\t\t\t           0.00\n" +
                    "------------------------------------------\n" +
                    "Total\t\t\t\t              $156.95\n" +
                    "------------------------------------------\n" +
                    "\n" +
                    "Charge\n" +
                    "156.95\n" +
                    "Visa XXXX-XXXX-XXXX-0123\n" +
                    "Refunds and Exchanges\n" +
                    "Within 30 days with receipt\n" +
                    "And tags attached\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "                                      Star Clothing Boutique\n" +
                    "                                           123 Star Road\n" +
                    "                                         City, State 12345\n" +
                    "\n" +
                    "Date:MM/DD/YYYY                                                 Time:HH:MM PM\n" +
                    "---------------------------------------------------------------------------\n" +
                    "SALE\n" +
                    "SKU\t\t                              Description\t\t\t\t               Total\n" +
                    "300678566                          PLAIN T-SHIRT\t\t\t               10.99\n" +
                    "300692003                          BLACK DENIM\t\t\t               29.99\n" +
                    "300651148                          BLUE DENIM\t\t                      29.99\n" +
                    "300642980                          STRIPED DRESS\t\t\t               49.99\n" +
                    "300638471                          BLACK BOOTS\t\t\t               35.99\n" +
                    "\n" +
                    "Subtotal\t\t\t\t\t\t\t                                         156.95\n" +
                    "Tax\t\t\t\t\t\t\t                                                    0.00\n" +
                    "---------------------------------------------------------------------------\n" +
                    "Total\t\t\t\t\t\t                                              $156.95\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\n" +
                    "Charge\n" +
                    "156.95\n" +
                    "Visa XXXX-XXXX-XXXX-0123\n" +
                    "Refunds and Exchanges\n" +
                    "Within 30 days with receipt\n" +
                    "And tags attached\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                   "     Star Clothing Boutique      \n" +
                   "          123 Star Road          \n" +
                   "        City, State 12345        \n" +
                   "                                 \n" +
                   "Date:MM/DD/YYYY    Time:HH:MM PM \n" +
                   "---------------------------------\n" +
                   "SALE\n" +
                   "SKU        Description     Total \n" +
                   "300678566  PLAIN T-SHIRT   10.99 \n" +
                   "300692003  BLACK DENIM     29.99 \n" +
                   "300651148  BLUE DENIM      29.99 \n" +
                   "300642980  STRIPED DRESS   49.99 \n" +
                   "30063847   BLACK BOOTS     35.99 \n" +
                   "                                 \n" +
                   "Subtotal                  156.95 \n" +
                   "Tax                         0.00 \n" +
                   "---------------------------------\n" +
                   "Total                    $156.95 \n" +
                   "---------------------------------\n" +
                   "                                 \n" +
                   "Charge                           \n" +
                   "156.95                           \n" +
                   "Visa XXXX-XXXX-XXXX-0123         \n" +
                   "Refunds and Exchanges            \n" +
                   "Within 30 days with receipt      \n" +
                   "And tags attached                \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                   "              Star Clothing Boutique             \n" +
                   "                  123 Star Road                  \n" +
                   "                City, State 12345                \n" +
                   "                                                 \n" +
                   "Date:MM/DD/YYYY                    Time:HH:MM PM \n" +
                   "-------------------------------------------------\n" +
                   "SALE                                             \n" +
                   "SKU                 Description            Total \n" +
                   "300678566           PLAIN T-SHIRT          10.99 \n" +
                   "300692003           BLACK DENIM            29.99 \n" +
                   "300651148           BLUE DENIM             29.99 \n" +
                   "300642980           STRIPED DRESS          49.99 \n" +
                   "30063847            BLACK BOOTS            35.99 \n" +
                   "                                                 \n" +
                   "Subtotal                                  156.95 \n" +
                   "Tax                                         0.00 \n" +
                   "-------------------------------------------------\n" +
                   "Total                                    $156.95 \n" +
                   "-------------------------------------------------\n" +
                   "                                                 \n" +
                   "Charge                                           \n" +
                   "156.95                                           \n" +
                   "Visa XXXX-XXXX-XXXX-0123                         \n" +
                   "Refunds and Exchanges                            \n" +
                   "Within 30 days with receipt                      \n" +
                   "And tags attached                                \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                   "           Star Clothing Boutique           \n" +
                   "                123 Star Road               \n" +
                   "              City, State 12345             \n" +
                   "                                            \n" +
                   "Date:MM/DD/YYYY               Time:HH:MM PM \n" +
                   "--------------------------------------------\n" +
                   "SALE                                        \n" +
                   "SKU              Description          Total \n" +
                   "300678566        PLAIN T-SHIRT        10.99 \n" +
                   "300692003        BLACK DENIM          29.99 \n" +
                   "300651148        BLUE DENIM           29.99 \n" +
                   "300642980        STRIPED DRESS        49.99 \n" +
                   "30063847         BLACK BOOTS          35.99 \n" +
                   "                                            \n" +
                   "Subtotal                             156.95 \n" +
                   "Tax                                    0.00 \n" +
                   "--------------------------------------------\n" +
                   "Total                               $156.95 \n" +
                   "--------------------------------------------\n" +
                   "                                            \n" +
                   "Charge                                      \n" +
                   "156.95                                      \n" +
                   "Visa XXXX-XXXX-XXXX-0123                    \n" +
                   "Refunds and Exchanges                       \n" +
                   "Within 30 days with receipt                 \n" +
                   "And tags attached                           \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                   "                         Star Clothing Boutique                        \n" +
                   "                             123 Star Road                             \n" +
                   "                           City, State 12345                           \n" +
                   "                                                                       \n" +
                   "Date:MM/DD/YYYY                                          Time:HH:MM PM \n" +
                   "-----------------------------------------------------------------------\n" +
                   "SALE                                                                   \n" +
                   "SKU                            Description                       Total \n" +
                   "300678566                      PLAIN T-SHIRT                     10.99 \n" +
                   "300692003                      BLACK DENIM                       29.99 \n" +
                   "300651148                      BLUE DENIM                        29.99 \n" +
                   "300642980                      STRIPED DRESS                     49.99 \n" +
                   "30063847                       BLACK BOOTS                       35.99 \n" +
                   "                                                                       \n" +
                   "Subtotal                                                        156.95 \n" +
                   "Tax                                                               0.00 \n" +
                   "-----------------------------------------------------------------------\n" +
                   "Total                                                          $156.95 \n" +
                   "-----------------------------------------------------------------------\n" +
                   "                                                                       \n" +
                   "Charge                                                                 \n" +
                   "156.95                                                                 \n" +
                   "Visa XXXX-XXXX-XXXX-0123                                               \n" +
                   "Refunds and Exchanges                                                  \n" +
                   "Within 30 days with receipt                                            \n" +
                   "And tags attached                                                      \n";
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.AppendUnitFeed(20 * 2);

            builder.AppendMultipleHeight(2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Star Micronics America, Inc."));

            builder.AppendUnitFeed(64);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("65 Clyde Road Suite G"));

            builder.AppendUnitFeed(64);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Somerset, NJ 08873-3485 U.S.A"));

            builder.AppendUnitFeed(64);

            builder.AppendMultipleHeight(1);
        }

        public override string CreatePasteTextLabelString()
        {
            return "Star Micronics America, Inc.\n" +
                   "65 Clyde Road Suite G\n" +
                   "Somerset, NJ 08873-3485 U.S.A";
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
                encoding = "ASCII";

                builder.AppendCodePage(CodePageType.CP998);
            }

            builder.AppendInternational(InternationalType.USA);

            builder.AppendCharacterSpace(0);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(pasteText));
        }
    }
}
