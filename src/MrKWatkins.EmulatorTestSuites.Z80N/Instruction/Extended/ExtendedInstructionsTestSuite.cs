using MrKWatkins.EmulatorTestSuites.Z80.Instruction;
using MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

namespace MrKWatkins.EmulatorTestSuites.Z80N.Instruction.Extended;

/// <summary>
/// Tests for the instructions the Z80N adds to the Z80, hand written from the ZX Spectrum Next FPGA core. The Z80N has no
/// silicon implementation, so the core is the definitive reference for the behaviour and the timing of its instructions.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/Z80N/ExtendedInstructions.html">Documentation</seealso>
/// <seealso href="https://gitlab.com/SpectrumNext/ZX_Spectrum_Next_FPGA">The core the tests were written from</seealso>
public sealed class ExtendedInstructionsTestSuite : InstructionTestSuite<ExtendedInstructionsTestCase>
{
    /// <summary>
    /// The default <see cref="TestAssertions"/> for the <see cref="ExtendedInstructionsTestSuite" />. Q is not asserted, as the
    /// tests do not say what it should be.
    /// </summary>
    public const TestAssertions DefaultAssertions = TestAssertions.All & ~TestAssertions.Q;

    /// <summary>
    /// Gets the singleton instance of the <see cref="ExtendedInstructionsTestSuite" />.
    /// </summary>
    public static readonly ExtendedInstructionsTestSuite Instance = new();

    private ExtendedInstructionsTestSuite()
        : base("Extended Instructions", new Uri("https://gitlab.com/SpectrumNext/ZX_Spectrum_Next_FPGA"))
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
    public override IEnumerable<ExtendedInstructionsTestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        var inputs = FuseFormat.ParseInput(OpenResource("tests.in"));
        var expected = FuseFormat.ParseExpected(OpenResource("tests.expected"));

        foreach (var (name, input) in inputs)
        {
            yield return new ExtendedInstructionsTestCase(name, options, input, expected[name]);
        }
    }
}