namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Flags specifying which aspects of the Z80 processor state should be tested during instruction execution.
/// </summary>
[Flags]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum TestAssertions : ulong
{
    /// <summary>
    /// Test nothing. Kinda pointless really.
    /// </summary>
    None = 0,

    /// <summary>
    /// Test the A register.
    /// </summary>
    /// <remarks>Registers. A and F are separated out so we can disable checking F if we're not checking some flags.</remarks>
    A = 1UL << 0,

    /// <summary>
    /// Test the F register.
    /// </summary>
    /// <remarks>Registers. A and F are separated out so we can disable checking F if we're not checking some flags.</remarks>
    F = 1UL << 1,

    /// <summary>
    /// Test the BC register pair.
    /// </summary>
    ///
    BC = 1UL << 2,

    /// <summary>
    /// Test the DE register pair.
    /// </summary>
    ///
    DE = 1UL << 3,

    /// <summary>
    /// Test the HL register pair.
    /// </summary>
    ///
    HL = 1UL << 4,

    /// <summary>
    /// Test the IX register pair.
    /// </summary>
    ///
    IX = 1UL << 5,

    /// <summary>
    /// Test the IY register pair.
    /// </summary>
    IY = 1UL << 6,

    /// <summary>
    /// Test the PC register.
    /// </summary>
    PC = 1UL << 7,

    /// <summary>
    /// Test the SP register.
    /// </summary>
    SP = 1UL << 8,

    /// <summary>
    /// Test the internal WZ register, sometimes called MEMPTR.
    /// </summary>
    WZ = 1UL << 9,

    /// <summary>
    /// Test the I register.
    /// </summary>
    I = 1UL << 10,

    /// <summary>
    /// Test the R register.
    /// </summary>
    R = 1UL << 11,

    /// <summary>
    /// Test the internal Q register.
    /// </summary>
    Q = 1UL << 12,

    /// <summary>
    /// Test the AF' register pair.
    /// </summary>
    ShadowAF = 1UL << 13,

    /// <summary>
    /// Test the BC' register pair.
    /// </summary>
    ShadowBC = 1UL << 14,

    /// <summary>
    /// Test the DE' register pair.
    /// </summary>
    ShadowDE = 1UL << 15,

    /// <summary>
    /// Test the HL' register pair.
    /// </summary>
    ShadowHL = 1UL << 16,

    /// <summary>
    /// Tests all the non-internal registers, i.e. all registers except <see cref="WZ" /> and <see cref="Q" />.
    /// </summary>
    RegistersExceptWZAndQ = A | F | BC | DE | HL | IX | IY | PC | SP | I | R | ShadowAF | ShadowBC | ShadowDE | ShadowHL,

    /// <summary>
    /// Tests all the registers except <see cref="Q" />.
    /// </summary>
    RegistersExceptQ = RegistersExceptWZAndQ | WZ,

    /// <summary>
    /// Tests all the registers.
    /// </summary>
    Registers = RegistersExceptQ | Q,

    /// <summary>
    /// Test the carry flag, C.
    /// </summary>
    C = 1UL << 17,

    /// <summary>
    /// Test the add/subtract flag, N.
    /// </summary>
    N = 1UL << 18,

    /// <summary>
    /// Test the parity/overflow flag, P/V.
    /// </summary>
    PV = 1UL << 19,

    /// <summary>
    /// Test the undocumented X flag, bit 3 of the F register.
    /// </summary>
    X = 1UL << 20,

    /// <summary>
    /// Test the half-carry flag, H.
    /// </summary>
    H = 1UL << 21,

    /// <summary>
    /// Test the undocumented Y flag, bit 5 of the F register.
    /// </summary>
    Y = 1UL << 22,

    /// <summary>
    /// Test the zero flag, Z.
    /// </summary>
    Z = 1UL << 23,

    /// <summary>
    /// Test the sign flag, S.
    /// </summary>
    S = 1UL << 24,

    /// <summary>
    /// Test the documented flags, <see cref="C" />, <see cref="N" />, <see cref="PV">P/V</see>, <see cref="H" />, <see cref="Z" /> and <see cref="S" />.
    /// </summary>
    DocumentedFlags = C | N | PV | H | Z | S,

    /// <summary>
    /// Test all the flags.
    /// </summary>
    Flags = DocumentedFlags | X | Y,

    /// <summary>
    /// Test the IFF1 interrupt flip-flop.
    /// </summary>
    IFF1 = 1UL << 25,

    /// <summary>
    /// Test the IFF2 interrupt flip-flop.
    /// </summary>
    IFF2 = 1UL << 26,

    /// <summary>
    /// Test the interrupt mode.
    /// </summary>
    IM = 1UL << 27,

    /// <summary>
    /// Test whether the CPU is in the halted state.
    /// </summary>
    Halted = 1UL << 28,

    /// <summary>
    /// Test all the interrupt-related properties, <see cref="IFF1" />, <see cref="IFF2" />, <see cref="IM" /> and <see cref="Halted" />.
    /// </summary>
    Interrupts = IFF1 | IFF2 | IM | Halted,

    /// <summary>
    /// Test I/O read operations.
    /// </summary>
    IOReads = 1UL << 29,

    /// <summary>
    /// Test I/O write operations.
    /// </summary>
    IOWrites = 1UL << 30,

    /// <summary>
    /// Test both I/O read and write operations.
    /// </summary>
    IO = IOReads | IOWrites,

    /// <summary>
    /// Test memory state.
    /// </summary>
    Memory = 1UL << 31,

    /// <summary>
    /// Test machine cycles.
    /// </summary>
    Cycles = 1UL << 32,

    /// <summary>
    /// Test T-states.
    /// </summary>
    TStates = 1UL << 33,

    /// <summary>
    /// Test everything except <see cref="Cycles" />.
    /// </summary>
    AllExceptCycles = Registers | Flags | IO | Interrupts | Memory | TStates,

    /// <summary>
    /// Test everything.
    /// </summary>
    All = AllExceptCycles | Cycles
}