using MrKWatkins.EmulatorTestSuites.Z80.Instruction;
using MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

namespace MrKWatkins.EmulatorTestSuites.Z80N.Instruction.Core;

/// <summary>
/// Tests for the instructions the Z80N adds to the Z80, hand written from the ZX Spectrum Next FPGA core. There is no Z80N
/// silicon, so the core is the definitive reference for the behaviour and the timing of its instructions.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/z80n.html#core">Documentation</seealso>
/// <seealso href="https://gitlab.com/SpectrumNext/ZX_Spectrum_Next_FPGA">The core the tests were written from</seealso>
public sealed class CoreTestSuite : InstructionTestSuite<CoreTestCase>
{
    /// <summary>
    /// The default <see cref="TestAssertions"/> for the <see cref="CoreTestSuite" />. Q is not asserted, as the tests do not say
    /// what it should be.
    /// </summary>
    public const TestAssertions DefaultAssertions = TestAssertions.All & ~TestAssertions.Q;

    /// <summary>
    /// Gets the singleton instance of the <see cref="CoreTestSuite" />.
    /// </summary>
    public static readonly CoreTestSuite Instance = new();

    private CoreTestSuite()
        : base("ZX Spectrum Next Core", new Uri("https://gitlab.com/SpectrumNext/ZX_Spectrum_Next_FPGA"))
    {
    }

    /// <summary>
    /// The default <see cref="InstructionTestSuiteOptions" /> for the test suite.
    /// </summary>
    public override InstructionTestSuiteOptions DefaultOptions { get; } = new() { AssertionsToRun = DefaultAssertions };

    /// <summary>
    /// Gets all the test cases using the specified <see cref="InstructionTestSuiteOptions" />.
    /// </summary>
    /// <paramref name="options">The <see cref="InstructionTestSuiteOptions" /> to use.</paramref>
    /// <returns>A sequence of test cases.</returns>
    public override IEnumerable<CoreTestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        var inputs = FuseFormat.ParseInput(OpenResource("tests.in"));
        var expected = FuseFormat.ParseExpected(OpenResource("tests.expected"));

        foreach (var (name, input) in inputs)
        {
            yield return new CoreTestCase(name, options, input, expected[name]);
        }
    }
}