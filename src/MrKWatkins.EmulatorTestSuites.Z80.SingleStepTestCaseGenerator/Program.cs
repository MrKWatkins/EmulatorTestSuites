using MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;
using MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

await Parallel.ForEachAsync(JsonTestCases.EnumerateTestCases(), (steps, _) => TestCaseGenerator.Generate(steps));