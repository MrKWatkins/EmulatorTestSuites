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
    public void StepUntil(ulong tStates)
    {
        while (TStates <= tStates)
        {
            Step();
        }
    }

    /// <summary>
    /// Executes the specified number of CPU steps.
    /// </summary>
    /// <param name="count">The number of steps to execute.</param>
    public void Step(ulong count)
    {
        while (count > 0)
        {
            Step();
            count--;
        }
    }

    /// <summary>
    /// Executes a single step of the CPU.
    /// </summary>
    public abstract void Step();
}