using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class TestState
{
    [JsonPropertyName("pc")]
    public ushort PC { get; init; }

    [JsonPropertyName("s")]
    public byte S { get; init; }

    [JsonPropertyName("a")]
    public byte A { get; init; }

    [JsonPropertyName("x")]
    public byte X { get; init; }

    [JsonPropertyName("y")]
    public byte Y { get; init; }

    [JsonPropertyName("p")]
    public byte P { get; init; }

    [JsonPropertyName("ram")]
    public Ram[] Ram { get; init; } = null!;
}