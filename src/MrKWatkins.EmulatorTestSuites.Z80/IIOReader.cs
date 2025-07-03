namespace MrKWatkins.EmulatorTestSuites.Z80;

public interface IIOReader
{
    [Pure]
    byte Read(ushort port);
}