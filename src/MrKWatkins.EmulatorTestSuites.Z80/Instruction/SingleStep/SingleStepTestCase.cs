using System.Text.RegularExpressions;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

/// <summary>
/// A test case from the <see cref="SingleStepTestSuite" />.
/// </summary>
public sealed partial class SingleStepTestCase : InstructionTestCase
{
    [GeneratedRegex("[ _]")]
    private static partial Regex SuperfluousIdCharactersRegex();

    internal SingleStepTestCase(string id, InstructionTestSuiteOptions options)
        : base(id, options)
    {
    }

    /// <summary>
    /// Gets the name of the opcode being tested.
    /// </summary>
    /// <returns>The name of the opcode, or <c>null</c> if the opcode cannot be determined for the test case.</returns>
    public override string? OpcodeName => OpcodeLookup.GetOrNull(SuperfluousIdCharactersRegex().Replace(Id, ""));

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        testOutput?.WriteLine("Executing ");
        var z80 = CreateZ80<TTestHarness>();
        foreach (var step in Step.Load(this))
        {
            Execute(z80, step, testOutput);
        }
    }

    private void Execute(Z80TestHarness z80, Step step, TextWriter? testOutput)
    {
        testOutput?.Write('.');

        z80.Reset();

        step.Input.Initialize(z80);

        z80.ExecuteInstruction();

        AdjustForOverlappedRead(z80);

        Assert(step, z80);
    }

    private void Assert(Step step, Z80TestHarness z80)
    {
        using (z80.CreateAssertionScope($"Step {step.Index}"))
        {
            step.Expected.Assert(AssertionsToRun, z80);
        }
    }
}