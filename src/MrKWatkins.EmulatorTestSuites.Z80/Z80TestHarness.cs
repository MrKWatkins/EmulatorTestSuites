using System.Runtime.CompilerServices;

namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <inheritdoc cref="IZ80TestHarness"/>
/// <remarks>
/// Compatibility base class for <see cref="IZ80TestHarness"/> implementations that provides reusable helper behavior for the test suites.
/// </remarks>
[SuppressMessage("ReSharper", "InconsistentNaming")]
#pragma warning disable CA1001
public abstract class Z80TestHarness : IZ80TestHarness
#pragma warning restore CA1001
{
    private AssertionScope? assertionScope;

    /// <inheritdoc />
    public abstract ushort RegisterAF { get; set; }

    /// <inheritdoc />
    public byte RegisterA
    {
        get => GetLowByte(RegisterAF);
        set => RegisterAF = SetLowByte(RegisterAF, value);
    }

    /// <inheritdoc />
    public byte RegisterF
    {
        get => GetHighByte(RegisterAF);
        set => RegisterAF = SetHighByte(RegisterAF, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterBC { get; set; }

    /// <inheritdoc />
    public byte RegisterB
    {
        get => GetLowByte(RegisterBC);
        set => RegisterBC = SetLowByte(RegisterBC, value);
    }

    /// <inheritdoc />
    public byte RegisterC
    {
        get => GetHighByte(RegisterBC);
        set => RegisterBC = SetHighByte(RegisterBC, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterDE { get; set; }

    /// <inheritdoc />
    public byte RegisterD
    {
        get => GetLowByte(RegisterDE);
        set => RegisterDE = SetLowByte(RegisterDE, value);
    }

    /// <inheritdoc />
    public byte RegisterE
    {
        get => GetHighByte(RegisterDE);
        set => RegisterDE = SetHighByte(RegisterDE, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterHL { get; set; }

    /// <inheritdoc />
    public byte RegisterH
    {
        get => GetLowByte(RegisterHL);
        set => RegisterHL = SetLowByte(RegisterHL, value);
    }

    /// <inheritdoc />
    public byte RegisterL
    {
        get => GetHighByte(RegisterHL);
        set => RegisterHL = SetHighByte(RegisterHL, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterIX { get; set; }

    /// <inheritdoc />
    public byte RegisterIXH
    {
        get => GetLowByte(RegisterIX);
        set => RegisterIX = SetLowByte(RegisterIX, value);
    }

    /// <inheritdoc />
    public byte RegisterIXL
    {
        get => GetHighByte(RegisterIX);
        set => RegisterIX = SetHighByte(RegisterIX, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterIY { get; set; }

    /// <inheritdoc />
    public byte RegisterIYH
    {
        get => GetLowByte(RegisterIY);
        set => RegisterIY = SetLowByte(RegisterIY, value);
    }

    /// <inheritdoc />
    public byte RegisterIYL
    {
        get => GetHighByte(RegisterIY);
        set => RegisterIY = SetHighByte(RegisterIY, value);
    }

    /// <inheritdoc />
    public abstract ushort RegisterSP { get; set; }

    /// <inheritdoc />
    public abstract ushort RegisterPC { get; set; }

    /// <inheritdoc />
    public abstract ushort RegisterWZ { get; set; }

    /// <inheritdoc />
    public abstract byte RegisterI { get; set; }

    /// <inheritdoc />
    public abstract byte RegisterR { get; set; }

    /// <inheritdoc />
    public abstract byte RegisterQ { get; set; }

    /// <inheritdoc />
    public abstract ushort ShadowRegisterAF { get; set; }

    /// <inheritdoc />
    public abstract ushort ShadowRegisterBC { get; set; }

    /// <inheritdoc />
    public abstract ushort ShadowRegisterDE { get; set; }

    /// <inheritdoc />
    public abstract ushort ShadowRegisterHL { get; set; }

    /// <inheritdoc />
    public bool FlagC
    {
        get => (RegisterF & 0b00000001) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000001 : RegisterF & 0b11111110);
    }

    /// <inheritdoc />
    public bool FlagN
    {
        get => (RegisterF & 0b00000010) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000010 : RegisterF & 0b11111101);
    }

    /// <inheritdoc />
    public bool FlagPV
    {
        get => (RegisterF & 0b00000100) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00000100 : RegisterF & 0b11111011);
    }

    /// <inheritdoc />
    public bool FlagX
    {
        get => (RegisterF & 0b00001000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00001000 : RegisterF & 0b11110111);
    }

    /// <inheritdoc />
    public bool FlagH
    {
        get => (RegisterF & 0b00010000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00010000 : RegisterF & 0b11101111);
    }

    /// <inheritdoc />
    public bool FlagY
    {
        get => (RegisterF & 0b00100000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b00100000 : RegisterF & 0b11011111);
    }

    /// <inheritdoc />
    public bool FlagZ
    {
        get => (RegisterF & 0b01000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b01000000 : RegisterF & 0b10111111);
    }

    /// <inheritdoc />
    public bool FlagS
    {
        get => (RegisterF & 0b10000000) != 0;
        set => RegisterF = (byte)(value ? RegisterF | 0b10000000 : RegisterF & 0b01111111);
    }

    /// <inheritdoc />
    public abstract bool IFF1 { get; set; }

    /// <inheritdoc />
    public abstract bool IFF2 { get; set; }

    /// <inheritdoc />
    public abstract byte IM { get; set; }

    /// <inheritdoc />
    public abstract bool Halted { get; set; }

    /// <inheritdoc />
    public abstract bool Interrupt { get; set; }

    /// <inheritdoc />
    public ulong TStates
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }

    /// <inheritdoc />
    [Pure]
    public abstract byte ReadByteFromMemory(ushort address);

    /// <inheritdoc />
    [Pure]
    public ushort ReadWordFromMemory(ushort address)
    {
        // Read the two bytes separately and assemble rather than use something like BinaryPrimitives.ReadUInt16LittleEndian.
        // This enables us to cope with wraparound from 0xFFFF -> 0x0000 by using the overflow on ushort.
        var lsb = ReadByteFromMemory(address);

        address++;
        var msb = ReadByteFromMemory(address);

        return (ushort)((msb << 8) | lsb);
    }

    /// <inheritdoc />
    public abstract void WriteByteToMemory(ushort address, byte value);

    /// <inheritdoc />
    public void WriteWordToMemory(ushort address, ushort value)
    {
        WriteByteToMemory(address, (byte)value);

        address++;
        WriteByteToMemory(address, (byte)(value >> 8));
    }

    /// <inheritdoc />
    [OverloadResolutionPriority(1)]
    public virtual void CopyToMemory(ushort address, ReadOnlySpan<byte> source)
    {
        foreach (var @byte in source)
        {
            WriteByteToMemory(address, @byte);
            address++;
        }
    }

    /// <inheritdoc />
    public virtual void CopyToMemory(ushort address, IReadOnlyList<byte> source)
    {
        foreach (var @byte in source)
        {
            WriteByteToMemory(address, @byte);
            address++;
        }
    }

    /// <inheritdoc />
    public virtual void ClearMemory()
    {
        for (var f = 0; f < 65536; f++)
        {
            WriteByteToMemory((ushort)f, 0);
        }
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public IIOReader IOReader { get; internal set; } = new NullIO();

    /// <inheritdoc />
    public IIOWriter IOWriter { get; internal set; } = new NullIO();

    /// <inheritdoc />
    public void SetIO<TIO>(TIO io)
        where TIO : IIOReader, IIOWriter
    {
        IOReader = io;
        IOWriter = io;
    }

    /// <inheritdoc />
    public bool RecordCycles
    {
        get => MutableCycles != null;
        set
        {
            if (value)
            {
                MutableCycles ??= [];
            }
            else
            {
                MutableCycles = null;
            }
        }
    }

    /// <summary>
    /// A mutable list of <see cref="Cycle"/>s to update when <see cref="RecordCycles" /> is <c>true</c>, <c>null</c> otherwise.
    /// </summary>
    protected internal List<Cycle>? MutableCycles { get; private set; }

    /// <inheritdoc />
    public IReadOnlyList<Cycle> Cycles => MutableCycles ?? throw new InvalidOperationException("Cycles are not being recorded.");

    /// <inheritdoc />
    public virtual void Reset()
    {
        TStates = 0;
        MutableCycles?.Clear();
        ClearMemory();
    }

    /// <inheritdoc />
    [MustDisposeResource]
    public IDisposable CreateAssertionScope(string? name = null)
    {
        if (assertionScope != null)
        {
            throw new InvalidOperationException("Cannot create a nested assertion scope.");
        }

        assertionScope = new AssertionScope(this, name);
        return assertionScope;
    }

    /// <inheritdoc />
    public void AssertEqual<T>(T actual, T expected, DefaultInterpolatedStringHandler message)
    {
        if (!EqualityComparer<T>.Default.Equals(actual, expected))
        {
            if (assertionScope != null)
            {
                assertionScope.AddError(message.ToString());
            }
            else
            {
                AssertFail(message.ToString());
            }
        }
    }

    /// <inheritdoc />
    public abstract void AssertFail(string message);

    /// <inheritdoc />
    public abstract void ExecuteInstruction();

    /// <inheritdoc />
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

    private sealed class AssertionScope(Z80TestHarness z80, string? name) : IDisposable
    {
        private readonly List<string> errors = new();

        public void AddError(string error) => errors.Add(error);

        public void Dispose()
        {
            z80.assertionScope = null;

            if (errors.Any())
            {
                var prefix = name != null ? $"{name} failed:{Environment.NewLine}{Environment.NewLine}" : "";

                z80.AssertFail(prefix + string.Join(Environment.NewLine, errors) + Environment.NewLine);
            }
        }
    }
}
