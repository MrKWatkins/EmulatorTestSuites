# RaxoftTestType Enum
## Definition

```c#
public enum RaxoftTestType
```

## Fields

| Name | Description |
| ---- | ----------- |
| [Ccf](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests all flags after executing CCF after each instruction tested. |
| [Doc](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests all registers but only the officially documented flags. |
| [DocFlags](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests documented flags only, ignores registers. |
| [Flags](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests all flags, ignores registers. |
| [Full](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests all flags and registers. |
| [Memptr](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md#fields) | Tests all flags after executing BIT N,(HL) after each instruction tested. |

