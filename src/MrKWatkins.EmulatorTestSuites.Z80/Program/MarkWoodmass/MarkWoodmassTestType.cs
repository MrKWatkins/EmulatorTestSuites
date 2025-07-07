namespace MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

/// <summary>
/// Specifies the type of <see cref="MarkWoodmassTestSuite"/>.
/// </summary>
public enum MarkWoodmassTestType
{
    /// <summary>
    /// Tests the flags for various DD/FD/CB instructions.
    /// </summary>
    Flags,

    /// <summary>
    /// Tests MEMPTR (WZ) implementations.
    /// </summary>
    Memptr
}