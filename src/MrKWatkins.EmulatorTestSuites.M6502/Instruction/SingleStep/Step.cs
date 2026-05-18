using System.IO.Compression;

namespace MrKWatkins.EmulatorTestSuites.M6502.Instruction.SingleStep;

/// <summary>
/// Represents a single step in a <see cref="SingleStepTestCase"/> containing input state and expected output state.
/// </summary>
public sealed class Step
{
    private Step(int index, M6502InputState input, M6502ExpectedState expected)
    {
        Index = index;
        Input = input;
        Expected = expected;
    }

    /// <summary>
    /// Gets the zero-based index of this step within the test case.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Gets the input state of the M6502 for this step.
    /// </summary>
    public M6502InputState Input { get; }

    /// <summary>
    /// Gets the expected state of the M6502 after executing this step.
    /// </summary>
    public M6502ExpectedState Expected { get; }

    [Pure]
    internal static IEnumerable<Step> Load(SingleStepTestCase testCase)
    {
        using var stream = typeof(Step).Assembly.GetManifestResourceStream(SingleStepTestSuite.ResourcePrefix + testCase.Id) ??
                           throw new InvalidOperationException($"Resource {testCase.Id} not found.");
        using var brotli = new BrotliStream(stream, CompressionMode.Decompress);
        using var reader = new BinaryReader(brotli);

        var count = reader.Read7BitEncodedInt();

        for (var f = 0; f < count; f++)
        {
            yield return LoadStep(f, reader);
        }
    }

    [MustUseReturnValue]
    private static Step LoadStep(int index, BinaryReader reader)
    {
        var input = LoadState<M6502InputState>(reader);
        var expected = LoadState<M6502ExpectedState>(reader);
        expected.Cycles = LoadCycles(reader).ToArray();
        expected.TStates = (ulong)expected.Cycles.Count;
        return new Step(index, input, expected);
    }

    [MustUseReturnValue]
    private static TState LoadState<TState>(BinaryReader reader)
        where TState : M6502State, new()
    {
        var state = new TState
        {
            RegisterA = reader.ReadByte(),
            RegisterX = reader.ReadByte(),
            RegisterY = reader.ReadByte(),
            RegisterS = reader.ReadByte(),
            RegisterP = reader.ReadByte(),
            RegisterPC = reader.ReadUInt16(),
            Memory = LoadMemory(reader)
        };

        return state;
    }

    [MustUseReturnValue]
    private static IReadOnlyList<MemoryState> LoadMemory(BinaryReader reader)
    {
        var memorySize = reader.Read7BitEncodedInt();
        var memory = new MemoryState[memorySize];
        for (var f = 0; f < memorySize; f++)
        {
            memory[f] = new MemoryState(reader.ReadUInt16(), reader.ReadByte());
        }

        return memory;
    }

    [MustUseReturnValue]
    private static IEnumerable<Cycle> LoadCycles(BinaryReader reader)
    {
        var cyclesSize = (ulong)reader.Read7BitEncodedInt();
        for (ulong f = 0; f < cyclesSize; f++)
        {
            var address = reader.ReadUInt16();
            var data = reader.ReadByte();
            var type = reader.ReadBoolean() ? CycleType.Write : CycleType.Read;
            yield return new Cycle(type, f, address, data);
        }
    }
}