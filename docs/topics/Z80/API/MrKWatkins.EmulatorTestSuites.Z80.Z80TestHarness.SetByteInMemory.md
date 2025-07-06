# Z80TestHarness.SetByteInMemory Method
## Definition

Sets a byte in memory. Does not take [TopOfRomArea](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.TopOfRomArea.md) into account so it will update the ROM area.

```c#
public void SetByteInMemory(ushort address, Byte value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) |  |
| value | [Byte](https://learn.microsoft.com/en-gb/dotnet/api/System.Byte) |  |

