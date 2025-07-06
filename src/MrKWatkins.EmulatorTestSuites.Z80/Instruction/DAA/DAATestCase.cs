namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA;

public sealed class DAATestCase : InstructionTestCase
{
    internal DAATestCase(string id, InstructionTestSuiteOptions options, Z80InputState input, Z80ExpectedState expected)
        : base(id, options)
    {
        Input = input;
        Expected = expected;
    }

    public override string Name => Id;

    public override string Opcode => "DAA";

    public Z80InputState Input { get; }

    public Z80ExpectedState Expected { get; }

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