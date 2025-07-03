namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

public enum FuseEventType : byte
{
    MemoryContend,
    MemoryRead,
    MemoryWrite,
    PortWrite,
    PortContend,
    PortRead,
}