namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

public static class CycleBuilder
{
    // TODO: Accurate and End.
    [Pure]
    public static IEnumerable<Cycle> BuildCycles([InstantHandle] IEnumerable<FuseEvent> fuseEvents, MemoryCycleMethod memoryCycleMethod)
    {
        if (memoryCycleMethod != MemoryCycleMethod.Start)
        {
            throw new NotSupportedException($"The {nameof(MemoryCycleMethod)} {memoryCycleMethod} is not supported.");
        }

        ulong tStates = 0;
        foreach (var @event in fuseEvents)
        {
            if (@event.Type is not (FuseEventType.MemoryContend or FuseEventType.PortContend))
            {
                var cycleType = GetCycleType(@event.Type);

                // Port events need to be one later.
                if (@event.Type is FuseEventType.PortRead or FuseEventType.PortWrite)
                {
                    yield return new Cycle(cycleType, tStates + 1, @event.Address, @event.Data);
                }
                else
                {
                    yield return new Cycle(cycleType, tStates, @event.Address, @event.Data);
                }
            }

            tStates = @event.TStatesAfter;
        }
    }

    [Pure]
    private static CycleType GetCycleType(FuseEventType type) => type switch
    {
        FuseEventType.MemoryRead => CycleType.MemoryRead,
        FuseEventType.MemoryWrite => CycleType.MemoryWrite,
        FuseEventType.PortWrite => CycleType.IOWrite,
        FuseEventType.PortRead => CycleType.IORead,
        _ => throw new NotSupportedException($"The {nameof(FuseEventType)} {type} is not supported.")
    };
}