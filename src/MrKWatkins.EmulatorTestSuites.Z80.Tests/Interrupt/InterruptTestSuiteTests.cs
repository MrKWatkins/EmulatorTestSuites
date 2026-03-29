using MrKWatkins.EmulatorTestSuites.Z80.Interrupt;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Interrupt;

public sealed class InterruptTestSuiteTests
{
    [Test]
    public void TestCases_Are_Enumerated()
    {
        var testCases = InterruptTestSuite.Instance.TestCases;

        testCases.Should().HaveCount(10);
        testCases[0].Id.Should().Equal("mode-0");
        testCases[0].Name.Should().Equal("Mode 0");
        testCases[^1].Id.Should().Equal("interrupt-overlap-mode-2");
        testCases[^1].Name.Should().Equal("Interrupt fully executes overlapped instructions {Mode 2}");
    }

    [Test]
    public void Execute_Requires_A_Steppable_Harness()
    {
        Assert.That(
            () => InterruptTestSuite.Instance.TestCases[0].Execute<NonSteppableInterruptTestHarness>(),
            Throws.TypeOf<NUnit.Framework.AssertionException>().With.Message.Contains(nameof(Z80SteppableTestHarness)));
    }

    [Test]
    public void Execute_Can_Run_A_Representative_Halt_Case()
    {
        ReplaySteppableInterruptTestHarness.SetReplay(
            new(CycleType.MemoryRead, RegisterPC: 0x0001),
            new(CycleType.None),
            new(CycleType.None, RegisterR: 0x01),
            new(CycleType.None),
            new(CycleType.MemoryRead, RegisterPC: 0x0001, Halted: true),
            new(CycleType.None),
            new(CycleType.None, RegisterR: 0x02),
            new(CycleType.None),
            new(CycleType.MemoryRead, RegisterPC: 0x0001),
            new(CycleType.None),
            new(CycleType.None, RegisterR: 0x03),
            new(CycleType.None),
            new(CycleType.MemoryRead, RegisterPC: 0x0001));

        InterruptTestSuite.Instance.TestCases.Single(x => x.Id == "halt-stays-on-next-opcode").Execute<ReplaySteppableInterruptTestHarness>();
    }

    private sealed class ReplaySteppableInterruptTestHarness : Z80SteppableTestHarness
    {
        private static IReadOnlyList<ReplayStep> replay = [];
        private readonly byte[] memory = new byte[65536];
        private int replayIndex;

        public static void SetReplay(params ReplayStep[] steps) => replay = steps;

        public override ushort RegisterAF { get; set; }

        public override ushort RegisterBC { get; set; }

        public override ushort RegisterDE { get; set; }

        public override ushort RegisterHL { get; set; }

        public override ushort RegisterIX { get; set; }

        public override ushort RegisterIY { get; set; }

        public override ushort RegisterSP { get; set; }

        public override ushort RegisterPC { get; set; }

        public override ushort RegisterWZ { get; set; }

        public override byte RegisterI { get; set; }

        public override byte RegisterR { get; set; }

        public override byte RegisterQ { get; set; }

        public override ushort ShadowRegisterAF { get; set; }

        public override ushort ShadowRegisterBC { get; set; }

        public override ushort ShadowRegisterDE { get; set; }

        public override ushort ShadowRegisterHL { get; set; }

        public override bool IFF1 { get; set; }

        public override bool IFF2 { get; set; }

        public override byte IM { get; set; }

        public override bool Halted { get; set; }

        public override bool Interrupt { get; set; }

        public override byte ReadByteFromMemory(ushort address) => memory[address];

        public override void WriteByteToMemory(ushort address, byte value) => memory[address] = value;

        public override void AssertFail(string message) => Assert.Fail(message);

        public override void ExecuteInstruction() => throw new NotSupportedException();

        public override void Step()
        {
            var step = replay[replayIndex++];
            var cycleIndex = (ulong)MutableCycles!.Count;
            MutableCycles.Add(new Cycle(step.CycleType, cycleIndex, 0x0000, null));

            if (step.RegisterPC.HasValue)
            {
                RegisterPC = step.RegisterPC.Value;
            }

            if (step.RegisterR.HasValue)
            {
                RegisterR = step.RegisterR.Value;
            }

            if (step.Halted.HasValue)
            {
                Halted = step.Halted.Value;
            }
        }
    }

    private sealed class NonSteppableInterruptTestHarness : Z80TestHarness
    {
        private readonly byte[] memory = new byte[65536];

        public override ushort RegisterAF { get; set; }

        public override ushort RegisterBC { get; set; }

        public override ushort RegisterDE { get; set; }

        public override ushort RegisterHL { get; set; }

        public override ushort RegisterIX { get; set; }

        public override ushort RegisterIY { get; set; }

        public override ushort RegisterSP { get; set; }

        public override ushort RegisterPC { get; set; }

        public override ushort RegisterWZ { get; set; }

        public override byte RegisterI { get; set; }

        public override byte RegisterR { get; set; }

        public override byte RegisterQ { get; set; }

        public override ushort ShadowRegisterAF { get; set; }

        public override ushort ShadowRegisterBC { get; set; }

        public override ushort ShadowRegisterDE { get; set; }

        public override ushort ShadowRegisterHL { get; set; }

        public override bool IFF1 { get; set; }

        public override bool IFF2 { get; set; }

        public override byte IM { get; set; }

        public override bool Halted { get; set; }

        public override bool Interrupt { get; set; }

        public override byte ReadByteFromMemory(ushort address) => memory[address];

        public override void WriteByteToMemory(ushort address, byte value) => memory[address] = value;

        public override void AssertFail(string message) => Assert.Fail(message);

        public override void ExecuteInstruction() => throw new NotSupportedException();
    }

    private readonly record struct ReplayStep(CycleType CycleType, ushort? RegisterPC = null, byte? RegisterR = null, bool? Halted = null);
}