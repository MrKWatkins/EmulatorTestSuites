using System.Runtime.CompilerServices;

namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Contract for a Z80 emulator test harness.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public interface IZ80TestHarness
{
    /// <summary>
    /// Gets or sets the AF register pair.
    /// </summary>
    ushort RegisterAF { get; set; }

    /// <summary>
    /// Gets or sets the A register.
    /// </summary>
    byte RegisterA { get; set; }

    /// <summary>
    /// Gets or sets the F register.
    /// </summary>
    byte RegisterF { get; set; }

    /// <summary>
    /// Gets or sets the BC register pair.
    /// </summary>
    ushort RegisterBC { get; set; }

    /// <summary>
    /// Gets or sets the B register.
    /// </summary>
    byte RegisterB { get; set; }

    /// <summary>
    /// Gets or sets the C register.
    /// </summary>
    byte RegisterC { get; set; }

    /// <summary>
    /// Gets or sets the DE register pair.
    /// </summary>
    ushort RegisterDE { get; set; }

    /// <summary>
    /// Gets or sets the D register.
    /// </summary>
    byte RegisterD { get; set; }

    /// <summary>
    /// Gets or sets the E register.
    /// </summary>
    byte RegisterE { get; set; }

    /// <summary>
    /// Gets or sets the HL register pair.
    /// </summary>
    ushort RegisterHL { get; set; }

    /// <summary>
    /// Gets or sets the H register.
    /// </summary>
    byte RegisterH { get; set; }

    /// <summary>
    /// Gets or sets the L register.
    /// </summary>
    byte RegisterL { get; set; }

    /// <summary>
    /// Gets or sets the IX register pair.
    /// </summary>
    ushort RegisterIX { get; set; }

    /// <summary>
    /// Gets or sets the IXH register.
    /// </summary>
    byte RegisterIXH { get; set; }

    /// <summary>
    /// Gets or sets the IXL register.
    /// </summary>
    byte RegisterIXL { get; set; }

    /// <summary>
    /// Gets or sets the IY register pair.
    /// </summary>
    ushort RegisterIY { get; set; }

    /// <summary>
    /// Gets or sets the IYH register.
    /// </summary>
    byte RegisterIYH { get; set; }

    /// <summary>
    /// Gets or sets the IYL register.
    /// </summary>
    byte RegisterIYL { get; set; }

    /// <summary>
    /// Gets or sets the SP register.
    /// </summary>
    ushort RegisterSP { get; set; }

    /// <summary>
    /// Gets or sets the PC register.
    /// </summary>
    ushort RegisterPC { get; set; }

    /// <summary>
    /// Gets or sets the internal WZ register, sometimes called MEMPTR.
    /// </summary>
    ushort RegisterWZ { get; set; }

    /// <summary>
    /// Gets or sets the I register.
    /// </summary>
    byte RegisterI { get; set; }

    /// <summary>
    /// Gets or sets the R register.
    /// </summary>
    byte RegisterR { get; set; }

    /// <summary>
    /// Gets or sets the internal Q register.
    /// </summary>
    byte RegisterQ { get; set; }

    /// <summary>
    /// Gets or sets the AF' register pair.
    /// </summary>
    ushort ShadowRegisterAF { get; set; }

    /// <summary>
    /// Gets or sets the BC' register pair.
    /// </summary>
    ushort ShadowRegisterBC { get; set; }

    /// <summary>
    /// Gets or sets the DE' register pair.
    /// </summary>
    ushort ShadowRegisterDE { get; set; }

    /// <summary>
    /// Gets or sets the HL' register pair.
    /// </summary>
    ushort ShadowRegisterHL { get; set; }

    /// <summary>
    /// Gets or sets the carry flag, C.
    /// </summary>
    bool FlagC { get; set; }

    /// <summary>
    /// Gets or sets the add/subtract flag, N.
    /// </summary>
    bool FlagN { get; set; }

    /// <summary>
    /// Gets or sets the parity/overflow flag, P/V.
    /// </summary>
    bool FlagPV { get; set; }

    /// <summary>
    /// Gets or sets the undocumented X flag, bit 3 of the F register.
    /// </summary>
    bool FlagX { get; set; }

    /// <summary>
    /// Gets or sets the half-carry flag, H.
    /// </summary>
    bool FlagH { get; set; }

    /// <summary>
    /// Gets or sets the undocumented Y flag, bit 5 of the F register.
    /// </summary>
    bool FlagY { get; set; }

    /// <summary>
    /// Gets or sets the zero flag, Z.
    /// </summary>
    bool FlagZ { get; set; }

    /// <summary>
    /// Gets or sets the sign flag, S.
    /// </summary>
    bool FlagS { get; set; }

    /// <summary>
    /// Gets or sets the IFF1 interrupt flip-flop.
    /// </summary>
    bool IFF1 { get; set; }

    /// <summary>
    /// Gets or sets the IFF2 interrupt flip-flop.
    /// </summary>
    bool IFF2 { get; set; }

    /// <summary>
    /// Gets or sets the interrupt mode.
    /// </summary>
    byte IM { get; set; }

    /// <summary>
    /// Gets or sets whether the CPU is in the halted state.
    /// </summary>
    bool Halted { get; set; }

    /// <summary>
    /// Gets or sets whether an interrupt is pending.
    /// </summary>
    bool Interrupt { get; set; }

    /// <summary>
    /// Gets or sets the number of T-states (clock cycles) executed.
    /// </summary>
    ulong TStates { get; set; }

    /// <summary>
    /// Reads a byte from memory.
    /// </summary>
    byte ReadByteFromMemory(ushort address);

    /// <summary>
    /// Reads a word in little endian format from memory.
    /// </summary>
    ushort ReadWordFromMemory(ushort address);

    /// <summary>
    /// Writes a byte to memory. Does *not* take <see cref="RomArea" /> into account as this is used by tests to setup memory.
    /// </summary>
    void WriteByteToMemory(ushort address, byte value);

    /// <summary>
    /// Writes a word in little endian format to memory. Does *not* take <see cref="RomArea" /> into account as this is used by tests to setup memory.
    /// </summary>
    void WriteWordToMemory(ushort address, ushort value);

    /// <summary>
    /// Copies a span of bytes into the memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting address in memory where the bytes will be copied.</param>
    /// <param name="source">The span of bytes to copy into memory.</param>
    [OverloadResolutionPriority(1)]
    void CopyToMemory(ushort address, ReadOnlySpan<byte> source);

    /// <summary>
    /// Copies a sequence of bytes into memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting memory address where the bytes will be copied.</param>
    /// <param name="source">The sequence of bytes to copy into memory.</param>
    void CopyToMemory(ushort address, IReadOnlyList<byte> source);

    /// <summary>
    /// Clears memory.
    /// </summary>
    void ClearMemory();

    /// <summary>
    /// Gets or sets the ROM area in memory. Memory writes in this area by the emulator should be ignored.
    /// </summary>
    (ushort Start, ushort End)? RomArea { get; set; }

    /// <summary>
    /// Gets the IO reader implementation.
    /// </summary>
    IIOReader IOReader { get; }

    /// <summary>
    /// Gets the IO writer implementation.
    /// </summary>
    IIOWriter IOWriter { get; }

    /// <summary>
    /// Sets both the IO reader and writer to the same implementation.
    /// </summary>
    /// <typeparam name="TIO">The type of the IO implementation.</typeparam>
    /// <param name="io">The IO implementation.</param>
    void SetIO<TIO>(TIO io)
        where TIO : IIOReader, IIOWriter;

    /// <summary>
    /// Gets or sets whether CPU cycles should be recorded.
    /// </summary>
    bool RecordCycles { get; set; }

    /// <summary>
    /// Gets the recorded CPU cycles. Only available when <see cref="RecordCycles"/> is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when cycles are not being recorded.</exception>
    IReadOnlyList<Cycle> Cycles { get; }

    /// <summary>
    /// Resets the test harness state.
    /// </summary>
    void Reset();

    /// <summary>
    /// Creates an assertion scope that allows multiple <see cref="AssertEqual{T}" /> assertions to be made with just one <see cref="AssertFail" />.
    /// </summary>
    /// <param name="name">Optional name for the scope.</param>
    /// <returns>An <see cref="IDisposable" /> that finishes the scope.</returns>
    /// <exception cref="InvalidOperationException">If a scope has already been started.</exception>
    IDisposable CreateAssertionScope(string? name = null);

    /// <summary>
    /// Asserts that the actual value is equal to the expected value. If the values are not equal, an error is reported.
    /// </summary>
    /// <typeparam name="T">The type of the values being compared.</typeparam>
    /// <param name="actual">The actual value to be checked.</param>
    /// <param name="expected">The expected value to compare against.</param>
    /// <param name="message">An interpolated string handler providing a custom error message if the values are not equal.</param>
    void AssertEqual<T>(T actual, T expected, DefaultInterpolatedStringHandler message);

    /// <summary>
    /// Signals that a test has failed with the provided error message.
    /// </summary>
    /// <param name="message">The error message indicating why the test failed.</param>
    void AssertFail(string message);

    /// <summary>
    /// Executes a single instruction.
    /// </summary>
    void ExecuteInstruction();

    /// <summary>
    /// Executes a single instruction with debug output.
    /// </summary>
    /// <param name="debug">Optional TextWriter for debug output.</param>
    void ExecuteInstruction(TextWriter? debug);

}
