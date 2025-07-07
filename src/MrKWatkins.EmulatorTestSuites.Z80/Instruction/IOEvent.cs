namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Represents an Input/Output event in the Z80 emulator, containing port and value information.
/// </summary>
/// <param name="port">The I/O port address.</param>
/// <param name="value">The value read from or written to the port.</param>
public readonly struct IOEvent(ushort port, byte value)
{
    /// <summary>
    /// Gets the I/O port address.
    /// </summary>
    public ushort Port { get; } = port;

    /// <summary>
    /// Gets the value that was read from or written to the port.
    /// </summary>
    public byte Value { get; } = value;

    /// <summary>
    /// Returns a string representation of the I/O event in hexadecimal format.
    /// </summary>
    /// <returns>A string in the format "0x1234 = 0x56".</returns>
    public override string ToString() => $"0x{Port:X4}: 0x{Value:X2}";
}