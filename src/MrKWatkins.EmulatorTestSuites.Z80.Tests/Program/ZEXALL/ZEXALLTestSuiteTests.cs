using MrKWatkins.EmulatorTestSuites.Z80.Program.ZEXALL;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.ZEXALL;

public sealed class ZEXALLTestSuiteTests
{
    [TestCase(ZEXALLTestType.ZEXALL, ExpectedResult = 67)]
    [TestCase(ZEXALLTestType.ZEXDOC, ExpectedResult = 67)]
    public int GetTestCases(ZEXALLTestType type)
    {
        var suite = ZEXALLTestSuite.Get(type);
        suite.Type.Should().Equal(type);
        return suite.TestCases.Count;
    }

    [Test]
    public void Flags() => ZEXALLTestSuite.ZEXALL.Type.Should().Equal(ZEXALLTestType.ZEXALL);

    [Test]
    public void Memptr() => ZEXALLTestSuite.ZEXDOC.Type.Should().Equal(ZEXALLTestType.ZEXDOC);
}