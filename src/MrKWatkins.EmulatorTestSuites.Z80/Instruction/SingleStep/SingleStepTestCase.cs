using System.Text.RegularExpressions;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

public sealed partial class SingleStepTestCase : InstructionTestCase
{
    [GeneratedRegex("[ _]")]
    private static partial Regex SuperfluousIdCharactersRegex();

    internal SingleStepTestCase(string id, InstructionTestSuiteOptions options)
        : base(id, options)
    {
    }

    public override string Opcode => OpcodeLookup.Get(SuperfluousIdCharactersRegex().Replace(Id, ""));

    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        testOutput?.WriteLine("Executing ");
        foreach (var step in Step.Load(this))
        {
            Execute<TTestHarness>(step, testOutput);
        }
    }

    private void Execute<TTestHarness>(Step step, TextWriter? testOutput)
        where TTestHarness : Z80TestHarness, new()
    {
        testOutput?.Write('.');

        // TODO: Avoid creating each time.
        var z80 = CreateZ80<TTestHarness>(step.Input);

        step.Input.Setup(z80);

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