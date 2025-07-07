namespace MrKWatkins.EmulatorTestSuites.Z80.Tests;

internal sealed class TestZ80TestHarness : Z80TestHarness
{
    public override ushort RegisterAF { get; set; }

    public override ushort RegisterBC { get; set; }

    public override ushort RegisterDE { get; set; }

    public override ushort RegisterHL { get; set; }

    public override ushort RegisterIX { get; set; }

    public override ushort RegisterIY { get; set; }

    public override ushort RegisterSP { get; set; }

    public override ushort RegisterPC { get; set; }

    public override ushort RegisterWZ { get; set; }

    public override byte RegisterI { get; set; }

    public override byte RegisterR { get; set; }

    public override byte RegisterQ { get; set; }

    public override ushort ShadowRegisterAF { get; set; }

    public override ushort ShadowRegisterBC { get; set; }

    public override ushort ShadowRegisterDE { get; set; }

    public override ushort ShadowRegisterHL { get; set; }

    public override bool FlagC { get; set; }

    public override bool FlagN { get; set; }

    public override bool FlagPV { get; set; }

    public override bool FlagX { get; set; }

    public override bool FlagH { get; set; }

    public override bool FlagY { get; set; }

    public override bool FlagZ { get; set; }

    public override bool FlagS { get; set; }

    public override bool IFF1 { get; set; }

    public override bool IFF2 { get; set; }

    public override byte IM { get; set; }

    public override bool Halted { get; set; }

    public override bool Interrupt { get; set; }

    public override void AssertFail(string message)
    {
        throw new NotImplementedException();
    }

    public override void Step()
    {
        throw new NotImplementedException();
    }

    public override void ExecuteInstruction(TextWriter? debug = null)
    {
        throw new NotImplementedException();
    }
}