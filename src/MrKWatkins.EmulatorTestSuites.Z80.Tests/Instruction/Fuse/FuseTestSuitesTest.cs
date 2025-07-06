using MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Instruction.Fuse;

public sealed class FuseTestSuitesTest
{
    [Test]
    public void GetTestCases()
    {
        var testCases = FuseTestSuite.Instance.GetTestCases().ToList();
        testCases.Should().HaveCount(1356);
    }

    [TestCase("00", "00 - NOP")]
    [TestCase("02", "02 - LD (BC), A")]
    [TestCase("02_1", "02_1 - LD (BC), A")]
    [TestCase("cb46", "cb46 - BIT 0, (HL)")]
    [TestCase("cb46_1", "cb46_1 - BIT 0, (HL)")]
    [TestCase("dda6", "dda6 - AND (IX + n)")]
    [TestCase("ddcb1f", "ddcb1f - RR (IX + n), A")]
    [TestCase("eda3", "eda3 - OUTI")]
    [TestCase("eda3_01", "eda3_01 - OUTI")]
    [TestCase("fd68", "fd68 - LD IYL, B")]
    [TestCase("fdcb3b", "fdcb3b - SRL (IY + n), E")]
    public void Name(string id, string expectedName)
    {
        var testCase = FuseTestSuite.Instance.GetTestCases().FirstOrDefault(t => t.Id == id);
        testCase.Should().NotBeNull();
        testCase!.Name.Should().Equal(expectedName);
    }
}