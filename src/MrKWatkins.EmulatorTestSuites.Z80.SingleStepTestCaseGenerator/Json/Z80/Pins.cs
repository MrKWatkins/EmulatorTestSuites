namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.Z80;

[Flags]
public enum Pins
{
    None = 0,
    Read = 1,
    Write = 2,
    Memory = 4,
    IO = 8
}