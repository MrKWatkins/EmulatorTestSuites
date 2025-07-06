using MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Instruction.DAA;

public sealed class DAATestSuitesTest
{
    [Test]
    public void GetTestCases()
    {
        var testCases = DAATestSuite.Instance.GetTestCases().ToList();
        testCases.Should().HaveCount(2048);
    }
}