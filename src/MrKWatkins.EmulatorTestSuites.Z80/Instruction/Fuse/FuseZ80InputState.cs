namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

public sealed class FuseZ80InputState : Z80InputState
{
    internal FuseZ80InputState()
    {
    }

    public ulong MinimumTStatesToRun { get; internal set; }
}