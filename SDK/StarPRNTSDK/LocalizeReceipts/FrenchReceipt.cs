using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class FrenchReceipt : LocalizeReceipt
    {
        public FrenchReceipt()
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
                encoding = "Windows-1252";

                builder.AppendCodePage(CodePageType.CP1252);
            }

            builder.AppendInternational(InternationalType.France);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics Communications\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "AVENUE LA MOTTE PICQUET\n" +
                        "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "--------------------------------\n" +
                        "Date   : MM/DD/YYYY\n" +
                        "Heure  : HH:MM\n" +
                        "Boutique: OLUA23    Caisse: 0001\n" +
                        "Conseiller: 002970  Ticket: 3881\n" +
                        "--------------------------------\n" +
                        "\n" +
                        "Vous avez été servi par : Souad\n" +
                        "\n" +
                        "CAC IPHONE\n" +
                        "3700615033581 1 X 19.99€  19.99€\n" +
                        "\n" +
                        "dont contribution\n" +
                        " environnementale :\n" +
                        "CAC IPHONE                 0.01€\n" +
                        "--------------------------------\n" +
                        "1 Piéce(s) Total :        19.99€\n" +
                        "Mastercard Visa  :        19.99€\n" +
                        "\n" +
                        "Taux TVA    Montant H.T.   T.V.A\n" +
                        "  20%          16.66€      3.33€\n" +
                        "\n"));


            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "Merci de votre visite et.\n" +
                        "à bientôt.\n" +
                        "Conservez votre ticket il\n" +
                        "vous sera demandé pour\n" +
                        "tout échange.\n" +
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
                encoding = "Windows-1252";

                builder.AppendCodePage(CodePageType.CP1252);
            }

            builder.AppendInternational(InternationalType.France);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics Communications\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "AVENUE LA MOTTE PICQUET\n" +
                        "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "------------------------------------------------\n" +
                        "Date: MM/DD/YYYY    Heure: HH:MM\n" +
                        "Boutique: OLUA23    Caisse: 0001\n" +
                        "Conseiller: 002970  Ticket: 3881\n" +
                        "------------------------------------------------\n" +
                        "\n" +
                        "Vous avez été servi par : Souad\n" +
                        "\n" +
                        "CAC IPHONE\n" +
                        "3700615033581   1    X     19.99€         19.99€\n" +
                        "\n" +
                        "dont contribution environnementale :\n" +
                        "CAC IPHONE                                 0.01€\n" +
                        "------------------------------------------------\n" +
                        "1 Piéce(s) Total :                        19.99€\n" +
                        "Mastercard Visa  :                        19.99€\n" +
                        "\n" +
                        "Taux TVA    Montant H.T.   T.V.A\n" +
                        "  20%          16.66€      3.33€\n" +
                        "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);


            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "Merci de votre visite et. à bientôt.\n" +
                        "Conservez votre ticket il\n" +
                        "vous sera demandé pour tout échange.\n"));

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
                encoding = "Windows-1252";

                builder.AppendCodePage(CodePageType.CP1252);
            }

            builder.AppendInternational(InternationalType.France);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics Communications\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "AVENUE LA MOTTE PICQUET\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "Date: MM/DD/YYYY    Heure: HH:MM\n" +
                            "Boutique: OLUA23    Caisse: 0001\n" +
                            "Conseiller: 002970  Ticket: 3881\n" +
                            "---------------------------------------------------------------------\n" +
                            "\n" +
                            "Vous avez été servi par : Souad\n" +
                            "\n" +
                            "CAC IPHONE\n" +
                            "3700615033581   1    X     19.99€                              19.99€\n" +
                            "\n" +
                            "dont contribution environnementale :\n" +
                            "CAC IPHONE                                                      0.01€\n" +
                            "---------------------------------------------------------------------\n" +
                            "1 Piéce(s) Total :                                             19.99€\n" +
                            "Mastercard Visa  :                                             19.99€\n" +
                            "\n" +
                            "Taux TVA    Montant H.T.   T.V.A\n" +
                            "  20%          16.66€      3.33€\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Merci de votre visite et. à bientôt.\n" +
                            "Conservez votre ticket il\n" +
                            "vous sera demandé pour tout échange.\n"));

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
                encoding = "Windows-1252";

                builder.AppendCodePage(CodePageType.CP1252);
            }

            builder.AppendInternational(InternationalType.France);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics Communications\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "AVENUE LA MOTTE PICQUET\n" +
                        "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "------------------------------------------\n" +
                        "Date: MM/DD/YYYY    Heure: HH:MM\n" +
                        "Boutique: OLUA23    Caisse: 0001\n" +
                        "Conseiller: 002970  Ticket: 3881\n" +
                        "------------------------------------------\n" +
                        "\n" +
                        "Vous avez été servi par : Souad\n" +
                        "\n" +
                        "CAC IPHONE\n" +
                        "3700615033581   1    X   19.99€     19.99€\n" +
                        "\n" +
                        "dont contribution environnementale :\n" +
                        "CAC IPHONE                           0.01€\n" +
                        "------------------------------------------\n" +
                        "1 Piéce(s) Total :                  19.99€\n" +
                        "Mastercard Visa  :                  19.99€\n" +
                        "\n" +
                        "Taux TVA    Montant H.T.   T.V.A\n" +
                        "  20%          16.66€      3.33€\n" +
                        "\n"));


            builder.AppendAlignment(AlignmentPosition.Center);


            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                        "Merci de votre visite et. à bientôt.\n" +
                        "Conservez votre ticket il\n" +
                        "vous sera demandé pour tout échange.\n"));

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
                encoding = "Windows-1252";

                builder.AppendCodePage(CodePageType.CP1252);
            }

            builder.AppendInternational(InternationalType.France);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("Star Micronics Communications\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "AVENUE LA MOTTE PICQUET\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "Date: MM/DD/YYYY    Heure: HH:MM\n" +
                            "Boutique: OLUA23    Caisse: 0001\n" +
                            "Conseiller: 002970  Ticket: 3881\n" +
                            "------------------------------------------\n" +
                            "\n" +
                            "Vous avez été servi par : Souad\n" +
                            "\n" +
                            "CAC IPHONE\n" +
                            "3700615033581 1 X 19.99€            19.99€\n" +
                            "\n" +
                            "dont contribution environnementale :\n" +
                            "CAC IPHONE                           0.01€\n" +
                            "------------------------------------------\n" +
                            "1 Piéce(s) Total :                  19.99€\n" +
                            "Mastercard Visa  :                  19.99€\n" +
                            "\n" +
                            "Taux TVA    Montant H.T.   T.V.A\n" +
                            "  20%          16.66€      3.33€\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Merci de votre visite et. à bientôt.\n" +
                            "Conservez votre ticket il\n" +
                            "vous sera demandé pour tout échange.\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_french)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "                Star Micronics\n" +
                    "                 Communications\n" +
                    "             AVENUE LA MOTTE\n" +
                    "           PICQUET City, State 12345\n" +
                    "\n" +
                    "----------------------------------------\n" +
                    "Date\t\t: MM/DD/YYYY\n" +
                    "Time\t\t: HH:MM PM\n" +
                    "Boutique\t: OLUA23\n" +
                    "Caisse\t: 0001\n" +
                    "Conseiller\t: 002970\n" +
                    "Ticket\t: 3881\n" +
                    "----------------------------------------\n" +
                    "Vous avez été servi par :\n" +
                    "\t\t\t\t\tSouad\n" +
                    "CAC IPHONE\n" +
                    "3700615033581 1 X\t\t19.99€\n" +
                    "\t\t\t\t\t19.99€\n" +
                    "dont contribution\n" +
                    " environnementale :\n" +
                    "CAC IPHONE\t\t  0.01€\n" +
                    "----------------------------------------\n" +
                    " 1 Piéce(s) Total :\t\t\t19.99€\n" +
                    "\n" +
                    "  Mastercard Visa :\t\t19.99€\n" +
                    "Taux TVA Montant H.T.\n" +
                    "     20%           16.66€\n" +
                    "T.V.A\n" +
                    "3.33€\n" +
                    "Merci de votre visite et.\n" +
                    "à bientôt.\n" +
                    "Conservez votre ticket il\n" +
                    "vous sera demandé pour\n" +
                    "tout échange.\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "                 Star Micronics\n" +
                    "                 Communications\n" +
                    "                 AVENUE LA MOTTE\n" +
                    "             PICQUET City, State 12345\n" +
                    "\n" +
                    "------------------------------------------\n" +
                    "Date: MM/DD/YYYY Time:HH:MM PM\n" +
                    "Boutique\t: OLUA23 Caisse\t: 0001\n" +
                    "Conseiller\t: 002970  Ticket\t: 3881\n" +
                    "------------------------------------------\n" +
                    "Vous avez été servi par : Souad\n" +
                    "CAC IPHONE\n" +
                    "3700615033581   1 X 19.99€     19.99€\n" +
                    "dont contribution environnementale :\n" +
                    "CAC IPHONE                       0.01€\n" +
                    "------------------------------------------\n" +
                    "\t\t  1 Piéce(s)    Total :\t 19.99€\n" +
                    "\n" +
                    "\t\t     Mastercard Visa  :\t 19.99€\n" +
                    "\t\tTaux TVA  Montant H.T. T.V.A\n" +
                    "\t\t          20%    16.66€\t   3.33€\n" +
                    "\tMerci de votre visite et. à bientôt.\n" +
                    "\tConservez votre ticket il vous sera\n" +
                    "\tdemandé pour tout échange.\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "                                         Star Micronics\n" +
                    "                                         Communications\n" +
                    "                  AVENUE LA MOTTE PICQUET City, State 12345\n" +
                    "\n" +
                    "---------------------------------------------------------------------------\n" +
                    "                      Date\t : MM/DD/YYYY\tTime\t : HH:MM PM\n" +
                    "                  Boutique\t : OLUA23\t\tCaisse\t : 0001\n" +
                    "                Conseiller\t : 002970\t\tTicket\t : 3881\n" +
                    "---------------------------------------------------------------------------\n" +
                    "Vous avez été servi par : Souad\n" +
                    "CAC IPHONE\n" +
                    "3700615033581      \t\t1  X  19.99€                  \t\t19.99€\n" +
                    "dont contribution environnementale :\n" +
                    "CAC IPHONE                                        \t\t\t\t  0.01€\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\t\t\t\t\t        1 Piéce(s)    Total :                   19.99€\n" +
                    "\n" +
                    "\t\t\t\t\t        Mastercard Visa  :                   19.99€\n" +
                    "\t\t\t\t                           Taux TVA  Montant H.T. T.V.A\n" +
                    "\t\t\t\t                              20%         16.66€\t 3.33€\n" +
                    "\t\t          Merci de votre visite et. à bientôt.\n" +
                    "\t\t          Conservez votre ticket il vous sera demandé pour\n" +
                    "\t\t          tout échange.\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "          Star Micronics         \n" +
                    "          Communications         \n" +
                    "         AVENUE LA MOTTE         \n" +
                    "    PICQUET City, State 12345    \n" +
                    "                                 \n" +
                    "---------------------------------\n" +
                    "Date : MM/DD/YYYY                \n" +
                    "Time : HH:MM PM                  \n" +
                    "Boutique : OLUA23                \n" +
                    "Caisse : 0001                    \n" +
                    "Conseiller : 002970              \n" +
                    "Ticket : 3881                    \n" +
                    "---------------------------------\n" +
                    "Vous avez été servi par :        \n" +
                    "                           Souad \n" +
                    "CAC IPHONE                       \n" +
                    "3700615033581 1 X         19.99€ \n" +
                    "                          19.99€ \n" +
                    "dont contribution                \n" +
                    " environnementale :              \n" +
                    "CAC IPHONE                 0.01€ \n" +
                    "---------------------------------\n" +
                    " 1 Piéce(s) Total :       19.99€ \n" +
                    "                                 \n" +
                    "  Mastercard Visa :       19.99€ \n" +
                    "Taux TVA Montant H.T.            \n" +
                    "     20%       16.66€            \n" +
                    "T.V.A                            \n" +
                    "3.33€                            \n" +
                    "Merci de votre visite et.        \n" +
                    "à bientôt.                       \n" +
                    "Conservez votre ticket il        \n" +
                    "vous sera demandé pour           \n" +
                    "tout échange.                    \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                  Star Micronics                 \n" +
                    "                  Communications                 \n" +
                    "                 AVENUE LA MOTTE                 \n" +
                    "            PICQUET City, State 12345            \n" +
                    "                                                 \n" +
                    "-------------------------------------------------\n" +
                    "Date: MM/DD/YYYY                   Time:HH:MM PM \n" +
                    "Boutique : OLUA23                  Caisse : 0001 \n" +
                    "Conseiller : 002970                Ticket : 3881 \n" +
                    "-------------------------------------------------\n" +
                    "Vous avez été servi par : Souad                  \n" +
                    "CAC IPHONE                                       \n" +
                    "3700615033581             1 X 19.99€      19.99€ \n" +
                    "dont contribution environnementale :             \n" +
                    "CAC IPHONE                                 0.01€ \n" +
                    "-------------------------------------------------\n" +
                    "    1 Piéce(s)            Total  :        19.99€ \n" +
                    "                                                 \n" +
                    "                     Mastercard Visa  :   19.99€ \n" +
                    "                 Taux TVA   Montant  H.T.  T.V.A \n" +
                    "                      20%          16.66€  3.33€ \n" +
                    "            Merci de votre visite et. à bientôt. \n" +
                    "             Conservez votre ticket il vous sera \n" +
                    "                      demandé pour tout échange. \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "               Star Micronics               \n" +
                    "               Communications               \n" +
                    "               AVENUE LA MOTTE              \n" +
                    "          PICQUET City, State 12345         \n" +
                    "                                            \n" +
                    "--------------------------------------------\n" +
                    "Date: MM/DD/YYYY              Time:HH:MM PM \n" +
                    "Boutique : OLUA23             Caisse : 0001 \n" +
                    "Conseiller : 002970           Ticket : 3881 \n" +
                    "--------------------------------------------\n" +
                    "Vous avez été servi par : Souad             \n" +
                    "CAC IPHONE                                  \n" +
                    "3700615033581        1 X 19.99€      19.99€ \n" +
                    "dont contribution environnementale :        \n" +
                    "CAC IPHONE                            0.01€ \n" +
                    "--------------------------------------------\n" +
                    "    1 Piéce(s)         Total  :      19.99€ \n" +
                    "                                            \n" +
                    "                Mastercard Visa  :   19.99€ \n" +
                    "            Taux TVA   Montant  H.T.  T.V.A \n" +
                    "                 20%          16.66€  3.33€ \n" +
                    "       Merci de votre visite et. à bientôt. \n" +
                    "        Conservez votre ticket il vous sera \n" +
                    "                 demandé pour tout échange. \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                             Star Micronics                            \n" +
                    "                             Communications                            \n" +
                    "               AVENUE LA MOTTE PICQUET City, State 12345               \n" +
                    "                                                                       \n" +
                    "-----------------------------------------------------------------------\n" +
                    "           Date: MM/DD/YYYY                              Time:HH:MM PM \n" +
                    "           Boutique : OLUA23                             Caisse : 0001 \n" +
                    "           Conseiller : 002970                           Ticket : 3881 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "Vous avez été servi par : Souad                                        \n" +
                    "CAC IPHONE                                                             \n" +
                    "3700615033581                     1 X 19.99€                    19.99€ \n" +
                    "dont contribution environnementale :                                   \n" +
                    "CAC IPHONE                                                       0.01€ \n" +
                    "-----------------------------------------------------------------------\n" +
                    "       1 Piéce(s)                Total  :                       19.99€ \n" +
                    "                                                                       \n" +
                    "                            Mastercard Visa  :                  19.99€ \n" +
                    "                             Taux TVA            Montant  H.T.   T.V.A \n" +
                    "                                  20%                   16.66€   3.33€ \n" +
                    "                                  Merci de votre visite et. à bientôt. \n" +
                    "                                   Conservez votre ticket il vous sera \n" +
                    "                                            demandé pour tout échange. \n";
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
