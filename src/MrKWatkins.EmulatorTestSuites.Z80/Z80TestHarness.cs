namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for a Z80 emulator test harness. Implement this class to use it with the test suites.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public abstract class Z80TestHarness : TestHarness<Cycle>
{
    /// <summary>
    /// Gets or sets the AF register pair.
    /// </summary>
    public abstract ushort RegisterAF { get; set; }

    /// <summary>
    /// Gets or sets the A register.
    /// </summary>
    public byte RegisterA
    {
        get => GetLowByte(RegisterAF);
        set => RegisterAF = SetLowByte(RegisterAF, value);
    }

    /// <summary>
    /// Gets or sets the F register.
    /// </summary>
    public byte RegisterF
    {
        get => GetHighByte(RegisterAF);
        set => RegisterAF = SetHighByte(RegisterAF, value);
    }

    /// <summary>
    /// Gets or sets the BC register pair.
    /// </summary>
    public abstract ushort RegisterBC { get; set; }

    /// <summary>
    /// Gets or sets the B register.
    /// </summary>
    public byte RegisterB
    {
        get => GetLowByte(RegisterBC);
        set => RegisterBC = SetLowByte(RegisterBC, value);
    }

    /// <summary>
    /// Gets or sets the C register.
    /// </summary>
    public byte RegisterC
    {
        get => GetHighByte(RegisterBC);
        set => RegisterBC = SetHighByte(RegisterBC, value);
    }

    /// <summary>
    /// Gets or sets the DE register pair.
    /// </summary>
    public abstract ushort RegisterDE { get; set; }

    /// <summary>
    /// Gets or sets the D register.
    /// </summary>
    public byte RegisterD
    {
        get => GetLowByte(RegisterDE);
        set => RegisterDE = SetLowByte(RegisterDE, value);
    }

    /// <summary>
    /// Gets or sets the E register.
    /// </summary>
    public byte RegisterE
    {
        get => GetHighByte(RegisterDE);
        set => RegisterDE = SetHighByte(RegisterDE, value);
    }

    /// <summary>
    /// Gets or sets the HL register pair.
    /// </summary>
    public abstract ushort RegisterHL { get; set; }

    /// <summary>
    /// Gets or sets the H register.
    /// </summary>
    public byte RegisterH
    {
        get => GetLowByte(RegisterHL);
        set => RegisterHL = SetLowByte(RegisterHL, value);
    }

    /// <summary>
    /// Gets or sets the L register.
    /// </summary>
    public byte RegisterL
    {
        get => GetHighByte(RegisterHL);
        set => RegisterHL = SetHighByte(RegisterHL, value);
    }

    /// <summary>
    /// Gets or sets the IX register pair.
    /// </summary>
    public abstract ushort RegisterIX { get; set; }

    /// <summary>
    /// Gets or sets the IXH register.
    /// </summary>
    public byte RegisterIXH
    {
        get => GetLowByte(RegisterIX);
        set => RegisterIX = SetLowByte(RegisterIX, value);
    }

    /// <summary>
    /// Gets or sets the IXL register.
    /// </summary>
    public byte RegisterIXL
    {
        get => GetHighByte(RegisterIX);
        set => RegisterIX = SetHighByte(RegisterIX, value);
    }

    /// <summary>
    /// Gets or sets the IY register pair.
    /// </summary>
    public abstract ushort RegisterIY { get; set; }

    /// <summary>
    /// Gets or sets the IYH register.
    /// </summary>
    public byte RegisterIYH
    {
        get => GetLowByte(RegisterIY);
        set => RegisterIY = SetLowByte(RegisterIY, value);
    }

    /// <summary>
    /// Gets or sets the IYL register.
    /// </summary>
    public byte RegisterIYL
    {
        get => GetHighByte(RegisterIY);
        set => RegisterIY = SetHighByte(RegisterIY, value);
    }

    /// <summary>
    /// Gets or sets the SP register.
    /// </summary>
    public abstract ushort RegisterSP { get; set; }

    /// <summary>
    /// Gets or sets the PC register.
    /// </summary>
    public abstract ushort RegisterPC { get; set; }

    /// <summary>
    /// Gets or sets the internal WZ register, sometimes called MEMPTR.
    /// </summary>
    public abstract ushort RegisterWZ { get; set; }

    /// <summary>
    /// Gets or sets the I register.
    /// </summary>
    public abstract byte RegisterI { get; set; }

    /// <summary>
    /// Gets or sets the R register.
    /// </summary>
    public abstract byte RegisterR { get; set; }

    /// <summary>
    /// Gets or sets the internal Q register.
    /// </summary>
    public abstract byte RegisterQ { get; set; }

    /// <summary>
    /// Gets or sets the AF' register pair.
    /// </summary>
    public abstract ushort ShadowRegisterAF { get; set; }

    /// <summary>
    /// Gets or sets the BC' register pair.
    /// </summary>
    public abstract ushort ShadowRegisterBC { get; set; }

    /// <summary>
    /// Gets or sets the DE' register pair.
    /// </summary>
    public abstract ushort ShadowRegisterDE { get; set; }

    /// <summary>
    /// Gets or sets the HL' register pair.
    /// </summary>
    public abstract ushort ShadowRegisterHL { get; set; }

    /// <summary>
    /// Gets or sets the carry flag, C.
    /// </summary>
    public bool FlagC
    {
        get => (RegisterF & 0b00000001) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000001 : RegisterF & 0b11111110);
    }

    /// <summary>
    /// Gets or sets the add/subtract flag, N.
    /// </summary>
    public bool FlagN
    {
        get => (RegisterF & 0b00000010) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000010 : RegisterF & 0b11111101);
    }

    /// <summary>
    /// Gets or sets the parity/overflow flag, P/V.
    /// </summary>
    public bool FlagPV
    {
        get => (RegisterF & 0b00000100) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000100 : RegisterF & 0b11111011);
    }

    /// <summary>
    /// Gets or sets the undocumented X flag, bit 3 of the F register.
    /// </summary>
    public bool FlagX
    {
        get => (RegisterF & 0b00001000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00001000 : RegisterF & 0b11110111);
    }

    /// <summary>
    /// Gets or sets the half-carry flag, H.
    /// </summary>
    public bool FlagH
    {
        get => (RegisterF & 0b00010000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00010000 : RegisterF & 0b11101111);
    }

    /// <summary>
    /// Gets or sets the undocumented Y flag, bit 5 of the F register.
    /// </summary>
    public bool FlagY
    {
        get => (RegisterF & 0b00100000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00100000 : RegisterF & 0b11011111);
    }

    /// <summary>
    /// Gets or sets the zero flag, Z.
    /// </summary>
    public bool FlagZ
    {
        get => (RegisterF & 0b01000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b01000000 : RegisterF & 0b10111111);
    }

    /// <summary>
    /// Gets or sets the sign flag, S.
    /// </summary>
    public bool FlagS
    {
        get => (RegisterF & 0b10000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b10000000 : RegisterF & 0b01111111);
    }

    /// <summary>
    /// Gets or sets the IFF1 interrupt flip-flop.
    /// </summary>
    public abstract bool IFF1 { get; set; }

    /// <summary>
    /// Gets or sets the IFF2 interrupt flip-flop.
    /// </summary>
    public abstract bool IFF2 { get; set; }

    /// <summary>
    /// Gets or sets the interrupt mode.
    /// </summary>
    public abstract byte IM { get; set; }

    /// <summary>
    /// Gets or sets whether the CPU is in the halted state.
    /// </summary>
    public abstract bool Halted { get; set; }

    /// <summary>
    /// Gets or sets whether the external interrupt line is asserted.
    /// </summary>
    public abstract bool Interrupt { get; set; }

    /// <summary>
    /// Gets or sets the ROM area in memory. Memory writes in this area by the emulator should be ignored.
    /// </summary>
    public (ushort Start, ushort End)? RomArea
    {
        get;
        set
        {
            if (value != field)
            {
                field = value;
                OnRomAreaChanged();
            }
        }
    }

    /// <summary>
    /// Called when <see cref="RomArea" /> changes. Override to update your emulator with the ROM area.
    /// </summary>
    protected virtual void OnRomAreaChanged()
    {
    }

    /// <summary>
    /// Gets the IO reader implementation.
    /// </summary>
    public IIOReader IOReader { get; internal set; } = new NullIO();

    /// <summary>
    /// Gets the IO writer implementation.
    /// </summary>
    public IIOWriter IOWriter { get; internal set; } = new NullIO();

    /// <summary>
    /// Sets both the IO reader and writer to the same implementation.
    /// </summary>
    /// <typeparam name="TIO">The type of the IO implementation.</typeparam>
    /// <param name="io">The IO implementation.</param>
    public void SetIO<TIO>(TIO io)
        where TIO : IIOReader, IIOWriter
    {
        IOReader = io;
        IOWriter = io;
    }

    /// <summary>
    /// Executes a single instruction.
    /// </summary>
    public abstract void ExecuteInstruction();

    /// <summary>
    /// Executes a single instruction with debug output.
    /// </summary>
    /// <param name="debug">Optional TextWriter for debug output.</param>
    public void ExecuteInstruction(TextWriter? debug)
    {
        if (debug != null)
        {
            if (Halted && HALTAdvancesPC)
            {
                RegisterPC--;
                Z80Debugging.WriteDebugInformation(this, debug);
                RegisterPC++;
            }
            else
            {
                Z80Debugging.WriteDebugInformation(this, debug);
            }
        }

        ExecuteInstruction();
    }

    /// <summary>
    /// Does the HALT instruction advance PC?
    /// </summary>
    /// <remarks>
    /// Some Z80 emulators do not advance the PC after a HALT instruction, but the official documentation states that it does.
    /// This property is used when writing debug information; if <c>true</c> then PC will be decremented before writing debug
    /// information, so that HALT is written to the logs, then restored afterwards. <c>true</c> by default.
    /// </remarks>
    protected virtual bool HALTAdvancesPC => true;

    [Pure]
    private static byte GetLowByte(ushort value) => (byte)(value >> 8); // Little endian, so the lowest byte is first in memory, i.e. the first byte in the short.

    [Pure]
    private static byte GetHighByte(ushort value) => (byte)(value & 0xFF);

    [Pure]
    private static ushort SetLowByte(ushort value, byte lowByte) => (ushort)((value & 0x00FF) | (lowByte << 8));

    [Pure]
    private static ushort SetHighByte(ushort value, byte highByte) => (ushort)((value & 0xFF00) | highByte);
}