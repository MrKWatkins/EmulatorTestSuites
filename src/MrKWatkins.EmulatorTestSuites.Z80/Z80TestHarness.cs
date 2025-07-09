using System.Runtime.CompilerServices;

namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for a Z80 emulator test harness. Implement this class to use it with the test suites.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
#pragma warning disable CA1001
public abstract class Z80TestHarness
#pragma warning restore CA1001
{
    private AssertionScope? assertionScope;

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
    /// Gets or sets whether an interrupt is pending.
    /// </summary>
    public abstract bool Interrupt { get; set; }

    /// <summary>
    /// Gets or sets the number of T-states (clock cycles) executed.
    /// </summary>
    public ulong TStates
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }

    /// <summary>
    /// Performs a memory read for the emulator.
    /// </summary>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte MemoryRead(ushort address) => GetByteFromMemory(address);

    /// <summary>
    /// Performs a memory write for the emulator. Takes <see cref="TopOfRomArea" /> into account and will not overwrite memory in the ROM area.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void MemoryWrite(ushort address, byte value) => SetByteInMemory(address, value);

    /// <summary>
    /// Copies a span of bytes into the memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting address in memory where the bytes will be copied.</param>
    /// <param name="source">The span of bytes to copy into memory.</param>
    [OverloadResolutionPriority(1)]
    public virtual void CopyToMemory(ushort address, ReadOnlySpan<byte> source)
    {
        foreach (var @byte in source)
        {
            SetByteInMemory(address, @byte);
            address++;
        }
    }

    /// <summary>
    /// Copies a sequence of bytes into memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting memory address where the bytes will be copied.</param>
    /// <param name="source">The sequence of bytes to copy into memory.</param>
    public virtual void CopyToMemory(ushort address, IReadOnlyList<byte> source)
    {
        foreach (var @byte in source)
        {
            SetByteInMemory(address, @byte);
            address++;
        }
    }

    /// <summary>
    /// Gets a byte from memory.
    /// </summary>
    [Pure]
    public abstract byte GetByteFromMemory(ushort address);

    /// <summary>
    /// Gets a word in little endian format from memory.
    /// </summary>
    [Pure]
    public ushort GetWordFromMemory(ushort address)
    {
        // Read the two bytes separately and assemble rather than use something like BinaryPrimitives.ReadUInt16LittleEndian.
        // This enables us to cope with wraparound from 0xFFFF -> 0x0000 by using the overflow on ushort.
        var lsb = GetByteFromMemory(address);

        address++;
        var msb = GetByteFromMemory(address);

        return (ushort)((msb << 8) | lsb);
    }

    /// <summary>
    /// Sets a byte in memory. Does not take <see cref="TopOfRomArea" /> into account so it will update the ROM area.
    /// </summary>
    public abstract void SetByteInMemory(ushort address, byte value);

    /// <summary>
    /// Sets a word in little endian format in memory. Does not take <see cref="TopOfRomArea" /> into account so it will update the ROM area.
    /// </summary>
    public void SetWordInMemory(ushort address, ushort value)
    {
        SetByteInMemory(address, (byte)value);

        address++;
        SetByteInMemory(address, (byte)(value >> 8));
    }

    /// <summary>
    /// Gets or sets the highest address of the ROM area. Memory writes below this address are ignored.
    /// </summary>
    public int TopOfRomArea { get; set; } = int.MinValue;

    /// <summary>
    /// Gets or sets the IO reader implementation.
    /// </summary>
    public IIOReader IOReader { get; set; } = new NullIO();

    /// <summary>
    /// Gets or sets the IO writer implementation.
    /// </summary>
    public IIOWriter IOWriter { get; set; } = new NullIO();

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
    /// Gets or sets whether CPU cycles should be recorded.
    /// </summary>
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

    /// <summary>
    /// Gets the recorded CPU cycles. Only available when <see cref="RecordCycles"/> is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when cycles are not being recorded.</exception>
    public IReadOnlyList<Cycle> Cycles => MutableCycles ?? throw new InvalidOperationException("Cycles are not being recorded.");

    /// <summary>
    /// Creates an assertion scope that allows multiple <see cref="AssertEqual{T}" /> assertions to be made with just one <see cref="AssertFail" />.
    /// </summary>
    /// <param name="name">Optional name for the scope.</param>
    /// <returns>An <see cref="IDisposable" /> that finishes the scope.</returns>
    /// <exception cref="InvalidOperationException">If a scope has already been started.</exception>
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

    /// <summary>
    /// Asserts that the actual value is equal to the expected value. If the values are not equal, an error is reported.
    /// </summary>
    /// <typeparam name="T">The type of the values being compared.</typeparam>
    /// <param name="actual">The actual value to be checked.</param>
    /// <param name="expected">The expected value to compare against.</param>
    /// <param name="message">An interpolated string handler providing a custom error message if the values are not equal.</param>
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

    /// <summary>
    /// Signals that a test has failed with the provided error message.
    /// </summary>
    /// <param name="message">The error message indicating why the test failed.</param>
    public abstract void AssertFail(string message);

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
            Z80Debugging.WriteDebugInformation(this, debug);
        }

        ExecuteInstruction();
    }

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
            if (errors.Any())
            {
                var prefix = name != null ? $"{name} failed:{Environment.NewLine}{Environment.NewLine}" : "";

                z80.AssertFail(prefix + string.Join(Environment.NewLine, errors) + Environment.NewLine);
            }
        }
    }
}