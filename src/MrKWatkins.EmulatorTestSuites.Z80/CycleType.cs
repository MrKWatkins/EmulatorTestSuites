namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Represents the type of memory or I/O operation cycle performed by the Z80 during emulation.
/// </summary>
public enum CycleType
{
    /// <summary>
    /// Represents no operation.
    /// </summary>
    None,

    /// <summary>
    /// Represents a memory read operation.
    /// </summary>
    MemoryRead,

    /// <summary>
    /// Represents a memory write operation.
    /// </summary>
    MemoryWrite,

    /// <summary>
    /// Represents an I/O port read operation.
    /// </summary>
    IORead,

    /// <summary>
    /// Represents an I/O port write operation.
    /// </summary>
    IOWrite,

    /// <summary>
    /// Represents a write to a Next register. Z80N only; the Next registers are on a bus of their own rather than the I/O bus.
    /// </summary>
    NextRegisterWrite
}