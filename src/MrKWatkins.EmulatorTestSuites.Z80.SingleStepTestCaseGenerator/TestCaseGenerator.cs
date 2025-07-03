using System.IO.Compression;
using MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;

// Tried using a delta from the initial state for the final state as most of it doesn't change. Stored whether a field had changed or not
// in a bit field, then just wrote the changed data. The raw size was reduced quite a bit, but after Brotli compression it actually came out
// slightly larger. I'm guessing this is because Brotli can copy large sections of the data in one rather than doing it field by field.
public static class TestCaseGenerator
{
    public static async ValueTask Generate(IReadOnlyList<TestStep> steps)
    {
        var name = steps[0].Name[..^5];
        var output = Path.Combine(Directory.Output, $"{name}");

        await using var stream = File.Create(output);
        await using var compressed = new BrotliStream(stream, new BrotliCompressionOptions { Quality = 11 });
        await using var binaryWriter = new BinaryWriter(compressed);
        WriteSteps(binaryWriter, steps);

        Console.WriteLine($"Generated test case {name} at {output}");
    }

    private static void WriteSteps(BinaryWriter binaryWriter, IReadOnlyList<TestStep> steps)
    {
        binaryWriter.Write7BitEncodedInt(steps.Count);
        foreach (var step in steps)
        {
            WriteStep(binaryWriter, step);
        }
    }

    private static void WriteStep(BinaryWriter binaryWriter, TestStep step)
    {
        WriteTestState(binaryWriter, step.Initial);
        WriteTestState(binaryWriter, step.Final);
        WriteCycles(binaryWriter, step.Cycles);
        WritePorts(binaryWriter, step.Ports);
    }

    private static void WritePorts(BinaryWriter binaryWriter, IReadOnlyList<Port> ports)
    {
        binaryWriter.Write7BitEncodedInt(ports.Count);
        foreach (var port in ports)
        {
            binaryWriter.Write(port.Address);
            binaryWriter.Write(port.Value);
            binaryWriter.Write((byte)port.Type);
        }
    }

    private static void WriteCycles(BinaryWriter binaryWriter, IReadOnlyList<Cycle> cycles)
    {
        binaryWriter.Write7BitEncodedInt(cycles.Count);
        foreach (var cycle in cycles)
        {
            var hasDataAndPins = (byte)cycle.Pins;
            if (cycle.Data != null)
            {
                hasDataAndPins |= 0b10000000;
            }

            binaryWriter.Write(cycle.Address);
            binaryWriter.Write(cycle.Data ?? 0);
            binaryWriter.Write(hasDataAndPins);
        }
    }

    private static void WriteTestState(BinaryWriter binaryWriter, TestState testState)
    {
        binaryWriter.Write(testState.F);
        binaryWriter.Write(testState.A);
        binaryWriter.Write(testState.C);
        binaryWriter.Write(testState.B);
        binaryWriter.Write(testState.E);
        binaryWriter.Write(testState.D);
        binaryWriter.Write(testState.L);
        binaryWriter.Write(testState.H);
        binaryWriter.Write(testState.IX);
        binaryWriter.Write(testState.IY);
        binaryWriter.Write(testState.SP);
        binaryWriter.Write(testState.PC);
        binaryWriter.Write(testState.WZ);
        binaryWriter.Write(testState.I);
        binaryWriter.Write(testState.R);
        binaryWriter.Write(testState.Q);
        binaryWriter.Write(testState.ShadowAF);
        binaryWriter.Write(testState.ShadowBC);
        binaryWriter.Write(testState.ShadowDE);
        binaryWriter.Write(testState.ShadowHL);
        binaryWriter.Write(testState.Interrupts);

        WriteRam(binaryWriter, testState);
    }

    private static void WriteRam(BinaryWriter binaryWriter, TestState testState)
    {
        binaryWriter.Write7BitEncodedInt(testState.Ram.Length);
        foreach (var ram in testState.Ram)
        {
            binaryWriter.Write(ram.Address);
            binaryWriter.Write(ram.Value);
        }
    }
}