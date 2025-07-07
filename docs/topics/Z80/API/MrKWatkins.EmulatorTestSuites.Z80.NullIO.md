# NullIO Class
## Definition

A null implementation of I/O operations that returns a constant value for reads and ignores writes.

```c#
public sealed class NullIO : IIOReader, IIOWriter
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [NullIO(Byte)](MrKWatkins.EmulatorTestSuites.Z80.NullIO.-ctor.md) | A null implementation of I/O operations that returns a constant value for reads and ignores writes. |

## Methods

| Name | Description |
| ---- | ----------- |
| [Read(UInt16)](MrKWatkins.EmulatorTestSuites.Z80.NullIO.Read.md) | Reads a byte from the specified I/O port. |
| [Write(UInt16, Byte)](MrKWatkins.EmulatorTestSuites.Z80.NullIO.Write.md) | Writes a byte to the specified I/O port. This implementation ignores the write operation. |

