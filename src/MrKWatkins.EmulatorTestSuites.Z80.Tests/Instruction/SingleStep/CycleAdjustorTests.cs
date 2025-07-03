using MrKWatkins.EmulatorTestSuites.Z80.Instruction;
using MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Instruction.SingleStep;

public sealed class CycleAdjustorTests
{
    [TestCaseSource(nameof(AdjustToTestCases))]
    public void AdjustTo(IReadOnlyList<Cycle> cycles, MemoryCycleMethod method, IReadOnlyList<Cycle> expected)
    {
        var actual = CycleAdjustor.AdjustTo(method, cycles).ToList();
        actual.Should().SequenceEqual(expected);
    }

    [Pure]
    public static IEnumerable<TestCaseData> AdjustToTestCases()
    {
        var original34 = new[]
        {
            new Cycle(CycleType.None, 0, 19604, null),
            new Cycle(CycleType.MemoryRead, 1, 19604, null),
            new Cycle(CycleType.None, 2, 37982, 52),
            new Cycle(CycleType.None, 3, 37982, null),
            new Cycle(CycleType.None, 4, 36112, null),
            new Cycle(CycleType.MemoryRead, 5, 36112, null),
            new Cycle(CycleType.None, 6, 36112, 94),
            new Cycle(CycleType.None, 7, 36112, null),
            new Cycle(CycleType.None, 8, 36112, null),
            new Cycle(CycleType.MemoryWrite, 9, 36112, 95),
            new Cycle(CycleType.None, 10, 36112, null)
        };

        yield return new TestCaseData(original34, MemoryCycleMethod.End, original34).SetArgDisplayNames($"0x34, {nameof(MemoryCycleMethod)}.{nameof(MemoryCycleMethod.End)}");

        var start34 = new[]
        {
            new Cycle(CycleType.MemoryRead, 0, 19604, null),
            new Cycle(CycleType.None, 1, 19604, 52),
            new Cycle(CycleType.None, 2, 37982, null),
            new Cycle(CycleType.None, 3, 37982, null),
            new Cycle(CycleType.MemoryRead, 4, 36112, null),
            new Cycle(CycleType.None, 5, 36112, 94),
            new Cycle(CycleType.None, 6, 36112, null),
            new Cycle(CycleType.None, 7, 36112, null),
            new Cycle(CycleType.MemoryWrite, 8, 36112, 95),
            new Cycle(CycleType.None, 9, 36112, null),
            new Cycle(CycleType.None, 10, 36112, null),
        };

        yield return new TestCaseData(original34, MemoryCycleMethod.Start, start34).SetArgDisplayNames($"0x34, {nameof(MemoryCycleMethod)}.{nameof(MemoryCycleMethod.Start)}");

        var accurate34 = new[]
        {
            new Cycle(CycleType.MemoryRead, 0, 19604, null),
            new Cycle(CycleType.MemoryRead, 1, 19604, 52),
            new Cycle(CycleType.None, 2, 37982, null),
            new Cycle(CycleType.None, 3, 37982, null),
            new Cycle(CycleType.MemoryRead, 4, 36112, null),
            new Cycle(CycleType.MemoryRead, 5, 36112, 94),
            new Cycle(CycleType.None, 6, 36112, null),
            new Cycle(CycleType.None, 7, 36112, null),
            new Cycle(CycleType.MemoryWrite, 8, 36112, 95),
            new Cycle(CycleType.MemoryWrite, 9, 36112, 95),
            new Cycle(CycleType.None, 10, 36112, null),
        };

        yield return new TestCaseData(original34, MemoryCycleMethod.Accurate, accurate34).SetArgDisplayNames($"0x34, {nameof(MemoryCycleMethod)}.{nameof(MemoryCycleMethod.Accurate)}");
    }
}