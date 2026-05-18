using MrKWatkins.EmulatorTestSuites.M6502.Instruction.SingleStep;

namespace MrKWatkins.EmulatorTestSuites.M6502.Tests.Instruction.SingleStep;

public sealed class SingleStepTestSuitesTest
{
    [Test]
    public void GetTestCases()
    {
        var testCases = SingleStepTestSuite.Instance.GetTestCases().ToList();
        testCases.Should().HaveCount(256);
    }

    [Test]
    public void LoadFirstStepOfBrk()
    {
        var testCase = SingleStepTestSuite.Instance.GetTestCases().Single(t => t.Id == "00");

        var step = Step.Load(testCase).First();

        step.Input.RegisterPC.Should().Equal(35714);
        step.Input.RegisterS.Should().Equal(81);
        step.Input.RegisterA.Should().Equal(203);
        step.Input.RegisterX.Should().Equal(117);
        step.Input.RegisterY.Should().Equal(162);
        step.Input.RegisterP.Should().Equal(106);

        step.Expected.RegisterPC.Should().Equal(9684);
        step.Expected.RegisterS.Should().Equal(78);
        step.Expected.RegisterA.Should().Equal(203);
        step.Expected.RegisterX.Should().Equal(117);
        step.Expected.RegisterY.Should().Equal(162);
        step.Expected.RegisterP.Should().Equal(110);

        step.Expected.Cycles.Should().SequenceEqual(
            new Cycle(CycleType.Read, 0, 35714, 0),
            new Cycle(CycleType.Read, 1, 35715, 63),
            new Cycle(CycleType.Write, 2, 337, 139),
            new Cycle(CycleType.Write, 3, 336, 132),
            new Cycle(CycleType.Write, 4, 335, 122),
            new Cycle(CycleType.Read, 5, 65534, 212),
            new Cycle(CycleType.Read, 6, 65535, 37));
    }
}