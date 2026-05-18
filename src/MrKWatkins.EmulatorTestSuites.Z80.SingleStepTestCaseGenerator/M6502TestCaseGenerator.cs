using MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator;

public static class M6502TestCaseGenerator
{
    private static readonly Generator Instance = new();

    public static ValueTask Generate((string Name, IReadOnlyList<TestStep> Steps) testCase) => Instance.Generate(testCase);

    private sealed class Generator : TestCaseGenerator<TestStep>
    {
        internal Generator()
            : base("M6502", Paths.M6502Output)
        {
        }

        protected override void WriteStep(BinaryWriter binaryWriter, TestStep step)
        {
            WriteTestState(binaryWriter, step.Initial);
            WriteTestState(binaryWriter, step.Final);
            WriteCycles(binaryWriter, step.Cycles);
        }

        private static void WriteTestState(BinaryWriter binaryWriter, TestState testState)
        {
            binaryWriter.Write(testState.A);
            binaryWriter.Write(testState.X);
            binaryWriter.Write(testState.Y);
            binaryWriter.Write(testState.S);
            binaryWriter.Write(testState.P);
            binaryWriter.Write(testState.PC);

            WriteRam(binaryWriter, testState.Ram);
        }

        private static void WriteCycles(BinaryWriter binaryWriter, IReadOnlyList<Cycle> cycles)
        {
            binaryWriter.Write7BitEncodedInt(cycles.Count);
            foreach (var cycle in cycles)
            {
                binaryWriter.Write(cycle.Address);
                binaryWriter.Write(cycle.Value);
                binaryWriter.Write(cycle.IsWrite);
            }
        }
    }
}