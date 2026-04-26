using MrKWatkins.EmulatorTestSuites.Z80;

namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum.Timing;

/// <summary>
/// A test case from the <see cref="TimingTestSuite" />.
/// </summary>
public sealed class TimingTestCase : ZXSpectrumTestCase
{
    private const ulong MaximumTStates = 10_000_000;
    private const ushort SpectrumRomStart = 0x0000;
    private const ushort SpectrumRomEnd = 0x3FFF;
    private const ushort ScreenMemoryAddress = 0x4000;
    private const ushort RandomizeUsrRoutineAddress = 0x34B6;
    private const ushort TestMachineCodeAddress = 0xC000;
    private const ushort StopAddress = 0xBC28;
    private const ushort TestNumberAddress = 40000;
    private const ushort ContendedFlagAddress = 40002;
    private const ushort ActualResultAddress = 0xEF00;
    private const ushort ExpectedResultAddress = 0xE200;
    private const ushort LateTimingOffset = 512;

    internal TimingTestCase(byte testNumber, string description, bool contended)
        : base(CreateId(testNumber, contended))
    {
        TestNumber = testNumber;
        Description = description;
        Contended = contended;
    }

    /// <summary>
    /// Gets the original test number.
    /// </summary>
    public byte TestNumber { get; }

    /// <summary>
    /// Gets whether this test case uses the contended variant.
    /// </summary>
    public bool Contended { get; }

    /// <summary>
    /// Gets the description of the instruction group being tested.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the display name for this test case.
    /// </summary>
    public override string Name => $"Test {TestNumber} {{{(Contended ? "Contended" : "Uncontended")}}} {Description}";

    /// <summary>
    /// Executes this test case using the specified <see cref="ZXSpectrumTestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="ZXSpectrumTestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var timingType = TimingTestSuite.Instance.GetTimingType<TTestHarness>();
        var spectrum = new TTestHarness();
        var z80 = spectrum.Z80;

        var actual = Execute(spectrum, this);
        var expected = ReadExpectedResult(z80, timingType, TestNumber, Contended);

        testOutput?.WriteLine($"{timingType} timings detected.");
        testOutput?.WriteLine($"Expected: R={expected.RegisterR} loop={expected.LoopCounter} sp={expected.StackPointer}");
        testOutput?.WriteLine($"Actual: R={actual.RegisterR} loop={actual.LoopCounter} sp={actual.StackPointer}");

        using (z80.CreateAssertionScope())
        {
            z80.AssertEqual(actual.RegisterR, expected.RegisterR, $"Expected R to be {expected.RegisterR} but was {actual.RegisterR}.");
            z80.AssertEqual(actual.LoopCounter, expected.LoopCounter, $"Expected loop to be {expected.LoopCounter} but was {actual.LoopCounter}.");
            z80.AssertEqual(actual.StackPointer, expected.StackPointer, $"Expected sp to be {expected.StackPointer} but was {actual.StackPointer}.");
        }
    }

    internal static TimingType DetectTiming<TTestHarness>()
        where TTestHarness : ZXSpectrumTestHarness, new()
    {
        var spectrum = new TTestHarness();
        var actual = Execute(spectrum, 0, false);

        return actual switch
        {
            { RegisterR: 2, LoopCounter: 0, StackPointer: 49478 } => TimingType.Early,
            { RegisterR: 122, LoopCounter: 0, StackPointer: 49478 } => TimingType.Late,
            _ => FailToDetectTimings(spectrum.Z80, actual)
        };
    }

    private static TimingResult Execute(ZXSpectrumTestHarness spectrum, TimingTestCase testCase)
    {
        var z80 = spectrum.Z80;
        if (RequiresScreen(testCase))
        {
            InitializeMachineCodeExecution(z80, testCase.TestNumber, testCase.Contended, false);
            z80.CopyToMemory(ScreenMemoryAddress, Screens.Get(testCase.TestNumber, testCase.Contended));
        }
        else
        {
            InitializeMachineCodeExecution(z80, testCase.TestNumber, testCase.Contended, true);
        }

        spectrum.StartFrame();

        ExecuteToStop(spectrum);
        return ReadActualResult(z80);
    }

    private static TimingResult Execute(ZXSpectrumTestHarness spectrum, byte testNumber, bool contended)
    {
        var z80 = spectrum.Z80;
        InitializeMachineCodeExecution(z80, testNumber, contended, true);
        z80.TStates = 0;

        ExecuteToStop(spectrum);
        return ReadActualResult(z80);
    }

    private static void InitializeMachineCodeExecution(Z80TestHarness z80, byte testNumber, bool contended, bool useNullIo)
    {
        z80.RomArea = (SpectrumRomStart, SpectrumRomEnd);
        if (useNullIo)
        {
            z80.SetIO(new NullIO(0xBF));
        }

        z80.CopyToMemory(0x0000, TimingTestSuite.Instance.BaseMemory);
        z80.RegisterSP = 0xFFFE;
        z80.WriteByteToMemory(TestNumberAddress, testNumber);
        z80.WriteByteToMemory(ContendedFlagAddress, (byte)(contended ? 1 : 0));
        z80.Interrupt = false;

        SetupTestMachineCode(z80);
    }

    [Pure]
    private static bool RequiresScreen(TimingTestCase testCase) => testCase.TestNumber is >= 35 and <= 37;

    private static void SetupTestMachineCode(Z80TestHarness z80)
    {
        // The machine code is called with RANDOMIZE USR 49152. The Spectrum ROM's USR routine expects BC to contain
        // the target address. See https://skoolkid.github.io/rom/asm/34B3.html.
        z80.RegisterPC = RandomizeUsrRoutineAddress;
        z80.RegisterBC = 49152;

        // Step by full instructions to ensure we're at an instruction boundary when the test machine code starts.
        while (z80.RegisterPC != TestMachineCodeAddress)
        {
            z80.ExecuteInstruction();
            AssertNotTimedOut(z80);
        }
    }

    private static void ExecuteToStop(ZXSpectrumTestHarness spectrum)
    {
        var z80 = spectrum.Z80;
        var steppable = spectrum.SteppableZ80;
        if (steppable != null)
        {
            while (z80.RegisterPC != StopAddress)
            {
                steppable.Step();
                AssertNotTimedOut(z80);
            }
            return;
        }

        while (z80.RegisterPC != StopAddress)
        {
            z80.ExecuteInstruction();
            AssertNotTimedOut(z80);
        }
    }

    [Pure]
    private static TimingResult ReadActualResult(Z80TestHarness z80) =>
        new(z80.ReadByteFromMemory(ActualResultAddress), z80.ReadWordFromMemory(ActualResultAddress + 1), z80.ReadWordFromMemory(ActualResultAddress + 3));

    [Pure]
    private static TimingResult ReadExpectedResult(Z80TestHarness z80, TimingType timingType, byte testNumber, bool contended)
    {
        var address = (ushort)(ExpectedResultAddress + testNumber * 10 + (contended ? 5 : 0));
        if (timingType == TimingType.Late)
        {
            address += LateTimingOffset;
        }

        return new(z80.ReadByteFromMemory(address), z80.ReadWordFromMemory((ushort)(address + 1)), z80.ReadWordFromMemory((ushort)(address + 3)));
    }

    [Pure]
    private static string CreateId(byte testNumber, bool contended) => $"{testNumber:00}-{(contended ? "contended" : "uncontended")}";

    private static void AssertNotTimedOut(Z80TestHarness z80)
    {
        if (z80.TStates <= MaximumTStates)
        {
            return;
        }

        z80.AssertFail($"Program test exceeded {MaximumTStates:N0} T-states without reaching stop address 0x{StopAddress:X4}. PC=0x{z80.RegisterPC:X4}.");
        throw new InvalidOperationException("The test harness did not fail the test when the program timed out.");
    }

    [Pure]
    private static TimingType FailToDetectTimings(Z80TestHarness z80, TimingResult actual)
    {
        z80.AssertFail($"Could not detect timings. Actual result was R={actual.RegisterR} loop={actual.LoopCounter} sp={actual.StackPointer}.");
        throw new InvalidOperationException("The test harness did not fail the test when timing detection failed.");
    }

    private readonly record struct TimingResult(byte RegisterR, ushort LoopCounter, ushort StackPointer);
}