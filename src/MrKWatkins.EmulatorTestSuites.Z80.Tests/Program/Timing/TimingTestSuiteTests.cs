using MrKWatkins.EmulatorTestSuites.Z80.Program.Timing;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program.Timing;

public sealed class TimingTestSuiteTests
{
    private const ulong TimeoutTStates = 10_000_001;

    [Test]
    public void GetTestCases()
    {
        var testCases = TimingTestSuite.Instance.TestCases;
        testCases.Should().HaveCount(68);
        testCases[0].Id.Should().Equal("01-uncontended");
        testCases[0].Name.Should().Equal("Test 1 {Uncontended} JR; INC BC; LD BC,(nn);LD (nn),BC");
        testCases[34].Id.Should().Equal("01-contended");
        testCases[34].Name.Should().Equal("Test 1 {Contended} JR; INC BC; LD BC,(nn);LD (nn),BC");
        testCases[^1].Id.Should().Equal("34-contended");
        testCases[^1].Name.Should().Equal("Test 34 {Contended} RST 18");
    }

    [Test]
    public void Execute_Instruction_Mode_Uses_Early_Timings()
    {
        EarlyInstructionTimingTestHarness.ResetCounters();
        TimingTestSuite.Instance.TestCases[0].Execute<EarlyInstructionTimingTestHarness>();

        EarlyInstructionTimingTestHarness.ExecuteInstructionCalls.Should().Equal(4);
    }

    [Test]
    public void Execute_Step_Mode_Uses_Late_Timings()
    {
        LateSteppableTimingTestHarness.ResetCounters();
        TimingTestSuite.Instance.TestCases[0].Execute<LateSteppableTimingTestHarness>();

        LateSteppableTimingTestHarness.ExecuteInstructionCalls.Should().Equal(2);
        LateSteppableTimingTestHarness.StepCalls.Should().Equal(2);
    }

    [Test]
    public void Execute_Fails_When_Program_Exceeds_MaximumTStates()
    {
        Assert.That(
            () => TimingTestSuite.Instance.TestCases[0].Execute<HangingTimingTestHarness>(),
            Throws.TypeOf<NUnit.Framework.AssertionException>().With.Message.Contains("Program test exceeded"));
    }

    private sealed class EarlyInstructionTimingTestHarness : FakeTimingTestHarness
    {
        public static int ExecuteInstructionCalls { get; private set; }

        public static void ResetCounters() => ExecuteInstructionCalls = 0;

        protected override bool UseLateTimings => false;

        public override void ExecuteInstruction()
        {
            ExecuteInstructionCalls++;
            SimulateInstruction();
        }
    }

    private sealed class LateSteppableTimingTestHarness : Z80SteppableTestHarness
    {
        private readonly byte[] memory = new byte[65536];

        public static int ExecuteInstructionCalls { get; private set; }
        public static int StepCalls { get; private set; }

        public static void ResetCounters()
        {
            ExecuteInstructionCalls = 0;
            StepCalls = 0;
        }

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

        public override void ExecuteInstruction()
        {
            ExecuteInstructionCalls++;
            SimulateInstruction();
        }

        public override void Step()
        {
            StepCalls++;
            SimulateInstruction();
        }

        private void SimulateInstruction()
        {
            if (RegisterPC == 0x34B6)
            {
                RegisterPC = 0xC000;
                return;
            }

            if (RegisterPC == 0xBC28)
            {
                return;
            }

            var testNumber = ReadByteFromMemory(40000);
            if (testNumber == 0)
            {
                WriteByteToMemory(0xEF00, 122);
                WriteWordToMemory(0xEF01, 0);
                WriteWordToMemory(0xEF03, 49478);
            }
            else
            {
                var expectedAddress = (ushort)(57856 + testNumber * 10 + ReadByteFromMemory(40002) * 5 + 512);
                WriteByteToMemory(0xEF00, ReadByteFromMemory(expectedAddress));
                WriteWordToMemory(0xEF01, ReadWordFromMemory((ushort)(expectedAddress + 1)));
                WriteWordToMemory(0xEF03, ReadWordFromMemory((ushort)(expectedAddress + 3)));
            }

            RegisterPC = 0xBC28;
        }
    }

    private sealed class HangingTimingTestHarness : FakeTimingTestHarness
    {
        protected override bool UseLateTimings => false;

        public override void ExecuteInstruction() => TStates += TimeoutTStates;
    }

    private abstract class FakeTimingTestHarness : Z80TestHarness
    {
        private readonly byte[] memory = new byte[65536];

        protected abstract bool UseLateTimings { get; }

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

        protected void SimulateInstruction()
        {
            if (RegisterPC == 0x34B6)
            {
                RegisterPC = 0xC000;
                return;
            }

            if (RegisterPC == 0xBC28)
            {
                return;
            }

            var testNumber = ReadByteFromMemory(40000);
            if (testNumber == 0)
            {
                WriteByteToMemory(0xEF00, UseLateTimings ? (byte)122 : (byte)2);
                WriteWordToMemory(0xEF01, 0);
                WriteWordToMemory(0xEF03, 49478);
            }
            else
            {
                var expectedAddress = (ushort)(57856 + testNumber * 10 + ReadByteFromMemory(40002) * 5);
                if (UseLateTimings)
                {
                    expectedAddress += 512;
                }

                WriteByteToMemory(0xEF00, ReadByteFromMemory(expectedAddress));
                WriteWordToMemory(0xEF01, ReadWordFromMemory((ushort)(expectedAddress + 1)));
                WriteWordToMemory(0xEF03, ReadWordFromMemory((ushort)(expectedAddress + 3)));
            }

            RegisterPC = 0xBC28;
        }
    }
}
