using System.IO.Compression;
using MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;

public abstract class TestCaseGenerator<TStep>(string cpuName, string outputDirectory)
{
    public async ValueTask Generate((string Name, IReadOnlyList<TStep> Steps) testCase)
    {
        var output = Path.Combine(outputDirectory, testCase.Name);

        Directory.CreateDirectory(outputDirectory);

        await using var stream = File.Create(output);
        await using var compressed = new BrotliStream(stream, new BrotliCompressionOptions { Quality = 11 });
        await using var binaryWriter = new BinaryWriter(compressed);
        WriteSteps(binaryWriter, testCase.Steps);

        Console.WriteLine($"Generated {cpuName} test case {testCase.Name} at {output}");
    }

    private void WriteSteps(BinaryWriter binaryWriter, IReadOnlyList<TStep> steps)
    {
        binaryWriter.Write7BitEncodedInt(steps.Count);
        foreach (var step in steps)
        {
            WriteStep(binaryWriter, step);
        }
    }

    protected static void WriteRam(BinaryWriter binaryWriter, IReadOnlyList<Ram> ram)
    {
        binaryWriter.Write7BitEncodedInt(ram.Count);
        foreach (var entry in ram)
        {
            binaryWriter.Write(entry.Address);
            binaryWriter.Write(entry.Value);
        }
    }

    protected abstract void WriteStep(BinaryWriter binaryWriter, TStep step);
}