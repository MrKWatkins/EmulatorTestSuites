namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

/// <summary>
/// A test case from the <see cref="RaxoftTestSuite" />.
/// </summary>
public sealed class RaxoftTestCase : ProgramTestCase
{
    private const ushort StartAddress = 0x8000;

    internal RaxoftTestCase(string id, ushort testAddress, byte[] memory, ushort testTableStartAddress)
        : base(id, testAddress, memory)
    {
        TestTableStartAddress = testTableStartAddress;
    }

    private protected override ushort StopAddress => 0x0000;

    private protected override ushort TestTableStartAddress { get; }

    private protected override string PassedString => "OK";

    private protected override string ErrorString => "FAILED";

    private protected override string SkippedString => "Skipped";

    private protected override void InitializeZ80(Z80TestHarness z80)
    {
        z80.RegisterPC = StartAddress;

        // CLS routine; needs interrupts. Return instead.
        z80.SetByteInMemory(0x0D6B, 0xC9);

        // CHAN_OPEN routine; needs interrupts. Return instead.
        z80.SetByteInMemory(0x1601, 0xC9);

        // 0xBF is expected on port 0xFE.
        z80.SetIO(new NullIO(0xBF));
    }

    private protected override PrintInterceptor OverridePrintRoutine(Z80TestHarness z80, ResultWatchingOutput output) => new ZXSpectrumPrintInterceptor(z80, output);
}