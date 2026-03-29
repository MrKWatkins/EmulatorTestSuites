using MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

namespace MrKWatkins.EmulatorTestSuites.Z80.Tests.Program;

public sealed class ProgramTestCaseTests
{
    private const ulong TimeoutTStates = 1_000_000_001;

    [Test]
    public void Execute_Instruction_Mode_Fails_When_Program_Exceeds_MaximumTStates()
    {
        var testCase = MarkWoodmassTestSuite.Get(MarkWoodmassTestType.Flags).TestCases[0];

        Assert.That(
            () => testCase.Execute<HangingInstructionProgramTestHarness>(),
            Throws.TypeOf<NUnit.Framework.AssertionException>().With.Message.Contains("Program test exceeded"));
    }

    [Test]
    public void Execute_Step_Mode_Fails_When_Program_Exceeds_MaximumTStates()
    {
        var testCase = MarkWoodmassTestSuite.Get(MarkWoodmassTestType.Flags).TestCases[0];

        Assert.That(
            () => testCase.Execute<HangingSteppableProgramTestHarness>(),
            Throws.TypeOf<NUnit.Framework.AssertionException>().With.Message.Contains("Program test exceeded"));
    }

    private abstract class HangingProgramTestHarnessBase : Z80TestHarness
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

        protected void AdvanceWithoutCompleting()
        {
            TStates += TimeoutTStates;
        }
    }

    private sealed class HangingInstructionProgramTestHarness : HangingProgramTestHarnessBase
    {
        public override void ExecuteInstruction() => AdvanceWithoutCompleting();
    }

    private sealed class HangingSteppableProgramTestHarness : Z80SteppableTestHarness
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

        public override void ExecuteInstruction() => TStates += TimeoutTStates;

        public override void Step() => TStates += TimeoutTStates;
    }
}