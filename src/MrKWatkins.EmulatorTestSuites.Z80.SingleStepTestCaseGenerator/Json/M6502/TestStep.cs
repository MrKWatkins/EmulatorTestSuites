using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public sealed class TestStep
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("initial")]
    public TestState Initial { get; init; } = null!;

    [JsonPropertyName("final")]
    public TestState Final { get; init; } = null!;

    [JsonPropertyName("cycles")]
    public Cycle[] Cycles { get; init; } = [];
}