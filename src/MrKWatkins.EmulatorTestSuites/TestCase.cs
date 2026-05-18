namespace MrKWatkins.EmulatorTestSuites;

/// <summary>
/// Base class for emulator test cases.
/// </summary>
/// <typeparam name="THarness">The type of harness used to execute the test case.</typeparam>
public abstract class TestCase<THarness>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestCase{THarness}" /> class.
    /// </summary>
    /// <param name="id">The unique identifier for this test case.</param>
    protected TestCase(string id)
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
    /// Executes this test case using the specified harness type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of harness to use for execution.</typeparam>
    /// <param name="testOutput">Optional <see cref="TextWriter" /> for test output. If <c>null</c>, no output will be written.</param>
    public abstract void Execute<TTestHarness>(TextWriter? testOutput = null)
        where TTestHarness : THarness, new();

    /// <summary>
    /// Returns a string representation of this <see cref="TestCase{THarness}" />.
    /// </summary>
    /// <returns>The <see cref="Name" /> of this <see cref="TestCase{THarness}" />.</returns>
    public sealed override string ToString() => Name;
}