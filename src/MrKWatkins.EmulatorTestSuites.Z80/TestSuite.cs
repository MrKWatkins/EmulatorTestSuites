namespace MrKWatkins.EmulatorTestSuites.Z80;

public abstract class TestSuite
{
    private protected TestSuite(string name, Uri source)
    {
        Name = name;
        Source = source;
    }

    public string Name { get; }

    public Uri Source { get; }

    [MustDisposeResource]
    protected Stream OpenResource(string resource) => GetType().Assembly.GetManifestResourceStream(GetType(), resource) ?? throw new InvalidOperationException($"Resource {resource} not found.");
}