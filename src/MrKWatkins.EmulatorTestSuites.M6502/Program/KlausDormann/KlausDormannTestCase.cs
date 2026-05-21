namespace MrKWatkins.EmulatorTestSuites.M6502.Program.KlausDormann;

/// <summary>
/// A test case from the <see cref="KlausDormannTestSuite" />.
/// </summary>
public sealed class KlausDormannTestCase : ProgramTestCase
{
    private const ushort StartAddress = 0x0400;
    private const ushort SuccessAddress = 0x3469;
    // Steppable harnesses detect the terminal self-loop at the next opcode boundary.
    private const ushort SteppableSuccessAddress = 0x346C;

    internal KlausDormannTestCase(byte[] memory)
        : base("6502 Functional Test", memory)
    {
    }

    [Pure]
    private protected override ulong MaximumTStates => 100_000_000_000;

    private protected override void SetupTestCase(M6502TestHarness m6502) => m6502.RegisterPC = StartAddress;

    private protected override void AssertCompleted(M6502TestHarness m6502, ushort stopAddress, TextWriter? testOutput)
    {
        if (stopAddress != SuccessAddress && stopAddress != SteppableSuccessAddress)
        {
            m6502.AssertFail($"Klaus Dormann functional test failed at trap 0x{stopAddress:X4}.");
            return;
        }

        testOutput?.WriteLine($"Klaus Dormann functional test passed at 0x{stopAddress:X4}.");
    }
}