using MrKWatkins.EmulatorTestSuites.Z80;
using MrKWatkins.EmulatorTestSuites.Z80.Instruction;
using MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

namespace MrKWatkins.EmulatorTestSuites.Z80N.Instruction.Core;

/// <summary>
/// A test case from the <see cref="CoreTestSuite" />.
/// </summary>
public sealed class CoreTestCase : InstructionTestCase
{
    private readonly FuseZ80InputState input;
    private readonly FuseZ80ExpectedState expected;

    internal CoreTestCase(string id, InstructionTestSuiteOptions options, FuseZ80InputState input, FuseZ80ExpectedState expected)
        : base(id, options)
    {
        this.input = input;
        this.expected = expected;

        input.IOReads = expected.Events.Where(e => e.Type == FuseEventType.PortRead).Select(e => new IOEvent(e.Address, e.Data ?? 0)).ToList();
        expected.Cycles = CycleBuilder.BuildCycles(expected.Events, MemoryCycleMethod).ToList();
    }

    /// <summary>
    /// Gets the name of the opcode being tested.
    /// </summary>
    /// <returns>The name of the opcode, or <c>null</c> if the opcode cannot be determined for the test case.</returns>
    public override string? OpcodeName => Z80NOpcodes.GetOrNull(Id.Split('_')[0]);

    /// <summary>
    /// Gets the initial Z80N state for this test case.
    /// </summary>
    public Z80InputState Input => input;

    /// <summary>
    /// Gets the expected Z80N state after executing the instruction.
    /// </summary>
    public Z80ExpectedState Expected => expected;

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var z80 = CreateZ80<TTestHarness>();

        input.Initialize(z80);

        while (true)
        {
            z80.ExecuteInstruction();

            // Break when we've run the minimum T-states.
            if (z80.TStates >= input.MinimumTStatesToRun)
            {
                break;
            }
        }

        using (z80.CreateAssertionScope())
        {
            expected.Assert(AssertionsToRun, z80);
        }
    }
}