namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <inheritdoc cref="IZ80SteppableTestHarness"/>
/// <remarks>
/// Compatibility base class for <see cref="IZ80SteppableTestHarness"/> implementations that provides reusable stepping helpers for the test suites.
/// </remarks>
public abstract class Z80SteppableTestHarness : Z80TestHarness, IZ80SteppableTestHarness
{
    /// <inheritdoc />
    public void Step(ulong count)
    {
        while (count > 0)
        {
            Step();
            count--;
        }
    }

    /// <inheritdoc />
    public abstract void Step();
}
