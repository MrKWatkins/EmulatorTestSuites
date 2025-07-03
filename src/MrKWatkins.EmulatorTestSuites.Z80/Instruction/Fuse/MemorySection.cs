namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

public sealed class MemorySection
{
    internal MemorySection(ushort address, byte[] data)
    {
        Address = address;
        Data = data;
    }

    public ushort Address { get; }

    public byte[] Data { get; }

    public override string ToString() => $"0x{Address:X4}: {string.Join(" ", Data.Select(d => d.ToString("X2")))}";
}