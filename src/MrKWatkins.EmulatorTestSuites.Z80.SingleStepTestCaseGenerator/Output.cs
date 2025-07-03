namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;

public static class Directory
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
    public static string Output => Path.Combine(Solution, "MrKWatkins.EmulatorTestSuites.Z80", "Instruction", "SingleStep", "TestCases");

    [PathReference]
    public static string JsonTemp => Path.Combine(Solution, "SingleStepTemp");
}