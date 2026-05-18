namespace MrKWatkins.EmulatorTestSuites.Instruction;

/// <summary>
/// Base class for instruction-oriented test cases.
/// </summary>
/// <typeparam name="THarness">The type of harness used to execute the test case.</typeparam>
/// <typeparam name="TCycle">The type used to represent recorded cycles.</typeparam>
public abstract class InstructionTestCase<THarness, TCycle> : TestCase<THarness>
    where THarness : TestHarness<TCycle>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InstructionTestCase{THarness, TCycle}" /> class.
    /// </summary>
    /// <param name="id">The unique identifier for this test case.</param>
    protected InstructionTestCase(string id)
        : base(id)
    {
    }

    /// <summary>
    /// Creates and initializes a harness for instruction execution.
    /// </summary>
    /// <typeparam name="TTestHarness">The concrete harness type to create.</typeparam>
    [Pure]
    protected TTestHarness CreateTestHarness<TTestHarness>()
        where TTestHarness : THarness, new()
    {
        var testHarness = new TTestHarness();
        InitializeTestHarness(testHarness);
        return testHarness;
    }

    /// <summary>
    /// Initializes a harness before the instruction test runs.
    /// </summary>
    /// <param name="testHarness">The harness to initialize.</param>
    protected virtual void InitializeTestHarness(THarness testHarness) => testHarness.RecordCycles = true;
}