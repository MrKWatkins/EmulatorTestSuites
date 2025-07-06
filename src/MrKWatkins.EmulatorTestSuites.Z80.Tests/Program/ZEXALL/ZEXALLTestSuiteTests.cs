using MrKWatkins.EmulatorTestSuites.Z80.Program.ZEXALL;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.ZEXALL;

public sealed class ZEXALLTestSuiteTests
{
    [TestCase(ZEXALLTestType.ZEXALL, ExpectedResult = 67)]
    [TestCase(ZEXALLTestType.ZEXDOC, ExpectedResult = 67)]
    public int GetTestCases(ZEXALLTestType type) => ZEXALLTestSuite.Get(type).TestCases.Count;
}