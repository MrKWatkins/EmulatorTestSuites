# Z80TestHarness.WriteByteToMemory Method
## Definition

Writes a byte to memory. Does *not* take [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) into account as this is used by tests to setup memory.

```c#
public abstract void WriteByteToMemory(ushort address, Byte value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |
| value | [Byte](https://learn.microsoft.com/en-gb/dotnet/api/System.Byte) |  |

