namespace MrKWatkins.EmulatorTestSuites.M6502;

/// <summary>
/// Base class for an M6502 emulator test harness that supports cycle stepping. Implement this class to use it with step-driven program suites.
/// </summary>
public abstract class M6502SteppableTestHarness : M6502TestHarness
{
    /// <summary>
    /// Executes a single CPU step.
    /// </summary>
    /// <returns><c>true</c> if the step was an opcode fetch, <c>false</c> otherwise.</returns>
    public abstract bool Step();
}