namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Contract for a Z80 emulator test harness that supports single cycle stepping.
/// </summary>
public interface IZ80SteppableTestHarness : IZ80TestHarness
{
    /// <summary>
    /// Executes a single step of the CPU.
    /// </summary>
    void Step();

    /// <summary>
    /// Executes the specified number of CPU steps.
    /// </summary>
    /// <param name="count">The number of steps to execute.</param>
    void Step(ulong count);
}
