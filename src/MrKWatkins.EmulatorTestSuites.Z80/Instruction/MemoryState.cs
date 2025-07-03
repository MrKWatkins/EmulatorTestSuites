namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public readonly struct MemoryState
{
    internal MemoryState(ushort address, byte value)
    {
        Address = address;
        Value = value;
    }

    public ushort Address { get; }

    public byte Value { get; }

    public override string ToString() => $"{Address:X4} = {Value:X2}";
}