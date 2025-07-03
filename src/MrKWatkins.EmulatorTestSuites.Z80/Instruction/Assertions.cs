namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

// TODO: Make general version for all tests. Maybe make more granular, e.g. to register/flag level.
[Flags]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum Assertions : ulong
{
    None = 0,

    // Registers. A and F are separated out so we can disable checking F if we're not checking some flags.
    A = 1UL << 0,
    F = 1UL << 1,
    BC = 1UL << 2,
    DE = 1UL << 3,
    HL = 1UL << 4,
    IX = 1UL << 5,
    IY = 1UL << 6,
    PC = 1UL << 7,
    SP = 1UL << 8,
    WZ = 1UL << 9,
    I = 1UL << 10,
    R = 1UL << 11,
    Q = 1UL << 12,
    ShadowAF = 1UL << 13,
    ShadowBC = 1UL << 14,
    ShadowDE = 1UL << 15,
    ShadowHL = 1UL << 16,
    RegistersExceptWZAndQ = A | F | BC | DE | HL | IX | IY | PC | SP | I | R | ShadowAF | ShadowBC | ShadowDE | ShadowHL,
    RegistersExceptQ = RegistersExceptWZAndQ | WZ,
    Registers = RegistersExceptQ | Q,

    // Flags.
    C = 1UL << 17,
    N = 1UL << 18,
    PV = 1UL << 19,
    X = 1UL << 20,
    H = 1UL << 21,
    Y = 1UL << 22,
    Z = 1UL << 23,
    S = 1UL << 24,
    DocumentedFlags = C | N | PV | H | Z | S,
    Flags = DocumentedFlags | X | Y,

    // Interrupts.
    IFF1 = 1UL << 25,
    IFF2 = 1UL << 26,
    IM = 1UL << 27,
    Halted = 1UL << 28,
    Interrupts = IFF1 | IFF2 | IM | Halted,

    // IO.
    IOReads = 1UL << 29,
    IOWrites = 1UL << 30,
    IO = IOReads | IOWrites,

    Memory = 1UL << 31,

    Cycles = 1UL << 32,

    TStates = 1UL << 33,

    AllExceptCycles = Registers | Flags | IO | Interrupts | Memory | TStates,
    All = AllExceptCycles | Cycles
}