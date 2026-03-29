namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Timing;

/// <summary>
/// Adds the frame-start hook exposed by timing-aware harnesses.
/// </summary>
public interface IFrameAwareTestHarness
{
    /// <summary>
    /// Synchronises the harness to the start of a new frame.
    /// </summary>
    void StartFrame();
}
