using System.Runtime.CompilerServices;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public class Z80ExpectedState : Z80State
{
    public IReadOnlyList<IOEvent> IOWrites { get; internal set; } = [];

    public IReadOnlyList<Cycle> Cycles { get; internal set; } = [];

    // ReSharper disable once InconsistentNaming
    public ulong TStates { get; internal set; }

    public void Assert(Assertions assertionsToRun, Z80TestHarness z80)
    {
        AssertEqual(assertionsToRun, z80, Assertions.TStates, z80.TStates, TStates, $"T-States should be {TStates} but was {z80.TStates}");
        AssertRegisters(assertionsToRun, z80);
        AssertFlags(assertionsToRun, z80);
        AssertInterrupts(assertionsToRun, z80);
        AssertMemory(assertionsToRun, z80);
        AssertIOWrites(assertionsToRun, z80);
        AssertCycles(assertionsToRun, z80);
    }

    private void AssertRegisters(Assertions assertionsToRun, Z80TestHarness z80)
    {
        AssertEqual(assertionsToRun, z80, Assertions.A, z80.RegisterA, RegisterA, $"Register A should be 0x{RegisterA:X2} but was 0x{z80.RegisterA:X2}");
        AssertEqual(assertionsToRun, z80, Assertions.F, z80.RegisterF, RegisterF, $"Register F should be 0x{RegisterF:X2} but was 0x{z80.RegisterF:X2}");
        AssertEqual(assertionsToRun, z80, Assertions.BC, z80.RegisterBC, RegisterBC, $"Register BC should be 0x{RegisterBC:X4} but was 0x{z80.RegisterBC:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.DE, z80.RegisterDE, RegisterDE, $"Register DE should be 0x{RegisterDE:X4} but was 0x{z80.RegisterDE:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.HL, z80.RegisterHL, RegisterHL, $"Register HL should be 0x{RegisterHL:X4} but was 0x{z80.RegisterHL:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.PC, z80.RegisterPC, RegisterPC, $"Register PC should be 0x{RegisterPC:X4} but was 0x{z80.RegisterPC:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.SP, z80.RegisterSP, RegisterSP, $"Register SP should be 0x{RegisterSP:X4} but was 0x{z80.RegisterSP:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.IX, z80.RegisterIX, RegisterIX, $"Register IX should be 0x{RegisterIX:X4} but was 0x{z80.RegisterIX:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.IY, z80.RegisterIY, RegisterIY, $"Register IY should be 0x{RegisterIY:X4} but was 0x{z80.RegisterIY:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.WZ, z80.RegisterWZ, RegisterWZ, $"Register WZ should be 0x{RegisterWZ:X4} but was 0x{z80.RegisterWZ:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.I, z80.RegisterI, RegisterI, $"Register I should be 0x{RegisterI:X2} but was 0x{z80.RegisterI:X2}");
        AssertEqual(assertionsToRun, z80, Assertions.R, z80.RegisterR, RegisterR, $"Register R should be 0x{RegisterR:X2} but was 0x{z80.RegisterR:X2}");
        AssertEqual(assertionsToRun, z80, Assertions.Q, z80.RegisterQ, RegisterQ, $"Register Q should be 0x{RegisterQ:X2} but was 0x{z80.RegisterQ:X2}");
        AssertEqual(assertionsToRun, z80, Assertions.ShadowAF, z80.ShadowRegisterAF, ShadowRegisterAF, $"Register AF' should be 0x{ShadowRegisterAF:X4} but was 0x{z80.ShadowRegisterAF:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.ShadowBC, z80.ShadowRegisterBC, ShadowRegisterBC, $"Register BC' should be 0x{ShadowRegisterBC:X4} but was 0x{z80.ShadowRegisterBC:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.ShadowDE, z80.ShadowRegisterDE, ShadowRegisterDE, $"Register DE' should be 0x{ShadowRegisterDE:X4} but was 0x{z80.ShadowRegisterDE:X4}");
        AssertEqual(assertionsToRun, z80, Assertions.ShadowHL, z80.ShadowRegisterHL, ShadowRegisterHL, $"Register HL' should be 0x{ShadowRegisterHL:X4} but was 0x{z80.ShadowRegisterHL:X4}");
    }

    private void AssertFlags(Assertions assertionsToRun, Z80TestHarness z80)
    {
        AssertEqual(assertionsToRun, z80, Assertions.C, z80.FlagC, FlagC, $"Flag C should should be {FormatFlag(FlagC)} but was {FormatFlag(z80.FlagC)}");
        AssertEqual(assertionsToRun, z80, Assertions.N, z80.FlagN, FlagN, $"Flag N should be {FormatFlag(FlagN)} but was {FormatFlag(z80.FlagN)}");
        AssertEqual(assertionsToRun, z80, Assertions.PV, z80.FlagPV, FlagPV, $"Flag PV should be {FormatFlag(FlagPV)} but was {FormatFlag(z80.FlagPV)}");
        AssertEqual(assertionsToRun, z80, Assertions.X, z80.FlagX, FlagX, $"Flag X should be {FormatFlag(FlagX)} but was {FormatFlag(z80.FlagX)}");
        AssertEqual(assertionsToRun, z80, Assertions.H, z80.FlagH, FlagH, $"Flag H should be {FormatFlag(FlagH)} but was {FormatFlag(z80.FlagH)}");
        AssertEqual(assertionsToRun, z80, Assertions.Y, z80.FlagY, FlagY, $"Flag Y should be {FormatFlag(FlagY)} but was {FormatFlag(z80.FlagY)}");
        AssertEqual(assertionsToRun, z80, Assertions.Z, z80.FlagZ, FlagZ, $"Flag Z should be {FormatFlag(FlagZ)} but was {FormatFlag(z80.FlagZ)}");
        AssertEqual(assertionsToRun, z80, Assertions.S, z80.FlagS, FlagS, $"Flag S should be {FormatFlag(FlagS)} but was {FormatFlag(z80.FlagS)}");
    }

    private void AssertInterrupts(Assertions assertionsToRun, Z80TestHarness z80)
    {
        AssertEqual(assertionsToRun, z80, Assertions.IM, z80.IM, IM, $"IM should should be {IM} but was {z80.IM}");
        AssertEqual(assertionsToRun, z80, Assertions.IFF1, z80.IFF1, IFF1, $"IFF1 should should be {FormatFlag(IFF1)} but was {FormatFlag(z80.IFF1)}");
        AssertEqual(assertionsToRun, z80, Assertions.IFF2, z80.IFF2, IFF2, $"IFF2 should should be {FormatFlag(IFF2)} but was {FormatFlag(z80.IFF2)}");
        AssertEqual(assertionsToRun, z80, Assertions.Halted, z80.Halted, Halted, $"Halted should should be {Halted} but was {z80.Halted}");
    }

    private void AssertMemory(Assertions assertionsToRun, Z80TestHarness z80)
    {
        if (!assertionsToRun.HasFlag(Assertions.Memory))
        {
            return;
        }

        foreach (var memory in Memory)
        {
            var address = memory.Address;
            var expected = memory.Value;
            var actual = z80.MemoryRead(address);
            z80.AssertEqual(actual, memory.Value, $"memory at 0x{address:X4} should be 0x{expected:X2} but was 0x{actual:X2}");
        }
    }

    private void AssertCycles(Assertions assertionsToRun, Z80TestHarness z80)
    {
        if (!assertionsToRun.HasFlag(Assertions.Cycles))
        {
            return;
        }

        var actualCycles = z80.Cycles.Where(ShouldAssertCycle).ToList();

        z80.AssertEqual(actualCycles.Count, Cycles.Count, $"Expected {Cycles.Count} cycles but was {actualCycles.Count}");

        for (var f = 0; f < Math.Min(actualCycles.Count, Cycles.Count); f++)
        {
            AssertCycle(z80, actualCycles[f], Cycles[f], f);
        }
    }

    private static void AssertCycle(Z80TestHarness z80, Cycle actual, Cycle expected, int index)
    {
        z80.AssertEqual(actual.Type, expected.Type, $"Expected cycle {index} to have type {expected.Type} but was {actual.Type}");
        z80.AssertEqual(actual.Address, expected.Address, $"Expected cycle {index} to have address {expected.Address} but was {actual.Address}");

        if (expected.Data.HasValue)
        {
            z80.AssertEqual(actual.Data, expected.Data, $"Expected cycle {index} to have data {expected.Data} but was {actual.Data}");
        }
    }

    protected virtual bool ShouldAssertCycle(Cycle cycle) => true;

    private void AssertIOWrites(Assertions assertionsToRun, Z80TestHarness z80)
    {
        if (!assertionsToRun.HasFlag(Assertions.IOWrites))
        {
            return;
        }

        if (z80.IOWriter is not InstructionIO ioWriter)
        {
            throw new InvalidOperationException($"Expected {nameof(z80)}.{nameof(z80.IOWriter)} to be an instance of {nameof(InstructionIO)} but was {z80.IOWriter.GetType().Name}.");
        }

        var actualEvents = ioWriter.IOWrites;

        z80.AssertEqual(actualEvents.Count, IOWrites.Count, $"Expected {IOWrites.Count} IO writes but was {actualEvents.Count}");

        for (var f = 0; f < Math.Min(actualEvents.Count, IOWrites.Count); f++)
        {
            AssertIOWrite(z80, actualEvents[f], IOWrites[f], f);
        }
    }

    private static void AssertIOWrite(Z80TestHarness z80, IOEvent actual, IOEvent expected, int index)
    {
        z80.AssertEqual(actual.Port, expected.Port, $"Expected IO write {index} to have port {expected.Port} but was {actual.Port}");
        z80.AssertEqual(actual.Value, expected.Value, $"Expected IO write {index} to have value {expected.Value} but was {actual.Value}");
    }

    private static char FormatFlag(bool flag) => flag ? '1' : '0';

    private static void AssertEqual<T>(Assertions assertionsToRun, Z80TestHarness z80, Assertions assertionsCategory, T actual, T expected, DefaultInterpolatedStringHandler message)
    {
        if (assertionsToRun.HasFlag(assertionsCategory))
        {
            z80.AssertEqual(actual, expected, message);
        }
    }
}