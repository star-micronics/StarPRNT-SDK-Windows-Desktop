namespace StarPRNTSDK
{
    public static class BcrFunctions
    {
        public static byte[] CreateClearBuffer()
        {
            // Barcode reader command builder sample is in "BcrBuilder" class.
            BcrBuilder builder = new BcrBuilder();

            builder.AppendClearBuffer();

            return builder.Commands;
        }
    }
}
