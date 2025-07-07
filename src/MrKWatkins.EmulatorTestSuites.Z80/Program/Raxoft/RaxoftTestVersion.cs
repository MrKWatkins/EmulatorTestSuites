namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

// TODO: Other versions.
/// <summary>
/// Specifies the version of <see cref="RaxoftTestSuite"/>.
/// </summary>
#pragma warning disable CA1707
[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum RaxoftTestVersion
{
    /// <summary>
    /// Version 1.0.
    /// </summary>
    /// <seealso href="https://github.com/raxoft/z80test/releases/tag/v1.0"/>
    V1_0,

    /// <summary>
    /// Version 1.2A.
    /// </summary>
    /// <seealso href="https://github.com/raxoft/z80test/releases/tag/v1.2a"/>
    V1_2A
}
#pragma warning restore CA1707