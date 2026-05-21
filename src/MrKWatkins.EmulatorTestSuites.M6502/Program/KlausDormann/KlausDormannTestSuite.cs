namespace MrKWatkins.EmulatorTestSuites.M6502.Program.KlausDormann;

/// <summary>
/// The Klaus Dormann 6502 functional test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/m6502.html">Documentation</seealso>
/// <seealso href="https://github.com/Klaus2m5/6502_65C02_functional_tests">Original test suite</seealso>
public sealed class KlausDormannTestSuite : ProgramTestSuite<KlausDormannTestCase>
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="KlausDormannTestSuite" />.
    /// </summary>
    public static readonly KlausDormannTestSuite Instance = new();

    private KlausDormannTestSuite()
        : base("Klaus Dormann Functional", new Uri("https://github.com/Klaus2m5/6502_65C02_functional_tests"))
    {
    }

    [Pure]
    private protected override IEnumerable<KlausDormannTestCase> EnumerateTestCases()
    {
        var memory = new byte[65536];
        using var stream = OpenResource("6502_functional_test.bin");
        stream.ReadExactly(memory);

        yield return new KlausDormannTestCase(memory);
    }
}