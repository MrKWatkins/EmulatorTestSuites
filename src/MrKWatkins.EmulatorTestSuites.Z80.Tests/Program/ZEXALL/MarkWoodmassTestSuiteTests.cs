using MrKWatkins.EmulatorTestSuites.Z80.Program.ZEXALL;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.ZEXALL;

public sealed class ZEXALLTestSuiteTests
{
    [TestCase(ZEXALLTestType.ZEXALL, 67)]
    [TestCase(ZEXALLTestType.ZEXDOC, 67)]
    public void GetTestCases(ZEXALLTestType type, int expectedCount)
    {
        var testCases = ZEXALLTestSuite.Get(type).TestCases.ToList();
        testCases.Should().HaveCount(expectedCount);
    }
}