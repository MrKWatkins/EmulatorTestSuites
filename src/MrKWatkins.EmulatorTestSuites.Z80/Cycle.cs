namespace MrKWatkins.EmulatorTestSuites.Z80;

public sealed class Cycle(CycleType type, ulong index, ushort address, byte? data, bool isOpcodeRead = false) : IEquatable<Cycle>
{
    public CycleType Type { get; } = type;

    public ulong Index { get; } = index;

    public ushort Address { get; } = address;

    public byte? Data { get; } = data;

    public bool IsOpcodeRead { get; } = isOpcodeRead;

    public override string ToString() => $"{Type}: 0x{Address:X4} 0x{Data:X2}";

    public bool Equals(Cycle? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Type == other.Type && Index == other.Index && Address == other.Address && Data == other.Data && IsOpcodeRead == other.IsOpcodeRead;
    }

    public override bool Equals(object? obj) => Equals(obj as Cycle);

    public override int GetHashCode() => HashCode.Combine((int)Type, Index, Address, Data, IsOpcodeRead);

    public static bool operator ==(Cycle? left, Cycle? right) => Equals(left, right);

    public static bool operator !=(Cycle? left, Cycle? right) => !Equals(left, right);
}