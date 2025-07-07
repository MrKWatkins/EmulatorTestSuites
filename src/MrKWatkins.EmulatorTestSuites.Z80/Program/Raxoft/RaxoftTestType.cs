namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

/// <summary>
/// Specifies the type of <see cref="RaxoftTestSuite"/>.
/// </summary>
public enum RaxoftTestType
{
    /// <summary>
    /// Tests all flags after executing CCF after each instruction tested.
    /// </summary>
    Ccf,

    /// <summary>
    /// Tests all registers but only the officially documented flags.
    /// </summary>
    Doc,

    /// <summary>
    /// Tests documented flags only, ignores registers.
    /// </summary>
    DocFlags,

    /// <summary>
    /// Tests all flags, ignores registers.
    /// </summary>
    Flags,

    /// <summary>
    /// Tests all flags after executing BIT N,(HL) after each instruction tested.
    /// </summary>
    Memptr,

    /// <summary>
    /// Tests all flags and registers.
    /// </summary>
    Full
}