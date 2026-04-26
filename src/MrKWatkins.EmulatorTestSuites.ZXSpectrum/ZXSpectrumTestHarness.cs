using MrKWatkins.EmulatorTestSuites.Z80;

namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum;

/// <summary>
/// Base class for a ZX Spectrum emulator test harness. Implement this class to use it with the test suites.
/// </summary>
public abstract class ZXSpectrumTestHarness
{
    /// <summary>
    /// Gets the Z80 CPU test harness used by the Spectrum emulator.
    /// </summary>
    public abstract Z80TestHarness Z80 { get; }

    /// <summary>
    /// Gets the steppable Z80 CPU test harness, or <c>null</c> if the emulator only supports instruction-level execution.
    /// </summary>
    public virtual Z80SteppableTestHarness? SteppableZ80 => Z80 as Z80SteppableTestHarness;

    /// <summary>
    /// Synchronises the harness to the start of a new frame.
    /// </summary>
    public abstract void StartFrame();
}