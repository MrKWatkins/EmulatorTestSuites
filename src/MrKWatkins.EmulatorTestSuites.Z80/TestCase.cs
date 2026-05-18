namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for test cases that validate Z80 emulator implementations.
/// </summary>
public abstract class TestCase : TestCase<Z80TestHarness>
{
    protected TestCase(string id)
        : base(id)
    {
    }
}