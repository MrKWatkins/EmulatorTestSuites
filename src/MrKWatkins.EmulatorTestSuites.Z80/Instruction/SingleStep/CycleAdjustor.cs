namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

/// <summary>
/// The SingleStepTests have been generated with the 'use simplified memory access T-states' option set. Memory read and write pins are set on the second T-State of the cycle,
/// which corresponds to <see cref="MemoryCycleMethod.End" />. This type adjusts them to match the specified method.
/// </summary>
public static class CycleAdjustor
{
    [Pure]
    public static IEnumerable<Cycle> AdjustTo(MemoryCycleMethod method, IEnumerable<Cycle> cycles) => method switch
    {
        MemoryCycleMethod.Accurate => AdjustToAccurate(cycles),
        MemoryCycleMethod.Start => AdjustToStart(cycles),
        MemoryCycleMethod.End => cycles,
        _ => throw new NotSupportedException($"The {nameof(MemoryCycleMethod)} {method} is not supported.")
    };

    [Pure]
    private static IEnumerable<Cycle> AdjustToAccurate(IEnumerable<Cycle> cycles)
    {
        foreach (var (previous, current, next) in EnumerateCycles(cycles))
        {
            if (next?.Type is CycleType.MemoryRead or CycleType.MemoryWrite)
            {
                yield return new Cycle(next.Type, current.Index, current.Address, next.Data);
            }
            else if (current.Type is CycleType.MemoryRead)
            {
                yield return new Cycle(CycleType.MemoryRead, current.Index, current.Address, next?.Data);
            }
            else if (previous?.Type is CycleType.MemoryRead)
            {
                yield return new Cycle(CycleType.None, current.Index, current.Address, previous.Data);
            }
            else
            {
                yield return current;
            }
        }
    }

    [Pure]
    private static IEnumerable<Cycle> AdjustToStart(IEnumerable<Cycle> cycles)
    {
        foreach (var (previous, current, next) in EnumerateCycles(cycles))
        {
            if (IsNotTypeNone(next))
            {
                yield return new Cycle(next.Type, current.Index, current.Address, next.Data);
            }
            else if (IsNotTypeNone(current))
            {
                if (next == null)
                {
                    throw new InvalidOperationException("Instruction ended with a memory read or write cycle.");
                }
                yield return new Cycle(CycleType.None, current.Index, current.Address, next.Data);
            }
            else if (previous?.Type is CycleType.MemoryRead)
            {
                yield return new Cycle(CycleType.None, current.Index, current.Address, previous.Data);
            }
            else
            {
                yield return current;
            }
        }
    }

    [Pure]
    private static bool IsNotTypeNone([NotNullWhen(true)] Cycle? cycle) => cycle != null && cycle.Type != CycleType.None;

    [Pure]
    private static IEnumerable<(Cycle? Previous, Cycle Current, Cycle? Next)> EnumerateCycles(IEnumerable<Cycle> cycles)
    {
        using var enumerator = cycles.GetEnumerator();
        enumerator.MoveNext();

        Cycle? previous = null;
        var current = enumerator.Current;
        while (enumerator.MoveNext())
        {
            yield return (previous, current, enumerator.Current);
            previous = current;
            current = enumerator.Current;
        }
        yield return (previous, current, null);
    }
}