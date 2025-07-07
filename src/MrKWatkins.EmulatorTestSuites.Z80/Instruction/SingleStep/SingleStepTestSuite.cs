namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

/// <summary>
/// The Single Step test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/singlestep.html">Documentation</seealso>
/// <seealso href="https://github.com/SingleStepTests/z80">Original test suite</seealso>
public sealed class SingleStepTestSuite : InstructionTestSuite<SingleStepTestCase>
{
    /// <summary>
    /// The default <see cref="TestAssertions"/> for the <see cref="SingleStepTestSuite" />.
    /// </summary>
    public const TestAssertions DefaultAssertions = TestAssertions.All & ~TestAssertions.Halted;

    internal const string ResourcePrefix = "MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.TestCases.";

    /// <summary>
    /// Gets the singleton instance of the <see cref="SingleStepTestSuite" />.
    /// </summary>
    public static readonly SingleStepTestSuite Instance = new();

    private SingleStepTestSuite()
        : base("Single Step", new Uri("https://github.com/SingleStepTests/z80"))
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
    public override IEnumerable<SingleStepTestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        foreach (var resource in typeof(SingleStepTestSuite).Assembly.GetManifestResourceNames().Where(n => n.StartsWith(ResourcePrefix, StringComparison.Ordinal)))
        {
            var name = resource[ResourcePrefix.Length..];

            yield return new SingleStepTestCase(name, options);
        }
    }
}