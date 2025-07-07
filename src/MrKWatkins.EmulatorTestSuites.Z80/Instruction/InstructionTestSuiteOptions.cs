using System.Collections.Frozen;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Represents configuration options for <see cref="InstructionTestSuite{TTestCase}"/>s, controlling which assertions to run and how memory cycles are handled.
/// </summary>
public sealed record InstructionTestSuiteOptions
{
    /// <summary>
    /// Gets or initializes the default set of <see cref="TestAssertions" /> to run for all tests. Defaults to running all available assertions.
    /// </summary>
    public TestAssertions AssertionsToRun { get; init; } = TestAssertions.All;

    /// <summary>
    /// Gets or initializes the method used for handling memory cycles during test execution. Defaults to using the <see cref="MemoryCycleMethod.Start"/> method.
    /// </summary>
    public MemoryCycleMethod MemoryCycleMethod { get; init; } = MemoryCycleMethod.Start;

    /// <summary>
    /// Gets or initializes a dictionary of test-specific assertion overrides. Keys are test IDs, and values are the specific assertions to run for that test. Defaults to an empty dictionary.
    /// </summary>
    public IReadOnlyDictionary<string, TestAssertions> AssertionsToRunOverrides { get; init; } = FrozenDictionary<string, TestAssertions>.Empty;

    [Pure]
    internal TestAssertions GetAssertionsToRunFor(string testId) => AssertionsToRunOverrides.GetValueOrDefault(testId, AssertionsToRun);
}