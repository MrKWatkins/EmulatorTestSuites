namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

/// <summary>
/// Represents the input state of a Z80 in an <see cref="InstructionTestCase" />.
/// </summary>
public class Z80InputState : Z80State
{
    /// <summary>
    /// Gets the list of I/O read events that occurred during execution.
    /// </summary>
    public IReadOnlyList<IOEvent> IOReads { get; internal set; } = [];

    /// <summary>
    /// Sets up the Z80 test harness with the current state values.
    /// </summary>
    /// <param name="z80">The Z80 test harness to configure.</param>
    public void Initialize(Z80TestHarness z80)
    {
        z80.RegisterAF = RegisterAF;
        z80.RegisterBC = RegisterBC;
        z80.RegisterDE = RegisterDE;
        z80.RegisterHL = RegisterHL;
        z80.RegisterPC = RegisterPC;
        z80.RegisterSP = RegisterSP;
        z80.RegisterIX = RegisterIX;
        z80.RegisterIY = RegisterIY;
        z80.RegisterWZ = RegisterWZ;
        z80.RegisterI = RegisterI;
        z80.RegisterR = RegisterR;
        z80.RegisterQ = RegisterQ;
        z80.ShadowRegisterAF = ShadowRegisterAF;
        z80.ShadowRegisterBC = ShadowRegisterBC;
        z80.ShadowRegisterDE = ShadowRegisterDE;
        z80.ShadowRegisterHL = ShadowRegisterHL;
        z80.IM = IM;
        z80.IFF1 = IFF1;
        z80.IFF2 = IFF2;
        z80.Halted = Halted;

        foreach (var memory in Memory)
        {
            z80.WriteByteToMemory(memory.Address, memory.Value);
        }

        var io = z80.IOReader as InstructionIO ?? throw new InvalidOperationException($"{nameof(Z80TestHarness.IOReader)} is not an {nameof(InstructionIO)} instance.");
        io.Initialize(this);
    }
}