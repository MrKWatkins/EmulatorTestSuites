namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

public sealed class FuseZ80ExpectedState : Z80ExpectedState
{
    internal FuseZ80ExpectedState(IReadOnlyList<FuseEvent> events)
    {
        Events = events;
        IOWrites = events.Where(e => e.Type == FuseEventType.PortWrite).Select(e => new IOEvent(e.Address, e.Data ?? 0)).ToList();
    }

    public IReadOnlyList<FuseEvent> Events { get; }

    protected override bool ShouldAssertCycle(Cycle cycle) => cycle.Type != CycleType.None;
}