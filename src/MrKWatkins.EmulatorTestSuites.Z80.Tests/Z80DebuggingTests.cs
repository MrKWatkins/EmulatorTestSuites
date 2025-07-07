namespace MrKWatkins.EmulatorTestSuites.Z80.Tests;

[TestFixture]
public sealed class Z80DebuggingTests
{
    [Test]
    public void WriteDebugInformation_debug_null()
    {
        var z80 = new TestZ80TestHarness();
        AssertThat.Invoking(() => Z80Debugging.WriteDebugInformation(z80, null)).Should().NotThrow();
    }

    [Test]
    public void WriteDebugInformation()
    {
        var z80 = new TestZ80TestHarness
        {
            RegisterPC = 0x1234,
            RegisterSP = 0x5678,
            RegisterAF = 0x9ABC,
            RegisterBC = 0xDEF0,
            RegisterDE = 0x1122,
            RegisterHL = 0x3344,
            RegisterIX = 0x5566,
            RegisterIY = 0x7788,
            RegisterI = 0x99,
            RegisterR = 0xAA,
            RegisterWZ = 0xBBCC,
            RegisterQ = 0xDD,
            FlagS = true,
            FlagZ = false,
            FlagH = true,
            FlagPV = false,
            FlagN = true,
            FlagC = false,
            FlagX = true,
            FlagY = false
        };

        z80.SetByteInMemory(0x1234, 0xC9);

        using var writer = new StringWriter();
        Z80Debugging.WriteDebugInformation(z80, writer);

        var output = writer.ToString();
        output.Should().Equal("0x1234: RET              PC 1234 SP 5678 AF 9ABC BC DEF0 DE 1122 HL 3344 IX 5566 IY 7788 I 99 R AA WZ BBCC Q DD SNpXHyNc" + Environment.NewLine);
    }
}