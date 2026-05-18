using MrKWatkins.EmulatorTestSuites.Instruction;

namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction;

/// <summary>
/// A test case from an <see cref="InstructionTestSuite{TTestCase}" />.
/// </summary>
public abstract class InstructionTestCase(string id) : InstructionTestCase<M6502TestHarness, Cycle>(id)
{
    [Pure]
    private protected TTestHarness CreateM6502<TTestHarness>()
        where TTestHarness : M6502TestHarness, new() => CreateTestHarness<TTestHarness>();
}