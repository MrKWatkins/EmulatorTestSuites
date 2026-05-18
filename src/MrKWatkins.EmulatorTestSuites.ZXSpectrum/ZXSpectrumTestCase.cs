namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum;

/// <summary>
/// Base class for test cases that validate ZX Spectrum emulator implementations.
/// </summary>
public abstract class ZXSpectrumTestCase : TestCase<ZXSpectrumTestHarness>
{
    protected ZXSpectrumTestCase(string id)
        : base(id)
    {
    }
}