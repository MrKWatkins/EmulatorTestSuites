# MemoryCycleMethod Enum
## Definition

How memory cycles are represented in a Z80 emulator.

```c#
public enum MemoryCycleMethod
```

## Fields

| Name | Description |
| ---- | ----------- |
| [Accurate](MrKWatkins.EmulatorTestSuites.Z80.Instruction.MemoryCycleMethod.md#fields) | Memory read cycles (MREQ + RD) last for two T-States. Memory write cycles (MREQ + MW) last for one cycle, on the second cycle. (Because first is just MREQ, no MW) |
| [End](MrKWatkins.EmulatorTestSuites.Z80.Instruction.MemoryCycleMethod.md#fields) | Memory read (MREQ + RD) and write (MREQ + MW) cycles last for one T-State on the second T-State. |
| [Start](MrKWatkins.EmulatorTestSuites.Z80.Instruction.MemoryCycleMethod.md#fields) | Memory read (MREQ + RD) and write (MREQ + MW) cycles last for one T-State on the first T-State. |

