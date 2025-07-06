namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public abstract class InstructionTestCase : TestCase
{
    private protected InstructionTestCase(string id, InstructionTestSuiteOptions options)
        : base(id)
    {
        AssertionsToRun = options.GetAssertionsToRunFor(id);
        MemoryCycleMethod = options.MemoryCycleMethod;
    }

    public override string Name => $"{Id} - {Opcode}";

    public abstract string Opcode { get; }

    public TestAssertions AssertionsToRun { get; }

    public MemoryCycleMethod MemoryCycleMethod { get; }

    [Pure]
    protected static TTestHarness CreateZ80<TTestHarness>(Z80InputState inputState)
        where TTestHarness : Z80TestHarness, new()
    {
        var z80 = new TTestHarness { RecordCycles = true };
        z80.SetIO(new InstructionIO(z80, inputState));
        return z80;
    }

    // TODO: Move to test harness?
    protected static void AdjustForOverlappedRead(Z80TestHarness z80)
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
    protected static bool LastCycleWasOverlappedRead(Z80TestHarness z80) => z80.MutableCycles?.LastOrDefault()?.IsOpcodeRead == true;
}