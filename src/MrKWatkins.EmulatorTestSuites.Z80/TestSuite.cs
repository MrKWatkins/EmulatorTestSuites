namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for test suites that provide <see cref="TestCase" />s for Z80 emulator implementations.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/z80.html">Documentation</seealso>
public abstract class TestSuite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestSuite"/> class.
    /// </summary>
    /// <param name="name">The name of the test suite.</param>
    /// <param name="source">The URI indicating the source of the test suite.</param>
    private protected TestSuite(string name, Uri source)
    {
        Name = name;
        Source = source;
    }

    /// <summary>
    /// Gets the name of the test suite.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the URL indicating the source of the original test suite.
    /// </summary>
    public Uri Source { get; }

    [MustDisposeResource]
    private protected Stream OpenResource(string resource) => GetType().Assembly.GetManifestResourceStream(GetType(), resource) ?? throw new InvalidOperationException($"Resource {resource} not found.");
}