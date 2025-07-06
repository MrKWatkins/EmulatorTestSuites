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
| [Cycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Cycles.md) |  |
| [FlagC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagC.md) |  |
| [FlagH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagH.md) |  |
| [FlagN](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagN.md) |  |
| [FlagPV](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagPV.md) |  |
| [FlagS](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagS.md) |  |
| [FlagX](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagX.md) |  |
| [FlagY](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagY.md) |  |
| [FlagZ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.FlagZ.md) |  |
| [Halted](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Halted.md) |  |
| [IFF1](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IFF1.md) |  |
| [IFF2](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IFF2.md) |  |
| [IM](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IM.md) |  |
| [Interrupt](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Interrupt.md) |  |
| [IOReader](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IOReader.md) |  |
| [IOWriter](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.IOWriter.md) |  |
| [MutableCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.MutableCycles.md) |  |
| [RecordCycles](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RecordCycles.md) |  |
| [RegisterA](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterA.md) |  |
| [RegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterAF.md) |  |
| [RegisterB](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterB.md) |  |
| [RegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterBC.md) |  |
| [RegisterC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterC.md) |  |
| [RegisterD](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterD.md) |  |
| [RegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterDE.md) |  |
| [RegisterE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterE.md) |  |
| [RegisterF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterF.md) |  |
| [RegisterH](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterH.md) |  |
| [RegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterHL.md) |  |
| [RegisterI](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterI.md) |  |
| [RegisterIX](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIX.md) |  |
| [RegisterIY](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterIY.md) |  |
| [RegisterL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterL.md) |  |
| [RegisterPC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterPC.md) |  |
| [RegisterQ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterQ.md) |  |
| [RegisterR](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterR.md) |  |
| [RegisterSP](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterSP.md) |  |
| [RegisterWZ](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RegisterWZ.md) |  |
| [ShadowRegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterAF.md) |  |
| [ShadowRegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterBC.md) |  |
| [ShadowRegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterDE.md) |  |
| [ShadowRegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ShadowRegisterHL.md) |  |
| [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) |  |
| [TStates](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TStates.md) |  |

## Methods

| Name | Description |
| ---- | ----------- |
| [AssertEqual&lt;T&gt;(T, T, DefaultInterpolatedStringHandler)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertEqual.md) |  |
| [AssertFail(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertFail.md) |  |
| [CopyToMemory(UInt16, ReadOnlySpan&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-readonlyspan((system-byte)))) |  |
| [CopyToMemory(UInt16, IReadOnlyList&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-collections-generic-ireadonlylist((system-byte)))) |  |
| [CreateAssertionScope(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CreateAssertionScope.md) |  |
| [ExecuteInstruction(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ExecuteInstruction.md) |  |
| [GetByteFromMemory(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.GetByteFromMemory.md) |  |
| [GetWordFromMemory(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.GetWordFromMemory.md) | Gets a word in little endian format from memory. |
| [MemoryRead(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.MemoryRead.md) | Performs a memory read for the emulator. |
| [MemoryWrite(UInt16, Byte)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.MemoryWrite.md) | Performs a memory write for the emulator. Takes [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account and will not overwrite memory in the ROM area. |
| [SetByteInMemory(UInt16, Byte)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.SetByteInMemory.md) | Sets a byte in memory. Does not take [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account so it will update the ROM area. |
| [SetIO&lt;TIO&gt;(TIO)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.SetIO.md) |  |
| [SetWordInMemory(UInt16, UInt16)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.SetWordInMemory.md) | Sets a word in little endian format in memory. Does not take [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account so it will update the ROM area. |
| [Step(UInt64)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80testharness-step(system-uint64)) |  |
| [Step()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80testharness-step) |  |

