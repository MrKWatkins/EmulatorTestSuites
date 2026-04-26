namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum.Timing;

/// <summary>
/// Tests 35-37 required floating bus emulation to pass. The floating bus values depend on what is displayed on the screen.
/// Rather than call the BASIC functions to prepare the screen, we instead load a snapshot for simplicity.
/// </summary>
internal static class Screens
{
    private const string ScreenResourceFolder = "Screens.";

    [Pure]
    public static byte[] Get(byte testNumber, bool contended) =>
        (testNumber, contended) switch
        {
            (35, false) => Load("35-uncontended.scr"),
            (35, true) => Load("35-contended.scr"),
            (36, true) => Load("36-contended.scr"),
            (37, true) => Load("37-contended.scr"),
            _ => throw new InvalidOperationException($"No screen is stored for timing test {testNumber} (contended={contended}).")
        };

    [Pure]
    private static byte[] Load(string fileName)
    {
        using var stream = typeof(Screens).Assembly.GetManifestResourceStream(typeof(Screens), ScreenResourceFolder + fileName)
                           ?? throw new InvalidOperationException($"Could not load prepared timing screen resource {fileName}.");
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        var screen = memory.ToArray();

        return screen;
    }
}