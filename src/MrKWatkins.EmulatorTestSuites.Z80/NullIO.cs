namespace MrKWatkins.EmulatorTestSuites.Z80;

public sealed class NullIO(byte readValue = 0xFF) : IIOReader, IIOWriter
{
    public byte Read(ushort port) => readValue;

    public void Write(ushort port, byte value)
    {
    }
}