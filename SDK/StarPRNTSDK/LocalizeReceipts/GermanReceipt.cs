using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class GermanReceipt : LocalizeReceipt
    {
        public GermanReceipt()
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

            builder.AppendInternational(InternationalType.Germany);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR\n" +
                            "Supermarkt\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Das Internet von seiner\n" +
                            "genussvollsten Seite\n" +
                            "\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("www.Star-EMEM.com\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Gebührenfrei Rufnummer:\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("08006646701\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("--------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("EUR\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Schmand 24%                 0.42\n" +
                            "Kefir                       0.79\n" +
                            "Haarspray                   1.79\n" +
                            "Gurken ST                   0.59\n" +
                            "Mandelknacker               1.59\n" +
                            "Mandelknacker               1.59\n" +
                            "Nussecken                   1.69\n" +
                            "Nussecken                   1.69\n" +
                            "Clemen.1kg NZ               1.49\n" +
                            "2X\n" +
                            "Zitronen ST                 1.18\n" +
                            "4X\n" +
                            "Grapefruit                  3.16\n" +
                            "Party Garnelen              9.79\n" +
                            "Apfelsaft                   1.39\n" +
                            "Lauchzw./Schl.B             0.49\n" +
                            "Butter                      1.19\n" +
                            "Profi-Haartrockner         27.99\n" +
                            "Mozarella 45%               0.59\n" +
                            "Mozarella 45%               0.59\n" +
                            "Bruschetta Brot             0.59\n" +
                            "Weizenmehl                  0.39\n" +
                            "Jodsalz                     0.19\n" +
                            "Eier M braun Bod            1.79\n" +
                            "Schlagsahne                 1.69\n" +
                            "Schlagsahne                 1.69\n" +
                            "\n" +
                            "Rueckgeld              EUR  0.00\n" +
                            "\n" +
                            "19.00% MwSt.               13.14\n" +
                            "NETTO-UMSATZ               82.33\n" +
                            "--------------------------------\n" +
                            "KontoNr:  0551716000 / 0 / 0512\n" +
                            "BLZ:      58862159\n" +
                            "Trace-Nr: 027929\n" +
                            "Beleg:    7238\n" +
                            "--------------------------------\n" +
                            "Kas: 003/006    Bon  0377 PC01 P\n" +
                            "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "USt–ID:    DE125580123\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "Vielen dank\n" +
                            "für Ihren Einkauf!\n" +
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

            builder.AppendInternational(InternationalType.Germany);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR\n" +
                            "Supermarkt\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Das Internet von seiner genussvollsten Seite\n" +
                            "\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("www.Star-EMEM.com\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Gebührenfrei Rufnummer:\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("08006646701\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("EUR\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Schmand 24%                                 0.42\n" +
                            "Kefir                                       0.79\n" +
                            "Haarspray                                   1.79\n" +
                            "Gurken ST                                   0.59\n" +
                            "Mandelknacker                               1.59\n" +
                            "Mandelknacker                               1.59\n" +
                            "Nussecken                                   1.69\n" +
                            "Nussecken                                   1.69\n" +
                            "Clemen.1kg NZ                               1.49\n" +
                            "2X\n" +
                            "Zitronen ST                                 1.18\n" +
                            "4X\n" +
                            "Grapefruit                                  3.16\n" +
                            "Party Garnelen                              9.79\n" +
                            "Apfelsaft                                   1.39\n" +
                            "Lauchzw./Schl.B                             0.49\n" +
                            "Butter                                      1.19\n" +
                            "Profi-Haartrockner                         27.99\n" +
                            "Mozarella 45%                               0.59\n" +
                            "Mozarella 45%                               0.59\n" +
                            "Bruschetta Brot                             0.59\n" +
                            "Weizenmehl                                  0.39\n" +
                            "Jodsalz                                     0.19\n" +
                            "Eier M braun Bod                            1.79\n" +
                            "Schlagsahne                                 1.69\n" +
                            "Schlagsahne                                 1.69\n" +
                            "\n" +
                            "Rueckgeld                              EUR  0.00\n" +
                            "\n" +
                            "19.00% MwSt.                               13.14\n" +
                            "NETTO-UMSATZ                               82.33\n" +
                            "------------------------------------------------\n" +
                            "KontoNr:  0551716000 / 0 / 0512\n" +
                            "BLZ:      58862159\n" +
                            "Trace-Nr: 027929\n" +
                            "Beleg:    7238\n" +
                            "------------------------------------------------\n" +
                            "Kas: 003/006    Bon  0377 PC01 P\n" +
                            "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "USt–ID:    DE125580123\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "Vielen dank\n" +
                            "für Ihren Einkauf!\n" +
                            "\n"));

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

            builder.AppendInternational(InternationalType.Germany);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR\n" +
                            "Supermarkt\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Das Internet von seiner genussvollsten Seite\n" +
                            "\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("www.Star-EMEM.com\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Gebührenfrei Rufnummer:\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("08006646701\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("---------------------------------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("EUR\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Schmand 24%                                                      0.42\n" +
                            "Kefir                                                            0.79\n" +
                            "Haarspray                                                        1.79\n" +
                            "Gurken ST                                                        0.59\n" +
                            "Mandelknacker                                                    1.59\n" +
                            "Mandelknacker                                                    1.59\n" +
                            "Nussecken                                                        1.69\n" +
                            "Nussecken                                                        1.69\n" +
                            "Clemen.1kg NZ                                                    1.49\n" +
                            "2X\n" +
                            "Zitronen ST                                                      1.18\n" +
                            "4X\n" +
                            "Grapefruit                                                       3.16\n" +
                            "Party Garnelen                                                   9.79\n" +
                            "Apfelsaft                                                        1.39\n" +
                            "Lauchzw./Schl.B                                                  0.49\n" +
                            "Butter                                                           1.19\n" +
                            "Profi-Haartrockner                                              27.99\n" +
                            "Mozarella 45%                                                    0.59\n" +
                            "Mozarella 45%                                                    0.59\n" +
                            "Bruschetta Brot                                                  0.59\n" +
                            "Weizenmehl                                                       0.39\n" +
                            "Jodsalz                                                          0.19\n" +
                            "Eier M braun Bod                                                 1.79\n" +
                            "Schlagsahne                                                      1.69\n" +
                            "Schlagsahne                                                      1.69\n" +
                            "\n" +
                            "Rueckgeld                                                   EUR  0.00\n" +
                            "\n" +
                            "19.00% MwSt.                                                    13.14\n" +
                            "NETTO-UMSATZ                                                    82.33\n" +
                            "---------------------------------------------------------------------\n" +
                            "KontoNr:  0551716000 / 0 / 0512\n" +
                            "BLZ:      58862159\n" +
                            "Trace-Nr: 027929\n" +
                            "Beleg:    7238\n" +
                            "---------------------------------------------------------------------\n" +
                            "Kas: 003/006    Bon  0377 PC01 P\n" +
                            "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "USt–ID:    DE125580123\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "Vielen dank\n" +
                            "für Ihren Einkauf!\n" +
                            "\n"));

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

            builder.AppendInternational(InternationalType.Germany);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR\n" +
                            "Supermarkt\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Das Internet von seiner\n" +
                            "genussvollsten Seite\n" +
                            "\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("www.Star-EMEM.com\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Gebührenfrei Rufnummer:\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("08006646701\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("EUR\n"));

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Schmand 24%                           0.42\n" +
                            "Kefir                                 0.79\n" +
                            "Haarspray                             1.79\n" +
                            "Gurken ST                             0.59\n" +
                            "Mandelknacker                         1.59\n" +
                            "Mandelknacker                         1.59\n" +
                            "Nussecken                             1.69\n" +
                            "Nussecken                             1.69\n" +
                            "Clemen.1kg NZ                         1.49\n" +
                            "2X\n" +
                            "Zitronen ST                           1.18\n" +
                            "4X\n" +
                            "Grapefruit                            3.16\n" +
                            "Party Garnelen                        9.79\n" +
                            "Apfelsaft                             1.39\n" +
                            "Lauchzw./Schl.B                       0.49\n" +
                            "Butter                                1.19\n" +
                            "Profi-Haartrockner                   27.99\n" +
                            "Mozarella 45%                         0.59\n" +
                            "Mozarella 45%                         0.59\n" +
                            "Bruschetta Brot                       0.59\n" +
                            "Weizenmehl                            0.39\n" +
                            "Jodsalz                               0.19\n" +
                            "Eier M braun Bod                      1.79\n" +
                            "Schlagsahne                           1.69\n" +
                            "Schlagsahne                           1.69\n" +
                            "\n" +
                            "Rueckgeld                        EUR  0.00\n" +
                            "\n" +
                            "19.00% MwSt.                         13.14\n" +
                            "NETTO-UMSATZ                         82.33\n" +
                            "------------------------------------------\n" +
                            "KontoNr:  0551716000 / 0 / 0512\n" +
                            "BLZ:      58862159\n" +
                            "Trace-Nr: 027929\n" +
                            "Beleg:    7238\n" +
                            "------------------------------------------\n" +
                            "Kas: 003/006    Bon  0377 PC01 P\n" +
                            "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "USt–ID:    DE125580123\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "Vielen dank\n" +
                            "für Ihren Einkauf!\n" +
                            "\n"));

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

            builder.AppendInternational(InternationalType.Germany);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "STAR\n" +
                            "Supermarkt\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "\n" +
                            "Das Internet von seiner\n" +
                            "genussvollsten Seite\n" +
                            "\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("www.Star-EMEM.com\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("Gebührenfrei Rufnummer:\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("08006646701\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes("EUR\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Schmand 24%                           0.42\n" +
                            "Kefir                                 0.79\n" +
                            "Haarspray                             1.79\n" +
                            "Gurken ST                             0.59\n" +
                            "Mandelknacker                         1.59\n" +
                            "Mandelknacker                         1.59\n" +
                            "Nussecken                             1.69\n" +
                            "Nussecken                             1.69\n" +
                            "Clemen.1kg NZ                         1.49\n" +
                            "2X\n" +
                            "Zitronen ST                           1.18\n" +
                            "4X\n" +
                            "Grapefruit                            3.16\n" +
                            "Party Garnelen                        9.79\n" +
                            "Apfelsaft                             1.39\n" +
                            "Lauchzw./Schl.B                       0.49\n" +
                            "Butter                                1.19\n" +
                            "Profi-Haartrockner                   27.99\n" +
                            "Mozarella 45%                         0.59\n" +
                            "Mozarella 45%                         0.59\n" +
                            "Bruschetta Brot                       0.59\n" +
                            "Weizenmehl                            0.39\n" +
                            "Jodsalz                               0.19\n" +
                            "Eier M braun Bod                      1.79\n" +
                            "Schlagsahne                           1.69\n" +
                            "Schlagsahne                           1.69\n" +
                            "\n" +
                            "Rueckgeld                        EUR  0.00\n" +
                            "\n" +
                            "19.00% MwSt.                         13.14\n" +
                            "NETTO-UMSATZ                         82.33\n" +
                            "------------------------------------------\n" +
                            "KontoNr:  0551716000 / 0 / 0512\n" +
                            "BLZ:      58862159\n" +
                            "Trace-Nr: 027929\n" +
                            "Beleg:    7238\n" +
                            "------------------------------------------\n" +
                            "Kas: 003/006    Bon  0377 PC01 P\n" +
                            "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "USt–ID:    DE125580123\n" +
                            "\n"));

            builder.AppendEmphasis(Encoding.GetEncoding(encoding).GetBytes(
                            "Vielen dank\n" +
                            "für Ihren Einkauf!\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_german)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "                         STAR\n" +
                    "                    Supermarkt\n" +
                    "\n" +
                    "             Das Internet von seiner\n" +
                    "               genussvollsten Seite\n" +
                    "\n" +
                    "                www.Star-EMEM.com\n" +
                    "            Gebührenfrei Rufnummer:\n" +
                    "                   08006646701\n" +
                    "----------------------------------------\n" +
                    "\t                                        EUR\n" +
                    "Schmand 24%\t\t\t   0.42\n" +
                    "Kefir\t\t\t\t\t   0.79\n" +
                    "Haarspray\t\t\t\t   1.79\n" +
                    "Gurken ST\t\t\t\t   0.59\n" +
                    "Mandelknacker\t\t\t   1.59\n" +
                    "Mandelknacker\t\t\t   1.59\n" +
                    "Nussecken\t\t\t\t   1.69\n" +
                    "Nussecken\t\t\t\t   1.69\n" +
                    "Clemen.1kg NZ\t\t\t   1.49\n" +
                    "2X\n" +
                    "Zitronen ST\t\t\t   1.18\n" +
                    "4X\n" +
                    "Grapefruit\t\t\t\t   3.16\n" +
                    "Party Garnelen\t\t\t   9.79\n" +
                    "Apfelsaft\t\t\t\t   1.39\n" +
                    "Lauchzw./Schl.B\t\t\t   0.49\n" +
                    "Butter\t\t\t\t   1.19\n" +
                    "Profi-Haartrockner\t\t 27.99\n" +
                    "Mozarella 45%\t\t\t   0.59\n" +
                    "Mozarella 45%\t\t\t   0.59\n" +
                    "Bruschetta Brot\t\t\t   0.59\n" +
                    "Weizenmehl\t\t\t   0.39\n" +
                    "Jodsalz\t\t\t\t   0.19\n" +
                    "Eier M braun Bod\t\t\t   1.79\n" +
                    "Schlagsahne\t\t\t   1.69\n" +
                    "Schlagsahne\t\t\t   1.69\n" +
                    "\n" +
                    "Rueckgeld\t\t\t    EUR  0.00\n" +
                    "\n" +
                    "19.00% MwSt.\t\t\t 13.14\n" +
                    "NETTO-UMSATZ\t\t\t 82.33\n" +
                    "----------------------------------------\n" +
                    "KontoNr: 0551716000/0/0512\n" +
                    "BLZ:     58862159\n" +
                    "Trace-Nr:027929\n" +
                    "Beleg:   7238\n" +
                    "----------------------------------------\n" +
                    "Kas:003/006 Bon0377 PC01 P\n" +
                    "Dat:30.03.2015\n" +
                    "Zeit18:06:01            43\n" +
                    "\n" +
                    "            USt–ID:    DE125580123\n" +
                    "\n" +
                    "                    Vielen dank\n" +
                    "                 für Ihren Einkauf!\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                "\t                      STAR\n" +
                "\t                Supermarkt\n" +
                "\n" +
                "\t       Das Internet von seiner\n" +
                "\t         genussvollsten Seite\n" +
                "\n" +
                "\t          www.Star-EMEM.com\n" +
                "\t       Gebührenfrei Rufnummer:\n" +
                "\t             08006646701\n" +
               "------------------------------------------\n" +
                "\t\t\t                                EUR\n" +
                "Schmand 24%\t\t                  0.42\n" +
                "Kefir\t\t\t                         0.79\n" +
                "Haarspray\t\t                         1.79\n" +
                "Gurken ST\t\t                         0.59\n" +
                "Mandelknacker\t\t                  1.59\n" +
                "Mandelknacker\t\t                  1.59\n" +
                "Nussecken\t\t                         1.69\n" +
                "Nussecken\t\t                         1.69\n" +
                "Clemen.1kg NZ\t\t                  1.49\n" +
                "2X\n" +
                "Zitronen ST\t\t                         1.18\n" +
                "4X\n" +
                "Grapefruit\t\t                         3.16\n" +
                "Party Garnelen\t\t                  9.79\n" +
                "Apfelsaft\t\t                         1.39\n" +
                "Lauchzw./Schl.B\t\t                  0.49\n" +
                "Butter\t\t                                1.19\n" +
                "Profi-Haartrockner\t\t         27.99\n" +
                "Mozarella 45%\t\t                  0.59\n" +
                "Mozarella 45%\t\t                  0.59\n" +
                "Bruschetta Brot\t\t                  0.59\n" +
                "Weizenmehl\t\t                         0.39\n" +
                "Jodsalz\t\t                                0.19\n" +
                "Eier M braun Bod\t\t                  1.79\n" +
                "Schlagsahne\t\t                         1.69\n" +
                "Schlagsahne\t\t                         1.69\n" +
                "\n" +
                "Rueckgeld\t\t                EUR   0.00\n" +
                "\n" +
                "19.00% MwSt.\t\t                13.14\n" +
                "NETTO-UMSATZ\t\t                82.33\n" +
                "------------------------------------------\n" +
                "KontoNr:  0551716000 / 0 / 0512\n" +
                "BLZ:      58862159\n" +
                "Trace-Nr: 027929\n" +
                "Beleg:    7238\n" +
                "------------------------------------------\n" +
                "Kas: 003/006    Bon  0377 PC01 P\n" +
                "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                "\n" +
                "\t        USt–ID:    DE125580123\n" +
                "\n" +
                "\t             Vielen dank\n" +
                "\t          für Ihren Einkauf!\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "\t\t\t\t                          STAR\n" +
                    "\t\t\t\t                     Supermarkt\n" +
                    "\n" +
                    "\t\t\t\t            Das Internet von seiner\n" +
                    "\t\t\t\t              genussvollsten Seite\n" +
                    "\n" +
                    "\t\t\t\t               www.Star-EMEM.com\n" +
                    "\t\t\t\t            Gebührenfrei Rufnummer:\n" +
                    "\t\t\t\t                    08006646701\n" +
                    "---------------------------------------------------------------------------\n" +
                    " \t\t\t\t\t\t\t                                                     EUR\n" +
                    "Schmand 24%\t\t\t\t\t\t                                      0.42\n" +
                    "Kefir\t\t\t\t\t\t                                                    0.79\n" +
                    "Haarspray\t\t\t\t\t\t                                             1.79\n" +
                    "Gurken ST\t\t\t\t\t\t                                             0.59\n" +
                    "Mandelknacker\t\t\t\t\t\t                                      1.59\n" +
                    "Mandelknacker\t\t\t\t\t\t                                      1.59\n" +
                    "Nussecken\t\t\t\t\t\t                                             1.69\n" +
                    "Nussecken\t\t\t\t\t\t                                             1.69\n" +
                    "Clemen.1kg NZ\t\t\t\t\t                                             1.49\n" +
                    "2X\n" +
                    "Zitronen ST\t\t\t\t\t\t                                             1.18\n" +
                    "4X\n" +
                    "Grapefruit\t\t\t\t\t\t                                             3.16\n" +
                    "Party Garnelen\t\t\t\t\t\t                                      9.79\n" +
                    "Apfelsaft\t\t\t\t\t\t                                             1.39\n" +
                    "Lauchzw./Schl.B\t\t\t\t\t\t                                      0.49\n" +
                    "Butter\t\t\t\t\t\t                                                    1.19\n" +
                    "Profi-Haartrockner\t\t\t\t\t\t                             27.99\n" +
                    "Mozarella 45%\t\t\t\t\t\t                                      0.59\n" +
                    "Mozarella 45%\t\t\t\t\t\t                                      0.59\n" +
                    "Bruschetta Brot\t\t\t\t\t\t                                      0.59\n" +
                    "Weizenmehl\t\t\t\t\t\t                                             0.39\n" +
                    "Jodsalz\t\t\t\t\t\t                                                    0.19\n" +
                    "Eier M braun Bod\t\t\t\t\t\t                                      1.79\n" +
                    "Schlagsahne\t\t\t\t\t\t                                             1.69\n" +
                    "Schlagsahne\t\t\t\t\t\t                                             1.69\n" +
                    "\n" +
                    "Rueckgeld\t\t\t\t\t\t                                    EUR  0.00\n" +
                    "\n" +
                    "19.00% MwSt.\t\t\t\t\t\t                                    13.14\n" +
                    "NETTO-UMSATZ\t\t\t\t\t\t                                    82.33\n" +
                    "---------------------------------------------------------------------------\n" +
                    "KontoNr:  0551716000 / 0 / 0512\n" +
                    "BLZ:      58862159\n" +
                    "Trace-Nr: 027929\n" +
                    "Beleg:    7238\n" +
                    "---------------------------------------------------------------------------\n" +
                    "Kas: 003/006    Bon  0377 PC01 P\n" +
                    "Dat: 30.03.2015 Zeit 18:06:01 43\n" +
                    "\n" +
                    "\t\t\t\t             USt–ID:    DE125580123\n" +
                    "\n" +
                    "\t\t\t\t                    Vielen dank\n" +
                    "\t\t\t\t                 für Ihren Einkauf!\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "               STAR              \n" +
                    "            Supermarkt           \n" +
                    "                                 \n" +
                    "     Das Internet von seiner     \n" +
                    "       genussvollsten Seite      \n" +
                    "                                 \n" +
                    "        www.Star-EMEM.com        \n" +
                    "     Gebührenfrei Rufnummer:     \n" +
                    "           08006646701           \n" +
                    "---------------------------------\n" +
                    "                             EUR \n" +
                    "Schmand 24%                 0.42 \n" +
                    "Kefir                       0.79 \n" +
                    "Haarspray                   1.79 \n" +
                    "Gurken ST                   0.59 \n" +
                    "Mandelknacker               1.59 \n" +
                    "Mandelknacker               1.59 \n" +
                    "Nussecken                   1.69 \n" +
                    "Nussecken                   1.69 \n" +
                    "Clemen.1kg NZ               1.49 \n" +
                    "2X                               \n" +
                    "Zitronen ST                 1.18 \n" +
                    "4X                               \n" +
                    "Grapefruit                  3.16 \n" +
                    "Party Garnelen              9.79 \n" +
                    "Apfelsaft                   1.39 \n" +
                    "Lauchzw./Schl.B             0.49 \n" +
                    "Butter                      1.19 \n" +
                    "Profi-Haartrockner         27.99 \n" +
                    "Mozarella 45%               0.59 \n" +
                    "Mozarella 45%               0.59 \n" +
                    "Bruschetta Brot             0.59 \n" +
                    "Weizenmehl                  0.39 \n" +
                    "Jodsalz                     0.19 \n" +
                    "Eier M braun Bod            1.79 \n" +
                    "Schlagsahne                 1.69 \n" +
                    "Schlagsahne                 1.69 \n" +
                    "                                 \n" +
                    "Rueckgeld             EUR   0.00 \n" +
                    "                                 \n" +
                    "19.00% MwSt.               13.14 \n" +
                    "NETTO-UMSATZ               82.33 \n" +
                    "---------------------------------\n" +
                    "KontoNr :  0551716000/0/0512     \n" +
                    "BLZ :      58862159              \n" +
                    "Trace-Nr : 027929                \n" +
                    "Beleg :    7238                  \n" +
                    "---------------------------------\n" +
                    "Kas :    003/006 Bon0377 PC01 P  \n" +
                    "Dat :    30.03.2015              \n" +
                    "Zeit18 : 06:01                43 \n" +
                    "                                 \n" +
                    "       USt–ID : DE125580123      \n" +
                    "                                 \n" +
                    "           Vielen dank           \n" +
                    "        für Ihren Einkauf!       \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                       STAR                      \n" +
                    "                    Supermarkt                   \n" +
                    "                                                 \n" +
                    "             Das Internet von seiner             \n" +
                    "               genussvollsten Seite              \n" +
                    "                                                 \n" +
                    "                www.Star-EMEM.com                \n" +
                    "             Gebührenfrei Rufnummer:             \n" +
                    "                   08006646701                   \n" +
                    "-------------------------------------------------\n" +
                    "                                             EUR \n" +
                    "Schmand 24%                                 0.42 \n" +
                    "Kefir                                       0.79 \n" +
                    "Haarspray                                   1.79 \n" +
                    "Gurken ST                                   0.59 \n" +
                    "Mandelknacker                               1.59 \n" +
                    "Mandelknacker                               1.59 \n" +
                    "Nussecken                                   1.69 \n" +
                    "Nussecken                                   1.69 \n" +
                    "Clemen.1kg NZ                               1.49 \n" +
                    "2X                                               \n" +
                    "Zitronen ST                                 1.18 \n" +
                    "4X                                               \n" +
                    "Grapefruit                                  3.16 \n" +
                    "Party Garnelen                              9.79 \n" +
                    "Apfelsaft                                   1.39 \n" +
                    "Lauchzw./Schl.B                             0.49 \n" +
                    "Butter                                      1.19 \n" +
                    "Profi-Haartrockner                         27.99 \n" +
                    "Mozarella 45%                               0.59 \n" +
                    "Mozarella 45%                               0.59 \n" +
                    "Bruschetta Brot                             0.59 \n" +
                    "Weizenmehl                                  0.39 \n" +
                    "Jodsalz                                     0.19 \n" +
                    "Eier M braun Bod                            1.79 \n" +
                    "Schlagsahne                                 1.69 \n" +
                    "Schlagsahne                                 1.69 \n" +
                    "                                                 \n" +
                    "Rueckgeld                            EUR    0.00 \n" +
                    "                                                 \n" +
                    "19.00% MwSt.                               13.14 \n" +
                    "NETTO-UMSATZ                               82.33 \n" +
                    "-------------------------------------------------\n" +
                    "KontoNr :  0551716000/0/0512                     \n" +
                    "BLZ :      58862159                              \n" +
                    "Trace-Nr : 027929                                \n" +
                    "Beleg :    7238                                  \n" +
                    "-------------------------------------------------\n" +
                    "Kas : 003/006 Bon0377 PC01 P                     \n" +
                    "Dat : 30.03.2015                                 \n" +
                    "Zeit18 : 06:01   43                              \n" +
                    "                                                 \n" +
                    "             USt–ID :    DE125580123             \n" +
                    "                                                 \n" +
                    "                   Vielen dank                   \n" +
                    "                für Ihren Einkauf!               \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "                    STAR                    \n" +
                    "                 Supermarkt                 \n" +
                    "                                            \n" +
                    "           Das Internet von seiner          \n" +
                    "            genussvollsten Seite            \n" +
                    "                                            \n" +
                    "              www.Star-EMEM.com             \n" +
                    "           Gebührenfrei Rufnummer:          \n" +
                    "                 08006646701                \n" +
                    "--------------------------------------------\n" +
                    "                                        EUR \n" +
                    "Schmand 24%                            0.42 \n" +
                    "Kefir                                  0.79 \n" +
                    "Haarspray                              1.79 \n" +
                    "Gurken ST                              0.59 \n" +
                    "Mandelknacker                          1.59 \n" +
                    "Mandelknacker                          1.59 \n" +
                    "Nussecken                              1.69 \n" +
                    "Nussecken                              1.69 \n" +
                    "Clemen.1kg NZ                          1.49 \n" +
                    "2X                                          \n" +
                    "Zitronen ST                            1.18 \n" +
                    "4X                                          \n" +
                    "Grapefruit                             3.16 \n" +
                    "Party Garnelen                         9.79 \n" +
                    "Apfelsaft                              1.39 \n" +
                    "Lauchzw./Schl.B                        0.49 \n" +
                    "Butter                                 1.19 \n" +
                    "Profi-Haartrockner                    27.99 \n" +
                    "Mozarella 45%                          0.59 \n" +
                    "Mozarella 45%                          0.59 \n" +
                    "Bruschetta Brot                        0.59 \n" +
                    "Weizenmehl                             0.39 \n" +
                    "Jodsalz                                0.19 \n" +
                    "Eier M braun Bod                       1.79 \n" +
                    "Schlagsahne                            1.69 \n" +
                    "Schlagsahne                            1.69 \n" +
                    "                                            \n" +
                    "Rueckgeld                       EUR    0.00 \n" +
                    "                                            \n" +
                    "19.00% MwSt.                          13.14 \n" +
                    "NETTO-UMSATZ                          82.33 \n" +
                    "--------------------------------------------\n" +
                    "KontoNr :  0551716000/0/0512                \n" +
                    "BLZ :      58862159                         \n" +
                    "Trace-Nr : 027929                           \n" +
                    "Beleg :    7238                             \n" +
                    "--------------------------------------------\n" +
                    "Kas : 003/006 Bon0377 PC01 P                \n" +
                    "Dat : 30.03.2015                            \n" +
                    "Zeit18 : 06:01   43                         \n" +
                    "                                            \n" +
                    "           USt–ID :    DE125580123          \n" +
                    "                                            \n" +
                    "                 Vielen dank                \n" +
                    "             für Ihren Einkauf!             \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                                  STAR                                 \n" +
                    "                               Supermarkt                              \n" +
                    "                                                                       \n" +
                    "                        Das Internet von seiner                        \n" +
                    "                          genussvollsten Seite                         \n" +
                    "                                                                       \n" +
                    "                           www.Star-EMEM.com                           \n" +
                    "                        Gebührenfrei Rufnummer:                        \n" +
                    "                              08006646701                              \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                                                   EUR \n" +
                    "Schmand 24%                                                       0.42 \n" +
                    "Kefir                                                             0.79 \n" +
                    "Haarspray                                                         1.79 \n" +
                    "Gurken ST                                                         0.59 \n" +
                    "Mandelknacker                                                     1.59 \n" +
                    "Mandelknacker                                                     1.59 \n" +
                    "Nussecken                                                         1.69 \n" +
                    "Nussecken                                                         1.69 \n" +
                    "Clemen.1kg NZ                                                     1.49 \n" +
                    "2X                                                                     \n" +
                    "Zitronen ST                                                       1.18 \n" +
                    "4X                                                                     \n" +
                    "Grapefruit                                                        3.16 \n" +
                    "Party Garnelen                                                    9.79 \n" +
                    "Apfelsaft                                                         1.39 \n" +
                    "Lauchzw./Schl.B                                                   0.49 \n" +
                    "Butter                                                            1.19 \n" +
                    "Profi-Haartrockner                                               27.99 \n" +
                    "Mozarella 45%                                                     0.59 \n" +
                    "Mozarella 45%                                                     0.59 \n" +
                    "Bruschetta Brot                                                   0.59 \n" +
                    "Weizenmehl                                                        0.39 \n" +
                    "Jodsalz                                                           0.19 \n" +
                    "Eier M braun Bod                                                  1.79 \n" +
                    "Schlagsahne                                                       1.69 \n" +
                    "Schlagsahne                                                       1.69 \n" +
                    "                                                                       \n" +
                    "Rueckgeld                                                  EUR    0.00 \n" +
                    "                                                                       \n" +
                    "19.00% MwSt.                                                     13.14 \n" +
                    "NETTO-UMSATZ                                                     82.33 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "KontoNr :  0551716000/0/0512                                           \n" +
                    "BLZ :      58862159                                                    \n" +
                    "Trace-Nr : 027929                                                      \n" +
                    "Beleg :    7238                                                        \n" +
                    "-----------------------------------------------------------------------\n" +
                    "Kas : 003/006 Bon0377 PC01 P                                           \n" +
                    "Dat : 30.03.2015                                                       \n" +
                    "Zeit18 : 06:01   43                                                    \n" +
                    "                                                                       \n" +
                    "                        USt–ID :    DE125580123                        \n" +
                    "                                                                       \n" +
                    "                              Vielen dank                              \n" +
                    "                           für Ihren Einkauf!                          \n";
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
