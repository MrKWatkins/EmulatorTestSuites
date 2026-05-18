namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction;

/// <summary>
/// Represents the input state of an M6502 in an <see cref="InstructionTestCase" />.
/// </summary>
public class M6502InputState : M6502State
{
    /// <summary>
    /// Sets up the M6502 test harness with the current state values.
    /// </summary>
    /// <param name="m6502">The M6502 test harness to configure.</param>
    public void Initialize(M6502TestHarness m6502)
    {
        m6502.RegisterA = RegisterA;
        m6502.RegisterX = RegisterX;
        m6502.RegisterY = RegisterY;
        m6502.RegisterS = RegisterS;
        m6502.RegisterP = RegisterP;
        m6502.RegisterPC = RegisterPC;

        foreach (var memory in Memory)
        {
            m6502.WriteByteToMemory(memory.Address, memory.Value);
        }
    }
}