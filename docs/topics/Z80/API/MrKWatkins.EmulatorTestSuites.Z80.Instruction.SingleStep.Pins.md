# Pins Enum
## Definition

Represents the various control pins and signals used by the Z80 processor during instruction execution. This enum uses flags to allow combinations of different signals.

```c#
public enum Pins
```

## Fields

| Name | Description |
| ---- | ----------- |
| [IO](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Indicates an I/O operation is being performed. |
| [IORead](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Combination of [Read](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) and [IO](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) pins indicating an I/O read operation. |
| [IOWrite](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Combination of [Write](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) and [IO](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) pins indicating an I/O write operation. |
| [Memory](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Indicates a memory operation is being performed. |
| [MemoryRead](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Combination of [Read](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) and [Memory](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) pins indicating a memory read operation. |
| [MemoryWrite](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Combination of [Write](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) and [Memory](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) pins indicating a memory write operation. |
| [None](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | No pins are active. |
| [Read](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Indicates a read operation is being performed. |
| [Write](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Pins.md#fields) | Indicates a write operation is being performed. |

