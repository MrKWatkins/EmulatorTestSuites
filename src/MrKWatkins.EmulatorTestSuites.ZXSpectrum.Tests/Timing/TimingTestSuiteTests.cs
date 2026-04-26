using MrKWatkins.EmulatorTestSuites.Z80;
using MrKWatkins.EmulatorTestSuites.ZXSpectrum.Timing;

namespace MrKWatkins.EmulatorTestSuites.ZXSpectrum.Tests.Timing;

public sealed class TimingTestSuiteTests
{
    private const ulong TimeoutTStates = 10_000_001;
    private const ushort PreparedScreenSampleAddress = 0x4140;

    [Test]
    public void GetTestCases()
    {
        var testCases = TimingTestSuite.Instance.TestCases;
        testCases.Should().HaveCount(72);
        testCases[0].Id.Should().Equal("01-uncontended");
        testCases[0].Name.Should().Equal("Test 1 {Uncontended} JR; INC BC; LD BC,(nn);LD (nn),BC");
        testCases[34].Id.Should().Equal("35-uncontended");
        testCases[34].Name.Should().Equal("Test 35 {Uncontended} IN A,(n); OUT (n),A; IN r,(C); OUT (C),r");
        testCases[35].Id.Should().Equal("01-contended");
        testCases[35].Name.Should().Equal("Test 1 {Contended} JR; INC BC; LD BC,(nn);LD (nn),BC");
        testCases[^3].Id.Should().Equal("35-contended");
        testCases[^3].Name.Should().Equal("Test 35 {Contended} IN A,(n); OUT (n),A; IN r,(C); OUT (C),r [CLS]");
        testCases[^2].Id.Should().Equal("36-contended");
        testCases[^1].Id.Should().Equal("37-contended");
        testCases[^1].Name.Should().Equal("Test 37 {Contended} IN A,(n); OUT (n),A; IN r,(C); OUT (C),r [21]");
    }

    [Test]
    public void Execute_Instruction_Mode_Uses_Early_Timings()
    {
        EarlyInstructionTimingZ80.ResetCounters();
        TimingTestSuite.Instance.TestCases[0].Execute<EarlyInstructionTimingTestHarness>();

        EarlyInstructionTimingZ80.ExecuteInstructionCalls.Should().Equal(4);
    }

    [Test]
    public void Execute_Step_Mode_Uses_Late_Timings()
    {
        LateSteppableTimingZ80.ResetCounters();
        TimingTestSuite.Instance.TestCases[0].Execute<LateSteppableTimingTestHarness>();

        LateSteppableTimingZ80.ExecuteInstructionCalls.Should().Equal(2);
        LateSteppableTimingZ80.StepCalls.Should().Equal(2);
    }

    [Test]
    public void Execute_Step_Mode_With_SpectrumHarness_Uses_PreparedScreenPrelude()
    {
        FrameAwareSteppableTimingTestHarness.ResetCounters();
        TimingTestSuite.Instance.TestCases[34].Execute<FrameAwareSteppableTimingTestHarness>();

        FrameAwareSteppableTimingTestHarness.StartFrameCalls.Should().Equal(1);
        PreparedScreenSteppableTimingZ80.PreparedTestNumber.Should().Equal(35);
        PreparedScreenSteppableTimingZ80.PreparedContendedFlag.Should().Equal(0);
        PreparedScreenSteppableTimingZ80.PreparedScreenByte.Should().Equal(0xFE);
    }

    [Test]
    public void Execute_Instruction_Mode_Uses_PreparedScreenPrelude()
    {
        PreparedScreenInstructionTimingTestHarness.ResetCounters();
        TimingTestSuite.Instance.TestCases[34].Execute<PreparedScreenInstructionTimingTestHarness>();

        PreparedScreenInstructionTimingTestHarness.StartFrameCalls.Should().Equal(1);
        PreparedScreenInstructionTimingZ80.PreparedTestNumber.Should().Equal(35);
        PreparedScreenInstructionTimingZ80.PreparedContendedFlag.Should().Equal(0);
        PreparedScreenInstructionTimingZ80.PreparedScreenByte.Should().Equal(0xFE);
    }

    [Test]
    public void Execute_Fails_When_Program_Exceeds_MaximumTStates()
    {
        Assert.That(
            () => TimingTestSuite.Instance.TestCases[0].Execute<HangingTimingTestHarness>(),
            Throws.TypeOf<NUnit.Framework.AssertionException>().With.Message.Contains("Program test exceeded"));
    }

    private sealed class EarlyInstructionTimingTestHarness() : FakeSpectrumTestHarness(new EarlyInstructionTimingZ80());

    private sealed class LateSteppableTimingTestHarness() : FakeSpectrumTestHarness(new LateSteppableTimingZ80());

    private sealed class PreparedScreenInstructionTimingTestHarness() : FakeSpectrumTestHarness(new PreparedScreenInstructionTimingZ80())
    {
        public static int StartFrameCalls { get; private set; }

        public static void ResetCounters()
        {
            StartFrameCalls = 0;
            PreparedScreenInstructionTimingZ80.ResetCounters();
        }

        public override void StartFrame() => StartFrameCalls++;
    }

    private sealed class FrameAwareSteppableTimingTestHarness() : FakeSpectrumTestHarness(new PreparedScreenSteppableTimingZ80())
    {
        public static int StartFrameCalls { get; private set; }

        public static void ResetCounters()
        {
            StartFrameCalls = 0;
            PreparedScreenSteppableTimingZ80.ResetCounters();
        }

        public override void StartFrame() => StartFrameCalls++;
    }

    private sealed class HangingTimingTestHarness() : FakeSpectrumTestHarness(new HangingTimingZ80());

    private abstract class FakeSpectrumTestHarness : ZXSpectrumTestHarness
    {
        private protected FakeSpectrumTestHarness(Z80TestHarness z80)
        {
            Z80 = z80;
        }

        public override Z80TestHarness Z80 { get; }

        public override void StartFrame()
        {
        }
    }

    private sealed class EarlyInstructionTimingZ80 : FakeTimingZ80
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

    private sealed class LateSteppableTimingZ80 : FakeSteppableTimingZ80
    {
        public static int ExecuteInstructionCalls { get; private set; }
        public static int StepCalls { get; private set; }

        public static void ResetCounters()
        {
            ExecuteInstructionCalls = 0;
            StepCalls = 0;
        }

        protected override bool UseLateTimings => true;

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
    }

    private sealed class PreparedScreenInstructionTimingZ80 : FakeTimingZ80
    {
        public static byte PreparedScreenByte { get; private set; }
        public static byte PreparedTestNumber { get; private set; }
        public static byte PreparedContendedFlag { get; private set; }

        public static void ResetCounters()
        {
            PreparedScreenByte = 0;
            PreparedTestNumber = 0;
            PreparedContendedFlag = 0;
        }

        protected override bool UseLateTimings => true;

        public override void ExecuteInstruction() => SimulateInstructionWithPreparedScreenCapture();

        private void SimulateInstructionWithPreparedScreenCapture()
        {
            if (RegisterPC == 0xC000)
            {
                PreparedScreenByte = ReadByteFromMemory(PreparedScreenSampleAddress);
                PreparedTestNumber = ReadByteFromMemory(40000);
                PreparedContendedFlag = ReadByteFromMemory(40002);
            }

            SimulateInstruction();
        }
    }

    private sealed class PreparedScreenSteppableTimingZ80 : FakeSteppableTimingZ80
    {
        public static byte PreparedScreenByte { get; private set; }
        public static byte PreparedTestNumber { get; private set; }
        public static byte PreparedContendedFlag { get; private set; }

        public static void ResetCounters()
        {
            PreparedScreenByte = 0;
            PreparedTestNumber = 0;
            PreparedContendedFlag = 0;
        }

        protected override bool UseLateTimings => true;

        public override void ExecuteInstruction() => SimulateInstructionWithPreparedScreenCapture();

        public override void Step() => SimulateInstructionWithPreparedScreenCapture();

        private void SimulateInstructionWithPreparedScreenCapture()
        {
            if (RegisterPC == 0xC000)
            {
                PreparedScreenByte = ReadByteFromMemory(PreparedScreenSampleAddress);
                PreparedTestNumber = ReadByteFromMemory(40000);
                PreparedContendedFlag = ReadByteFromMemory(40002);
            }

            SimulateInstruction();
        }
    }

    private sealed class HangingTimingZ80 : FakeTimingZ80
    {
        protected override bool UseLateTimings => false;

        public override void ExecuteInstruction() => TStates += TimeoutTStates;
    }

    private abstract class FakeTimingZ80 : Z80TestHarness
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

    private abstract class FakeSteppableTimingZ80 : Z80SteppableTestHarness
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