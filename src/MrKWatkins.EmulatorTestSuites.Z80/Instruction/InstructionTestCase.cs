namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// A test case from an <see cref="InstructionTestSuite{TTestCase}" />.
/// </summary>
public abstract class InstructionTestCase : global::MrKWatkins.EmulatorTestSuites.Instruction.InstructionTestCase<Z80TestHarness, Cycle>
{
    protected InstructionTestCase(string id, InstructionTestSuiteOptions options)
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
    private protected TTestHarness CreateZ80<TTestHarness>()
        where TTestHarness : Z80TestHarness, new()
    {
        return CreateTestHarness<TTestHarness>();
    }

    protected override void InitializeTestHarness(Z80TestHarness z80)
    {
        base.InitializeTestHarness(z80);
        z80.SetIO(new InstructionIO(z80));
    }
}