namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

public sealed class SingleStepTestSuite : InstructionTestSuite<SingleStepTestCase>
{
    public const TestAssertions DefaultAssertions = TestAssertions.All & ~TestAssertions.Halted;
    internal const string ResourcePrefix = "MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.TestCases.";

    public static readonly SingleStepTestSuite Instance = new();

    private SingleStepTestSuite()
        : base("Single Step", new Uri("https://github.com/SingleStepTests/z80"))
    {
    }

    public override InstructionTestSuiteOptions DefaultOptions { get; } = new() { AssertionsToRun = DefaultAssertions };

    public override IEnumerable<SingleStepTestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        foreach (var resource in typeof(SingleStepTestSuite).Assembly.GetManifestResourceNames().Where(n => n.StartsWith(ResourcePrefix, StringComparison.Ordinal)))
        {
            var name = resource[ResourcePrefix.Length..];

            yield return new SingleStepTestCase(name, options);
        }
    }
}