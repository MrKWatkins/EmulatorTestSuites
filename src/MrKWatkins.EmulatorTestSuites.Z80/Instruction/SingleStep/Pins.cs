namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

/// <summary>
/// Represents the various control pins and signals used by the Z80 processor during instruction execution. This enum uses flags to allow combinations of different signals.
/// </summary>
[Flags]
public enum Pins : byte
{
    /// <summary>
    /// No pins are active.
    /// </summary>
    None = 0,

    /// <summary>
    /// Indicates a read operation is being performed.
    /// </summary>
    Read = 1,

    /// <summary>
    /// Indicates a write operation is being performed.
    /// </summary>
    Write = 2,

    /// <summary>
    /// Indicates a memory operation is being performed.
    /// </summary>
    Memory = 4,

    /// <summary>
    /// Indicates an I/O operation is being performed.
    /// </summary>
    IO = 8,

    /// <summary>
    /// Combination of <see cref="Read"/> and <see cref="Memory"/> pins indicating a memory read operation.
    /// </summary>
    MemoryRead = Read | Memory,

    /// <summary>
    /// Combination of <see cref="Write"/> and <see cref="Memory"/> pins indicating a memory write operation.
    /// </summary>
    MemoryWrite = Write | Memory,

    /// <summary>
    /// Combination of <see cref="Read"/> and <see cref="IO"/> pins indicating an I/O read operation.
    /// </summary>
    IORead = Read | IO,

    /// <summary>
    /// Combination of <see cref="Write"/> and <see cref="IO"/> pins indicating an I/O write operation.
    /// </summary>
    IOWrite = Write | IO
}