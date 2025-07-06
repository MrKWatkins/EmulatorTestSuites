using MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.Raxoft;

public sealed class RaxoftTestSuiteTests
{
    [TestCase(RaxoftTestType.Ccf, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.Doc, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.DocFlags, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.Flags, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.Full, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.Memptr, RaxoftTestVersion.V1_0, 152)]
    [TestCase(RaxoftTestType.Ccf, RaxoftTestVersion.V1_2A, 160)]
    [TestCase(RaxoftTestType.Doc, RaxoftTestVersion.V1_2A, 160)]
    [TestCase(RaxoftTestType.DocFlags, RaxoftTestVersion.V1_2A, 160)]
    [TestCase(RaxoftTestType.Flags, RaxoftTestVersion.V1_2A, 160)]
    [TestCase(RaxoftTestType.Full, RaxoftTestVersion.V1_2A, 160)]
    [TestCase(RaxoftTestType.Memptr, RaxoftTestVersion.V1_2A, 160)]
    public void GetTestCases(RaxoftTestType type, RaxoftTestVersion version, int expectedCount)
    {
        var testCases = RaxoftTestSuite.Get(type, version).TestCases.ToList();
        testCases.Should().HaveCount(expectedCount);
    }
}