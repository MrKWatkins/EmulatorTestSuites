namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for test suites that provide <see cref="TestCase" />s for Z80 emulator implementations.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/z80.html">Documentation</seealso>
public abstract class TestSuite : global::MrKWatkins.EmulatorTestSuites.TestSuite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestSuite"/> class.
    /// </summary>
    /// <param name="name">The name of the test suite.</param>
    /// <param name="source">The URI indicating the source of the test suite.</param>
    protected TestSuite(string name, Uri source)
        : base(name, source)
    {
    }
}