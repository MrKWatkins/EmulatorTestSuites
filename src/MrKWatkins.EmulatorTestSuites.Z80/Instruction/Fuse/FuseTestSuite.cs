namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// The Fuse test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/fuse.html">Documentation</seealso>
/// <seealso href="https://fuse-emulator.sourceforge.net">Original test suite</seealso>
public sealed class FuseTestSuite : InstructionTestSuite<FuseTestCase>
{
    /// <summary>
    /// The default <see cref="TestAssertions"/> for the <see cref="FuseTestSuite" />.
    /// </summary>
    public const TestAssertions DefaultAssertions = TestAssertions.All & ~TestAssertions.Q;

    /// <summary>
    /// Gets the singleton instance of the <see cref="FuseTestSuite" />.
    /// </summary>
    public static readonly FuseTestSuite Instance = new();

    private FuseTestSuite()
        : base("Fuse", new Uri("https://fuse-emulator.sourceforge.net"))
    {
    }

    /// <summary>
    /// The default <see cref="InstructionTestSuiteOptions" /> for the test suite.
    /// </summary>
    public override InstructionTestSuiteOptions DefaultOptions { get; } = new() { AssertionsToRun = DefaultAssertions };

    /// <summary>
    /// Gets all the test cases using the specified <see cref="InstructionTestSuiteOptions" />.
    /// </summary>
    /// <paramref name="options">The <see cref="InstructionTestSuiteOptions" /> to use.</paramref>
    /// <returns>A sequence of test cases.</returns>
    public override IEnumerable<FuseTestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        var inputs = FuseFormat.ParseInput(OpenResource("tests.in"));
        var expected = FuseFormat.ParseExpected(OpenResource("tests.expected"));

        foreach (var (name, input) in inputs)
        {
            yield return new FuseTestCase(name, options, input, expected[name]);
        }
    }
}