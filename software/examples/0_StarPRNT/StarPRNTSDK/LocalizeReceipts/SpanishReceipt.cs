using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class SpanishReceipt : LocalizeReceipt
    {
        public SpanishReceipt()
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

            builder.AppendInternational(InternationalType.Spain);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes(
                            "BAR RESTAURANT\n" +
                            "EL POZO\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "C/.ROCAFORT 187\n" +
                            "08029 BARCELONA\n" +
                            "\n" +
                            "NIF :X-3856907Z\n" +
                            "TEL :934199465\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "--------------------------------\n" +
                            "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                            "CAN P/U DESCRIPCION  SUMA\n" +
                            "--------------------------------\n" +
                            " 4  3,00  JARRA  CERVEZA   12,00\n" +
                            " 1  1,60  COPA DE CERVEZA   1,60\n" +
                            "--------------------------------\n" +
                            "               SUB TOTAL : 13,60\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("TOTAL:     13,60 EUROS\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "NO: 000018851     IVA INCLUIDO\n" +
                            "--------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "**** GRACIAS POR SU VISITA! ****\n" +
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

            builder.AppendInternational(InternationalType.Spain);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("BAR RESTAURANT EL POZO\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "C/.ROCAFORT 187 08029 BARCELONA\n" +
                            "NIF :X-3856907Z  TEL :934199465\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------------\n" +
                            "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                            "CAN P/U DESCRIPCION  SUMA\n" +
                            "------------------------------------------------\n" +
                            " 4     3,00      JARRA  CERVEZA            12,00\n" +
                            " 1     1,60      COPA DE CERVEZA            1,60\n" +
                            "------------------------------------------------\n" +
                            "                           SUB TOTAL :     13,60\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("TOTAL:     13,60 EUROS\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "NO: 000018851  IVA INCLUIDO\n" +
                            "------------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "**** GRACIAS POR SU VISITA! ****\n" +
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

            builder.AppendInternational(InternationalType.Spain);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultiple(Encoding.GetEncoding(encoding).GetBytes("BAR RESTAURANT EL POZO\n"), 2, 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "C/.ROCAFORT 187 08029 BARCELONA\n" +
                            "NIF :X-3856907Z  TEL :934199465\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                            "CAN P/U DESCRIPCION  SUMA\n" +
                            "---------------------------------------------------------------------\n" +
                            " 4     3,00          JARRA  CERVEZA                             12,00\n" +
                            " 1     1,60          COPA DE CERVEZA                             1,60\n" +
                            "---------------------------------------------------------------------\n" +
                            "                                         SUB TOTAL :            13,60\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("TOTAL:     13,60 EUROS\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "NO: 000018851  IVA INCLUIDO\n" +
                            "---------------------------------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "**** GRACIAS POR SU VISITA! ****\n" +
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

            builder.AppendInternational(InternationalType.Spain);

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("BAR RESTAURANT EL POZO\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "C/.ROCAFORT 187 08029 BARCELONA\n" +
                            "NIF :X-3856907Z  TEL :934199465\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                            "CAN P/U DESCRIPCION  SUMA\n" +
                            "------------------------------------------\n" +
                            " 4    3,00    JARRA  CERVEZA         12,00\n" +
                            " 1    1,60    COPA DE CERVEZA         1,60\n" +
                            "------------------------------------------\n" +
                            "                     SUB TOTAL :     13,60\n"));

            builder.AppendAlignment(AlignmentPosition.Right);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("TOTAL:     13,60 EUROS\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "NO: 000018851  IVA INCLUIDO\n" +
                            "------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "**** GRACIAS POR SU VISITA! ****\n" +
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

            builder.AppendInternational(InternationalType.Spain);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("BAR RESTAURANT EL POZO\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "C/.ROCAFORT 187 08029 BARCELONA\n" +
                            "NIF :X-3856907Z  TEL :934199465\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                            "CAN P/U DESCRIPCION  SUMA\n" +
                            "------------------------------------------\n" +
                            " 4 3,00 JARRA  CERVEZA               12,00\n" +
                            " 1 1,60 COPA DE CERVEZA               1,60\n" +
                            "------------------------------------------\n" +
                            " SUB TOTAL :                         13,60\n" +
                            "                     TOTAL:    13,60 EUROS\n" +
                            "NO: 000018851  IVA INCLUIDO\n" +
                            "------------------------------------------\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("**** GRACIAS POR SU VISITA! ****\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_spanish)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "               BAR RESTAURANT\n" +
                    "                                           EL POZO\n" +
                    "C/.ROCAFORT 187\n" +
                    "08029 BARCELONA\n" +
                    "NIF :X-3856907Z\n" +
                    "TEL :934199465\n" +
                    "----------------------------------------\n" +
                    "MESA: 100 P: -\n" +
                    "    FECHA: YYYY-MM-DD\n" +
                    "CAN P/U DESCRIPCION  SUMA\n" +
                    "----------------------------------------\n" +
                    "3,00 \tJARRA CERVEZA\t\t12,00\n" +
                    "1,60 \tCOPA DE CERVEZA\t  1,60\n" +
                    "----------------------------------------\n" +
                    "                  SUB TOTAL :\t13,60\n" +
                    "TOTAL:                     13,60 \tEUROS\n" +
                    " NO:000018851 IVA INCLUIDO\n" +
                    "\n" +
                    "----------------------------------------\n" +
                    "     **GRACIAS POR SU VISITA!**\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "                BAR RESTAURANT\n" +
                    "\t\t                               EL POZO\n" +
                    "C/.ROCAFORT 187\n" +
                    "08029 BARCELONA\n" +
                    "NIF :X-3856907Z\n" +
                    "TEL :934199465\n" +
                    "------------------------------------------\n" +
                    "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                    "CAN P/U DESCRIPCION  SUMA\n" +
                    "------------------------------------------\n" +
                    "4 3,00 JARRA  CERVEZA   \t\t12,00\n" +
                    "1 1,60 COPA DE CERVEZA  \t  1,60\n" +
                    "------------------------------------------\n" +
                    "                     SUB TOTAL : \t\t13,60\n" +
                    "TOTAL:               \t13,60 \t\tEUROS\n" +
                    "NO: 000018851 IVA INCLUIDO\n" +
                    "\n" +
                    "------------------------------------------\n" +
                    "      **GRACIAS POR SU VISITA!**\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "                                   BAR RESTAURANT EL POZO\n" +
                    "                          C/.ROCAFORT 187 08029 BARCELONA\n" +
                    "                          NIF :X-3856907Z  TEL :934199465\n" +
                    "---------------------------------------------------------------------------\n" +
                    "MESA: 100 P: - FECHA: YYYY-MM-DD\n" +
                    "CAN P/U DESCRIPCION  SUMA\n" +
                    "---------------------------------------------------------------------------\n" +
                    "4\t\t    3,00\t\t    JARRA  CERVEZA\t\t                     12,00\n" +
                    "1\t\t    1,60\t\t    COPA DE CERVEZA\t\t                       1,60\n" +
                    "---------------------------------------------------------------------------\n" +
                    "\t\t\t\t                                  SUB TOTAL :       \t\t13,60\n" +
                    "\t\t\t\t                                  TOTAL :      \t13,60\tEUROS\n" +
                    "NO: 000018851 IVA INCLUIDO\n" +
                    "\n" +
                    "---------------------------------------------------------------------------\n" +
                    "                             ***GRACIAS POR SU VISITA!***\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "          BAR RESTAURANT         \n" +
                    "                         EL POZO \n" +
                    "C/.ROCAFORT 187                  \n" +
                    "08029 BARCELONA                  \n" +
                    "NIF :X-3856907Z                  \n" +
                    "TEL :934199465                   \n" +
                    "---------------------------------\n" +
                    "MESA: 100 P: -                   \n" +
                    "    FECHA: YYYY-MM-DD            \n" +
                    "CAN P/U DESCRIPCION  SUMA        \n" +
                    "---------------------------------\n" +
                    "3,00  JARRA CERVEZA        12,00 \n" +
                    "1,60  COPA DE CERVEZA       1,60 \n" +
                    "---------------------------------\n" +
                    "           SUB TOTAL :     13,60 \n" +
                    "TOTAL:              13,60  EUROS \n" +
                    " NO:000018851 IVA INCLUIDO       \n" +
                    "                                 \n" +
                    "---------------------------------\n" +
                    "    **GRACIAS POR SU VISITA!**   \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "                                  BAR RESTAURANT \n" +
                    "                                         EL POZO \n" +
                    "C/.ROCAFORT 187                                  \n" +
                    "08029 BARCELONA                                  \n" +
                    "NIF :X-3856907Z                                  \n" +
                    "TEL :934199465                                   \n" +
                    "-------------------------------------------------\n" +
                    "MESA: 100 P: - FECHA: YYYY-MM-DD                 \n" +
                    "CAN P/U DESCRIPCION  SUMA                        \n" +
                    "-------------------------------------------------\n" +
                    "4  3,00  JARRA CERVEZA        12,00              \n" +
                    "1  1,60  COPA DE CERVEZA      1,60               \n" +
                    "-------------------------------------------------\n" +
                    "                             SUB TOTAL  :  13,60 \n" +
                    "TOTAL:                       13,60  EUROS        \n" +
                    "NO:000018851 IVA INCLUIDO                        \n" +
                    "                                                 \n" +
                    "-------------------------------------------------\n" +
                    "                      **GRACIAS POR SU VISITA!** \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "                             BAR RESTAURANT \n" +
                    "                                    EL POZO \n" +
                    "C/.ROCAFORT 187                             \n" +
                    "08029 BARCELONA                             \n" +
                    "NIF :X-3856907Z                             \n" +
                    "TEL :934199465                              \n" +
                    "--------------------------------------------\n" +
                    "MESA: 100 P: - FECHA: YYYY-MM-DD            \n" +
                    "CAN P/U DESCRIPCION  SUMA                   \n" +
                    "--------------------------------------------\n" +
                    "4  3,00  JARRA CERVEZA        12,00         \n" +
                    "1  1,60  COPA DE CERVEZA      1,60          \n" +
                    "--------------------------------------------\n" +
                    "                        SUB TOTAL  :  13,60 \n" +
                    "TOTAL:                  13,60  EUROS        \n" +
                    "NO:000018851 IVA INCLUIDO                   \n" +
                    "                                            \n" +
                    "--------------------------------------------\n" +
                    "                 **GRACIAS POR SU VISITA!** \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                                                BAR RESTAURANT EL POZO \n" +
                    "                                       C/.ROCAFORT 187 08029 BARCELONA \n" +
                    "                                      NIF :X-3856907Z   TEL :934199465 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "MESA: 100 P: - FECHA: YYYY-MM-DD                                       \n" +
                    "CAN P/U DESCRIPCION  SUMA                                              \n" +
                    "-----------------------------------------------------------------------\n" +
                    "4  3,00  JARRA CERVEZA                                           12,00 \n" +
                    "1  1,60  COPA DE CERVEZA                                          1,60 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                                   SUB TOTAL  :  13,60 \n" +
                    "                                                 TOTAL  : 13,60  EUROS \n" +
                    "NO:000018851 IVA INCLUIDO                                              \n" +
                    "                                                                       \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                            **GRACIAS POR SU VISITA!** \n";
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
