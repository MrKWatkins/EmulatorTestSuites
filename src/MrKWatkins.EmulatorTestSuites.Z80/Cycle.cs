namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Represents a single CPU cycle with its associated type, timing, address, and data information.
/// </summary>
/// <param name="type">The type of CPU cycle.</param>
/// <param name="index">The sequential index of the cycle.</param>
/// <param name="address">The memory address associated with the cycle.</param>
/// <param name="data">The data value associated with the cycle, if any.</param>
/// <param name="isOpcodeRead">Indicates whether this cycle is reading an opcode.</param>
public sealed class Cycle(CycleType type, ulong index, ushort address, byte? data, bool isOpcodeRead = false) : IEquatable<Cycle>
{
    /// <summary>
    /// Gets the type of CPU cycle.
    /// </summary>
    public CycleType Type { get; } = type;

    /// <summary>
    /// Gets the sequential index of the cycle.
    /// </summary>
    public ulong Index { get; } = index;

    /// <summary>
    /// Gets the memory address associated with the cycle.
    /// </summary>
    public ushort Address { get; } = address;

    /// <summary>
    /// Gets the data value associated with the cycle, if any.
    /// </summary>
    public byte? Data { get; } = data;

    /// <summary>
    /// Gets a value indicating whether this cycle is reading an opcode. Only set when <see cref="Type" /> is <see cref="CycleType.MemoryRead" />.
    /// </summary>
    public bool IsOpcodeRead { get; } = isOpcodeRead;

    /// <summary>
    /// Returns a string representation of this <see cref="Cycle" />.
    /// </summary>
    /// <returns>A string representing this <see cref="Cycle" />.</returns>
    public override string ToString() => $"{Type}: 0x{Address:X4} 0x{Data:X2}";

    /// <summary>
    /// Indicates whether this <see cref="Cycle"/> is equal to another <see cref="Cycle"/>.
    /// </summary>
    /// <param name="other">A <see cref="Cycle"/> to compare with this <see cref="Cycle"/>.</param>
    /// <returns><c>true</c> if this <see cref="Cycle"/> is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    /// Determines whether the specified object is equal to this <see cref="Cycle"/>.
    /// </summary>
    /// <param name="obj">The object to compare with this <see cref="Cycle"/>.</param>
    /// <returns><c>true</c> if this <see cref="Cycle"/> is equal to the <paramref name="obj" /> parameter; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => Equals(obj as Cycle);

    /// <summary>
    /// Gets a hash code for this <see cref="Cycle"/>.
    /// </summary>
    /// <returns>A hash code for this <see cref="Cycle"/>.</returns>
    public override int GetHashCode() => HashCode.Combine((int)Type, Index, Address, Data, IsOpcodeRead);

    /// <summary>
    /// Tests if two <see cref="Cycle" /> instances are equal to each other.
    /// </summary>
    /// <param name="left">The left <see cref="Cycle" />.</param>
    /// <param name="right">The left <see cref="Cycle" />.</param>
    /// <returns><c>true</c> if <paramref name="left" /> and <paramref name="right" /> are equal, <c>false</c> otherwise.</returns>
    public static bool operator ==(Cycle? left, Cycle? right) => Equals(left, right);

    /// <summary>
    /// Tests if two <see cref="Cycle" /> instances are not equal to each other.
    /// </summary>
    /// <param name="left">The left <see cref="Cycle" />.</param>
    /// <param name="right">The left <see cref="Cycle" />.</param>
    /// <returns><c>true</c> if <paramref name="left" /> and <paramref name="right" /> are not equal, <c>false</c> otherwise.</returns>
    public static bool operator !=(Cycle? left, Cycle? right) => !Equals(left, right);
}