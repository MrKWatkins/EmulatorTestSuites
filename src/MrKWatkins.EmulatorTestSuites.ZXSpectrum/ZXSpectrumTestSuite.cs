namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum;

/// <summary>
/// Base class for test suites that provide <see cref="ZXSpectrumTestCase" />s for ZX Spectrum emulator implementations.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/zxspectrum.html">Documentation</seealso>
public abstract class ZXSpectrumTestSuite : TestSuite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ZXSpectrumTestSuite"/> class.
    /// </summary>
    /// <param name="name">The name of the test suite.</param>
    /// <param name="source">The URI indicating the source of the test suite.</param>
    protected ZXSpectrumTestSuite(string name, Uri source)
        : base(name, source)
    {
    }
}