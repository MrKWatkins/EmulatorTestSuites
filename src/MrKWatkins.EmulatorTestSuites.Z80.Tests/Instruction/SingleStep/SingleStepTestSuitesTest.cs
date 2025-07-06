using MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Instruction.SingleStep;

public sealed class SingleStepTestSuitesTest
{
    [Test]
    public void GetTestCases()
    {
        var testCases = SingleStepTestSuite.Instance.GetTestCases().ToList();
        testCases.Should().HaveCount(1610);
    }

    [TestCase("00", "00 - NOP")]
    [TestCase("02", "02 - LD (BC), A")]
    [TestCase("CB 46", "CB 46 - BIT 0, (HL)")]
    [TestCase("DD A6", "DD A6 - AND (IX + n)")]
    [TestCase("DD CB __ 1F", "DD CB __ 1F - RR (IX + n), A")]
    [TestCase("ED A3", "ED A3 - OUTI")]
    [TestCase("FD 68", "FD 68 - LD IYL, B")]
    [TestCase("FD CB __ 3B", "FD CB __ 3B - SRL (IY + n), E")]
    public void Name(string id, string expectedName)
    {
        var testCase = SingleStepTestSuite.Instance.GetTestCases().FirstOrDefault(t => t.Id == id);
        testCase.Should().NotBeNull();
        testCase!.Name.Should().Equal(expectedName);
    }
}