# Z80TestHarness Class
## Definition

Base class for a Z80 emulator test harness. Implement this class to use it with the test suites.

```c#
public abstract class Z80TestHarness
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [Z80TestHarness()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.-ctor.md) |  |

## Properties

| Name | Description |
| ---- | ----------- |
| [Cycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Cycles.md) | Gets the recorded CPU cycles. Only available when [RecordCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RecordCycles.md) is true. |
| [FlagC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagC.md) | Gets or sets the carry flag, C. |
| [FlagH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagH.md) | Gets or sets the half-carry flag, H. |
| [FlagN](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagN.md) | Gets or sets the add/subtract flag, N. |
| [FlagPV](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagPV.md) | Gets or sets the parity/overflow flag, P/V. |
| [FlagS](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagS.md) | Gets or sets the sign flag, S. |
| [FlagX](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagX.md) | Gets or sets the undocumented X flag, bit 3 of the F register. |
| [FlagY](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagY.md) | Gets or sets the undocumented Y flag, bit 5 of the F register. |
| [FlagZ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagZ.md) | Gets or sets the zero flag, Z. |
| [Halted](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Halted.md) | Gets or sets whether the CPU is in the halted state. |
| [IFF1](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IFF1.md) | Gets or sets the IFF1 interrupt flip-flop. |
| [IFF2](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IFF2.md) | Gets or sets the IFF2 interrupt flip-flop. |
| [IM](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IM.md) | Gets or sets the interrupt mode. |
| [Interrupt](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Interrupt.md) | Gets or sets whether an interrupt is pending. |
| [IOReader](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IOReader.md) | Gets the IO reader implementation. |
| [IOWriter](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IOWriter.md) | Gets the IO writer implementation. |
| [MutableCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.MutableCycles.md) | A mutable list of [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md)s to update when [RecordCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RecordCycles.md) is `true`, `null` otherwise. |
| [RecordCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RecordCycles.md) | Gets or sets whether CPU cycles should be recorded. |
| [RegisterA](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterA.md) | Gets or sets the A register. |
| [RegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterAF.md) | Gets or sets the AF register pair. |
| [RegisterB](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterB.md) | Gets or sets the B register. |
| [RegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterBC.md) | Gets or sets the BC register pair. |
| [RegisterC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterC.md) | Gets or sets the C register. |
| [RegisterD](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterD.md) | Gets or sets the D register. |
| [RegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterDE.md) | Gets or sets the DE register pair. |
| [RegisterE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterE.md) | Gets or sets the E register. |
| [RegisterF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterF.md) | Gets or sets the F register. |
| [RegisterH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterH.md) | Gets or sets the H register. |
| [RegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterHL.md) | Gets or sets the HL register pair. |
| [RegisterI](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterI.md) | Gets or sets the I register. |
| [RegisterIX](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIX.md) | Gets or sets the IX register pair. |
| [RegisterIXH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIXH.md) | Gets or sets the IXH register. |
| [RegisterIXL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIXL.md) | Gets or sets the IXL register. |
| [RegisterIY](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIY.md) | Gets or sets the IY register pair. |
| [RegisterIYH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIYH.md) | Gets or sets the IYH register. |
| [RegisterIYL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIYL.md) | Gets or sets the IYL register. |
| [RegisterL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterL.md) | Gets or sets the L register. |
| [RegisterPC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterPC.md) | Gets or sets the PC register. |
| [RegisterQ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterQ.md) | Gets or sets the internal Q register. |
| [RegisterR](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterR.md) | Gets or sets the R register. |
| [RegisterSP](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterSP.md) | Gets or sets the SP register. |
| [RegisterWZ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterWZ.md) | Gets or sets the internal WZ register, sometimes called MEMPTR. |
| [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) | Gets or sets the ROM area in memory. Memory writes in this area by the emulator should be ignored. |
| [ShadowRegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterAF.md) | Gets or sets the AF&#39; register pair. |
| [ShadowRegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterBC.md) | Gets or sets the BC&#39; register pair. |
| [ShadowRegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterDE.md) | Gets or sets the DE&#39; register pair. |
| [ShadowRegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterHL.md) | Gets or sets the HL&#39; register pair. |
| [TStates](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TStates.md) | Gets or sets the number of T-states (clock cycles) executed. |

## Methods

| Name | Description |
| ---- | ----------- |
| [AssertEqual&lt;T&gt;(T, T, DefaultInterpolatedStringHandler)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertEqual.md) | Asserts that the actual value is equal to the expected value. If the values are not equal, an error is reported. |
| [AssertFail(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertFail.md) | Signals that a test has failed with the provided error message. |
| [ClearMemory()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ClearMemory.md) | Clears memory. |
| [CopyToMemory(UInt16, ReadOnlySpan&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-readonlyspan((system-byte)))) | Copies a span of bytes into the memory starting at the specified address. |
| [CopyToMemory(UInt16, IReadOnlyList&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-collections-generic-ireadonlylist((system-byte)))) | Copies a sequence of bytes into memory starting at the specified address. |
| [CreateAssertionScope(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CreateAssertionScope.md) | Creates an assertion scope that allows multiple [AssertEqual&lt;T&gt;(T, T, DefaultInterpolatedStringHandler)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertEqual.md) assertions to be made with just one [AssertFail(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertFail.md). |
| [ExecuteInstruction()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ExecuteInstruction.md#mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction) | Executes a single instruction. |
| [ExecuteInstruction(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ExecuteInstruction.md#mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction(system-io-textwriter)) | Executes a single instruction with debug output. |
| [OnRomAreaChanged()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.OnRomAreaChanged.md) | Called when [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) changes. Override to update your emulator with the ROM area. |
| [ReadByteFromMemory(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ReadByteFromMemory.md) | Reads a byte from memory. |
| [ReadWordFromMemory(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ReadWordFromMemory.md) | Reads a word in little endian format from memory. |
| [Reset()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Reset.md) | Resets the test harness state. |
| [SetIO&lt;TIO&gt;(TIO)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.SetIO.md) | Sets both the IO reader and writer to the same implementation. |
| [WriteByteToMemory(UInt16, Byte)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.WriteByteToMemory.md) | Writes a byte to memory. Does *not* take [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) into account as this is used by tests to setup memory. |
| [WriteWordToMemory(UInt16, UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.WriteWordToMemory.md) | Writes a word in little endian format to memory. Does *not* take [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) into account as this is used by tests to setup memory. |

