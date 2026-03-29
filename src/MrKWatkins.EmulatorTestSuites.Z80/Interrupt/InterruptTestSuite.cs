namespace MrKWatkins.EmulatorTestSuites.Z80.Interrupt;

/// <summary>
/// Standalone interrupt and HALT behaviour tests that require a steppable emulator.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/interrupt.html">Documentation</seealso>
/// <seealso href="https://github.com/floooh/chips-test/blob/master/tests/z80-int.c">Original tests</seealso>
public sealed class InterruptTestSuite : TestSuite
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="InterruptTestSuite" />.
    /// </summary>
    public static readonly InterruptTestSuite Instance = new();

    private InterruptTestSuite()
        : base("Interrupt", new Uri("https://github.com/floooh/chips-test/blob/master/tests/z80-int.c"))
    {
        TestCases =
        [
            InterruptTestCase.CreateMode0(),
            InterruptTestCase.CreateMode1(),
            InterruptTestCase.CreateMode2(),
            InterruptTestCase.CreateInterruptsDoNotTriggerIfDisabled(),
            InterruptTestCase.CreateInterruptsDoNotTriggerDuringEI(),
            InterruptTestCase.CreateHaltStaysOnTheNextOpcode(),
            InterruptTestCase.CreateInterruptResetsHalted(),
            InterruptTestCase.CreateInterruptFullyExecutesOverlappedInstruction(0),
            InterruptTestCase.CreateInterruptFullyExecutesOverlappedInstruction(1),
            InterruptTestCase.CreateInterruptFullyExecutesOverlappedInstruction(2)
        ];
    }

    /// <summary>
    /// Gets the interrupt test cases.
    /// </summary>
    public IReadOnlyList<InterruptTestCase> TestCases { get; }
}