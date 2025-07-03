namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public abstract class Z80State
{
    public ushort RegisterAF { get; internal set; }

    public byte RegisterA
    {
        get => (byte)(RegisterAF >> 8);
        internal set => RegisterAF = (ushort)((RegisterAF & 0x00FF) | (value << 8));
    }

    public byte RegisterF
    {
        get => (byte)(RegisterAF & 0xFF);
        internal set => RegisterAF = (ushort)((RegisterAF & 0xFF00) | value);
    }

    public ushort RegisterBC { get; internal set; }

    public ushort RegisterDE { get; internal set; }

    public ushort RegisterHL { get; internal set; }

    public ushort ShadowRegisterAF { get; internal set; }

    public ushort ShadowRegisterBC { get; internal set; }

    public ushort ShadowRegisterDE { get; internal set; }

    public ushort ShadowRegisterHL { get; internal set; }

    public ushort RegisterIX { get; internal set; }

    public ushort RegisterIY { get; internal set; }

    public ushort RegisterSP { get; internal set; }

    public ushort RegisterPC { get; internal set; }

    public ushort RegisterWZ { get; internal set; }

    public byte RegisterI { get; internal set; }

    public byte RegisterR { get; internal set; }

    public byte RegisterQ { get; internal set; }

    public bool FlagC
    {
        get => (RegisterF & 0b00000001) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000001 : RegisterF & 0b11111110);
    }

    public bool FlagN
    {
        get => (RegisterF & 0b00000010) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000010 : RegisterF & 0b11111101);
    }

    public bool FlagPV
    {
        get => (RegisterF & 0b00000100) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000100 : RegisterF & 0b11111011);
    }

    public bool FlagX
    {
        get => (RegisterF & 0b00001000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00001000 : RegisterF & 0b11110111);
    }

    public bool FlagH
    {
        get => (RegisterF & 0b00010000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00010000 : RegisterF & 0b11101111);
    }

    public bool FlagY
    {
        get => (RegisterF & 0b00100000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00100000 : RegisterF & 0b11011111);
    }

    public bool FlagZ
    {
        get => (RegisterF & 0b01000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b01000000 : RegisterF & 0b10111111);
    }

    public bool FlagS
    {
        get => (RegisterAF & 0b10000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b10000000 : RegisterF & 0b01111111);
    }

    public bool IFF1 { get; internal set; }

    public bool IFF2 { get; internal set; }

    public byte IM { get; internal set; }

    public bool Halted { get; internal set; }

    public IReadOnlyList<MemoryState> Memory { get; internal set; } = [];
}