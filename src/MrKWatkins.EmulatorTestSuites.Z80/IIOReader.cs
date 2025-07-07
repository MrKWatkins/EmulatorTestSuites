namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Interface for reading I/O ports in Z80 emulation.
/// </summary>
public interface IIOReader
{
    /// <summary>
    /// Reads a byte from the specified I/O port.
    /// </summary>
    /// <param name="port">The port address to read from.</param>
    /// <returns>The byte value read from the port.</returns>
    [Pure]
    byte Read(ushort port);
}