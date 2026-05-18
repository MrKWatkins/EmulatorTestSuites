namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction;

/// <summary>
/// Base class for instruction-based test suites that provide <typeparamref name="TTestCase"/>s for M6502 emulator implementations.
/// </summary>
/// <typeparam name="TTestCase">The type of test cases provided by this test suite.</typeparam>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/m6502.html">Documentation</seealso>
public abstract class InstructionTestSuite<TTestCase> : TestSuite
    where TTestCase : InstructionTestCase
{
    private protected InstructionTestSuite(string name, Uri source)
        : base(name, source)
    {
    }

    /// <summary>
    /// Gets all the test cases provided by this suite.
    /// </summary>
    [Pure]
    [SuppressMessage("Design", "CA1024:Use properties where appropriate")]
    public abstract IEnumerable<TTestCase> GetTestCases();
}