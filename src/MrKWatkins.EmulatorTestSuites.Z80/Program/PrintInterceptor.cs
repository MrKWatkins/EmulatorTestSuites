namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

internal abstract class PrintInterceptor
{
    public const ushort PrintRoutineAddress = 0x0010;

    private protected PrintInterceptor(Z80TestHarness z80, ResultWatchingOutput output)
    {
        Z80 = z80;
        Output = output;
        z80.SetByteInMemory(PrintRoutineAddress, 0xC9);
    }

    public Z80TestHarness Z80 { get; }

    public ResultWatchingOutput Output { get; }

    internal abstract void HandlePrintRoutine();
}