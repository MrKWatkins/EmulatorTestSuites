namespace MrKWatkins.EmulatorTestSuites.M6502.Program;

/// <summary>
/// Base class for M6502 test cases that execute a full program and verify the result.
/// </summary>
public abstract class ProgramTestCase : TestCase
{
    private readonly byte[] memory;

    private protected ProgramTestCase(string id, byte[] memory)
        : base(id)
    {
        this.memory = memory;
    }

    /// <summary>
    /// Executes the test case with the specified test output.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="M6502TestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output.</param>
    public sealed override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var m6502 = new TTestHarness();
        m6502.Reset();
        m6502.CopyToMemory(0x0000, memory);
        SetupTestCase(m6502);

        if (m6502 is M6502SteppableTestHarness steppable)
        {
            Execute(steppable, testOutput);
            return;
        }

        Execute(m6502, testOutput);
    }

    private void Execute(M6502TestHarness m6502, TextWriter? testOutput)
    {
        while (true)
        {
            var pc = m6502.RegisterPC;
            m6502.ExecuteInstruction();
            AssertNotTimedOut(m6502);

            if (m6502.RegisterPC == pc)
            {
                AssertCompleted(m6502, pc, testOutput);
                return;
            }
        }
    }

    private void Execute(M6502SteppableTestHarness m6502, TextWriter? testOutput)
    {
        ushort? lastOpcodeReadPc = null;

        while (true)
        {
            var pc = m6502.RegisterPC;
            var opcodeRead = m6502.Step();
            AssertNotTimedOut(m6502);

            if (!opcodeRead)
            {
                continue;
            }

            if (lastOpcodeReadPc == pc)
            {
                AssertCompleted(m6502, pc, testOutput);
                return;
            }

            lastOpcodeReadPc = pc;
        }
    }

    [Pure]
    private protected virtual ulong MaximumTStates => 100_000_000;

    private protected virtual void SetupTestCase(M6502TestHarness m6502)
    {
    }

    private protected abstract void AssertCompleted(M6502TestHarness m6502, ushort stopAddress, TextWriter? testOutput);

    private void AssertNotTimedOut(M6502TestHarness m6502)
    {
        if (m6502.TStates <= MaximumTStates)
        {
            return;
        }

        m6502.AssertFail($"Program test exceeded {MaximumTStates:N0} T-states without reaching a terminal loop. PC=0x{m6502.RegisterPC:X4}.");
        throw new InvalidOperationException("The test harness did not fail the test when the program timed out.");
    }
}