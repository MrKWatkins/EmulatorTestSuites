namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

[Flags]
public enum Pins : byte
{
    None = 0,
    Read = 1,
    Write = 2,
    Memory = 4,
    IO = 8,
    MemoryRead = Read | Memory,
    MemoryWrite = Write | Memory,
    IORead = Read | IO,
    IOWrite = Write | IO
}