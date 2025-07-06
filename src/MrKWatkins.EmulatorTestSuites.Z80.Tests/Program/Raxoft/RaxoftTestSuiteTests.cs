using MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.Raxoft;

public sealed class RaxoftTestSuiteTests
{
    [TestCase(RaxoftTestType.Ccf, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.Doc, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.DocFlags, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.Flags, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.Full, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.Memptr, RaxoftTestVersion.V1_0, ExpectedResult = 152)]
    [TestCase(RaxoftTestType.Ccf, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    [TestCase(RaxoftTestType.Doc, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    [TestCase(RaxoftTestType.DocFlags, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    [TestCase(RaxoftTestType.Flags, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    [TestCase(RaxoftTestType.Full, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    [TestCase(RaxoftTestType.Memptr, RaxoftTestVersion.V1_2A, ExpectedResult = 160)]
    public int GetTestCases(RaxoftTestType type, RaxoftTestVersion version) => RaxoftTestSuite.Get(type, version).TestCases.Count;
}