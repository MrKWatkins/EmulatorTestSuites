using System.IO.Compression;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep;

public sealed class Step
{
    private Step(int index, Z80InputState input, Z80ExpectedState expected)
    {
        Index = index;
        Input = input;
        Expected = expected;
    }

    public int Index { get; }

    public Z80InputState Input { get; }

    public Z80ExpectedState Expected { get; }

    [Pure]
    internal static IEnumerable<Step> Load(SingleStepTestCase testCase)
    {
        using var stream = typeof(Step).Assembly.GetManifestResourceStream(SingleStepTestSuite.ResourcePrefix + testCase.Id) ?? throw new InvalidOperationException($"Resource {testCase.Id} not found.");
        using var brotli = new BrotliStream(stream, CompressionMode.Decompress);
        using var reader = new BinaryReader(brotli);

        var count = reader.Read7BitEncodedInt();

        for (var f = 0; f < count; f++)
        {
            yield return LoadStep(testCase, f, reader);
        }
    }

    [MustUseReturnValue]
    private static Step LoadStep(SingleStepTestCase testCase, int index, BinaryReader reader)
    {
        var input = LoadZ80State<Z80InputState>(reader);

        var expected = LoadZ80State<Z80ExpectedState>(reader);
        expected.Cycles = CycleAdjustor.AdjustTo(testCase.MemoryCycleMethod, LoadCycles(reader)).ToArray();
        expected.TStates = (ulong)expected.Cycles.Count;

        var (ioReads, ioWrites) = LoadPorts(reader);

        input.IOReads = ioReads;
        expected.IOWrites = ioWrites;

        return new Step(index, input, expected);
    }

    [MustUseReturnValue]
    private static TZ80State LoadZ80State<TZ80State>(BinaryReader reader)
        where TZ80State : Z80State, new()
    {
        var state = new TZ80State
        {
            RegisterAF = reader.ReadUInt16(),
            RegisterBC = reader.ReadUInt16(),
            RegisterDE = reader.ReadUInt16(),
            RegisterHL = reader.ReadUInt16(),
            RegisterIX = reader.ReadUInt16(),
            RegisterIY = reader.ReadUInt16(),
            RegisterSP = reader.ReadUInt16(),
            RegisterPC = reader.ReadUInt16(),
            RegisterWZ = reader.ReadUInt16(),
            RegisterI = reader.ReadByte(),
            RegisterR = reader.ReadByte(),
            RegisterQ = reader.ReadByte(),
            ShadowRegisterAF = reader.ReadUInt16(),
            ShadowRegisterBC = reader.ReadUInt16(),
            ShadowRegisterDE = reader.ReadUInt16(),
            ShadowRegisterHL = reader.ReadUInt16()
        };

        var interrupts = reader.ReadByte();
        state.IFF1 = (interrupts & 0b00000001) == 0b00000001;
        state.IFF2 = (interrupts & 0b00000010) == 0b00000010;
        state.IM = (byte)((interrupts & 0b00001100) >> 2);

        state.Memory = LoadMemory(reader);

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
            var hasDataAndPins = reader.ReadByte();

            var hasData = (hasDataAndPins & 0b10000000) != 0;
            var pins = (Pins)(hasDataAndPins & 0b01111111);

            yield return new Cycle(ToCycleType(pins), f, address, hasData ? data : null);
        }
    }

    [Pure]
    private static CycleType ToCycleType(Pins pins) => pins switch
    {
        Pins.None => CycleType.None,
        Pins.MemoryRead => CycleType.MemoryRead,
        Pins.MemoryWrite => CycleType.MemoryWrite,
        Pins.IORead => CycleType.IORead,
        Pins.IOWrite => CycleType.IOWrite,
        _ => throw new NotSupportedException($"The {nameof(Pins)} combination {pins} is not supported.")
    };

    [MustUseReturnValue]
    private static (IReadOnlyList<IOEvent> Reads, IReadOnlyList<IOEvent> Writes) LoadPorts(BinaryReader reader)
    {
        var reads = new List<IOEvent>();
        var writes = new List<IOEvent>();
        var portsSize = reader.Read7BitEncodedInt();
        for (var f = 0; f < portsSize; f++)
        {
            var ioEvent = new IOEvent(reader.ReadUInt16(), reader.ReadByte());
            if (reader.ReadBoolean())
            {
                writes.Add(ioEvent);
            }
            else
            {
                reads.Add(ioEvent);
            }
        }

        return (reads, writes);
    }
}