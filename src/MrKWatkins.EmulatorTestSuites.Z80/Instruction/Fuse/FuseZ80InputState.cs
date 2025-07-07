namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// The input state for <see cref="FuseTestCase"/>s.
/// </summary>
public sealed class FuseZ80InputState : Z80InputState
{
    internal FuseZ80InputState()
    {
    }

    /// <summary>
    /// Gets or sets the minimum number of T-states that must be run for this test case.
    /// </summary>
    public ulong MinimumTStatesToRun { get; internal set; }
}