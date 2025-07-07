namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA;

/// <summary>
/// A test case from the <see cref="DAATestSuite" />.
/// </summary>
public sealed class DAATestCase : InstructionTestCase
{
    internal DAATestCase(string id, InstructionTestSuiteOptions options, Z80InputState input, Z80ExpectedState expected)
        : base(id, options)
    {
        Input = input;
        Expected = expected;
    }

    /// <summary>
    /// Gets the name of the test case, which is the same as its ID.
    /// </summary>
    public override string Name => Id;

    /// <summary>
    /// Gets the opcode name for the test case.
    /// </summary>
    public override string OpcodeName => "DAA";

    /// <summary>
    /// Gets the initial Z80 state for this test case.
    /// </summary>
    public Z80InputState Input { get; }

    /// <summary>
    /// Gets the expected Z80 state after executing the DAA instruction.
    /// </summary>
    public Z80ExpectedState Expected { get; }

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var z80 = CreateZ80<TTestHarness>(Input);

        Input.Setup(z80);

        z80.ExecuteInstruction();

        AdjustForOverlappedRead(z80);

        using (z80.CreateAssertionScope())
        {
            Expected.Assert(AssertionsToRun, z80);
        }
    }
}