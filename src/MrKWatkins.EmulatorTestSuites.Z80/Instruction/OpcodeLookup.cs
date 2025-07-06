using System.Collections.Frozen;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

internal static class OpcodeLookup
{
    private static readonly Lazy<FrozenDictionary<string, string>> LazyLookup = new(BuildLookup);

    [Pure]
    internal static string? GetOrNull(string key) => LazyLookup.Value.GetValueOrDefault(key);

    [Pure]
    private static FrozenDictionary<string, string> BuildLookup()
    {
        using var opcodes = typeof(OpcodeLookup).Assembly.GetManifestResourceStream(typeof(OpcodeLookup), "opcodes.txt") ??
                            throw new InvalidOperationException("Could not load resource Opcodes.txt");

        var lookup = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        using var reader = new StreamReader(opcodes);
        while (true)
        {
            var line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var parts = line.Split('|');
            lookup.Add(parts[0], parts[1]);
        }
        return lookup.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }
}