namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// A test case from an <see cref="InstructionTestSuite{TTestCase}" />.
/// </summary>
public abstract class InstructionTestCase : TestCase
{
    private protected InstructionTestCase(string id, InstructionTestSuiteOptions options)
        : base(id)
    {
        AssertionsToRun = options.GetAssertionsToRunFor(id);
        MemoryCycleMethod = options.MemoryCycleMethod;
    }

    /// <summary>
    /// Gets the name of the test case.
    /// </summary>
    public override string Name => OpcodeName != null ? $"{Id} - {OpcodeName}" : Id;

    /// <summary>
    /// Gets the name of the opcode being tested.
    /// </summary>
    /// <returns>The name of the opcode, or <c>null</c> if the opcode cannot be determined for the test case.</returns>
    public abstract string? OpcodeName { get; }

    /// <summary>
    /// The <see cref="TestAssertions" /> to run for this test case.
    /// </summary>
    public TestAssertions AssertionsToRun { get; }

    // TODO: This should be on the test harness.
    /// <summary>
    /// The <see cref="MemoryCycleMethod" /> used by the emulator being tested.
    /// </summary>
    public MemoryCycleMethod MemoryCycleMethod { get; }

    [Pure]
    private protected static TTestHarness CreateZ80<TTestHarness>()
        where TTestHarness : Z80TestHarness, new()
    {
        var z80 = new TTestHarness { RecordCycles = true };
        z80.SetIO(new InstructionIO(z80));
        return z80;
    }

    // TODO: This should be on the test harness and up to the user.
    private protected static void AdjustForOverlappedRead(Z80TestHarness z80)
    {
        // If the last cycle was a MemoryRead, then we've had an overlapped read. The instruction tests (obviously) assume instruction level execution so won't
        // take this into account. We need to change the event to a None, however we do not need to adjust PC as we do that in the second opcode read step.
        // TODO: Optionally adjust PC for other stepped emulators who might not do this.
        if (LastCycleWasOverlappedRead(z80))
        {
            z80.TStates--;
            z80.MutableCycles!.RemoveAt(z80.MutableCycles.Count - 1);
        }
    }

    [Pure]
    private protected static bool LastCycleWasOverlappedRead(Z80TestHarness z80) => z80.MutableCycles?.LastOrDefault()?.IsOpcodeRead == true;
}