# IOEvent Struct
## Definition

Represents an Input/Output event in the Z80 emulator, containing port and value information.

```c#
public sealed struct IOEvent
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [IOEvent(UInt16, Byte)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.IOEvent.-ctor.md) | Represents an Input/Output event in the Z80 emulator, containing port and value information. |

## Properties

| Name | Description |
| ---- | ----------- |
| [Port](MrKWatkins.EmulatorTestSuites.Z80.Instruction.IOEvent.Port.md) | Gets the I/O port address. |
| [Value](MrKWatkins.EmulatorTestSuites.Z80.Instruction.IOEvent.Value.md) | Gets the value that was read from or written to the port. |

## Methods

| Name | Description |
| ---- | ----------- |
| [ToString()](MrKWatkins.EmulatorTestSuites.Z80.Instruction.IOEvent.ToString.md) | Returns a string representation of the I/O event in hexadecimal format. |

