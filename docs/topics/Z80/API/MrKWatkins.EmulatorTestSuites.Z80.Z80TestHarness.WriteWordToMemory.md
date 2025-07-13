# Z80TestHarness.WriteWordToMemory Method
## Definition

Writes a word in little endian format to memory. Does *not* take [RomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.RomArea.md) into account as this is used by tests to setup memory.

```c#
public void WriteWordToMemory(ushort address, ushort value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |
| value | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |

