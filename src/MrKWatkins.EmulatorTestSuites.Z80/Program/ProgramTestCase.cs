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
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    public sealed override void Execute<TTestHarness>(TextWriter? testOutput = null) => Execute<TTestHarness>(testOutput, null);

    /// <summary>
    /// Executes the test case with the specified test and debug output.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use.</typeparam>
    /// <param name="testOutput">Optional writer for test output. This will be the output from the test program.</param>
    /// <param name="debugOutput">Optional writer for debug output. This will be the state of the emulator before each instruction.</param>
    public void Execute<TTestHarness>(TextWriter? testOutput, TextWriter? debugOutput)
        where TTestHarness : Z80TestHarness, new()
    {
        var z80 = new TTestHarness
        {
            RegisterSP = 0xFFFE,
            TopOfRomArea = TopOfRomArea
        };

        z80.CopyToMemory(0x0000, memory);
        InitializeZ80(z80);
        SetupTestCase(z80);

        var resultWatcher = new ResultWatchingOutput(testOutput, PassedString, ErrorString, SkippedString);
        var printInterceptor = OverridePrintRoutine(z80, resultWatcher);

        // TODO: T-state limit.
        var stopAddress = StopAddress;
        while (true)
        {
            var pc = z80.RegisterPC;
            if (pc == PrintInterceptor.PrintRoutineAddress)
            {
                printInterceptor.HandlePrintRoutine();
            }
            else if (pc == stopAddress)
            {
                break;
            }

            z80.ExecuteInstruction(debugOutput);
        }

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

    private protected virtual void SetupTestCase(Z80TestHarness z80)
    {
        // Write the address of the test at the start of the test table.
        z80.SetWordInMemory(TestTableStartAddress, testAddress);

        // Write the 0x0000 terminator afterwards.
        z80.SetWordInMemory((ushort)(TestTableStartAddress + 2), 0x0000);
    }

    private protected abstract ushort StopAddress { get; }

    private protected abstract ushort TestTableStartAddress { get; }

    private protected abstract string PassedString { get; }

    private protected abstract string ErrorString { get; }

    private protected virtual string? SkippedString => null;

    private protected virtual int TopOfRomArea => int.MinValue;

    private protected abstract void InitializeZ80(Z80TestHarness z80);

    [Pure]
    private protected abstract PrintInterceptor OverridePrintRoutine(Z80TestHarness z80, ResultWatchingOutput output);
}