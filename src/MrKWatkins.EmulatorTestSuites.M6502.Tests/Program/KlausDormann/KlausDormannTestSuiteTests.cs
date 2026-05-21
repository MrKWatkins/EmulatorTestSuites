using MrKWatkins.EmulatorTestSuites.M6502.Program.KlausDormann;

namespace MrKWatkins.EmulatorTestSuites.M6502.Tests.Program.KlausDormann;

public sealed class KlausDormannTestSuiteTests
{
    [Test]
    public void TestCases()
    {
        var suite = KlausDormannTestSuite.Instance;

        suite.Name.Should().Equal("Klaus Dormann Functional");
        suite.Source.Should().Equal(new Uri("https://github.com/Klaus2m5/6502_65C02_functional_tests"));
        suite.TestCases.Should().HaveCount(1);
        suite.TestCases[0].Name.Should().Equal("6502 Functional Test");
    }
}