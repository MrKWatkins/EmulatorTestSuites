namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

internal abstract class PrintInterceptor
{
    public const ushort PrintRoutineAddress = 0x0010;

    private protected PrintInterceptor(IZ80TestHarness z80, ResultWatchingOutput output)
    {
        Z80 = z80;
        Output = output;
        z80.WriteByteToMemory(PrintRoutineAddress, 0xC9);
    }

    public IZ80TestHarness Z80 { get; }

    public ResultWatchingOutput Output { get; }

    internal abstract void HandlePrintRoutine();
}
