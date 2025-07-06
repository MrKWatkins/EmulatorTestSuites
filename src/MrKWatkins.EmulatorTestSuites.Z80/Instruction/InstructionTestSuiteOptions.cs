using System.Collections.Frozen;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public sealed record InstructionTestSuiteOptions
{
    public TestAssertions AssertionsToRun { get; init; } = TestAssertions.All;

    public MemoryCycleMethod MemoryCycleMethod { get; init; } = MemoryCycleMethod.Start;

    public IReadOnlyDictionary<string, TestAssertions> AssertionsToRunOverrides { get; init; } = FrozenDictionary<string, TestAssertions>.Empty;

    [Pure]
    public TestAssertions GetAssertionsToRunFor(string testName) => AssertionsToRunOverrides.GetValueOrDefault(testName, AssertionsToRun);
}