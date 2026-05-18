namespace MrKWatkins.EmulatorTestSuites;

/// <summary>
/// Base class for emulator test suites.
/// </summary>
public abstract class TestSuite
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestSuite"/> class.
    /// </summary>
    /// <param name="name">The name of the test suite.</param>
    /// <param name="source">The URI indicating the source of the test suite.</param>
    protected TestSuite(string name, Uri source)
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
    protected Stream OpenResource(string resource) => OpenResource(GetType(), resource);

    [MustDisposeResource]
    private static Stream OpenResource(Type type, string resource) =>
        type.Assembly.GetManifestResourceStream(type, resource) ?? throw new InvalidOperationException($"Resource {resource} not found for {type.FullName}.");
}