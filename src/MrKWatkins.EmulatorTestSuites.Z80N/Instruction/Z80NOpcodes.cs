using System.Collections.Frozen;

namespace MrKWatkins.EmulatorTestSuites.Z80N.Instruction;

/// <summary>
/// The names of the instructions the Z80N adds to the Z80, keyed by their opcode. The Z80 package's opcode names describe a Z80,
/// where all of these are unused opcodes that do nothing.
/// </summary>
internal static class Z80NOpcodes
{
    private static readonly IReadOnlyDictionary<string, string> Names = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        ["ED23"] = "SWAPNIB",
        ["ED24"] = "MIRROR A",
        ["ED27"] = "TEST n",
        ["ED28"] = "BSLA DE, B",
        ["ED29"] = "BSRA DE, B",
        ["ED2A"] = "BSRL DE, B",
        ["ED2B"] = "BSRF DE, B",
        ["ED2C"] = "BRLC DE, B",
        ["ED30"] = "MUL D, E",
        ["ED31"] = "ADD HL, A",
        ["ED32"] = "ADD DE, A",
        ["ED33"] = "ADD BC, A",
        ["ED34"] = "ADD HL, nn",
        ["ED35"] = "ADD DE, nn",
        ["ED36"] = "ADD BC, nn",
        ["ED8A"] = "PUSH nn",
        ["ED90"] = "OUTINB",
        ["ED91"] = "NEXTREG n, n",
        ["ED92"] = "NEXTREG n, A",
        ["ED93"] = "PIXELDN",
        ["ED94"] = "PIXELAD",
        ["ED95"] = "SETAE",
        ["ED98"] = "JP (C)",
        ["EDA4"] = "LDIX",
        ["EDA5"] = "LDWS",
        ["EDAC"] = "LDDX",
        ["EDB4"] = "LDIRX",
        ["EDB7"] = "LDPIRX",
        ["EDBC"] = "LDDRX"
    }.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);

    [Pure]
    public static string? GetOrNull(string opcode) => Names.GetValueOrDefault(opcode);
}