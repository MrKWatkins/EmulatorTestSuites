namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// Represents an event from the FUSE Z80 test suite.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public readonly struct FuseEvent
{
    private FuseEvent(FuseEventType type, ulong tStatesAfter, ushort address, byte? data)
    {
        Type = type;
        TStatesAfter = tStatesAfter;
        Address = address;
        Data = data;
    }

    /// <summary>
    /// Gets the type of the <see cref="FuseEvent"/>.
    /// </summary>
    public FuseEventType Type { get; }

    /// <summary>
    /// Gets the number of T-states after the event occurred.
    /// </summary>
    public ulong TStatesAfter { get; }

    /// <summary>
    /// Gets the memory address associated with the event.
    /// </summary>
    public ushort Address { get; }

    /// <summary>
    /// Gets the optional data value associated with the event.
    /// </summary>
    public byte? Data { get; }

    /// <summary>
    /// Returns a string representation of this <see cref="FuseEvent" />.
    /// </summary>
    /// <returns>A string representing this <see cref="FuseEvent" />.</returns>
    public override string ToString() => $"{Type}: T-States After = {TStatesAfter}, 0x{Address:X4} {Data?.ToString("X2") ?? ""}";

    [Pure]
    internal static FuseEvent Parse(string line)
    {
        var components = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var type = components[1].ToEventType();
        var time = ulong.Parse(components[0]);
        var address = components[2].ToWord();
        byte? data = components.Length == 4 ? components[3].ToByte() : null;

        return new FuseEvent(type, time, address, data);
    }
}