namespace MrKWatkins.EmulatorTestSuites.M6502;

/// <summary>
/// Base class for test suites that provide <see cref="TestCase" />s for M6502 emulator implementations.
/// </summary>
public abstract class TestSuite(string name, Uri source) : global::MrKWatkins.EmulatorTestSuites.TestSuite(name, source);