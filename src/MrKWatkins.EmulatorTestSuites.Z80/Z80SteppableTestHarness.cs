namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for a Z80 emulator test harness that supports single cycle stepping. Implement this class to use it with the test suites.
/// </summary>
public abstract class Z80SteppableTestHarness : Z80TestHarness
{
    /// <summary>
    /// Executes CPU steps until the specified number of T-states are reached.
    /// </summary>
    /// <param name="tStates">The target T-states to reach.</param>
    public void Step(ulong tStates)
    {
        while (TStates <= tStates)
        {
            Step();
        }
    }

    /// <summary>
    /// Executes a single step of the CPU.
    /// </summary>
    public abstract void Step();
}