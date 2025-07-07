namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Interface for writing to I/O ports in Z80 emulation.
/// </summary>
public interface IIOWriter
{
    /// <summary>
    /// Writes a byte value to the specified I/O port.
    /// </summary>
    /// <param name="port">The port address to write to.</param>
    /// <param name="value">The byte value to write to the port.</param>
    void Write(ushort port, byte value);
}