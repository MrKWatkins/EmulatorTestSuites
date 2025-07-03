namespace MrKWatkins.EmulatorTestSuites.Z80;

public interface IIOWriter
{
    void Write(ushort port, byte value);
}