namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Represents the state of a Z80 processor, including registers, flags, and memory.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public abstract class Z80State
{
    private protected Z80State()
    {
    }

    /// <summary>
    /// Gets the AF register pair.
    /// </summary>
    public ushort RegisterAF { get; internal set; }

    /// <summary>
    /// Gets the A register.
    /// </summary>
    public byte RegisterA
    {
        get => (byte)(RegisterAF >> 8);
        internal set => RegisterAF = (ushort)((RegisterAF & 0x00FF) | (value << 8));
    }

    /// <summary>
    /// Gets the F register.
    /// </summary>
    public byte RegisterF
    {
        get => (byte)(RegisterAF & 0xFF);
        internal set => RegisterAF = (ushort)((RegisterAF & 0xFF00) | value);
    }

    /// <summary>
    /// Gets the BC register pair.
    /// </summary>
    public ushort RegisterBC { get; internal set; }

    /// <summary>
    /// Gets the DE register pair.
    /// </summary>
    public ushort RegisterDE { get; internal set; }

    /// <summary>
    /// Gets the HL register pair.
    /// </summary>
    public ushort RegisterHL { get; internal set; }

    /// <summary>
    /// Gets the AF' register pair.
    /// </summary>
    public ushort ShadowRegisterAF { get; internal set; }

    /// <summary>
    /// Gets the BC' register pair.
    /// </summary>
    public ushort ShadowRegisterBC { get; internal set; }

    /// <summary>
    /// Gets the DE' register pair.
    /// </summary>
    public ushort ShadowRegisterDE { get; internal set; }

    /// <summary>
    /// Gets the HL' register pair.
    /// </summary>
    public ushort ShadowRegisterHL { get; internal set; }

    /// <summary>
    /// Gets the IX register pair.
    /// </summary>
    public ushort RegisterIX { get; internal set; }

    /// <summary>
    /// Gets the IY register pair.
    /// </summary>
    public ushort RegisterIY { get; internal set; }

    /// <summary>
    /// Gets the SP register.
    /// </summary>
    public ushort RegisterSP { get; internal set; }

    /// <summary>
    /// Gets the PC register.
    /// </summary>
    public ushort RegisterPC { get; internal set; }

    /// <summary>
    /// Gets the internal WZ register, sometimes called MEMPTR.
    /// </summary>
    public ushort RegisterWZ { get; internal set; }

    /// <summary>
    /// Gets the I register.
    /// </summary>
    public byte RegisterI { get; internal set; }

    /// <summary>
    /// Gets the R register.
    /// </summary>
    public byte RegisterR { get; internal set; }

    /// <summary>
    /// Gets the internal Q register.
    /// </summary>
    public byte RegisterQ { get; internal set; }

    /// <summary>
    /// Gets the carry flag, C.
    /// </summary>
    public bool FlagC
    {
        get => (RegisterF & 0b00000001) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00000001 : RegisterF & 0b11111110);
    }

    /// <summary>
    /// Gets the add/subtract flag, N.
    /// </summary>
    public bool FlagN
    {
        get => (RegisterF & 0b00000010) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00000010 : RegisterF & 0b11111101);
    }

    /// <summary>
    /// Gets the parity/overflow flag, P/V.
    /// </summary>
    public bool FlagPV
    {
        get => (RegisterF & 0b00000100) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00000100 : RegisterF & 0b11111011);
    }

    /// <summary>
    /// Gets the undocumented X flag, bit 3 of the F register.
    /// </summary>
    public bool FlagX
    {
        get => (RegisterF & 0b00001000) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00001000 : RegisterF & 0b11110111);
    }

    /// <summary>
    /// Gets the half-carry flag, H.
    /// </summary>
    public bool FlagH
    {
        get => (RegisterF & 0b00010000) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00010000 : RegisterF & 0b11101111);
    }

    /// <summary>
    /// Gets the undocumented Y flag, bit 5 of the F register.
    /// </summary>
    public bool FlagY
    {
        get => (RegisterF & 0b00100000) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b00100000 : RegisterF & 0b11011111);
    }

    /// <summary>
    /// Gets the zero flag, Z.
    /// </summary>
    public bool FlagZ
    {
        get => (RegisterF & 0b01000000) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b01000000 : RegisterF & 0b10111111);
    }

    /// <summary>
    /// Gets the sign flag, S.
    /// </summary>
    public bool FlagS
    {
        get => (RegisterAF & 0b10000000) != 0;
        internal set => RegisterF = (byte)(value ? RegisterF | 0b10000000 : RegisterF & 0b01111111);
    }

    /// <summary>
    /// Gets the IFF1 interrupt flip-flop.
    /// </summary>
    public bool IFF1 { get; internal set; }

    /// <summary>
    /// Gets the IFF2 interrupt flip-flop.
    /// </summary>
    public bool IFF2 { get; internal set; }

    /// <summary>
    /// Gets the interrupt mode.
    /// </summary>
    public byte IM { get; internal set; }

    /// <summary>
    /// Gets whether the CPU is in the halted state.
    /// </summary>
    public bool Halted { get; internal set; }

    /// <summary>
    /// Gets the memory state.
    /// </summary>
    public IReadOnlyList<MemoryState> Memory { get; internal set; } = [];
}