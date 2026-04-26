namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum;

/// <summary>
/// Base class for test suites that provide <see cref="ZXSpectrumTestCase" />s for ZX Spectrum emulator implementations.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/zxspectrum.html">Documentation</seealso>
public abstract class ZXSpectrumTestSuite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ZXSpectrumTestSuite"/> class.
    /// </summary>
    /// <param name="name">The name of the test suite.</param>
    /// <param name="source">The URI indicating the source of the test suite.</param>
    private protected ZXSpectrumTestSuite(string name, Uri source)
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
    private protected Stream OpenResource(string resource) => OpenResource(GetType(), resource);

    [MustDisposeResource]
    private protected static Stream OpenResource(Type type, string resource) =>
        type.Assembly.GetManifestResourceStream(type, resource) ?? throw new InvalidOperationException($"Resource {resource} not found for {type.FullName}.");
}