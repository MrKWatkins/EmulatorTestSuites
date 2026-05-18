namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction.SingleStep;

/// <summary>
/// A test case from the <see cref="SingleStepTestSuite" />.
/// </summary>
public sealed class SingleStepTestCase : InstructionTestCase
{
    internal SingleStepTestCase(string id)
        : base(id)
    {
    }

    /// <summary>
    /// Executes this test case using the specified <see cref="M6502TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="M6502TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        testOutput?.WriteLine("Executing ");
        var m6502 = CreateM6502<TTestHarness>();
        foreach (var step in Step.Load(this))
        {
            Execute(m6502, step, testOutput);
        }
    }

    private static void Execute(M6502TestHarness m6502, Step step, TextWriter? testOutput)
    {
        testOutput?.Write('.');

        m6502.Reset();

        step.Input.Initialize(m6502);

        m6502.ExecuteInstruction();

        using (m6502.CreateAssertionScope($"Step {step.Index}"))
        {
            step.Expected.Assert(m6502);
        }
    }
}