namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

internal sealed class CPMPrintInterceptor : PrintInterceptor
{
    internal CPMPrintInterceptor(Z80TestHarness z80, ResultWatchingOutput output)
        : base(z80, output)
    {
    }

    internal override void HandlePrintRoutine()
    {
        switch (Z80.RegisterC)
        {
            case 2:
                Output.Write(Z80.RegisterE);
                return;

            case 9:
                var messageAddress = Z80.RegisterDE;
                byte byteToPrint;
                while ((byteToPrint = Z80.MemoryRead(messageAddress)) != '$')
                {
                    Output.Write(byteToPrint);
                    messageAddress++;
                }

                return;
        }
    }
}