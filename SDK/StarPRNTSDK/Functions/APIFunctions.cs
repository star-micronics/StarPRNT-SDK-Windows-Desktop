using StarMicronics.StarIOExtension;
using StarPRNTSDK.Properties;
using System.Drawing;
using System.Text;

namespace StarPRNTSDK
{
    public static class APIFunctions
    {
        public static byte[] CreateGenericData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);
            builder.Append((byte)0x0a);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateFontStyleData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);
            builder.AppendFontStyle(FontStyleType.B);
            builder.Append(data);
            builder.AppendFontStyle(FontStyleType.A);
            builder.Append(data);
            builder.AppendFontStyle(FontStyleType.B);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateInitializationData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);
            builder.AppendMultiple(2, 2);
            builder.Append(data);
            builder.AppendFontStyle(FontStyleType.B);
            builder.Append(data);
            builder.AppendInitialization(InitializationType.Command);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateCodePageData(Emulation emulation)
        {
            byte[] bytes2 = new byte[] { 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 0x0a };
            byte[] bytes3 = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x0a };
            byte[] bytes4 = new byte[] { 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x0a };
            byte[] bytes5 = new byte[] { 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 0x0a };
            byte[] bytes6 = new byte[] { 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 0x0a };
            byte[] bytes7 = new byte[] { 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f, 0x0a };
            byte[] bytes8 = new byte[] { (byte)0x80, (byte)0x81, (byte)0x82, (byte)0x83, (byte)0x84, (byte)0x85, (byte)0x86, (byte)0x87, (byte)0x88, (byte)0x89, (byte)0x8a, (byte)0x8b, (byte)0x8c, (byte)0x8d, (byte)0x8e, (byte)0x8f, 0x0a };
            byte[] bytes9 = new byte[] { (byte)0x90, (byte)0x91, (byte)0x92, (byte)0x93, (byte)0x94, (byte)0x95, (byte)0x96, (byte)0x97, (byte)0x98, (byte)0x99, (byte)0x9a, (byte)0x9b, (byte)0x9c, (byte)0x9d, (byte)0x9e, (byte)0x9f, 0x0a };
            byte[] bytesA = new byte[] { (byte)0xa0, (byte)0xa1, (byte)0xa2, (byte)0xa3, (byte)0xa4, (byte)0xa5, (byte)0xa6, (byte)0xa7, (byte)0xa8, (byte)0xa9, (byte)0xaa, (byte)0xab, (byte)0xac, (byte)0xad, (byte)0xae, (byte)0xaf, 0x0a };
            byte[] bytesB = new byte[] { (byte)0xb0, (byte)0xb1, (byte)0xb2, (byte)0xb3, (byte)0xb4, (byte)0xb5, (byte)0xb6, (byte)0xb7, (byte)0xb8, (byte)0xb9, (byte)0xba, (byte)0xbb, (byte)0xbc, (byte)0xbd, (byte)0xbe, (byte)0xbf, 0x0a };
            byte[] bytesC = new byte[] { (byte)0xc0, (byte)0xc1, (byte)0xc2, (byte)0xc3, (byte)0xc4, (byte)0xc5, (byte)0xc6, (byte)0xc7, (byte)0xc8, (byte)0xc9, (byte)0xca, (byte)0xcb, (byte)0xcc, (byte)0xcd, (byte)0xce, (byte)0xcf, 0x0a };
            byte[] bytesD = new byte[] { (byte)0xd0, (byte)0xd1, (byte)0xd2, (byte)0xd3, (byte)0xd4, (byte)0xd5, (byte)0xd6, (byte)0xd7, (byte)0xd8, (byte)0xd9, (byte)0xda, (byte)0xdb, (byte)0xdc, (byte)0xdd, (byte)0xde, (byte)0xdf, 0x0a };
            byte[] bytesE = new byte[] { (byte)0xe0, (byte)0xe1, (byte)0xe2, (byte)0xe3, (byte)0xe4, (byte)0xe5, (byte)0xe6, (byte)0xe7, (byte)0xe8, (byte)0xe9, (byte)0xea, (byte)0xeb, (byte)0xec, (byte)0xed, (byte)0xee, (byte)0xef, 0x0a };
            byte[] bytesF = new byte[] { (byte)0xf0, (byte)0xf1, (byte)0xf2, (byte)0xf3, (byte)0xf4, (byte)0xf5, (byte)0xf6, (byte)0xf7, (byte)0xf8, (byte)0xf9, (byte)0xfa, (byte)0xfb, (byte)0xfc, (byte)0xfd, (byte)0xfe, (byte)0xff, 0x0a };

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendCodePage(CodePageType.CP998); builder.Append(Encoding.UTF8.GetBytes("*CP998*\n"));

            builder.Append(bytes2);
            builder.Append(bytes3);
            builder.Append(bytes4);
            builder.Append(bytes5);
            builder.Append(bytes6);
            builder.Append(bytes7);
            builder.Append(bytes8);
            builder.Append(bytes9);
            builder.Append(bytesA);
            builder.Append(bytesB);
            builder.Append(bytesC);
            builder.Append(bytesD);
            builder.Append(bytesE);
            builder.Append(bytesF);

            builder.Append(Encoding.UTF8.GetBytes("\n"));

            //builder.AppendCodePage(CodePageType.CP437); builder.Append(Encoding.UTF8.GetBytes("*CP437*\n"));
            //builder.AppendCodePage(CodePageType.CP737); builder.Append(Encoding.UTF8.GetBytes("*CP737*\n"));
            //builder.AppendCodePage(CodePageType.CP772); builder.Append(Encoding.UTF8.GetBytes("*CP774*\n"));
            //builder.AppendCodePage(CodePageType.CP774); builder.Append(Encoding.UTF8.GetBytes("*CP774*\n"));
            //builder.AppendCodePage(CodePageType.CP851); builder.Append(Encoding.UTF8.GetBytes("*CP851*\n"));
            //builder.AppendCodePage(CodePageType.CP852); builder.Append(Encoding.UTF8.GetBytes("*CP852*\n"));
            //builder.AppendCodePage(CodePageType.CP855); builder.Append(Encoding.UTF8.GetBytes("*CP855*\n"));
            //builder.AppendCodePage(CodePageType.CP857); builder.Append(Encoding.UTF8.GetBytes("*CP857*\n"));
            //builder.AppendCodePage(CodePageType.CP858); builder.Append(Encoding.UTF8.GetBytes("*CP858*\n"));
            //builder.AppendCodePage(CodePageType.CP860); builder.Append(Encoding.UTF8.GetBytes("*CP860*\n"));
            //builder.AppendCodePage(CodePageType.CP861); builder.Append(Encoding.UTF8.GetBytes("*CP861*\n"));
            //builder.AppendCodePage(CodePageType.CP862); builder.Append(Encoding.UTF8.GetBytes("*CP862*\n"));
            //builder.AppendCodePage(CodePageType.CP863); builder.Append(Encoding.UTF8.GetBytes("*CP863*\n"));
            //builder.AppendCodePage(CodePageType.CP864); builder.Append(Encoding.UTF8.GetBytes("*CP864*\n"));
            //builder.AppendCodePage(CodePageType.CP865); builder.Append(Encoding.UTF8.GetBytes("*CP865*\n"));
            //builder.AppendCodePage(CodePageType.CP866); builder.Append(Encoding.UTF8.GetBytes("*CP866*\n"));
            //builder.AppendCodePage(CodePageType.CP869); builder.Append(Encoding.UTF8.GetBytes("*CP869*\n"));
            //builder.AppendCodePage(CodePageType.CP874); builder.Append(Encoding.UTF8.GetBytes("*CP874*\n"));
            //builder.AppendCodePage(CodePageType.CP928); builder.Append(Encoding.UTF8.GetBytes("*CP928*\n"));
            builder.AppendCodePage(CodePageType.CP932); builder.Append(Encoding.UTF8.GetBytes("*CP932*\n"));
            //builder.AppendCodePage(CodePageType.CP998); builder.Append(Encoding.UTF8.GetBytes("*CP998*\n"));
            //builder.AppendCodePage(CodePageType.CP999); builder.Append(Encoding.UTF8.GetBytes("*CP999*\n"));
            //builder.AppendCodePage(CodePageType.CP1001); builder.Append(Encoding.UTF8.GetBytes("*CP1001*\n"));
            //builder.AppendCodePage(CodePageType.CP1250); builder.Append(Encoding.UTF8.GetBytes("*CP1250*\n"));
            //builder.AppendCodePage(CodePageType.CP1251); builder.Append(Encoding.UTF8.GetBytes("*CP1251*\n"));
            //builder.AppendCodePage(CodePageType.CP1252); builder.Append(Encoding.UTF8.GetBytes("*CP1252*\n"));
            //builder.AppendCodePage(CodePageType.CP2001); builder.Append(Encoding.UTF8.GetBytes("*CP2001*\n"));
            //builder.AppendCodePage(CodePageType.CP3001); builder.Append(Encoding.UTF8.GetBytes("*CP3001*\n"));
            //builder.AppendCodePage(CodePageType.CP3002); builder.Append(Encoding.UTF8.GetBytes("*CP3002*\n"));
            //builder.AppendCodePage(CodePageType.CP3011); builder.Append(Encoding.UTF8.GetBytes("*CP3011*\n"));
            //builder.AppendCodePage(CodePageType.CP3012); builder.Append(Encoding.UTF8.GetBytes("*CP3012*\n"));
            //builder.AppendCodePage(CodePageType.CP3021); builder.Append(Encoding.UTF8.GetBytes("*CP3021*\n"));
            //builder.AppendCodePage(CodePageType.CP3041); builder.Append(Encoding.UTF8.GetBytes("*CP3041*\n"));
            //builder.AppendCodePage(CodePageType.CP3840); builder.Append(Encoding.UTF8.GetBytes("*CP3840*\n"));
            //builder.AppendCodePage(CodePageType.CP3841); builder.Append(Encoding.UTF8.GetBytes("*CP3841*\n"));
            //builder.AppendCodePage(CodePageType.CP3843); builder.Append(Encoding.UTF8.GetBytes("*CP3843*\n"));
            //builder.AppendCodePage(CodePageType.CP3844); builder.Append(Encoding.UTF8.GetBytes("*CP3844*\n"));
            //builder.AppendCodePage(CodePageType.CP3845); builder.Append(Encoding.UTF8.GetBytes("*CP3845*\n"));
            //builder.AppendCodePage(CodePageType.CP3846); builder.Append(Encoding.UTF8.GetBytes("*CP3846*\n"));
            //builder.AppendCodePage(CodePageType.CP3847); builder.Append(Encoding.UTF8.GetBytes("*CP3847*\n"));
            //builder.AppendCodePage(CodePageType.CP3848); builder.Append(Encoding.UTF8.GetBytes("*CP3848*\n"));
            //builder.AppendCodePage(CodePageType.UTF8); builder.Append(Encoding.UTF8.GetBytes("*UTF8*\n"));
            //builder.AppendCodePage(CodePageType.Blank); builder.Append(Encoding.UTF8.GetBytes("*Blank*\n"));

            builder.Append(bytes2);
            builder.Append(bytes3);
            builder.Append(bytes4);
            builder.Append(bytes5);
            builder.Append(bytes6);
            builder.Append(bytes7);
            builder.Append(bytes8);
            builder.Append(bytes9);
            builder.Append(bytesA);
            builder.Append(bytesB);
            builder.Append(bytesC);
            builder.Append(bytesD);
            builder.Append(bytesE);
            builder.Append(bytesF);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateInternationalData(Emulation emulation)
        {
            byte[] bytes = new byte[] { 0x23, 0x24, 0x40, 0x58, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x60, 0x7b, 0x7c, 0x7d, 0x7e, 0x0a };

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("*USA*\n"));
            builder.AppendInternational(InternationalType.USA);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*France*\n"));
            builder.AppendInternational(InternationalType.France);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Germany*\n"));
            builder.AppendInternational(InternationalType.Germany);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*UK*\n"));
            builder.AppendInternational(InternationalType.UK);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Denmark*\n"));
            builder.AppendInternational(InternationalType.Denmark);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Sweden*\n"));
            builder.AppendInternational(InternationalType.Sweden);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Italy*\n"));
            builder.AppendInternational(InternationalType.Italy);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Spain*\n"));
            builder.AppendInternational(InternationalType.Spain);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Japan*\n"));
            builder.AppendInternational(InternationalType.Japan);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Norway*\n"));
            builder.AppendInternational(InternationalType.Norway);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Denmark2*\n"));
            builder.AppendInternational(InternationalType.Denmark2);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Spain2*\n"));
            builder.AppendInternational(InternationalType.Spain2);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*LatinAmerica*\n"));
            builder.AppendInternational(InternationalType.LatinAmerica);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Korea*\n"));
            builder.AppendInternational(InternationalType.Korea);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Ireland*\n"));
            builder.AppendInternational(InternationalType.Ireland);
            builder.Append(bytes);

            builder.Append(Encoding.UTF8.GetBytes("*Legal*\n"));
            builder.AppendInternational(InternationalType.Legal);
            builder.Append(bytes);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateFeedData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.");
            byte[] dataWithLf = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);
            builder.AppendLineFeed();

            builder.AppendLineFeed(data);

            builder.Append(data);
            builder.AppendLineFeed(2);

            builder.AppendLineFeed(data, 2);

            builder.Append(data);
            builder.AppendUnitFeed(64);

            builder.AppendUnitFeed(data, 64);

            builder.Append(dataWithLf);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateCharacterSpaceData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendCharacterSpace(0);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(1);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(2);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(3);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(4);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(5);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(6);
            builder.AppendLineFeed(data);
            builder.AppendCharacterSpace(7);
            builder.AppendLineFeed(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateLineSpaceData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendLineSpace(32);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineSpace(24);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineSpace(32);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineSpace(24);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);
            builder.AppendLineFeed(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateTopMarginData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendTopMargin(2);
            builder.Append(Encoding.UTF8.GetBytes("*Top margin:2mm*\n"));
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.AppendTopMargin(6);
            builder.Append(Encoding.UTF8.GetBytes("*Top margin:6mm*\n"));
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.AppendTopMargin(11);
            builder.Append(Encoding.UTF8.GetBytes("*Top margin:11mm*\n"));
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateEmphasisData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");
            byte[] dataHalf0 = Encoding.UTF8.GetBytes("Hello ");
            byte[] dataHalf1 = Encoding.UTF8.GetBytes("World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendEmphasis(true);
            builder.Append(data);
            builder.AppendEmphasis(false);
            builder.Append(data);

            builder.AppendEmphasis(data);
            builder.Append(data);

            builder.AppendEmphasis(dataHalf0);
            builder.Append(dataHalf1);

            builder.Append(dataHalf0);
            builder.AppendEmphasis(dataHalf1);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateInvertData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");
            byte[] dataHalf0 = Encoding.UTF8.GetBytes("Hello ");
            byte[] dataHalf1 = Encoding.UTF8.GetBytes("World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendInvert(true);
            builder.Append(data);
            builder.AppendInvert(false);
            builder.Append(data);

            builder.AppendInvert(data);
            builder.Append(data);

            builder.AppendInvert(dataHalf0);
            builder.Append(dataHalf1);

            builder.Append(dataHalf0);
            builder.AppendInvert(dataHalf1);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateUnderLineData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");
            byte[] dataHalf0 = Encoding.UTF8.GetBytes("Hello ");
            byte[] dataHalf1 = Encoding.UTF8.GetBytes("World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendUnderLine(true);
            builder.Append(data);
            builder.AppendUnderLine(false);
            builder.Append(data);

            builder.AppendUnderLine(data);
            builder.Append(data);

            builder.AppendUnderLine(dataHalf0);
            builder.Append(dataHalf1);

            builder.Append(dataHalf0);
            builder.AppendUnderLine(dataHalf1);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateMultipleData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");
            byte[] dataHalf0 = Encoding.UTF8.GetBytes("Hello ");
            byte[] dataHalf1 = Encoding.UTF8.GetBytes("World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendMultiple(2, 2);
            builder.Append(data);
            builder.AppendMultiple(1, 1);
            builder.Append(data);

            builder.AppendMultiple(data, 2, 2);
            builder.Append(data);

            builder.AppendMultiple(dataHalf0, 2, 2);
            builder.Append(dataHalf1);
            builder.Append(dataHalf0);
            builder.AppendMultiple(dataHalf1, 2, 2);

            builder.AppendMultipleHeight(2);
            builder.Append(data);
            builder.AppendMultipleHeight(1);
            builder.Append(data);

            builder.AppendMultipleHeight(dataHalf0, 2);
            builder.Append(dataHalf1);
            builder.Append(dataHalf0);
            builder.AppendMultipleHeight(dataHalf1, 2);

            builder.AppendMultipleWidth(2);
            builder.Append(data);
            builder.AppendMultipleWidth(1);
            builder.Append(data);

            builder.AppendMultipleWidth(dataHalf0, 2);
            builder.Append(dataHalf1);
            builder.Append(dataHalf0);
            builder.AppendMultipleWidth(dataHalf1, 2);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateAbsolutePositionData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendAbsolutePosition(40);
            builder.Append(data);
            builder.Append(data);

            builder.AppendAbsolutePosition(data, 40);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateAlignmentData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);

            builder.AppendAlignment(AlignmentPosition.Center);
            builder.Append(data);
            builder.AppendAlignment(AlignmentPosition.Right);
            builder.Append(data);
            builder.AppendAlignment(AlignmentPosition.Left);
            builder.Append(data);

            builder.AppendAlignment(data, AlignmentPosition.Center);
            builder.AppendAlignment(data, AlignmentPosition.Right);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateHorizontalTabData(Emulation emulation)
        {
            byte[] data1 = Encoding.UTF8.GetBytes("QTY\tITEM\tTOTAL\n");
            byte[] data2 = Encoding.UTF8.GetBytes("1\tApple\t1.50\n");
            byte[] data3 = Encoding.UTF8.GetBytes("2\tOrange\t2.00\n");
            byte[] data4 = Encoding.UTF8.GetBytes("5\tBanana\t3.00\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendHorizontalTabPosition(new int[] { 5, 24 });

            builder.Append(Encoding.UTF8.GetBytes("*Tab Position:5, 24*\n"));
            builder.Append(data1);
            builder.Append(data2);
            builder.Append(data3);
            builder.Append(data4);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;

        }

        public static byte[] CreateLogoData(Emulation emulation)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("*Normal*\n"));
            builder.AppendLogo(LogoSize.Normal, 1);

            builder.Append(Encoding.UTF8.GetBytes("\n*Double Width*\n"));
            builder.AppendLogo(LogoSize.DoubleWidth, 1);

            builder.Append(Encoding.UTF8.GetBytes("\n*Double Height*\n"));
            builder.AppendLogo(LogoSize.DoubleHeight, 1);

            builder.Append(Encoding.UTF8.GetBytes("\n*Double Width and Double Height*\n"));
            builder.AppendLogo(LogoSize.DoubleWidthDoubleHeight, 1);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateCutPaperData(Emulation emulation)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.FullCut);

            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCut);

            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.FullCutWithFeed);

            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);
            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreatePeripheralData(Emulation emulation)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendPeripheral(PeripheralChannel.No1);
            builder.AppendPeripheral(PeripheralChannel.No2);
            builder.AppendPeripheral(PeripheralChannel.No1, 2000);
            builder.AppendPeripheral(PeripheralChannel.No2, 2000);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateSoundData(Emulation emulation)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendSound(SoundChannel.No1);
            builder.AppendSound(SoundChannel.No2);
            builder.AppendSound(SoundChannel.No1, 3);
            builder.AppendSound(SoundChannel.No2, 3);
            builder.AppendSound(SoundChannel.No1, 1, 1000, 1000);
            builder.AppendSound(SoundChannel.No2, 1, 1000, 1000);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateBitmapData(Emulation emulation, int width)
        {
            Bitmap sphereImage;

            using (var stream = Properties.Resources.sphere_image)
            {
                sphereImage = new Bitmap(stream);
            }

            Bitmap starLogoImage;

            using (var stream = Properties.Resources.star_logo_image)
            {
                starLogoImage = new Bitmap(stream);
            }

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("*diffusion:true*\n"));
            builder.AppendBitmap(sphereImage, true);
            builder.Append(Encoding.UTF8.GetBytes("\n*diffusion:false*\n"));
            builder.AppendBitmap(sphereImage, false);

            builder.Append(Encoding.UTF8.GetBytes("\n*Normal*\n"));
            builder.AppendBitmap(starLogoImage, true);

            builder.Append(Encoding.UTF8.GetBytes("\n*width:Full, bothScale:true*\n"));
            builder.AppendBitmap(starLogoImage, true, width, true);
            builder.Append(Encoding.UTF8.GetBytes("\n*width:Full, bothScale:false*\n"));
            builder.AppendBitmap(starLogoImage, true, width, false);

            builder.Append(Encoding.UTF8.GetBytes("\n*Right90*\n"));
            builder.AppendBitmap(starLogoImage, true, BitmapConverterRotation.Right90);
            builder.Append(Encoding.UTF8.GetBytes("\n*Rotate180*\n"));
            builder.AppendBitmap(starLogoImage, true, BitmapConverterRotation.Rotate180);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Left90*\n"));
            //builder.AppendBitmap(starLogoImage, true, BitmapConverterRotation.Left90);

            builder.Append(Encoding.UTF8.GetBytes("\n*Normal,    AbsolutePosition:40*\n"));
            builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, 40);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Right90,   AbsolutePosition:40*\n"));
            //builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, BitmapConverterRotation.Right90, 40);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Rotate180, AbsolutePosition:40*\n"));
            //builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, BitmapConverterRotation.Rotate180, 40);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Left90,    AbsolutePosition:40*\n"));
            //builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, BitmapConverterRotation.Left90, 40);

            builder.Append(Encoding.UTF8.GetBytes("\n*Normal,    Alignment:Center*\n"));
            builder.AppendBitmapWithAlignment(starLogoImage, true, AlignmentPosition.Center);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Right90,   Alignment:Center*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Right90, AlignmentPosition.Center);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Rotate180, Alignment:Center*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Rotate180, AlignmentPosition.Center);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Left90,    Alignment:Center*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Left90, AlignmentPosition.Center);

            builder.Append(Encoding.UTF8.GetBytes("\n*Normal,    Alignment:Right*\n"));
            builder.AppendBitmapWithAlignment(starLogoImage, true, AlignmentPosition.Right);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Right90,   Alignment:Right*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Right90, AlignmentPosition.Right);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Rotate180, Alignment:Right*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Rotate180, AlignmentPosition.Right);
            //builder.Append(Encoding.UTF8.GetBytes("\n*Left90,    Alignment:Right*\n"));
            //builder.AppendBitmapWithAlignment(starLogoImage, true, BitmapConverterRotation.Left90, AlignmentPosition.Right);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateBarcodeData(Emulation emulation)
        {
            byte[] dataUpcE = Encoding.UTF8.GetBytes("01234500006");
            byte[] dataUpcA = Encoding.UTF8.GetBytes("01234567890");
            byte[] dataJan8 = Encoding.UTF8.GetBytes("0123456");
            byte[] dataJan13 = Encoding.UTF8.GetBytes("012345678901");
            byte[] dataCode39 = Encoding.UTF8.GetBytes("0123456789");
            byte[] dataItf = Encoding.UTF8.GetBytes("0123456789");
            byte[] dataCode128 = Encoding.UTF8.GetBytes("{B0123456789");
            byte[] dataCode93 = Encoding.UTF8.GetBytes("0123456789");
            byte[] dataNw7 = Encoding.UTF8.GetBytes("A0123456789B");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("*UPCE*\n"));
            builder.AppendBarcode(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*UPCA*\n"));
            builder.AppendBarcode(dataUpcA, BarcodeSymbology.UPCA, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*JAN8*\n"));
            builder.AppendBarcode(dataJan8, BarcodeSymbology.JAN8, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*JAN13*\n"));
            builder.AppendBarcode(dataJan13, BarcodeSymbology.JAN13, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Code39*\n"));
            builder.AppendBarcode(dataCode39, BarcodeSymbology.Code39, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*ITF*\n"));
            builder.AppendBarcode(dataItf, BarcodeSymbology.ITF, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Code128*\n"));
            builder.AppendBarcode(dataCode128, BarcodeSymbology.Code128, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Code93*\n"));
            builder.AppendBarcode(dataCode93, BarcodeSymbology.Code93, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*NW7*\n"));
            builder.AppendBarcode(dataNw7, BarcodeSymbology.NW7, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("*HRI:NO*\n"));
            builder.AppendBarcode(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, false);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Mode:1*\n"));
            builder.AppendBarcode(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Mode:2*\n"));
            builder.AppendBarcode(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode2, 40, true);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Mode:3*\n"));
            builder.AppendBarcode(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode3, 40, true);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*AbsolutePosition:40*\n"));
            builder.AppendBarcodeWithAbsolutePosition(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, true, 40);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Center*\n"));
            builder.AppendBarcodeWithAlignment(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, true, AlignmentPosition.Center);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Right*\n"));
            builder.AppendBarcodeWithAlignment(dataUpcE, BarcodeSymbology.UPCE, BarcodeWidth.Mode1, 40, true, AlignmentPosition.Right);
            builder.AppendUnitFeed(32);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreatePdf417Data(Emulation emulation)
        {
            byte[] data;

            data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("\n*Module:2*\n"));
            builder.AppendPdf417(data, 0, 1, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Module:4*\n"));
            builder.AppendPdf417(data, 0, 1, Pdf417Level.ECC0, 4, 2);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Column:2*\n"));
            builder.AppendPdf417(data, 0, 2, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Column:4*\n"));
            builder.AppendPdf417(data, 0, 4, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Line:10*\n"));
            builder.AppendPdf417(data, 10, 0, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Line:40*\n"));
            builder.AppendPdf417(data, 40, 0, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Level:ECC0*\n"));
            builder.AppendPdf417(data, 0, 7, Pdf417Level.ECC0, 2, 2);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Level:ECC8*\n"));
            builder.AppendPdf417(data, 0, 7, Pdf417Level.ECC8, 2, 2);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*AbsolutePosition:40*\n"));
            builder.AppendPdf417WithAbsolutePosition(data, 0, 1, Pdf417Level.ECC0, 2, 2, 40);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Center*\n"));
            builder.AppendPdf417WithAlignment(data, 0, 1, Pdf417Level.ECC0, 2, 2, AlignmentPosition.Center);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Right*\n"));
            builder.AppendPdf417WithAlignment(data, 0, 1, Pdf417Level.ECC0, 2, 2, AlignmentPosition.Right);
            builder.AppendUnitFeed(32);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateQrCodeData(Emulation emulation)
        {
            byte[] data;

            data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("*Cell:2*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.L, 2);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Cell:8*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.L, 8);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("*Level:L*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.L, 4);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Level:M*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.M, 4);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Level:Q*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.Q, 4);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("*Level:H*\n"));
            builder.AppendQrCode(data, QrCodeModel.No2, QrCodeLevel.H, 4);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*AbsolutePosition:40*\n"));
            builder.AppendQrCodeWithAbsolutePosition(data, QrCodeModel.No2, QrCodeLevel.L, 4, 40);
            builder.AppendUnitFeed(32);

            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Center*\n"));
            builder.AppendQrCodeWithAlignment(data, QrCodeModel.No2, QrCodeLevel.L, 4, AlignmentPosition.Center);
            builder.AppendUnitFeed(32);
            builder.Append(Encoding.UTF8.GetBytes("\n*Alignment:Right*\n"));
            builder.AppendQrCodeWithAlignment(data, QrCodeModel.No2, QrCodeLevel.L, 4, AlignmentPosition.Right);
            builder.AppendUnitFeed(32);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreateBlackMarkData(Emulation emulation, BlackMarkType type)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello World.\n");

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendBlackMark(type);

            builder.Append(data);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            //builder.AppendBlackMark(BlackMarkType.Invalid);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreatePageModeData(Emulation emulation, int width)
        {
            byte[] data;

            data = Encoding.UTF8.GetBytes("Hello World.\n");

            Bitmap starLogoImage;

            using (var stream = Properties.Resources.star_logo_image)
            {
                starLogoImage = new Bitmap(stream);
            }

            int height = 30 * 8;        // 30mm!!

            Rectangle rectangle;

            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.Append(Encoding.UTF8.GetBytes("\n*Normal*\n"));

            rectangle = new Rectangle(0, 0, width, height);

            builder.BeginPageMode(rectangle, BitmapConverterRotation.Normal);

            builder.Append(data);

            builder.AppendPageModeVerticalAbsolutePosition(160);

            builder.Append(data);

            builder.AppendPageModeVerticalAbsolutePosition(80);

            builder.AppendAbsolutePosition(data, 40);

            builder.EndPageMode();

            builder.Append(Encoding.UTF8.GetBytes("\n*Right90*\n"));

            //rectangle = new Rectangle(0, 0, width, height);
            //rectangle = new Rectangle(0, 0, height, width);
            rectangle = new Rectangle(0, 0, width, width);

            builder.BeginPageMode(rectangle, BitmapConverterRotation.Right90);

            builder.Append(data);

            builder.AppendPageModeVerticalAbsolutePosition(160);

            builder.Append(data);

            builder.AppendPageModeVerticalAbsolutePosition(80);

            builder.AppendAbsolutePosition(data, 40);

            builder.EndPageMode();

            //builder.Append(Encoding.UTF8.GetBytes("\n*Rotate180*\n"));

            //rectangle = new Rectangle(0, 0, width, height);

            //builder.BeginPageMode(rectangle, BitmapConverterRotation.Rotate180);

            //builder.Append(data);

            //builder.AppendPageModeVerticalAbsolutePosition(160);

            //builder.Append(data);

            //builder.AppendPageModeVerticalAbsolutePosition(80);

            //builder.AppendAbsolutePosition(data, 40);

            //builder.EndPageMode();

            //builder.Append(Encoding.UTF8.GetBytes("\n*Left90*\n"));

            //rectangle = new Rectangle(0, 0, width, height);
            //rectangle = new Rectangle(0, 0, height, width);

            //builder.BeginPageMode(rectangle, BitmapConverterRotation.Left90);

            //builder.Append(data);

            //builder.AppendPageModeVerticalAbsolutePosition(160);

            //builder.Append(data);

            //builder.AppendPageModeVerticalAbsolutePosition(80);

            //builder.AppendAbsolutePosition(data, 40);

            //builder.EndPageMode();

            builder.Append(Encoding.UTF8.GetBytes("\n*Mixed Text*\n"));

            //rectangle = new Rectangle(0, 0, width, height);
            rectangle = new Rectangle(0, 0, width, width);

            builder.BeginPageMode(rectangle, BitmapConverterRotation.Normal);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendAbsolutePosition(data, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Right90);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendAbsolutePosition(data, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Rotate180);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendAbsolutePosition(data, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Left90);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendAbsolutePosition(data, width / 2);

            builder.EndPageMode();

            builder.Append(Encoding.UTF8.GetBytes("\n*Mixed Bitmap*\n"));

            //rectangle = new Rectangle(0, 0, width, height);
            rectangle = new Rectangle(0, 0, width, width);

            builder.BeginPageMode(rectangle, BitmapConverterRotation.Normal);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendBitmapWithAbsolutePosition(starLogoImage, false, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Right90);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Rotate180);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, width / 2);

            builder.AppendPageModeRotation(BitmapConverterRotation.Left90);

            builder.AppendPageModeVerticalAbsolutePosition(width / 2);

            builder.AppendBitmapWithAbsolutePosition(starLogoImage, true, width / 2);

            builder.EndPageMode();

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }

        public static byte[] CreatePrintableAreaData(Emulation emulation, PrintableAreaType type)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            Bitmap pritableAreaImage;

            using (Bitmap stream = Resources.printable_area_image)
            {
                pritableAreaImage = new Bitmap(stream);
            }

            byte[] data1 = Encoding.UTF8.GetBytes("123456789");
            byte[] data2 = Encoding.UTF8.GetBytes("0");

            builder.BeginDocument();

            builder.AppendPrintableArea(type);

            switch (type)
            {
                default:
                case PrintableAreaType.Standard:
                    builder.Append(Encoding.UTF8.GetBytes("*Standard*\n"));
                    break;

                case PrintableAreaType.Type1:
                    builder.Append(Encoding.UTF8.GetBytes("*Type1*\n"));
                    break;

                case PrintableAreaType.Type2:
                    builder.Append(Encoding.UTF8.GetBytes("*Type2*\n"));
                    break;

                case PrintableAreaType.Type3:
                    builder.Append(Encoding.UTF8.GetBytes("*Type3*\n"));
                    break;

                case PrintableAreaType.Type4:
                    builder.Append(Encoding.UTF8.GetBytes("*Type4*\n"));
                    break;
            }

            builder.AppendBitmap(pritableAreaImage, true);

            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);
            builder.Append(data1);
            builder.AppendInvert(data2);

            builder.AppendCutPaper(CutPaperAction.PartialCutWithFeed);

            builder.EndDocument();

            return builder.Commands;
        }
    }
}
