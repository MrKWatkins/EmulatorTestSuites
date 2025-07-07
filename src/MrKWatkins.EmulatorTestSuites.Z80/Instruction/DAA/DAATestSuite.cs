using System.Globalization;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA;

/// <summary>
/// The DAA test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/daa.html">Documentation</seealso>
/// <seealso href="https://github.com/ruyrybeyro/daatable">Original test suite</seealso>
public sealed class DAATestSuite : InstructionTestSuite<DAATestCase>
{
    /// <summary>
    /// Gets the singleton instance of the <see cref="DAATestSuite" />.
    /// </summary>
    public static readonly DAATestSuite Instance = new();

    private DAATestSuite()
        : base("DAA", new Uri("https://github.com/ruyrybeyro/daatable"))
    {
    }

    /// <summary>
    /// Gets the default options for the DAA test suite.
    /// </summary>
    public override InstructionTestSuiteOptions DefaultOptions { get; } = new();

    /// <summary>
    /// Gets all the test cases using the specified <see cref="InstructionTestSuiteOptions" />.
    /// </summary>
    /// <paramref name="options">The <see cref="InstructionTestSuiteOptions" /> to use.</paramref>
    /// <returns>A sequence of test cases.</returns>
    public override IEnumerable<DAATestCase> GetTestCases(InstructionTestSuiteOptions options)
    {
        using var stream = OpenResource("daaoutput.txt");
        using var reader = new StreamReader(stream);

        return ParseInput(options, reader).ToList();
    }

    [Pure]
    private static IEnumerable<DAATestCase> ParseInput(InstructionTestSuiteOptions options, TextReader reader)
    {
        var cycles = new[]
        {
            new Cycle(CycleType.MemoryRead, 0, 0x0000, null, true),
            new Cycle(CycleType.None, 1, 0x0000, 0x27),
            new Cycle(CycleType.None, 2, 0x0000, 0x27),
            new Cycle(CycleType.None, 3, 0x0000, 0x27)
        };

        var memory = new[]
        {
            new MemoryState(0x0000, 0x27)
        };

        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line) || line[0] != 'N')
            {
                continue;
            }

            var input = new Z80InputState
            {
                FlagN = CharToBool(line[2]),
                FlagC = CharToBool(line[6]),
                FlagH = CharToBool(line[10]),
                RegisterA = byte.Parse(line.AsSpan(12, 2), NumberStyles.HexNumber),
                Memory = memory
            };

            var output = new Z80ExpectedState
            {
                FlagN = CharToBool(line[17]),
                FlagC = CharToBool(line[21]),
                FlagH = CharToBool(line[25]),
                RegisterA = byte.Parse(line.AsSpan(27, 2), NumberStyles.HexNumber),
                RegisterR = 0x01,
                RegisterPC = 0x0001,
                Cycles = cycles,
                TStates = 4
            };

            // Set the other flags not defined by the tests.
            output.FlagZ = output.RegisterA == 0;
            output.FlagPV = (~System.Numerics.BitOperations.PopCount(output.RegisterA) & 0x01) == 0x01;

            // Copy X, Y and S from A.
            output.RegisterF |= (byte)(output.RegisterA & 0b10101000);

            // We've updated the flags so Q will match F.
            output.RegisterQ = output.RegisterF;

            yield return new DAATestCase(line, options, input, output);
        }
    }

    [Pure]
    private static bool CharToBool(char c) => c switch
    {
        '1' => true,
        '0' => false,
        _ => throw new NotSupportedException($"Unexpected character {c}.")
    };
}