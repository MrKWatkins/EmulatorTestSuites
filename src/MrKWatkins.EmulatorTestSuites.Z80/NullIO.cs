namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// A null implementation of I/O operations that returns a constant value for reads and ignores writes.
/// </summary>
public sealed class NullIO(byte readValue = 0xFF) : IIOReader, IIOWriter
{
    /// <summary>
    /// Reads a byte from the specified I/O port.
    /// </summary>
    /// <param name="port">The port address to read from.</param>
    /// <returns>The constant value specified in the constructor.</returns>
    public byte Read(ushort port) => readValue;

    /// <summary>
    /// Writes a byte to the specified I/O port. This implementation ignores the write operation.
    /// </summary>
    /// <param name="port">The port address to write to.</param>
    /// <param name="value">The value to write.</param>
    public void Write(ushort port, byte value)
    {
    }
}