namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// A test case from the <see cref="FuseTestSuite" />.
/// </summary>
public sealed class FuseTestCase : InstructionTestCase
{
    internal FuseTestCase(string id, InstructionTestSuiteOptions options, FuseZ80InputState input, FuseZ80ExpectedState expected)
        : base(id, options)
    {
        Input = input;
        Expected = expected;

        Input.IOReads = expected.Events.Where(r => r.Type == FuseEventType.PortRead).Select(r => new IOEvent(r.Address, r.Data ?? 0)).ToList();

        // For Fuse, we just test memory and IO events. We ignore empty cycles because we have no way to get the Address value (IR) for None cycles after an opcode read.
        // We could infer some from the MemoryContends, but not all, plus Fuse puts IR on the address bus after incrementing R; it should be before.
        Expected.Cycles = CycleBuilder.BuildCycles(expected.Events, MemoryCycleMethod).ToList();
    }

    /// <summary>
    /// Gets the name of the opcode being tested.
    /// </summary>
    /// <returns>The name of the opcode, or <c>null</c> if the opcode cannot be determined for the test case.</returns>
    public override string? OpcodeName => OpcodeLookup.GetOrNull(Id.Split('_')[0]);

    /// <summary>
    /// Gets the initial Z80 state for this test case.
    /// </summary>
    public FuseZ80InputState Input { get; }

    /// <summary>
    /// Gets the expected Z80 state after executing the DAA instruction.
    /// </summary>
    public FuseZ80ExpectedState Expected { get; }

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var z80 = CreateZ80<TTestHarness>(Input);

        Input.Setup(z80);

        while (true)
        {
            z80.ExecuteInstruction();

            // Break when we've run the minimum T-states. If we've just had an overlapped read, then we need to adjust TStates by 1.
            var tStates = z80.TStates;
            if (LastCycleWasOverlappedRead(z80))
            {
                tStates--;

            }

            if (tStates >= Input.MinimumTStatesToRun)
            {
                break;
            }
        }

        AdjustForOverlappedRead(z80);

        Assert(z80);
    }

    private void Assert(Z80TestHarness z80)
    {
        using (z80.CreateAssertionScope())
        {
            Expected.Assert(AssertionsToRun, z80);
        }
    }
}