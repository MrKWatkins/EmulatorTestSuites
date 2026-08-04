using MrKWatkins.EmulatorTestSuites.Z80;
using MrKWatkins.EmulatorTestSuites.Z80N.Instruction.Core;

namespace MrKWatkins.EmulatorTestSuites.Z80N.Tests.Instruction.Core;

public sealed class CoreTestSuiteTests
{
    [Test]
    public void GetTestCases()
    {
        var testCases = CoreTestSuite.Instance.GetTestCases().ToList();
        testCases.Should().HaveCount(42);

        foreach (var testCase in testCases)
        {
            AssertThat.Invoking(() => testCase.Name).Should().NotThrow();
        }
    }

    /// <summary>
    /// Every test case should be for one of the instructions the Z80N adds, so every one should have a name for its opcode.
    /// </summary>
    [Test]
    public void GetTestCases_AllOpcodesAreNamed() =>
        CoreTestSuite.Instance.GetTestCases().Where(testCase => testCase.OpcodeName == null).Should().BeEmpty();

    /// <summary>
    /// The last cycle of a test case cannot start after the instruction has finished.
    /// </summary>
    [Test]
    public void GetTestCases_CyclesAreWithinTheInstruction()
    {
        foreach (var testCase in CoreTestSuite.Instance.GetTestCases())
        {
            testCase.Expected.Cycles.Where(cycle => cycle.Index >= testCase.Expected.TStates).Should().BeEmpty();
        }
    }

    [TestCase("ed23", "ed23 - SWAPNIB")]
    [TestCase("ed24_1", "ed24_1 - MIRROR A")]
    [TestCase("ed91", "ed91 - NEXTREG n, n")]
    [TestCase("eda4", "eda4 - LDIX")]
    [TestCase("eda4_1", "eda4_1 - LDIX")]
    [TestCase("edb7", "edb7 - LDPIRX")]
    public void Name(string id, string expectedName)
    {
        var testCase = CoreTestSuite.Instance.GetTestCases().FirstOrDefault(t => t.Id == id);
        testCase.Should().NotBeNull();
        testCase!.Name.Should().Equal(expectedName);
    }

    /// <summary>
    /// NEXTREG is the only instruction that writes to a Next register, and it does so on a bus of its own rather than the I/O bus.
    /// </summary>
    [Test]
    public void NextRegisterWrites()
    {
        var testCase = CoreTestSuite.Instance.GetTestCases().Single(t => t.Id == "ed91");

        testCase.Expected.NextRegisterWrites.Should().HaveCount(1);
        testCase.Expected.NextRegisterWrites[0].Port.Should().Equal(0x07);
        testCase.Expected.NextRegisterWrites[0].Value.Should().Equal(0x03);
        testCase.Expected.Cycles.Where(cycle => cycle.Type == CycleType.NextRegisterWrite).Should().HaveCount(1);
    }
}