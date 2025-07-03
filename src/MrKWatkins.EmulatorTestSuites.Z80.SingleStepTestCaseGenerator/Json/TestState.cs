using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class TestState
{
    [JsonPropertyName("pc")]
    public ushort PC { get; init; }

    [JsonPropertyName("sp")]
    public ushort SP { get; init; }

    [JsonPropertyName("a")]
    public byte A { get; init; }

    [JsonPropertyName("b")]
    public byte B { get; init; }

    [JsonPropertyName("c")]
    public byte C { get; init; }

    [JsonPropertyName("d")]
    public byte D { get; init; }

    [JsonPropertyName("e")]
    public byte E { get; init; }

    [JsonPropertyName("f")]
    public byte F { get; init; }

    [JsonPropertyName("h")]
    public byte H { get; init; }

    [JsonPropertyName("l")]
    public byte L { get; init; }

    [JsonPropertyName("i")]
    public byte I { get; init; }

    [JsonPropertyName("r")]
    public byte R { get; init; }

    // EI refers to if Enable Interrupt was the last-emulated instruction.
    [JsonPropertyName("ei")]
    public byte EI { get; init; }

    [JsonPropertyName("wz")]
    public ushort WZ { get; init; }

    [JsonPropertyName("ix")]
    public ushort IX { get; init; }

    [JsonPropertyName("iy")]
    public ushort IY { get; init; }

    [JsonPropertyName("af_")]
    public ushort ShadowAF { get; init; }

    [JsonPropertyName("bc_")]
    public ushort ShadowBC { get; init; }

    [JsonPropertyName("de_")]
    public ushort ShadowDE { get; init; }

    [JsonPropertyName("hl_")]
    public ushort ShadowHL { get; init; }

    [JsonPropertyName("im")]
    public byte IM { get; init; }

    // Used to track specific behavior during interrupt depending on if CMOS or not and previously executed instructions.
    [JsonPropertyName("p")]
    public byte P { get; init; }

    // Used to track if the last-modified opcode modified flag registers.
    [JsonPropertyName("q")]
    public byte Q { get; init; }

    [JsonPropertyName("iff1")]
    public byte IFF1 { get; init; }

    [JsonPropertyName("iff2")]
    public byte IFF2 { get; init; }

    [JsonPropertyName("ram")]
    public Ram[] Ram { get; init; } = null!;

    public byte Interrupts
    {
        get
        {
            int interrupts = IFF1;
            interrupts |= IFF2 << 1;
            interrupts |= IM << 2;
            return (byte)interrupts;
        }
    }
}