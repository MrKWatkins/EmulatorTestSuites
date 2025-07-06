# Z80TestHarness.SetWordInMemory Method
## Definition

Sets a word in little endian format in memory. Does not take [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account so it will update the ROM area.

```c#
public void SetWordInMemory(ushort address, ushort value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |
| value | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |

