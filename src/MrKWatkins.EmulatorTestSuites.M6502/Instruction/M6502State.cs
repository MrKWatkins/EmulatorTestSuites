namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction;

/// <summary>
/// Represents the state of an M6502 processor, including registers, flags, and memory.
/// </summary>
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public abstract class M6502State
{
    private protected M6502State()
    {
    }

    /// <summary>
    /// Gets the accumulator register.
    /// </summary>
    public byte RegisterA { get; internal set; }

    /// <summary>
    /// Gets the X index register.
    /// </summary>
    public byte RegisterX { get; internal set; }

    /// <summary>
    /// Gets the Y index register.
    /// </summary>
    public byte RegisterY { get; internal set; }

    /// <summary>
    /// Gets the stack pointer.
    /// </summary>
    public byte RegisterS { get; internal set; }

    /// <summary>
    /// Gets the processor status register.
    /// </summary>
    public byte RegisterP { get; internal set; }

    /// <summary>
    /// Gets the program counter.
    /// </summary>
    public ushort RegisterPC { get; internal set; }

    /// <summary>
    /// Gets the carry flag, C.
    /// </summary>
    public bool FlagC => (RegisterP & 0b00000001) != 0;

    /// <summary>
    /// Gets the zero flag, Z.
    /// </summary>
    public bool FlagZ => (RegisterP & 0b00000010) != 0;

    /// <summary>
    /// Gets the interrupt disable flag, I.
    /// </summary>
    public bool FlagI => (RegisterP & 0b00000100) != 0;

    /// <summary>
    /// Gets the decimal flag, D.
    /// </summary>
    public bool FlagD => (RegisterP & 0b00001000) != 0;

    /// <summary>
    /// Gets the break flag, B.
    /// </summary>
    public bool FlagB => (RegisterP & 0b00010000) != 0;

    /// <summary>
    /// Gets the overflow flag, V.
    /// </summary>
    public bool FlagV => (RegisterP & 0b01000000) != 0;

    /// <summary>
    /// Gets the negative flag, N.
    /// </summary>
    public bool FlagN => (RegisterP & 0b10000000) != 0;

    /// <summary>
    /// Gets the memory state.
    /// </summary>
    public IReadOnlyList<MemoryState> Memory { get; internal set; } = [];
}