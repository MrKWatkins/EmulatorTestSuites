# Z80TestHarness.MemoryWrite Method
## Definition

Performs a memory write for the emulator. Takes [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account and will not overwrite memory in the ROM area.

```c#
public void MemoryWrite(ushort address, Byte value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |
| value | [Byte](https://learn.microsoft.com/en-gb/dotnet/api/System.Byte) |  |

