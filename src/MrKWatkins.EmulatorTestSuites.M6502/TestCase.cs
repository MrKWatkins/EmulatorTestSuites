namespace MrKWatkins.EmulatorTestSuites.M6502;

/// <summary>
/// Base class for test cases that validate M6502 emulator implementations.
/// </summary>
public abstract class TestCase : TestCase<M6502TestHarness>
{
    protected TestCase(string id)
        : base(id)
    {
    }
}