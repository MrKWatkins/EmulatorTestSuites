namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// The expected state for <see cref="FuseTestCase"/>s.
/// </summary>
public sealed class FuseZ80ExpectedState : Z80ExpectedState
{
    internal FuseZ80ExpectedState(IReadOnlyList<FuseEvent> events)
    {
        Events = events;
        IOWrites = events.Where(e => e.Type == FuseEventType.PortWrite).Select(e => new IOEvent(e.Address, e.Data ?? 0)).ToList();
    }

    /// <summary>
    /// The expected events.
    /// </summary>
    public IReadOnlyList<FuseEvent> Events { get; }

    private protected override bool ShouldAssertCycle(Cycle cycle) => cycle.Type != CycleType.None;
}