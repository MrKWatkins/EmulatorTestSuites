namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction;

/// <summary>
/// Represents the expected state of an M6502 after executing an <see cref="InstructionTestCase" />.
/// </summary>
public class M6502ExpectedState : M6502State
{
    /// <summary>
    /// Gets the expected list of cycles that occurred during instruction execution.
    /// </summary>
    public IReadOnlyList<Cycle> Cycles { get; internal set; } = [];

    /// <summary>
    /// Gets the expected number of cycles taken to execute the instruction.
    /// </summary>
    public ulong TStates { get; internal set; }

    /// <summary>
    /// Asserts that the actual M6502 state matches the expected state.
    /// </summary>
    /// <param name="m6502">The M6502 test harness containing the actual state to verify.</param>
    public void Assert(M6502TestHarness m6502)
    {
        m6502.AssertEqual(m6502.TStates, TStates, $"T-States should be {TStates} but was {m6502.TStates}");
        m6502.AssertEqual(m6502.RegisterA, RegisterA, $"Register A should be 0x{RegisterA:X2} but was 0x{m6502.RegisterA:X2}");
        m6502.AssertEqual(m6502.RegisterX, RegisterX, $"Register X should be 0x{RegisterX:X2} but was 0x{m6502.RegisterX:X2}");
        m6502.AssertEqual(m6502.RegisterY, RegisterY, $"Register Y should be 0x{RegisterY:X2} but was 0x{m6502.RegisterY:X2}");
        m6502.AssertEqual(m6502.RegisterS, RegisterS, $"Register S should be 0x{RegisterS:X2} but was 0x{m6502.RegisterS:X2}");
        m6502.AssertEqual(m6502.RegisterP, RegisterP, $"Register P should be 0x{RegisterP:X2} but was 0x{m6502.RegisterP:X2}");
        m6502.AssertEqual(m6502.RegisterPC, RegisterPC, $"Register PC should be 0x{RegisterPC:X4} but was 0x{m6502.RegisterPC:X4}");

        AssertMemory(m6502);
        AssertCycles(m6502);
    }

    private void AssertMemory(M6502TestHarness m6502)
    {
        foreach (var memory in Memory)
        {
            var actual = m6502.ReadByteFromMemory(memory.Address);
            m6502.AssertEqual(actual, memory.Value, $"memory at 0x{memory.Address:X4} should be 0x{memory.Value:X2} but was 0x{actual:X2}");
        }
    }

    private void AssertCycles(M6502TestHarness m6502)
    {
        var actualCycles = m6502.Cycles;

        m6502.AssertEqual(actualCycles.Count, Cycles.Count, $"Expected {Cycles.Count} cycles but was {actualCycles.Count}");

        for (var f = 0; f < Math.Min(actualCycles.Count, Cycles.Count); f++)
        {
            AssertCycle(m6502, actualCycles[f], Cycles[f], f);
        }
    }

    private static void AssertCycle(M6502TestHarness m6502, Cycle actual, Cycle expected, int index)
    {
        m6502.AssertEqual(actual.Type, expected.Type, $"Expected cycle {index} to have type {expected.Type} but was {actual.Type}");
        m6502.AssertEqual(actual.Address, expected.Address, $"Expected cycle {index} to have address {expected.Address} but was {actual.Address}");
        m6502.AssertEqual(actual.Data, expected.Data, $"Expected cycle {index} to have data {expected.Data} but was {actual.Data}");
    }
}