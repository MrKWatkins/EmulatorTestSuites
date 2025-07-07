namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Represents the state of a memory location in the Z80 emulator, containing an address and its corresponding value.
/// </summary>
public readonly struct MemoryState
{
    internal MemoryState(ushort address, byte value)
    {
        Address = address;
        Value = value;
    }

    /// <summary>
    /// Gets the memory address.
    /// </summary>
    public ushort Address { get; }

    /// <summary>
    /// Gets the value stored at the specified memory address.
    /// </summary>
    public byte Value { get; }

    /// <summary>
    /// Returns a string representation of the memory state in hexadecimal format.
    /// </summary>
    /// <returns>A string in the format "0x1234 = 0x56".</returns>
    public override string ToString() => $"0x{Address:X4} = 0x{Value:X2}";
}