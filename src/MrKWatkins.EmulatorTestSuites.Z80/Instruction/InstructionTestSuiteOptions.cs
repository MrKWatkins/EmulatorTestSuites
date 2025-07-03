using System.Collections.Frozen;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public sealed record InstructionTestSuiteOptions
{
    public Assertions AssertionsToRun { get; init; } = Assertions.All;

    public MemoryCycleMethod MemoryCycleMethod { get; init; } = MemoryCycleMethod.Start;

    public IReadOnlyDictionary<string, Assertions> AssertionsToRunOverrides { get; init; } = FrozenDictionary<string, Assertions>.Empty;

    [Pure]
    public Assertions GetAssertionsToRunFor(string testName) => AssertionsToRunOverrides.GetValueOrDefault(testName, AssertionsToRun);
}