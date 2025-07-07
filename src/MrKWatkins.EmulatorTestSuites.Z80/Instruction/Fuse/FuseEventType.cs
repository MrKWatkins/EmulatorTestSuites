namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// Types of a <see cref="FuseEvent" />.
/// </summary>
public enum FuseEventType : byte
{
    /// <summary>
    /// A memory contention event.
    /// </summary>
    MemoryContend,

    /// <summary>
    /// A memory read event.
    /// </summary>
    MemoryRead,

    /// <summary>
    /// A memory write event.
    /// </summary>
    MemoryWrite,

    /// <summary>
    /// A port write event.
    /// </summary>
    PortWrite,

    /// <summary>
    /// A port contention event.
    /// </summary>
    PortContend,

    /// <summary>
    /// A port read event.
    /// </summary>
    PortRead,
}