namespace MrKWatkins.EmulatorTestSuites.Z80.Interrupt;

/// <summary>
/// A standalone interrupt test case from the <see cref="InterruptTestSuite" />.
/// </summary>
public sealed class InterruptTestCase : TestCase
{
    private readonly Action<Z80SteppableTestHarness> execute;

    private InterruptTestCase(string id, string name, Action<Z80SteppableTestHarness> execute)
        : base(id)
    {
        Name = name;
        this.execute = execute;
    }

    /// <summary>
    /// Gets the display name for this test case.
    /// </summary>
    public override string Name { get; }

    /// <summary>
    /// Executes this test case using the specified <see cref="Z80SteppableTestHarness" /> type.
    /// </summary>
    /// <typeparam name="TTestHarness">The type of steppable harness to execute against.</typeparam>
    /// <param name="testOutput">Optional test output.</param>
    public override void Execute<TTestHarness>(TextWriter? testOutput = null)
    {
        var z80 = new TTestHarness();
        if (z80 is not Z80SteppableTestHarness steppable)
        {
            z80.AssertFail($"{nameof(InterruptTestSuite)} requires a {nameof(Z80SteppableTestHarness)}.");
            throw new InvalidOperationException("The test harness did not fail the test when a non-steppable harness was used.");
        }

        steppable.Reset();
        steppable.RecordCycles = true;

        testOutput?.WriteLine($"Running {Name}.");
        execute(steppable);
    }

    internal static InterruptTestCase CreateMode0() => new("mode-0", "Mode 0", ExecuteMode0);

    internal static InterruptTestCase CreateMode1() => new("mode-1", "Mode 1", ExecuteMode1);

    internal static InterruptTestCase CreateMode2() => new("mode-2", "Mode 2", ExecuteMode2);

    internal static InterruptTestCase CreateInterruptsDoNotTriggerIfDisabled() =>
        new("interrupts-disabled", "Interrupts do not trigger if disabled", ExecuteInterruptsDoNotTriggerIfDisabled);

    internal static InterruptTestCase CreateInterruptsDoNotTriggerDuringEI() =>
        new("interrupts-deferred-during-ei", "Interrupts do not trigger during EI", ExecuteInterruptsDoNotTriggerDuringEI);

    internal static InterruptTestCase CreateHaltStaysOnTheNextOpcode() =>
        new("halt-stays-on-next-opcode", "HALT stays on the next opcode", ExecuteHaltStaysOnTheNextOpcode);

    internal static InterruptTestCase CreateInterruptResetsHalted() =>
        new("interrupt-resets-halted", "Interrupt resets Halted", ExecuteInterruptResetsHalted);

    internal static InterruptTestCase CreateInterruptFullyExecutesOverlappedInstruction(byte mode) =>
        new($"interrupt-overlap-mode-{mode}", $"Interrupt fully executes overlapped instructions {{Mode {mode}}}", z80 => ExecuteInterruptFullyExecutesOverlappedInstruction(z80, mode));

    private static void ExecuteMode0(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;
        z80.SetIO(new NullIO());

        Load(z80, 0x0000,
        [
            0xFB,             // EI
            0xED, 0x46,       // IM 0
            0x31, 0x22, 0x11, // LD SP,0x1122
            0x00,             // NOP
            0x00,             // NOP
            0x00,             // NOP
            0x18, 0xFB        // JR -5
        ]);

        Load(z80, 0x0038,
        [
            0x3E, 0x33, // LD A,0x33
            0xED, 0x4D  // RETI
        ]);

        z80.Step(4);  // EI
        z80.Step(8);  // IM 0
        z80.Step(10); // LD SP,0x1122
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to be enabled after EI.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to be enabled after EI.");
        z80.AssertEqual(z80.IM, (byte)0, $"Expected interrupt mode 0.");
        z80.AssertEqual(z80.RegisterSP, (ushort)0x1122, $"Expected SP to be 0x1122.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x05, $"Expected R to be 0x05 during the NOP refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0007, $"Expected PC to remain on the interrupted NOP.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared when interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared when interrupt handling starts.");
        StepAndAssertEvent(z80, CycleType.IORead);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x06, $"Expected R to be incremented by the interrupt handler refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x1120, $"Expected interrupt handling to push two bytes onto the stack.");

        z80.AssertEqual(z80.RegisterPC, (ushort)0x0038, $"Expected IM 0 to dispatch via RST 0x38.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterA, (byte)0x33, $"Expected LD A,0x33 to complete in the interrupt handler.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x1122, $"Expected RETI to restore SP.");
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0007, $"Expected RETI to return to the interrupted instruction.");
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to remain cleared after RETI.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to remain cleared after RETI.");
    }

    private static void ExecuteMode1(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;

        Load(z80, 0x0000,
        [
            0xFB,       // EI
            0xED, 0x56, // IM 1
            0x00,       // NOP
            0x00,       // NOP
            0x00,       // NOP
            0x18, 0xFB  // JR -5
        ]);

        Load(z80, 0x0038,
        [
            0x3E, 0x33, // LD A,0x33
            0xED, 0x4D  // RETI
        ]);

        z80.Step(4); // EI
        z80.Step(8); // IM 1

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to be enabled after EI.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to be enabled after EI.");
        z80.AssertEqual(z80.IM, (byte)1, $"Expected interrupt mode 1.");

        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x04, $"Expected R to be 0x04 during the NOP refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected PC to remain on the interrupted NOP.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared when interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared when interrupt handling starts.");
        StepAndAssertEvent(z80, CycleType.IORead);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x05, $"Expected R to be incremented by the interrupt handler refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x00FE, $"Expected interrupt handling to push two bytes onto the stack.");

        z80.AssertEqual(z80.RegisterPC, (ushort)0x0038, $"Expected IM 1 to dispatch via RST 0x38.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterA, (byte)0x33, $"Expected LD A,0x33 to complete in the interrupt handler.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x0100, $"Expected RETI to restore SP.");
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected RETI to return to the interrupted instruction.");
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to remain cleared after RETI.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to remain cleared after RETI.");
    }

    private static void ExecuteMode2(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;
        z80.SetIO(new NullIO(0xE0));

        Load(z80, 0x0000,
        [
            0xFB,             // EI
            0xED, 0x5E,       // IM 2
            0x3E, 0x01,       // LD A,0x01
            0xED, 0x47,       // LD I,A
            0x00,             // NOP
            0x00,             // NOP
            0x00,             // NOP
            0x18, 0xFB,       // JR -5
            0x00,             // NOP
            0x3E, 0x33,       // LD A,0x33
            0xED, 0x4D        // RETI
        ]);

        z80.WriteWordToMemory(0x01E0, 0x000D);

        z80.Step(4); // EI
        z80.Step(8); // IM 2
        z80.Step(7); // LD A,0x01
        z80.Step(9); // LD I,A
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to be enabled after EI.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to be enabled after EI.");
        z80.AssertEqual(z80.IM, (byte)2, $"Expected interrupt mode 2.");
        z80.AssertEqual(z80.RegisterI, (byte)0x01, $"Expected I register to be initialised for IM 2.");
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0007, $"Expected PC to be positioned at the first NOP in the loop.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x07, $"Expected R to be 0x07 during the NOP refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared when interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared when interrupt handling starts.");
        StepAndAssertEvent(z80, CycleType.IORead);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x08, $"Expected R to be incremented by the interrupt handler refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        z80.AssertEqual(z80.RegisterWZ, (ushort)0x01E0, $"Expected WZ to hold the IM 2 vector address.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x00FE, $"Expected interrupt handling to push two bytes onto the stack.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        z80.AssertEqual(z80.RegisterPC, (ushort)0x000D, $"Expected IM 2 to jump to the vector table target.");
        z80.AssertEqual(z80.RegisterWZ, (ushort)0x000D, $"Expected WZ to be updated to the IM 2 jump target.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterA, (byte)0x33, $"Expected LD A,0x33 to complete in the interrupt handler.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x0100, $"Expected RETI to restore SP.");
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0008, $"Expected RETI to return to the interrupted instruction.");
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to remain cleared after RETI.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to remain cleared after RETI.");
    }

    private static void ExecuteInterruptsDoNotTriggerIfDisabled(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;

        Load(z80, 0x0000,
        [
            0xF3, // DI
            0x00, // NOP
            0x00  // NOP
        ]);

        z80.Step(4);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to advance past DI.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared after DI.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared after DI.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0002, $"Expected PC to advance to the first NOP.");

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0003, $"Expected execution to continue normally when interrupts are disabled.");
        z80.AssertEqual(z80.Interrupt, false, $"Expected the pending interrupt to be marked as handled even though it did not trigger.");
    }

    private static void ExecuteInterruptsDoNotTriggerDuringEI(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;

        Load(z80, 0x0000,
        [
            0xFB,       // EI
            0xED, 0x56, // IM 1
            0xFB,       // EI
            0xFB,       // EI
            0x00        // NOP
        ]);

        z80.Step(4); // EI
        z80.Step(8); // IM 1

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to be enabled after EI.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to be enabled after EI.");
        z80.AssertEqual(z80.IM, (byte)1, $"Expected interrupt mode 1.");

        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x04, $"Expected R to be 0x04 during EI.");
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected PC to advance to the next EI before the interrupt is taken.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0005, $"Expected the second EI to complete before interrupt handling starts.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0006, $"Expected the third EI to complete before interrupt handling starts.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared when interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared when interrupt handling starts.");
        StepAndAssertEvent(z80, CycleType.IORead);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x07, $"Expected R to be incremented by the interrupt handler refresh cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterSP, (ushort)0x00FE, $"Expected interrupt handling to push two bytes onto the stack.");

        z80.AssertEqual(z80.RegisterPC, (ushort)0x0038, $"Expected IM 1 to dispatch via RST 0x38.");
    }

    private static void ExecuteHaltStaysOnTheNextOpcode(Z80SteppableTestHarness z80)
    {
        Load(z80, 0x0000,
        [
            0x76, // HALT
            0xE7  // RST 0x20
        ]);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to advance past HALT.");
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x01, $"Expected R to increment during HALT.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.Halted, true, $"Expected HALT to latch the halted state.");

        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to remain positioned on the next opcode while halted.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x02, $"Expected R to increment during the repeated HALT cycle.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to stay on the repeated opcode read while halted.");
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterR, (byte)0x03, $"Expected R to keep incrementing while halted.");
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to still be positioned on the next opcode.");
    }

    private static void ExecuteInterruptResetsHalted(Z80SteppableTestHarness z80)
    {
        z80.RegisterSP = 0x0100;

        Load(z80, 0x0000,
        [
            0xFB,       // EI
            0xED, 0x56, // IM 1
            0x76,       // HALT
            0xE7        // RST 0x20
        ]);

        Load(z80, 0x0038,
        [
            0xED, 0x4D // RETI
        ]);

        z80.Step(4);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0001, $"Expected PC to advance past EI.");
        z80.AssertEqual(z80.IFF1, false, $"Expected EI flip-flops to update during overlap, not immediately.");
        z80.AssertEqual(z80.IFF2, false, $"Expected EI flip-flops to update during overlap, not immediately.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0002, $"Expected PC to advance to IM 1.");
        z80.AssertEqual(z80.IFF1, true, $"Expected EI overlap to enable IFF1.");
        z80.AssertEqual(z80.IFF2, true, $"Expected EI overlap to enable IFF2.");

        z80.Step(7);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0003, $"Expected PC to advance past IM 1.");
        z80.AssertEqual(z80.IM, (byte)0, $"Expected IM to update during overlap, not immediately.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected PC to advance to HALT.");
        z80.AssertEqual(z80.IM, (byte)1, $"Expected IM 1 to become active during overlap.");

        z80.Step(3);
        z80.AssertEqual(z80.Halted, false, $"Expected HALT to update during overlap, not immediately.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected PC to remain after HALT once the halted state is latched.");
        z80.AssertEqual(z80.Halted, true, $"Expected HALT to latch during overlap.");

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to remain set until interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to remain set until interrupt handling starts.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared when interrupt handling starts.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared when interrupt handling starts.");
        StepAndAssertEvent(z80, CycleType.IORead);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryWrite);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        z80.AssertEqual(z80.RegisterPC, (ushort)0x0038, $"Expected IM 1 to dispatch via RST 0x38.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0004, $"Expected RETI to return to the opcode after HALT.");
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to remain cleared after RETI.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to remain cleared after RETI.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterPC, (ushort)0x0005, $"Expected normal execution to resume after HALT is released.");
    }

    private static void ExecuteInterruptFullyExecutesOverlappedInstruction(Z80SteppableTestHarness z80, byte mode)
    {
        z80.RegisterSP = 0x0100;

        Load(z80, 0x0000,
        [
            0xFB,             // EI
            0xED, mode switch
            {
                0 => 0x46, // IM 0
                1 => 0x56, // IM 1
                2 => 0x5E, // IM 2
                _ => throw new InvalidOperationException($"Invalid interrupt mode {mode}.")
            },
            0x3C,             // INC A
            0xE7              // RST 0x20
        ]);

        Load(z80, 0x0038,
        [
            0xED, 0x4D // RETI
        ]);

        z80.Step(4); // EI
        z80.Step(8); // IM mode
        z80.AssertEqual(z80.TStates, 12UL, $"Expected EI and IM to consume 12 T-states.");
        z80.AssertEqual(z80.IFF1, true, $"Expected IFF1 to be enabled after EI.");
        z80.AssertEqual(z80.IFF2, true, $"Expected IFF2 to be enabled after EI.");

        StepAndAssertEvent(z80, CycleType.MemoryRead);
        StepAndAssertEvent(z80, CycleType.None);

        z80.Interrupt = true;

        StepAndAssertEvent(z80, CycleType.None);
        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterA, (byte)0, $"Expected INC A to complete during the overlap, not before it.");

        StepAndAssertEvent(z80, CycleType.None);
        z80.AssertEqual(z80.RegisterA, (byte)1, $"Expected INC A to complete before interrupt handling advances.");
        z80.AssertEqual(z80.IFF1, false, $"Expected IFF1 to be cleared on the first interrupt-handling step.");
        z80.AssertEqual(z80.IFF2, false, $"Expected IFF2 to be cleared on the first interrupt-handling step.");

        StepAndAssertEvent(z80, CycleType.IORead);
    }

    private static void Load(Z80TestHarness z80, ushort address, ReadOnlySpan<byte> bytes) => z80.CopyToMemory(address, bytes);

    private static void StepAndAssertEvent(Z80SteppableTestHarness z80, CycleType expectedType)
    {
        z80.Step();
        var actualType = z80.Cycles[^1].Type;
        z80.AssertEqual(actualType, expectedType, $"Expected cycle type {expectedType} but was {actualType}.");
    }
}
