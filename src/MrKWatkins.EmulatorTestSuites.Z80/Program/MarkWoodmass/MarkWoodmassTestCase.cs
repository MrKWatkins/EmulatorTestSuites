namespace MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

public sealed class MarkWoodmassTestCase : ProgramTestCase
{
    private readonly ushort startAddress;
    private readonly ushort endOfTestAddress;

    internal MarkWoodmassTestCase(string name, ushort testAddress, byte[] memory, ushort startAddress, ushort testTableStartAddress, ushort endOfTestAddress)
        : base(name, testAddress, memory)
    {
        TestTableStartAddress = testTableStartAddress;
        this.startAddress = startAddress;
        this.endOfTestAddress = endOfTestAddress;
    }

    private protected override ushort StopAddress => 0x80E6;

    private protected override ushort TestTableStartAddress { get; }

    private protected override string PassedString => "passed";

    private protected override string ErrorString => "failed";

    private protected override void InitializeZ80(Z80TestHarness z80)
    {
        // Tests expect certain initial register values.
        z80.RegisterI = 0x3F;
        z80.RegisterAF = 0x3262;
        z80.RegisterSP = 0x7FE8;
        z80.RegisterIY = 0x5C3A;
        z80.RegisterPC = startAddress;

        // Fudge stack.
        z80.SetByteInMemory(0x7FDB, 0x0B);

        // The tests call the CLS (0x0D6B) routine and CHAN_OPEN (0x1601) routines. These, however, don't work with the emulator
        // unless interrupts are running.
        // We cannot put C9 at those addresses as their values are used by the CPD and LDD flags tests. They are both called
        // from a subroutine that starts at 0x80DA and does nothing else of importance. So we inject a RET at 0x80DA making the
        // routine do nothing.
        z80.SetByteInMemory(0x80DA, 0xC9);
    }

    protected override void SetupTestCase(Z80TestHarness z80)
    {
        z80.SetWordInMemory((ushort)(startAddress - 2), 0x0000);

        // The first instruction is LD HL, AddressOfTestTable. Opcode bytes are 21 HH LL, so skip the first byte and write the new address.
        z80.SetWordInMemory((ushort)(startAddress + 1), TestTableStartAddress);

        // Write 0x0000 after the end of the test to terminate.
        z80.SetWordInMemory(endOfTestAddress, 0x0000);
    }

    // Lastly, after tweaking the ROM routines, the tests expect a read-only Spectrum ROM.
    private protected override int TopOfRomArea => 16384;

    private protected override PrintInterceptor OverridePrintRoutine(Z80TestHarness z80, ResultWatchingOutput output) => new ZXSpectrumPrintInterceptor(z80, output);
}