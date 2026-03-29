namespace MrKWatkins.EmulatorTestSuites.Z80.Program.ZEXALL;

/// <summary>
/// A test case from the <see cref="ZEXALLTestSuite" />.
/// </summary>
public sealed class ZEXALLTestCase : ProgramTestCase
{
    internal ZEXALLTestCase(string id, ushort testAddress, byte[] memory)
        : base(id, testAddress, memory)
    {
    }

    private protected override ushort StopAddress => 0x0000;

    private protected override ushort TestTableStartAddress => 0x013A;

    private protected override string PassedString => "OK";

    private protected override string ErrorString => "ERROR";

    // The longest OakCpu steppable aluop cases complete at 20,006,915,491 T-states.
    private protected override ulong MaximumTStates => 20_100_000_000;

    private protected override void InitializeZ80(IZ80TestHarness z80)
    {
        z80.RegisterPC = ZEXALLTestSuite.StartAddress;

        // SP - loaded by first instructions.
        z80.WriteByteToMemory(0x0006, 0xFF);
        z80.WriteByteToMemory(0x0007, 0xFF);

        // Do nothing for RST $38.
        z80.WriteByteToMemory(0x0038, 0xC9);
    }

    private protected override PrintInterceptor OverridePrintRoutine(IZ80TestHarness z80, ResultWatchingOutput output) => new CPMPrintInterceptor(z80, output);
}
