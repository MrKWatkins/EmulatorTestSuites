namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Base class for instruction-based test suites that provide <typeparamref name="TTestCase"/>s for Z80 emulator implementations.
/// </summary>
/// <typeparam name="TTestCase">The type of test cases provided by this test suite.</typeparam>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/z80.html#instruction-test-suites">Documentation</seealso>
public abstract class InstructionTestSuite<TTestCase> : TestSuite
    where TTestCase : InstructionTestCase
{
    private protected InstructionTestSuite(string name, Uri source)
        : base(name, source)
    {
    }

    /// <summary>
    /// The default <see cref="InstructionTestSuiteOptions" /> for the test suite.
    /// </summary>
    public abstract InstructionTestSuiteOptions DefaultOptions { get; }

    /// <summary>
    /// Gets all the test cases using the <see cref="DefaultOptions" />.
    /// </summary>
    /// <returns>A sequence of test cases.</returns>
    [Pure]
    public IEnumerable<TTestCase> GetTestCases() => GetTestCases(DefaultOptions);

    /// <summary>
    /// Gets all the test cases, overriding the <see cref="InstructionTestSuiteOptions.AssertionsToRun"/> on the <see cref="DefaultOptions" />.
    /// </summary>
    /// <paramref name="assertionsToRun">The assertions to run.</paramref>
    /// <returns>A sequence of test cases.</returns>
    [Pure]
    public IEnumerable<TTestCase> GetTestCases(TestAssertions assertionsToRun) => GetTestCases(DefaultOptions with { AssertionsToRun = assertionsToRun });

    /// <summary>
    /// Gets all the test cases, overriding the <see cref="InstructionTestSuiteOptions.AssertionsToRun"/> on the <see cref="DefaultOptions" /> for specific tests.
    /// </summary>
    /// <paramref name="assertionsToRunOverrides">Assertions to run overrides, keyed by <see cref="TestCase.Id"/>.</paramref>
    /// <returns>A sequence of test cases.</returns>
    [Pure]
    public IEnumerable<TTestCase> GetTestCases(IReadOnlyDictionary<string, TestAssertions> assertionsToRunOverrides) =>
        GetTestCases(DefaultOptions with { AssertionsToRunOverrides = assertionsToRunOverrides });

    /// <summary>
    /// Gets all the test cases, overriding the <see cref="InstructionTestSuiteOptions.AssertionsToRun"/> on the <see cref="DefaultOptions" /> for all tests
    /// along with overrides for specific tests.
    /// </summary>
    /// <paramref name="assertionsToRun">The assertions to run.</paramref>
    /// <paramref name="assertionsToRunOverrides">Assertions to run overrides, keyed by <see cref="TestCase.Id"/>.</paramref>
    /// <returns>A sequence of test cases.</returns>
    [Pure]
    public IEnumerable<TTestCase> GetTestCases(TestAssertions assertionsToRun, IReadOnlyDictionary<string, TestAssertions> assertionsToRunOverrides) =>
        GetTestCases(DefaultOptions with { AssertionsToRun = assertionsToRun, AssertionsToRunOverrides = assertionsToRunOverrides });

    /// <summary>
    /// Gets all the test cases using the specified <see cref="InstructionTestSuiteOptions" />.
    /// </summary>
    /// <paramref name="options">The <see cref="InstructionTestSuiteOptions" /> to use.</paramref>
    /// <returns>A sequence of test cases.</returns>
    [Pure]
    public abstract IEnumerable<TTestCase> GetTestCases(InstructionTestSuiteOptions options);
}