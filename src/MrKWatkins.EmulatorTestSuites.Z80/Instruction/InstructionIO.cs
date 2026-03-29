namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

internal sealed class InstructionIO(Z80TestHarness z80) : IIOReader, IIOWriter
{
    private readonly Queue<IOEvent> ioReads = new();
    private readonly List<IOEvent> ioWrites = new();

    internal void Initialize(Z80InputState inputState)
    {
        ioReads.Clear();
        foreach (var ioEvent in inputState.IOReads)
        {
            ioReads.Enqueue(ioEvent);
        }
        ioWrites.Clear();
    }

    public byte Read(ushort port)
    {
        if (!ioReads.TryDequeue(out var ioEvent))
        {
            z80.AssertFail($"Unexpected IO read from {port:X4}.");
        }

        if (port != ioEvent.Port)
        {
            z80.AssertFail($"Unexpected IO read from {port:X4}; expected {ioEvent.Port:X4}.");
        }

        return ioEvent.Value;
    }

    public void Write(ushort port, byte value) => ioWrites.Add(new IOEvent(port, value));

    public IReadOnlyList<IOEvent> IOWrites => ioWrites;
}