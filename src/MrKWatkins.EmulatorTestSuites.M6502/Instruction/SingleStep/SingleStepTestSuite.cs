namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction.SingleStep;

/// <summary>
/// The Single Step test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/m6502.html">Documentation</seealso>
/// <seealso href="https://github.com/SingleStepTests/65x02/tree/main/6502">Original test suite</seealso>
public sealed class SingleStepTestSuite : InstructionTestSuite<SingleStepTestCase>
{
    internal const string ResourcePrefix = "MrKWatkins.EmulatorTestSuites.M6502.Instruction.SingleStep.TestCases.";

    /// <summary>
    /// Gets the singleton instance of the <see cref="SingleStepTestSuite" />.
    /// </summary>
    public static readonly SingleStepTestSuite Instance = new();

    private SingleStepTestSuite()
        : base("Single Step", new Uri("https://github.com/SingleStepTests/65x02"))
    {
    }

    /// <summary>
    /// Gets all the test cases provided by this suite.
    /// </summary>
    [Pure]
    [SuppressMessage("Design", "CA1024:Use properties where appropriate")]
    public override IEnumerable<SingleStepTestCase> GetTestCases()
    {
        foreach (var resource in typeof(SingleStepTestSuite).Assembly.GetManifestResourceNames().Where(n => n.StartsWith(ResourcePrefix, StringComparison.Ordinal)))
        {
            yield return new SingleStepTestCase(resource[ResourcePrefix.Length..]);
        }
    }
}