namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Base class for test cases that validate Z80 emulator implementations.
/// </summary>
public abstract class TestCase
{
    private protected TestCase(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the unique identifier for this test case.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the display name of the test case. By default, returns the <see cref="Id"/>.
    /// </summary>
    public virtual string Name => Id;

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80TestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of <see cref="Z80TestHarness" /> to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public abstract void Execute<TTestHarness>(TextWriter? testOutput = null)
        where TTestHarness : Z80TestHarness, new();

    /// <summary>
    /// Returns a string representation of this <see cref="TestCase" />.
    /// </summary>
    /// <returns>The <see cref="Name" /> of this <see cref="TestCase" />.</returns>
    public sealed override string ToString() => Name;
}