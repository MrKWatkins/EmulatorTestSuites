# Cycle Constructors

Represents a single CPU cycle with its associated type, timing, address, and data information.

```c#
public Cycle(CycleType type, ulong index, ushort address, Byte? data, bool isOpcodeRead = false);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [CycleType](MrKWatkins.EmulatorTestSuites.Z80.CycleType.md) | The type of CPU cycle. |
| index | [UInt64](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt64) | The sequential index of the cycle. |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) | The memory address associated with the cycle. |
| data | [Byte?](https://learn.microsoft.com/en-gb/dotnet/api/System.Nullable-1) | The data value associated with the cycle, if any. |
| isOpcodeRead | [Boolean](https://learn.microsoft.com/en-gb/dotnet/api/System.Boolean) | Indicates whether this cycle is reading an opcode. |

