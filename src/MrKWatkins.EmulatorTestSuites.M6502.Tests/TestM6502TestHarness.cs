namespace MrKWatkins.EmulatorTestSuites.M6502.Tests;

internal sealed class TestM6502TestHarness : M6502TestHarness
{
    private readonly byte[] memory = new byte[65536];

    public override byte RegisterA { get; set; }

    public override byte RegisterX { get; set; }

    public override byte RegisterY { get; set; }

    public override byte RegisterS { get; set; }

    public override byte RegisterP { get; set; }

    public override ushort RegisterPC { get; set; }

    public override byte ReadByteFromMemory(ushort address) => memory[address];

    public override void WriteByteToMemory(ushort address, byte value) => memory[address] = value;

    public override void AssertFail(string message) => throw new NUnit.Framework.AssertionException(message);

    public override void ExecuteInstruction() => throw new NotImplementedException();
}