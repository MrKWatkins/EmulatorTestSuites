namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

/// <summary>
/// Parses the text format of the Fuse test suite. Used by the <see cref="FuseTestSuite" /> and by suites in other packages that
/// hand write their test cases, as the format is easy to read and write.
/// </summary>
internal static class FuseFormat
{
    /// <summary>
    /// Parses the input states, keyed by test case ID, from a tests.in file.
    /// </summary>
    [Pure]
    public static IReadOnlyDictionary<string, FuseZ80InputState> ParseInput(Stream stream)
    {
        using var reader = new StreamReader(stream);

        var inputs = new Dictionary<string, FuseZ80InputState>();
        while (reader.ReadLine() is { } name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            var input = new FuseZ80InputState();
            inputs.Add(name, input);
            Parse(input, reader.ReadLine()!, reader);
        }
        return inputs;
    }

    /// <summary>
    /// Parses the expected states, keyed by test case ID, from a tests.expected file.
    /// </summary>
    [Pure]
    public static IReadOnlyDictionary<string, FuseZ80ExpectedState> ParseExpected(Stream stream)
    {
        using var reader = new StreamReader(stream);

        var expecteds = new Dictionary<string, FuseZ80ExpectedState>();
        while (reader.ReadLine() is { } name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                continue;
            }

            var events = new List<FuseEvent>();
            string line;
            while (true)
            {
                line = reader.ReadLine()!;
                if (!char.IsWhiteSpace(line[0]))
                {
                    break;
                }

                events.Add(FuseEvent.Parse(line));
            }

            var expected = new FuseZ80ExpectedState(events);
            expecteds.Add(name, expected);
            Parse(expected, line, reader);
        }
        return expecteds;
    }

    private static void Parse(Z80State state, string firstLine, StreamReader reader)
    {
        ParseRegisters(state, firstLine);
        ParseInterrupts(state, reader.ReadLine()!);

        var memory = new List<MemoryState>();
        while (reader.ReadLine() is { } line)
        {
            if (string.IsNullOrWhiteSpace(line) || line == "-1")
            {
                break;
            }

            memory.AddRange(ParseMemory(line));
        }

        state.Memory = memory;
    }

    private static void ParseRegisters(Z80State state, string line)
    {
        var registers = line.Split(' ');
        state.RegisterAF = registers[0].ToWord();
        state.RegisterBC = registers[1].ToWord();
        state.RegisterDE = registers[2].ToWord();
        state.RegisterHL = registers[3].ToWord();
        state.ShadowRegisterAF = registers[4].ToWord();
        state.ShadowRegisterBC = registers[5].ToWord();
        state.ShadowRegisterDE = registers[6].ToWord();
        state.ShadowRegisterHL = registers[7].ToWord();
        state.RegisterIX = registers[8].ToWord();
        state.RegisterIY = registers[9].ToWord();
        state.RegisterSP = registers[10].ToWord();
        state.RegisterPC = registers[11].ToWord();
        state.RegisterWZ = registers[12].ToWord();
    }

    private static void ParseInterrupts(Z80State state, string line)
    {
        var interrupts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        state.RegisterI = interrupts[0].ToByte();
        state.RegisterR = interrupts[1].ToByte();
        state.IFF1 = interrupts[2].ToBool();
        state.IFF2 = interrupts[3].ToBool();
        state.IM = interrupts[4].ToByte();
        state.Halted = interrupts[5].ToBool();
        var tStates = ulong.Parse(interrupts[6]);

        if (state is Z80ExpectedState expected)
        {
            expected.TStates = tStates;
        }
        else
        {
            ((FuseZ80InputState)state).MinimumTStatesToRun = tStates;
        }
    }

    [Pure]
    private static IEnumerable<MemoryState> ParseMemory(string line)
    {
        var data = line.Split(' ');
        var address = data[0].ToWord();
        foreach (var @byte in data[1..^1].Select(d => d.ToByte()))
        {
            yield return new MemoryState(address, @byte);
            address++;
        }
    }
}