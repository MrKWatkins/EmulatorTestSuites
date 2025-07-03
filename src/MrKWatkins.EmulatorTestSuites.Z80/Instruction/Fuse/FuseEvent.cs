namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

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

    public FuseEventType Type { get; }

    public ulong TStatesAfter { get; }

    public ushort Address { get; }

    public byte? Data { get; }

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