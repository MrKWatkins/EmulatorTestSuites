namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public abstract class InstructionTestSuite<TTestCase> : TestSuite
    where TTestCase : InstructionTestCase
{
    private protected InstructionTestSuite(string name, Uri source)
        : base(name, source)
    {
    }

    public abstract InstructionTestSuiteOptions DefaultOptions { get; }

    [Pure]
    public IEnumerable<TTestCase> GetTestCases() => GetTestCases(DefaultOptions);

    [Pure]
    public IEnumerable<TTestCase> GetTestCases(IReadOnlyDictionary<string, TestAssertions> assertionsToRunOverrides) =>
        GetTestCases(DefaultOptions with { AssertionsToRunOverrides = assertionsToRunOverrides });

    [Pure]
    public abstract IEnumerable<TTestCase> GetTestCases(InstructionTestSuiteOptions options);
}