using MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.MarkWoodmass;

public sealed class MarkWoodmassTestSuiteTests
{
    [TestCase(MarkWoodmassTestType.Flags, ExpectedResult = 47)]
    [TestCase(MarkWoodmassTestType.Memptr, ExpectedResult = 58)]
    public int GetTestCases(MarkWoodmassTestType type)
    {
        var suite = MarkWoodmassTestSuite.Get(type);
        suite.Type.Should().Equal(type);
        return suite.TestCases.Count;
    }

    [Test]
    public void Flags() => MarkWoodmassTestSuite.Flags.Type.Should().Equal(MarkWoodmassTestType.Flags);

    [Test]
    public void Memptr() => MarkWoodmassTestSuite.Memptr.Type.Should().Equal(MarkWoodmassTestType.Memptr);
}