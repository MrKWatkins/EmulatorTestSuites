using MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.MarkWoodmass;

public sealed class MarkWoodmassTestSuiteTests
{
    [TestCase(MarkWoodmassTestType.Flags, ExpectedResult = 47)]
    [TestCase(MarkWoodmassTestType.Memptr, ExpectedResult = 58)]
    public int GetTestCases(MarkWoodmassTestType type) => MarkWoodmassTestSuite.Get(type).TestCases.Count;
}