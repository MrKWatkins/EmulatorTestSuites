namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;

public static class Paths
{
    [PathReference]
    private static string Solution
    {
        get
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            while (!directory.EnumerateFiles("EmulatorTestSuites.sln").Any())
            {
                directory = directory.Parent ?? throw new InvalidOperationException("Could not find the solution directory.");
            }

            return directory.FullName;
        }
    }

    [PathReference]
    public static string Z80Output => Path.Combine(Solution, "MrKWatkins.EmulatorTestSuites.Z80", "Instruction", "SingleStep", "TestCases");

    [PathReference]
    public static string M6502Output => Path.Combine(Solution, "MrKWatkins.EmulatorTestSuites.M6502", "Instruction", "SingleStep", "TestCases");

    [PathReference]
    public static string Z80JsonTemp => Path.Combine(Solution, "SingleStepTemp", "Z80");

    [PathReference]
    public static string M6502JsonTemp => Path.Combine(Solution, "SingleStepTemp", "M6502");
}