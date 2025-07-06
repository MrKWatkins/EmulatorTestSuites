using MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.MarkWoodmass;

public sealed class MarkWoodmassTestSuiteTests
{
    [TestCase(MarkWoodmassTestType.Flags, 47)]
    [TestCase(MarkWoodmassTestType.Memptr, 58)]
    public void GetTestCases(MarkWoodmassTestType type, int expectedCount)
    {
        var testCases = MarkWoodmassTestSuite.Get(type).TestCases.ToList();
        testCases.Should().HaveCount(expectedCount);
    }
}