namespace MrKWatkins.EmulatorTestSuites.M6502.Tests;

[TestFixture]
public sealed class M6502TestHarnessTests
{
    [Test]
    public void RegisterA()
    {
        var harness = new TestM6502TestHarness();
        harness.RegisterA.Should().Equal(0x00);

        harness.RegisterA = 0x12;

        harness.RegisterA.Should().Equal(0x12);
    }

    [Test]
    public void RegisterPC()
    {
        var harness = new TestM6502TestHarness();
        harness.RegisterPC.Should().Equal(0x0000);

        harness.RegisterPC = 0x1234;

        harness.RegisterPC.Should().Equal(0x1234);
    }

    [Test]
    public void FlagC()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagC.Should().BeFalse();

        harness.FlagC = true;

        harness.FlagC.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b00000001);

        harness.RegisterP = 0b11111111;
        harness.FlagC = false;

        harness.FlagC.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b11111110);
    }

    [Test]
    public void FlagZ()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagZ.Should().BeFalse();

        harness.FlagZ = true;

        harness.FlagZ.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b00000010);

        harness.RegisterP = 0b11111111;
        harness.FlagZ = false;

        harness.FlagZ.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b11111101);
    }

    [Test]
    public void FlagI()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagI.Should().BeFalse();

        harness.FlagI = true;

        harness.FlagI.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b00000100);

        harness.RegisterP = 0b11111111;
        harness.FlagI = false;

        harness.FlagI.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b11111011);
    }

    [Test]
    public void FlagD()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagD.Should().BeFalse();

        harness.FlagD = true;

        harness.FlagD.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b00001000);

        harness.RegisterP = 0b11111111;
        harness.FlagD = false;

        harness.FlagD.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b11110111);
    }

    [Test]
    public void FlagB()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagB.Should().BeFalse();

        harness.FlagB = true;

        harness.FlagB.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b00010000);

        harness.RegisterP = 0b11111111;
        harness.FlagB = false;

        harness.FlagB.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b11101111);
    }

    [Test]
    public void FlagV()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagV.Should().BeFalse();

        harness.FlagV = true;

        harness.FlagV.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b01000000);

        harness.RegisterP = 0b11111111;
        harness.FlagV = false;

        harness.FlagV.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b10111111);
    }

    [Test]
    public void FlagN()
    {
        var harness = new TestM6502TestHarness();
        harness.FlagN.Should().BeFalse();

        harness.FlagN = true;

        harness.FlagN.Should().BeTrue();
        harness.RegisterP.Should().Equal(0b10000000);

        harness.RegisterP = 0b11111111;
        harness.FlagN = false;

        harness.FlagN.Should().BeFalse();
        harness.RegisterP.Should().Equal(0b01111111);
    }

    [Test]
    public void ReadWordFromMemory()
    {
        var harness = new TestM6502TestHarness();
        harness.WriteByteToMemory(0x1234, 0x78);
        harness.WriteByteToMemory(0x1235, 0x56);

        harness.ReadWordFromMemory(0x1234).Should().Equal(0x5678);
    }

    [Test]
    public void WriteWordToMemory()
    {
        var harness = new TestM6502TestHarness();

        harness.WriteWordToMemory(0x1234, 0x5678);

        harness.ReadByteFromMemory(0x1234).Should().Equal(0x78);
        harness.ReadByteFromMemory(0x1235).Should().Equal(0x56);
    }
}