using StarMicronics.StarIOExtension;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    class PortugueseReceipt : LocalizeReceipt
    {
        public PortugueseReceipt()
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

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes(
                            "COMERCIAL DE ALIMENTOS\n" +
                            "STAR LTDA.\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Avenida Moyses Roysen,\n" +
                            "S/N Vila Guilherme\n" +
                            "Cep: 02049-010 – Sao Paulo – SP\n" +
                            "CNPJ: 62.545.579/0013-69\n" +
                            "IE:110.819.138.118\n" +
                            "IM: 9.041.041-5\n"));


            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "--------------------------------\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "CCF:133939 COO:227808\n" +
                            "--------------------------------\n" +
                            "CUPOM FISCAL\n" +
                            "--------------------------------\n" +
                            "001 2505 CAFÉ DO PONTO TRAD A\n" +
                            "                    1un F1 8,15)\n" +
                            "002 2505 CAFÉ DO PONTO TRAD A\n" +
                            "                    1un F1 8,15)\n" +
                            "003 2505 CAFÉ DO PONTO TRAD A\n" +
                            "                    1un F1 8,15)\n" +
                            "004 6129 AGU MIN NESTLE 510ML\n" +
                            "                    1un F1 1,39)\n" +
                            "005 6129 AGU MIN NESTLE 510ML\n" +
                            "                    1un F1 1,39)\n" +
                            "--------------------------------\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes("TOTAL  R$  27,23\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DINHEIROv                  29,00\n" +
                            "TROCO R$                    1,77\n" +
                            "Valor dos Tributos R$2,15(7,90%)\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "ITEM(S) CINORADIS 5\n" +
                            "OP.:15326  PDV:9  BR,BF:93466\n" +
                            "OBRIGADO PERA PREFERENCIA.\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes(
                            "VOLTE SEMPRE!\n" +
                            "\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SAC 0800 724 2822\n" +
                            "--------------------------------\n" +
                            "MD5:\n" +
                            "fe028828a532a7dbaf4271155aa4e2db\n" +
                            "Calypso_CA CA.20.c13\n" +
                            " – Unisys Brasil\n" +
                            "--------------------------------\n" +
                            "DARUMA AUTOMAÇÃO   MACH 2\n" +
                            "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                            "Lj:0204 OPR:ANGELA JORGE\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DDDDDDDDDAEHFGBFCC\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "FAB:DR0911BR000000275026\n" +
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

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("COMERCIAL DE ALIMENTOS STAR LTDA.\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Avenida Moyses Roysen, S/N  Vila Guilherme\n" +
                            "Cep: 02049-010 – Sao Paulo – SP\n" +
                            "CNPJ: 62.545.579/0013-69\n" +
                            "IE:110.819.138.118  IM: 9.041.041-5\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                             "------------------------------------------------\n" +
                            "MM/DD/YYYY HH:MM:SS  CCF:133939 COO:227808\n" +
                            "------------------------------------------------\n" +
                            "CUPOM FISCAL\n" +
                            "------------------------------------------------\n" +
                            "001  2505  CAFÉ DO PONTO TRAD A  1un F1  8,15)\n" +
                            "002  2505  CAFÉ DO PONTO TRAD A  1un F1  8,15)\n" +
                            "003  2505  CAFÉ DO PONTO TRAD A  1un F1  8,15)\n" +
                            "004  6129  AGU MIN NESTLE 510ML  1un F1  1,39)\n" +
                            "005  6129  AGU MIN NESTLE 510ML  1un F1  1,39)\n" +
                            "------------------------------------------------\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes("TOTAL  R$         27,23\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DINHEIROv                                29,00\n" +
                            "TROCO R$                                  1,77\n" +
                            "Valor dos Tributos R$2,15 (7,90%)\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "ITEM(S) CINORADIS 5\n" +
                            "OP.:15326  PDV:9  BR,BF:93466\n" +
                            "OBRIGADO PERA PREFERENCIA.\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes(
                            "VOLTE SEMPRE!\n" +
                            "\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SAC 0800 724 2822\n" +
                            "------------------------------------------------\n" +
                            "MD5:fe028828a532a7dbaf4271155aa4e2db\n" +
                            "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                            "------------------------------------------------\n" +
                            "DARUMA AUTOMAÇÃO   MACH 2\n" +
                            "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                            "Lj:0204 OPR:ANGELA JORGE\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DDDDDDDDDAEHFGBFCC\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "FAB:DR0911BR000000275026\n" +
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

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("COMERCIAL DE ALIMENTOS STAR LTDA.\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Avenida Moyses Roysen, S/N  Vila Guilherme\n" +
                            "Cep: 02049-010 – Sao Paulo – SP\n" +
                            "CNPJ: 62.545.579/0013-69\n" +
                            "IE:110.819.138.118  IM: 9.041.041-5\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "---------------------------------------------------------------------\n" +
                            "MM/DD/YYYY HH:MM:SS  CCF:133939 COO:227808\n" +
                            "---------------------------------------------------------------------\n" +
                            "CUPOM FISCAL\n" +
                            "---------------------------------------------------------------------\n" +
                            "001  2505        CAFÉ DO PONTO TRAD A    1un F1            8,15)\n" +
                            "002  2505        CAFÉ DO PONTO TRAD A    1un F1            8,15)\n" +
                            "003  2505        CAFÉ DO PONTO TRAD A    1un F1            8,15)\n" +
                            "004  6129        AGU MIN NESTLE 510ML    1un F1            1,39)\n" +
                            "005  6129        AGU MIN NESTLE 510ML    1un F1            1,39)\n" +
                            "---------------------------------------------------------------------\n"));


            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes("TOTAL  R$                  27,23\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DINHEIROv                                                  29,00\n" +
                            "TROCO R$                                                    1,77\n" +
                            "Valor dos Tributos R$2,15 (7,90%)\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "ITEM(S) CINORADIS 5\n" +
                            "OP.:15326  PDV:9  BR,BF:93466\n" +
                            "OBRIGADO PERA PREFERENCIA.\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes(
                            "VOLTE SEMPRE!\n" +
                            "\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SAC 0800 724 2822\n" +
                            "---------------------------------------------------------------------\n" +
                            "MD5:fe028828a532a7dbaf4271155aa4e2db\n" +
                            "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                            "---------------------------------------------------------------------\n" +
                            "DARUMA AUTOMAÇÃO   MACH 2\n" +
                            "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                            "Lj:0204 OPR:ANGELA JORGE\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DDDDDDDDDAEHFGBFCC\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "FAB:DR0911BR000000275026\n" +
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

            builder.AppendCharacterSpace(0);

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes("\n"));

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("COMERCIAL DE ALIMENTOS STAR LTDA.\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Avenida Moyses Roysen, S/N  Vila Guilherme\n" +
                            "Cep: 02049-010 – Sao Paulo – SP\n" +
                            "CNPJ: 62.545.579/0013-69\n" +
                            "IE:110.819.138.118  IM: 9.041.041-5\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "MM/DD/YYYY HH:MM:SS  CCF:133939 COO:227808\n" +
                            "------------------------------------------\n" +
                            "CUPOM FISCAL\n" +
                            "------------------------------------------\n" +
                            "001   2505    CAFÉ DO PONTO TRAD A\n" +
                            "                            1un F1  8,15)\n" +
                            "002   2505    CAFÉ DO PONTO TRAD A\n" +
                            "                            1un F1  8,15)\n" +
                            "003   2505    CAFÉ DO PONTO TRAD A\n" +
                            "                            1un F1  8,15)\n" +
                            "004   6129    AGU MIN NESTLE 510ML\n" +
                            "                            1un F1  1,39)\n" +
                            "005   6129    AGU MIN NESTLE 510ML\n" +
                            "                            1un F1  1,39)\n" +
                            "------------------------------------------\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes("TOTAL  R$      27,23\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DINHEIROv                          29,00\n" +
                            "TROCO R$                            1,77\n" +
                            "Valor dos Tributos R$2,15 (7,90%)\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "ITEM(S) CINORADIS 5\n" +
                            "OP.:15326  PDV:9  BR,BF:93466\n" +
                            "OBRIGADO PERA PREFERENCIA.\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes(
                            "VOLTE SEMPRE!\n" +
                            "\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SAC 0800 724 2822\n" +
                            "------------------------------------------\n" +
                            "MD5:fe028828a532a7dbaf4271155aa4e2db\n" +
                            "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                            "------------------------------------------\n" +
                            "DARUMA AUTOMAÇÃO   MACH 2\n" +
                            "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                            "Lj:0204 OPR:ANGELA JORGE\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DDDDDDDDDAEHFGBFCC\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "FAB:DR0911BR000000275026\n" +
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

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleHeight(Encoding.GetEncoding(encoding).GetBytes("\nCOMERCIAL DE ALIMENTOS STAR LTDA.\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "Avenida Moyses Roysen, S/N Vila Guilherme\n" +
                            "Cep: 02049-010 – Sao Paulo – SP\n" +
                            "CNPJ: 62.545.579/0013-69\n" +
                            "IE:110.819.138.118  IM: 9.041.041-5\n"));

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "------------------------------------------\n" +
                            "MM/DD/YYYY HH:MM:SS  CCF:133939 COO:227808\n" +
                            "------------------------------------------\n" +
                            "CUPOM FISCAL\n" +
                            "------------------------------------------\n" +
                            "01 2505 CAFÉ DO PONTO TRAD A  1un F1 8,15)\n" +
                            "02 2505 CAFÉ DO PONTO TRAD A  1un F1 8,15)\n" +
                            "03 2505 CAFÉ DO PONTO TRAD A  1un F1 8,15)\n" +
                            "04 6129 AGU MIN NESTLE 510ML  1un F1 1,39)\n" +
                            "05 6129 AGU MIN NESTLE 510ML  1un F1 1,39)\n" +
                            "------------------------------------------\n" +
                            "TOTAL  R$                            27,23\n" +
                            "DINHEIROv                            29,00\n" +
                            "TROCO R$                              1,77\n" +
                            "Valor dos Tributos R$2,15 (7,90%)\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes("TOTAL  R$      27,23\n"), 2);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "ITEM(S) CINORADIS 5\n" +
                            "OP.:15326  PDV:9  BR,BF:93466\n" +
                            "OBRIGADO PERA PREFERENCIA.\n"));

            builder.AppendMultipleWidth(Encoding.GetEncoding(encoding).GetBytes(
                            "VOLTE SEMPRE!\n" +
                            "\n"), 2);

            builder.AppendAlignment(AlignmentPosition.Left);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "SAC 0800 724 2822\n" +
                            "------------------------------------------\n" +
                            "MD5:  fe028828a532a7dbaf4271155aa4e2db\n" +
                            "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                            "------------------------------------------\n" +
                            "DARUMA AUTOMAÇÃO   MACH 2\n" +
                            "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                            "Lj:0204 OPR:ANGELA JORGE\n" +
                            "\n"));

            builder.AppendAlignment(AlignmentPosition.Center);

            builder.Append(Encoding.GetEncoding(encoding).GetBytes(
                            "DDDDDDDDDAEHFGBFCC\n" +
                            "MM/DD/YYYY HH:MM:SS\n" +
                            "FAB:DR0911BR000000275026\n"));
        }

        public override Bitmap CreateCouponImage()
        {
            Bitmap couponImage;

            using (var stream = Properties.Resources.coupon_image_portuguese)
            {
                couponImage = new Bitmap(stream);
            }

            return couponImage;
        }

        public override string Create2inchRasterReceiptText()
        {
            return
                    "         COMERCIAL DE ALIMENTOS\n" +
                    "                STAR LTDA.\n" +
                    "          Avenida Moyses Roysen,\n" +
                    "             S/N Vila Guilherme\n" +
                    "Cep: 02049-010 – Sao Paulo – SP\n" +
                    "CNPJ: 62.545.579/0013-69\n" +
                    "IE:110.819.138.118\n" +
                    "IM: 9.041.041-5\n" +
                    "----------------------------------------\n" +
                    "MM/DD/YYYY HH:MM:SS\n" +
                    "CCF:133939 COO:227808\n" +
                    "----------------------------------------\n" +
                    "CUPOM FISCAL\n" +
                    "----------------------------------------\n" +
                    "01 CAFÉ DO PONTO TRAD A\n" +
                    "              \t\t\t1un F1 8,15)\n" +
                    "02 CAFÉ DO PONTO TRAD A\n" +
                    "              \t\t\t1un F1 8,15)\n" +
                    "03 CAFÉ DO PONTO TRAD A\n" +
                    "              \t\t\t1un F1 8,15)\n" +
                    "04 AGU MIN NESTLE 510ML\n" +
                    "              \t\t\t1un F1 1,39)\n" +
                    "05 AGU MIN NESTLE 510ML\n" +
                    "              \t\t\t1un F1 1,39)\n" +
                    "----------------------------------------\n" +
                    "TOTAL  R$            \t\t 27,23\n" +
                    "DINHEIROv            \t\t 29,00\n" +
                    "\n" +
                    "TROCO R$              \t\t   1,77\n" +
                    "Valor dos Tributos\n" +
                    "R$2,15(7,90%)\n" +
                    "ITEM(S) CINORADIS 5\n" +
                    "OP.:15326  PDV:9\n" +
                    "            BR,BF:93466\n" +
                    "OBRIGADO PERA PREFERENCIA.\n" +
                    "VOLTE SEMPRE!\n" +
                    "SAC 0800 724 2822\n" +
                    "----------------------------------------\n" +
                    "MD5:\n" +
                    "fe028828a532a7dbaf4271155a\n" +
                    "a4e2db\n" +
                    "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                    "----------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2\n" +
                    "ECF-IF VERSÃO:01,00,00\n" +
                    "ECF:093\n" +
                    "Lj:0204 OPR:ANGELA JORGE\n" +
                    "DDDDDDDDDAEHFGBFCC\n" +
                    "MM/DD/YYYY HH:MM:SS\n" +
                    "FAB:DR0911BR000000275026\n";
        }

        public override string Create3inchRasterReceiptText()
        {
            return
                    "         COMERCIAL DE ALIMENTOS\n" +
                    "            STAR LTDA.\n" +
                    "        Avenida Moyses Roysen,\n" +
                    "          S/N Vila Guilherme\n" +
                    "     Cep: 02049-010 – Sao Paulo – SP\n" +
                    "        CNPJ: 62.545.579/0013-69\n" +
                    "  IE:110.819.138.118    IM: 9.041.041-5\n" +
                    "------------------------------------------\n" +
                    "MM/DD/YYYY\t\t\t HH:MM:SS\n" +
                    "CCF:133939 COO:227808\n" +
                    "------------------------------------------\n" +
                    "CUPOM FISCAL\n" +
                    "------------------------------------------\n" +
                    "01 CAFÉ DO PONTO TRAD A\n" +
                    "\t\t\t                  1un F1  8,15)\n" +
                    "02 CAFÉ DO PONTO TRAD A\n" +
                    "\t\t\t                  1un F1  8,15)\n" +
                    "03 CAFÉ DO PONTO TRAD A\n" +
                    "\t\t\t                  1un F1  8,15)\n" +
                    "04 AGU MIN NESTLE 510ML\n" +
                    "\t\t\t                  1un F1  1,39)\n" +
                    "05 AGU MIN NESTLE 510ML\n" +
                    "\t\t\t                  1un F1  1,39)\n" +
                    "------------------------------------------\n" +
                    "TOTAL  R$\t\t\t                27,23\n" +
                    "DINHEIROv\t\t\t                29,00\n" +
                    "\n" +
                    "TROCO R$\t\t\t                  1,77\n" +
                    "Valor dos Tributos R$2,15(7,90%)\n" +
                    "ITEM(S) CINORADIS 5\n" +
                    "OP.:15326  PDV:9  BR,BF:93466\n" +
                    "OBRIGADO PERA PREFERENCIA.\n" +
                    "VOLTE SEMPRE!    SAC 0800 724 2822\n" +
                    "------------------------------------------\n" +
                    "MD5:  fe028828a532a7dbaf4271155aa4e2db\n" +
                    "Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                    "------------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2\n" +
                    "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                    "Lj:0204 OPR:ANGELA JORGE\n" +
                    "DDDDDDDDDAEHFGBFCC\n" +
                    "MM/DD/YYYY HH:MM:SS\n" +
                    "FAB:DR0911BR000000275026\n";
        }

        public override string Create4inchRasterReceiptText()
        {
            return
                    "                     COMERCIAL DE ALIMENTOS STAR LTDA.\n" +
                    "                     Avenida Moyses Roysen, S/N Vila Guilherme\n" +
                    "                         Cep: 02049-010 – Sao Paulo – SP\n" +
                    "                          CNPJ: 62.545.579/0013-69\n" +
                    "                            IE:110.819.138.118    IM: 9.041.041-5\n" +
                    "---------------------------------------------------------------------------\n" +
                    "              MM/DD/YYYY HH:MM:SS CCF:133939   COO:227808\n" +
                    "---------------------------------------------------------------------------\n" +
                    "CUPOM FISCAL\n" +
                    "---------------------------------------------------------------------------\n" +
                    "01   CAFÉ DO PONTO TRAD A\t\t    1un F1\t\t                8,15)\n" +
                    "02   CAFÉ DO PONTO TRAD A\t\t    1un F1\t\t                8,15)\n" +
                    "03   CAFÉ DO PONTO TRAD A\t\t    1un F1\t\t                8,15)\n" +
                    "04   AGU MIN NESTLE 510ML\t\t    1un F1\t\t                1,39)\n" +
                    "05   AGU MIN NESTLE 510ML\t\t    1un F1\t\t                1,39)\n" +
                    "---------------------------------------------------------------------------\n" +
                    "TOTAL  R$\t\t\t\t\t\t                                           27,23\n" +
                    "DINHEIROv\t\t\t\t\t\t                                           29,00\n" +
                    "\n" +
                    "TROCO R$\t\t\t\t\t\t                                             1,77\n" +
                    "Valor dos Tributos R$2,15(7,90%)\n" +
                    "ITEM(S) CINORADIS 5\n" +
                    "OP.:15326  PDV:9  BR,BF:93466\n" +
                    "OBRIGADO PERA PREFERENCIA.\n" +
                    "                       VOLTE SEMPRE!    SAC 0800 724 2822\n" +
                    "---------------------------------------------------------------------------\n" +
                    "                   MD5:  fe028828a532a7dbaf4271155aa4e2db\n" +
                    "                     Calypso_CA CA.20.c13 – Unisys Brasil\n" +
                    "---------------------------------------------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2\n" +
                    "ECF-IF VERSÃO:01,00,00 ECF:093\n" +
                    "Lj:0204 OPR:ANGELA JORGE\n" +
                    "DDDDDDDDDAEHFGBFCC\n" +
                    "MM/DD/YYYY HH:MM:SS\n" +
                    "FAB:DR0911BR000000275026\n";
        }

        public override string Create2inchBitmapSourceText()
        {
            return
                    "      COMERCIAL DE ALIMENTOS     \n" +
                    "            STAR LTDA.           \n" +
                    "      Avenida Moyses Roysen,     \n" +
                    "        S/N Vila Guilherme       \n" +
                    "Cep: 02049-010 – Sao Paulo – SP  \n" +
                    "CNPJ: 62.545.579/0013-69         \n" +
                    "IE:110.819.138.118               \n" +
                    "IM: 9.041.041-5                  \n" +
                    "---------------------------------\n" +
                    "MM/DD/YYYY HH:MM:SS              \n" +
                    "CCF:133939 COO:227808            \n" +
                    "---------------------------------\n" +
                    "CUPOM FISCAL                     \n" +
                    "---------------------------------\n" +
                    "01 CAFÉ DO PONTO TRAD A          \n" +
                    "                    1un F1 8,15) \n" +
                    "02 CAFÉ DO PONTO TRAD A          \n" +
                    "                    1un F1 8,15) \n" +
                    "03 CAFÉ DO PONTO TRAD A          \n" +
                    "                    1un F1 8,15) \n" +
                    "04 AGU MIN NESTLE 510ML          \n" +
                    "                    1un F1 1,39) \n" +
                    "05 AGU MIN NESTLE 510ML          \n" +
                    "                    1un F1 1,39) \n" +
                    "---------------------------------\n" +
                    "TOTAL  R$                  27,23 \n" +
                    "DINHEIROv                  29,00 \n" +
                    "                                 \n" +
                    "TROCO R$                    1,77 \n" +
                    "Valor dos Tributos               \n" +
                    "R$2,15(7,90%)                    \n" +
                    "ITEM(S) CINORADIS 5              \n" +
                    "OP.:15326  PDV:9                 \n" +
                    "            BR,BF:93466          \n" +
                    "OBRIGADO PERA PREFERENCIA.       \n" +
                    "VOLTE SEMPRE!                    \n" +
                    "SAC 0800 724 2822                \n" +
                    "---------------------------------\n" +
                    "MD5:                             \n" +
                    "fe028828a532a7dbaf4271155a       \n" +
                    "a4e2db                           \n" +
                    "Calypso_CA CA.20.c13 –           \n" +
                    "                   Unisys Brasil \n" +
                    "---------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2        \n" +
                    "ECF-IF VERSÃO:01,00,00           \n" +
                    "ECF:093                          \n" +
                    "Lj:0204 OPR:ANGELA JORGE         \n" +
                    "DDDDDDDDDAEHFGBFCC               \n" +
                    "MM/DD/YYYY HH:MM:SS              \n" +
                    "FAB:DR0911BR000000275026         \n";
        }

        public override string Create3inchBitmapSourceText()
        {
            return
                    "              COMERCIAL DE ALIMENTOS             \n" +
                    "                    STAR LTDA.                   \n" +
                    "              Avenida Moyses Roysen,             \n" +
                    "                S/N Vila Guilherme               \n" +
                    "         Cep: 02049-010 – Sao Paulo – SP         \n" +
                    "             CNPJ: 62.545.579/0013-69            \n" +
                    "             IE:110.819.138.118  IM: 9.041.041-5 \n" +
                    "-------------------------------------------------\n" +
                    "MM/DD/YYYY HH:MM:SS                              \n" +
                    "CCF:133939 COO:227808                            \n" +
                    "-------------------------------------------------\n" +
                    "CUPOM FISCAL                                     \n" +
                    "-------------------------------------------------\n" +
                    "01   CAFÉ DO PONTO TRAD A   1un F1         8,15) \n" +
                    "02   CAFÉ DO PONTO TRAD A   1un F1         8,15) \n" +
                    "03   CAFÉ DO PONTO TRAD A   1un F1         8,15) \n" +
                    "04   AGU MIN NESTLE 510ML   1un F1         1,39) \n" +
                    "05   AGU MIN NESTLE 510ML   1un F1         1,39) \n" +
                    "-------------------------------------------------\n" +
                    "TOTAL  R$                                  27,23 \n" +
                    "DINHEIROv                                  29,00 \n" +
                    "                                                 \n" +
                    "TROCO R$                                    1,77 \n" +
                    "Valor dos Tributos  R$2,15(7,90%)                \n" +
                    "ITEM(S) CINORADIS 5                              \n" +
                    "OP.:15326    PDV:9    BR,BF:93466                \n" +
                    "OBRIGADO PERA PREFERENCIA.                       \n" +
                    "VOLTE SEMPRE!      SAC 0800 724 2822             \n" +
                    "-------------------------------------------------\n" +
                    "MD5:  fe028828a532a7dbaf4271155a                 \n" +
                    "a4e2db  Calypso_CA CA.20.c13 – Unisys Brasil     \n" +
                    "-------------------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2                        \n" +
                    "ECF-IF VERSÃO:01,00,00                           \n" +
                    "ECF:093                                          \n" +
                    "Lj:0204 OPR:ANGELA JORGE                         \n" +
                    "DDDDDDDDDAEHFGBFCC                               \n" +
                    "MM/DD/YYYY HH:MM:SS                              \n" +
                    "FAB:DR0911BR000000275026                         \n";
        }

        public override string CreateEscPos3inchBitmapSourceText()
        {
            return
                    "           COMERCIAL DE ALIMENTOS           \n" +
                    "                 STAR LTDA.                 \n" +
                    "           Avenida Moyses Roysen,           \n" +
                    "             S/N Vila Guilherme             \n" +
                    "      Cep: 02049-010 – Sao Paulo – SP       \n" +
                    "          CNPJ: 62.545.579/0013-69          \n" +
                    "        IE:110.819.138.118  IM: 9.041.041-5 \n" +
                    "--------------------------------------------\n" +
                    "MM/DD/YYYY HH:MM:SS                         \n" +
                    "CCF:133939 COO:227808                       \n" +
                    "--------------------------------------------\n" +
                    "CUPOM FISCAL                                \n" +
                    "--------------------------------------------\n" +
                    "01   CAFÉ DO PONTO TRAD A   1un F1    8,15) \n" +
                    "02   CAFÉ DO PONTO TRAD A   1un F1    8,15) \n" +
                    "03   CAFÉ DO PONTO TRAD A   1un F1    8,15) \n" +
                    "04   AGU MIN NESTLE 510ML   1un F1    1,39) \n" +
                    "05   AGU MIN NESTLE 510ML   1un F1    1,39) \n" +
                    "--------------------------------------------\n" +
                    "TOTAL  R$                             27,23 \n" +
                    "DINHEIROv                             29,00 \n" +
                    "                                            \n" +
                    "TROCO R$                               1,77 \n" +
                    "Valor dos Tributos  R$2,15(7,90%)           \n" +
                    "ITEM(S) CINORADIS 5                         \n" +
                    "OP.:15326    PDV:9    BR,BF:93466           \n" +
                    "OBRIGADO PERA PREFERENCIA.                  \n" +
                    "VOLTE SEMPRE!      SAC 0800 724 2822        \n" +
                    "--------------------------------------------\n" +
                    "MD5:  fe028828a532a7dbaf4271155a            \n" +
                    "a4e2db Calypso_CA CA.20.c13 – Unisys Brasil \n" +
                    "--------------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2                   \n" +
                    "ECF-IF VERSÃO:01,00,00                      \n" +
                    "ECF:093                                     \n" +
                    "Lj:0204 OPR:ANGELA JORGE                    \n" +
                    "DDDDDDDDDAEHFGBFCC                          \n" +
                    "MM/DD/YYYY HH:MM:SS                         \n" +
                    "FAB:DR0911BR000000275026                    \n";
        }

        public override string Create4inchBitmapSourceText()
        {
            return
                    "                         COMERCIAL DE ALIMENTOS                        \n" +
                    "                               STAR LTDA.                              \n" +
                    "                         Avenida Moyses Roysen,                        \n" +
                    "                           S/N Vila Guilherme                          \n" +
                    "                    Cep: 02049-010 – Sao Paulo – SP                    \n" +
                    "                        CNPJ: 62.545.579/0013-69                       \n" +
                    "                                   IE:110.819.138.118  IM: 9.041.041-5 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                           MM/DD/YYYY HH:MM:SS   CCF:133939 COO:227808 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "CUPOM FISCAL                                                           \n" +
                    "-----------------------------------------------------------------------\n" +
                    "01   CAFÉ DO PONTO TRAD A   1un F1                               8,15) \n" +
                    "02   CAFÉ DO PONTO TRAD A   1un F1                               8,15) \n" +
                    "03   CAFÉ DO PONTO TRAD A   1un F1                               8,15) \n" +
                    "04   AGU MIN NESTLE 510ML   1un F1                               1,39) \n" +
                    "05   AGU MIN NESTLE 510ML   1un F1                               1,39) \n" +
                    "-----------------------------------------------------------------------\n" +
                    "TOTAL  R$                                                        27,23 \n" +
                    "DINHEIROv                                                        29,00 \n" +
                    "                                                                       \n" +
                    "TROCO R$                                                          1,77 \n" +
                    "Valor dos Tributos  R$2,15(7,90%)                                      \n" +
                    "ITEM(S) CINORADIS 5                                                    \n" +
                    "OP.:15326    PDV:9    BR,BF:93466                                      \n" +
                    "OBRIGADO PERA PREFERENCIA.                                             \n" +
                    "                                  VOLTE SEMPRE!      SAC 0800 724 2822 \n" +
                    "-----------------------------------------------------------------------\n" +
                    "                                      MD5:  fe028828a532a7dbaf4271155a \n" +
                    "                           a4e2db Calypso_CA CA.20.c13 – Unisys Brasil \n" +
                    "-----------------------------------------------------------------------\n" +
                    "DARUMA AUTOMAÇÃO   MACH 2                                              \n" +
                    "ECF-IF VERSÃO:01,00,00                                                 \n" +
                    "ECF:093                                                                \n" +
                    "Lj:0204 OPR:ANGELA JORGE                                               \n" +
                    "DDDDDDDDDAEHFGBFCC                                                     \n" +
                    "MM/DD/YYYY HH:MM:SS                                                    \n" +
                    "FAB:DR0911BR000000275026                                               \n";
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
