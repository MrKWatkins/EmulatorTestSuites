namespace MrKWatkins.EmulatorTestSuites.M6502;

/// <summary>
/// Base class for an M6502 emulator test harness. Implement this class to use it with the test suites.
/// </summary>
public abstract class M6502TestHarness : TestHarness<Cycle>
{
    /// <summary>
    /// Gets or sets the accumulator register.
    /// </summary>
    public abstract byte RegisterA { get; set; }

    /// <summary>
    /// Gets or sets the X index register.
    /// </summary>
    public abstract byte RegisterX { get; set; }

    /// <summary>
    /// Gets or sets the Y index register.
    /// </summary>
    public abstract byte RegisterY { get; set; }

    /// <summary>
    /// Gets or sets the stack pointer.
    /// </summary>
    public abstract byte RegisterS { get; set; }

    /// <summary>
    /// Gets or sets the processor status register.
    /// </summary>
    public abstract byte RegisterP { get; set; }

    /// <summary>
    /// Gets or sets the program counter.
    /// </summary>
    public abstract ushort RegisterPC { get; set; }

    /// <summary>
    /// Gets or sets the carry flag, C.
    /// </summary>
    public bool FlagC
    {
        get => (RegisterP & 0b00000001) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b00000001 : RegisterP & 0b11111110);
    }

    /// <summary>
    /// Gets or sets the zero flag, Z.
    /// </summary>
    public bool FlagZ
    {
        get => (RegisterP & 0b00000010) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b00000010 : RegisterP & 0b11111101);
    }

    /// <summary>
    /// Gets or sets the interrupt disable flag, I.
    /// </summary>
    public bool FlagI
    {
        get => (RegisterP & 0b00000100) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b00000100 : RegisterP & 0b11111011);
    }

    /// <summary>
    /// Gets or sets the decimal flag, D.
    /// </summary>
    public bool FlagD
    {
        get => (RegisterP & 0b00001000) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b00001000 : RegisterP & 0b11110111);
    }

    /// <summary>
    /// Gets or sets the break flag, B.
    /// </summary>
    public bool FlagB
    {
        get => (RegisterP & 0b00010000) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b00010000 : RegisterP & 0b11101111);
    }

    /// <summary>
    /// Gets or sets the overflow flag, V.
    /// </summary>
    public bool FlagV
    {
        get => (RegisterP & 0b01000000) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b01000000 : RegisterP & 0b10111111);
    }

    /// <summary>
    /// Gets or sets the negative flag, N.
    /// </summary>
    public bool FlagN
    {
        get => (RegisterP & 0b10000000) != 0;
        set => RegisterP = (byte)(value ? RegisterP | 0b10000000 : RegisterP & 0b01111111);
    }

    /// <summary>
    /// Executes a single instruction.
    /// </summary>
    public abstract void ExecuteInstruction();
}