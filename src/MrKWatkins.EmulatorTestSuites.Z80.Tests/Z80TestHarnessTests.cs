
namespace MrKWatkins.EmulatorTestSuites.Z80.Tests;

[TestFixture]
public sealed class Z80TestHarnessTests
{
    [Test]
    public void RegisterAF()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterAF.Should().Equal(0x0000);
        harness.RegisterA.Should().Equal(0x00);
        harness.RegisterF.Should().Equal(0x00);

        harness.RegisterAF = 0x1234;
        harness.RegisterAF.Should().Equal(0x1234);
        harness.RegisterA.Should().Equal(0x12);
        harness.RegisterF.Should().Equal(0x34);

        harness.RegisterA = 0xBC;
        harness.RegisterAF.Should().Equal(0xBC34);

        harness.RegisterF = 0xDE;
        harness.RegisterAF.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterBC()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterBC.Should().Equal(0x0000);
        harness.RegisterB.Should().Equal(0x00);
        harness.RegisterC.Should().Equal(0x00);

        harness.RegisterBC = 0x1234;
        harness.RegisterBC.Should().Equal(0x1234);
        harness.RegisterB.Should().Equal(0x12);
        harness.RegisterC.Should().Equal(0x34);

        harness.RegisterB = 0xBC;
        harness.RegisterBC.Should().Equal(0xBC34);

        harness.RegisterC = 0xDE;
        harness.RegisterBC.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterDE()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterDE.Should().Equal(0x0000);
        harness.RegisterD.Should().Equal(0x00);
        harness.RegisterE.Should().Equal(0x00);

        harness.RegisterDE = 0x1234;
        harness.RegisterDE.Should().Equal(0x1234);
        harness.RegisterD.Should().Equal(0x12);
        harness.RegisterE.Should().Equal(0x34);

        harness.RegisterD = 0xBC;
        harness.RegisterDE.Should().Equal(0xBC34);

        harness.RegisterE = 0xDE;
        harness.RegisterDE.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterHL()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterHL.Should().Equal(0x0000);
        harness.RegisterH.Should().Equal(0x00);
        harness.RegisterL.Should().Equal(0x00);

        harness.RegisterHL = 0x1234;
        harness.RegisterHL.Should().Equal(0x1234);
        harness.RegisterH.Should().Equal(0x12);
        harness.RegisterL.Should().Equal(0x34);

        harness.RegisterH = 0xBC;
        harness.RegisterHL.Should().Equal(0xBC34);

        harness.RegisterL = 0xDE;
        harness.RegisterHL.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterIX()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterIX.Should().Equal(0x0000);
        harness.RegisterIXH.Should().Equal(0x00);
        harness.RegisterIXL.Should().Equal(0x00);

        harness.RegisterIX = 0x1234;
        harness.RegisterIX.Should().Equal(0x1234);
        harness.RegisterIXH.Should().Equal(0x12);
        harness.RegisterIXL.Should().Equal(0x34);

        harness.RegisterIXH = 0xBC;
        harness.RegisterIX.Should().Equal(0xBC34);

        harness.RegisterIXL = 0xDE;
        harness.RegisterIX.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterIY()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterIY.Should().Equal(0x0000);
        harness.RegisterIYH.Should().Equal(0x00);
        harness.RegisterIYL.Should().Equal(0x00);

        harness.RegisterIY = 0x1234;
        harness.RegisterIY.Should().Equal(0x1234);
        harness.RegisterIYH.Should().Equal(0x12);
        harness.RegisterIYL.Should().Equal(0x34);

        harness.RegisterIYH = 0xBC;
        harness.RegisterIY.Should().Equal(0xBC34);

        harness.RegisterIYL = 0xDE;
        harness.RegisterIY.Should().Equal(0xBCDE);
    }

    [Test]
    public void RegisterPC()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterPC.Should().Equal(0x0000);

        harness.RegisterPC = 0x1234;
        harness.RegisterPC.Should().Equal(0x1234);
    }

    [Test]
    public void RegisterSP()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterSP.Should().Equal(0x0000);

        harness.RegisterSP = 0x1234;
        harness.RegisterSP.Should().Equal(0x1234);
    }

    [Test]
    public void RegisterWZ()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterWZ.Should().Equal(0x0000);

        harness.RegisterWZ = 0x1234;
        harness.RegisterWZ.Should().Equal(0x1234);
    }

    [Test]
    public void RegisterI()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterI.Should().Equal(0x00);

        harness.RegisterI = 0x12;
        harness.RegisterI.Should().Equal(0x12);
    }

    [Test]
    public void RegisterR()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterR.Should().Equal(0x00);

        harness.RegisterR = 0x12;
        harness.RegisterR.Should().Equal(0x12);
    }

    [Test]
    public void RegisterQ()
    {
        var harness = new TestZ80TestHarness();
        harness.RegisterQ.Should().Equal(0x00);

        harness.RegisterQ = 0x12;
        harness.RegisterQ.Should().Equal(0x12);
    }

    [Test]
    public void ShadowRegisterAF()
    {
        var harness = new TestZ80TestHarness();
        harness.ShadowRegisterAF.Should().Equal(0x0000);

        harness.ShadowRegisterAF = 0x1234;
        harness.ShadowRegisterAF.Should().Equal(0x1234);
    }

    [Test]
    public void ShadowRegisterBC()
    {
        var harness = new TestZ80TestHarness();
        harness.ShadowRegisterBC.Should().Equal(0x0000);

        harness.ShadowRegisterBC = 0x1234;
        harness.ShadowRegisterBC.Should().Equal(0x1234);
    }

    [Test]
    public void ShadowRegisterDE()
    {
        var harness = new TestZ80TestHarness();
        harness.ShadowRegisterDE.Should().Equal(0x0000);

        harness.ShadowRegisterDE = 0x1234;
        harness.ShadowRegisterDE.Should().Equal(0x1234);
    }

    [Test]
    public void ShadowRegisterHL()
    {
        var harness = new TestZ80TestHarness();
        harness.ShadowRegisterHL.Should().Equal(0x0000);

        harness.ShadowRegisterHL = 0x1234;
        harness.ShadowRegisterHL.Should().Equal(0x1234);
    }

    [Test]
    public void IFF1()
    {
        var harness = new TestZ80TestHarness();
        harness.IFF1.Should().BeFalse();

        harness.IFF1 = true;
        harness.IFF1.Should().BeTrue();
    }

    [Test]
    public void IFF2()
    {
        var harness = new TestZ80TestHarness();
        harness.IFF2.Should().BeFalse();

        harness.IFF2 = true;
        harness.IFF2.Should().BeTrue();
    }

    [Test]
    public void IM()
    {
        var harness = new TestZ80TestHarness();
        harness.IM.Should().Equal(0);

        harness.IM = 2;
        harness.IM.Should().Equal(2);
    }

    [Test]
    public void Halted()
    {
        var harness = new TestZ80TestHarness();
        harness.Halted.Should().BeFalse();

        harness.Halted = true;
        harness.Halted.Should().BeTrue();
    }

    [Test]
    public void Interrupt()
    {
        var harness = new TestZ80TestHarness();
        harness.Interrupt.Should().BeFalse();

        harness.Interrupt = true;
        harness.Interrupt.Should().BeTrue();
    }
}