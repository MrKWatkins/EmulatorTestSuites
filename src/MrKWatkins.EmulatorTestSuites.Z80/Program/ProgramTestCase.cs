namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

/// <summary>
/// Base class for Z80 test cases that execute a full program and verify the results.
/// </summary>
public abstract class ProgramTestCase : TestCase
{
    private readonly ushort testAddress;
    private readonly byte[] memory;

    private protected ProgramTestCase(string id, ushort testAddress, byte[] memory)
        : base(id)
    {
        this.testAddress = testAddress;
        this.memory = memory;
    }

    /// <summary>
    /// Executes the test case with the specified test output.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="IZ80TestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    public sealed override void Execute<TTestHarness>(TextWriter? testOutput = null) => Execute<TTestHarness>(testOutput, null);

    /// <summary>
    /// Executes the test case with the specified test and debug output. Execution will proceed step by step if <typeparamref name="TTestHarness"/>
    /// is a <see cref="IZ80SteppableTestHarness"/>, or instruction by instruction otherwise.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="IZ80TestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    /// <param name="debugOutput">Optional writer for debug output. This will be the state of the emulator before each instruction. Only used for instruction by instruction execution.</param>
    public void Execute<TTestHarness>(TextWriter? testOutput, TextWriter? debugOutput)
        where TTestHarness : IZ80TestHarness, new()
    {
        var z80 = new TTestHarness();
        if (z80 is IZ80SteppableTestHarness steppableTestHarness)
        {
            Execute(steppableTestHarness, testOutput);
        }
        else
        {
            Execute(z80, testOutput, debugOutput);
        }
    }

    /// <summary>
    /// Executes the test case with the specified test and debug output. Execution will proceed instruction by instruction.
    /// </summary>
    /// <param name="z80">The test harness to use.</param>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    /// <param name="debugOutput">Optional writer for debug output. This will be the state of the emulator before each instruction.</param>
    public void Execute(IZ80TestHarness z80, TextWriter? testOutput = null, TextWriter? debugOutput = null)
    {
        var (resultWatcher, printInterceptor) = BeforeExecute(z80, testOutput);

        while (true)
        {
            var pc = z80.RegisterPC;
            if (pc == PrintInterceptor.PrintRoutineAddress)
            {
                printInterceptor.HandlePrintRoutine();
            }
            else if (pc == StopAddress)
            {
                break;
            }

            z80.ExecuteInstruction(debugOutput);
            AssertNotTimedOut(z80);
        }

        AfterExecute(z80, resultWatcher);
    }

    /// <summary>
    /// Executes the test case with the specified test and debug output. Execution will proceed step by step.
    /// </summary>
    /// <param name="z80">The steppable test harness to use.</param>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    public void Execute(IZ80SteppableTestHarness z80, TextWriter? testOutput = null)
    {
        var (resultWatcher, printInterceptor) = BeforeExecute(z80, testOutput);

        while (true)
        {
            var pc = z80.RegisterPC;
            if (pc == PrintInterceptor.PrintRoutineAddress)
            {
                // We'll have intercepted on the first part of the opcode read. Complete it.
                z80.Step();
                AssertNotTimedOut(z80);
                z80.Step();
                AssertNotTimedOut(z80);
                z80.Step();
                AssertNotTimedOut(z80);

                printInterceptor.HandlePrintRoutine();
            }
            else if (pc == StopAddress)
            {
                break;
            }

            z80.Step();
            AssertNotTimedOut(z80);
        }

        AfterExecute(z80, resultWatcher);
    }

    [MustUseReturnValue]
    private (ResultWatchingOutput ResultWatcher, PrintInterceptor PrintInterceptor) BeforeExecute(IZ80TestHarness z80, TextWriter? testOutput)
    {
        z80.RegisterSP = 0xFFFE;
        z80.RomArea = RomArea;

        z80.CopyToMemory(0x0000, memory);
        InitializeZ80(z80);
        SetupTestCase(z80);

        var resultWatcher = new ResultWatchingOutput(testOutput, PassedString, ErrorString, SkippedString);
        var printInterceptor = OverridePrintRoutine(z80, resultWatcher);
        return (resultWatcher, printInterceptor);
    }

    private static void AfterExecute(IZ80TestHarness z80, ResultWatchingOutput resultWatcher)
    {
        switch (resultWatcher.Result)
        {
            case ProgramTestResult.None:
                z80.AssertFail("Test did not return a result.");
                break;

            case ProgramTestResult.Failed:
                z80.AssertFail("Test failed.");
                break;
        }
    }

    private protected void AssertNotTimedOut(IZ80TestHarness z80)
    {
        if (z80.TStates <= MaximumTStates)
        {
            return;
        }

        z80.AssertFail($"Program test exceeded {MaximumTStates:N0} T-states without reaching stop address 0x{StopAddress:X4}. PC=0x{z80.RegisterPC:X4}.");
        throw new InvalidOperationException("The test harness did not fail the test when the program timed out.");
    }

    private protected virtual void SetupTestCase(IZ80TestHarness z80)
    {
        // Write the address of the test at the start of the test table.
        z80.WriteWordToMemory(TestTableStartAddress, testAddress);

        // Write the 0x0000 terminator afterwards.
        z80.WriteWordToMemory((ushort)(TestTableStartAddress + 2), 0x0000);
    }

    private protected abstract ushort StopAddress { get; }

    private protected abstract ushort TestTableStartAddress { get; }

    private protected abstract string PassedString { get; }

    private protected abstract string ErrorString { get; }

    private protected virtual string? SkippedString => null;

    private protected virtual ulong MaximumTStates => 100_000_000;

    private protected virtual (ushort Start, ushort End)? RomArea => null;

    private protected abstract void InitializeZ80(IZ80TestHarness z80);

    [Pure]
    private protected abstract PrintInterceptor OverridePrintRoutine(IZ80TestHarness z80, ResultWatchingOutput output);
}
