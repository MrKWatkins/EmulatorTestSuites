namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public class Z80InputState : Z80State
{
    public IReadOnlyList<IOEvent> IOReads { get; internal set; } = [];

    public virtual void Setup(Z80TestHarness z80)
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

        foreach (var memory in Memory)
        {
            z80.SetByteInMemory(memory.Address, memory.Value);
        }
    }
}