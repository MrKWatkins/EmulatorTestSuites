using M6502JsonTestCases = MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502.JsonTestCases;
using Z80JsonTestCases = MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.Z80.JsonTestCases;
using GeneratorPaths = MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Paths;

ClearOutput(GeneratorPaths.M6502Output);

await Parallel.ForEachAsync(Z80JsonTestCases.EnumerateTestCases(),
    (testCase, _) => MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Z80TestCaseGenerator.Generate(testCase));
await Parallel.ForEachAsync(M6502JsonTestCases.EnumerateTestCases(),
    (testCase, _) => MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.M6502TestCaseGenerator.Generate(testCase));

static void ClearOutput(string path)
{
    if (!Directory.Exists(path))
    {
        return;
    }

    foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly))
    {
        File.Delete(file);
    }
}