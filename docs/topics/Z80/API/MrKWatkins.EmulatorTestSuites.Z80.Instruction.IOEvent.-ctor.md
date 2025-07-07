# IOEvent Constructors

Represents an Input/Output event in the Z80 emulator, containing port and value information.

```c#
public IOEvent(ushort port, Byte value);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| port | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) | The I/O port address. |
| value | [Byte](https://learn.microsoft.com/en-gb/dotnet/api/System.Byte) | The value read from or written to the port. |

