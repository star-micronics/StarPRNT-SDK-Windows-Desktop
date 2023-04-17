using StarMicronics.StarIOExtension;

namespace StarPRNTSDK
{
    public static class CashDrawerFunctions
    {
        public static byte[] CreateData(Emulation emulation, PeripheralChannel channel)
        {
            ICommandBuilder builder = StarIoExt.CreateCommandBuilder(emulation);

            builder.BeginDocument();

            builder.AppendPeripheral(channel);

            builder.EndDocument();

            return builder.Commands;
        }
    }
}
