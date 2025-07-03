using System.Globalization;

namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse;

internal static class StringExtensions
{
    [Pure]
    internal static bool ToBool(this string value) => value == "1";

    [Pure]
    internal static byte ToByte(this string value) => byte.Parse(value, NumberStyles.AllowHexSpecifier);

    [Pure]
    internal static ushort ToWord(this string value) => ushort.Parse(value, NumberStyles.AllowHexSpecifier);

    [Pure]
    internal static FuseEventType ToEventType(this string value) => value switch
    {
        "MR" => FuseEventType.MemoryRead,
        "MW" => FuseEventType.MemoryWrite,
        "MC" => FuseEventType.MemoryContend,
        "PR" => FuseEventType.PortRead,
        "PW" => FuseEventType.PortWrite,
        "PC" => FuseEventType.PortContend,
        _ => throw new InvalidOperationException($"Unknown event type \"{value}\".")
    };
}