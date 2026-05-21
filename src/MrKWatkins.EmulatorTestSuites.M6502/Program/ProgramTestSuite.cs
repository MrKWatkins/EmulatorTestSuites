namespace MrKWatkins.EmulatorTestSuites.M6502.Program;

/// <summary>
/// Base class for program-based test suites that provide <typeparamref name="TTestCase" />s for M6502 emulator implementations.
/// </summary>
/// <typeparam name="TTestCase">The type of test cases provided by this test suite.</typeparam>
public abstract class ProgramTestSuite<TTestCase> : TestSuite
    where TTestCase : TestCase
{
    private readonly Lazy<IReadOnlyList<TTestCase>> lazyTestCases;

    private protected ProgramTestSuite(string name, Uri source)
        : base(name, source)
    {
        lazyTestCases = new Lazy<IReadOnlyList<TTestCase>>(() => EnumerateTestCases().ToList());
    }

    /// <summary>
    /// Gets the list of test cases in this test suite.
    /// </summary>
    public IReadOnlyList<TTestCase> TestCases => lazyTestCases.Value;

    /// <summary>
    /// Enumerates the test cases in this suite.
    /// </summary>
    [Pure]
    private protected abstract IEnumerable<TTestCase> EnumerateTestCases();
}