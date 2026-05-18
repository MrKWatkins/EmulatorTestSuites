namespace MrKWatkins.EmulatorTestSuites.M6502;

/// <summary>
/// Represents the type of memory operation cycle performed by the M6502 during emulation.
/// </summary>
public enum CycleType
{
    /// <summary>
    /// Represents a memory read operation.
    /// </summary>
    Read,

    /// <summary>
    /// Represents a memory write operation.
    /// </summary>
    Write
}