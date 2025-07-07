# Z80State Class
## Definition

Represents the state of a Z80 processor, including registers, flags, and memory.

```c#
public abstract class Z80State
```

## Properties

| Name | Description |
| ---- | ----------- |
| [FlagC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagC.md) | Gets the carry flag, C. |
| [FlagH](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagH.md) | Gets the half-carry flag, H. |
| [FlagN](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagN.md) | Gets the add/subtract flag, N. |
| [FlagPV](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagPV.md) | Gets the parity/overflow flag, P/V. |
| [FlagS](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagS.md) | Gets the sign flag, S. |
| [FlagX](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagX.md) | Gets the undocumented X flag, bit 3 of the F register. |
| [FlagY](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagY.md) | Gets the undocumented Y flag, bit 5 of the F register. |
| [FlagZ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.FlagZ.md) | Gets the zero flag, Z. |
| [Halted](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.Halted.md) | Gets whether the CPU is in the halted state. |
| [IFF1](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.IFF1.md) | Gets the IFF1 interrupt flip-flop. |
| [IFF2](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.IFF2.md) | Gets the IFF2 interrupt flip-flop. |
| [IM](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.IM.md) | Gets the interrupt mode. |
| [Memory](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.Memory.md) | Gets the memory state. |
| [RegisterA](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterA.md) | Gets the A register. |
| [RegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterAF.md) | Gets the AF register pair. |
| [RegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterBC.md) | Gets the BC register pair. |
| [RegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterDE.md) | Gets the DE register pair. |
| [RegisterF](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterF.md) | Gets the F register. |
| [RegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterHL.md) | Gets the HL register pair. |
| [RegisterI](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterI.md) | Gets the I register. |
| [RegisterIX](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterIX.md) | Gets the IX register pair. |
| [RegisterIY](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterIY.md) | Gets the IY register pair. |
| [RegisterPC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterPC.md) | Gets the PC register. |
| [RegisterQ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterQ.md) | Gets the internal Q register. |
| [RegisterR](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterR.md) | Gets the R register. |
| [RegisterSP](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterSP.md) | Gets the SP register. |
| [RegisterWZ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.RegisterWZ.md) | Gets the internal WZ register, sometimes called MEMPTR. |
| [ShadowRegisterAF](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.ShadowRegisterAF.md) | Gets the AF&#39; register pair. |
| [ShadowRegisterBC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.ShadowRegisterBC.md) | Gets the BC&#39; register pair. |
| [ShadowRegisterDE](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.ShadowRegisterDE.md) | Gets the DE&#39; register pair. |
| [ShadowRegisterHL](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80State.ShadowRegisterHL.md) | Gets the HL&#39; register pair. |

