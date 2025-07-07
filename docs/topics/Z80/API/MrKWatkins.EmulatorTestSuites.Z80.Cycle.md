# Cycle Class
## Definition

Represents a single CPU cycle with its associated type, timing, address, and data information.

```c#
public sealed class Cycle : IEquatable<Cycle>
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [Cycle(CycleType, UInt64, UInt16, Byte?, Boolean)](MrKWatkins.EmulatorTestSuites.Z80.Cycle.-ctor.md) | Represents a single CPU cycle with its associated type, timing, address, and data information. |

## Properties

| Name | Description |
| ---- | ----------- |
| [Address](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Address.md) | Gets the memory address associated with the cycle. |
| [Data](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Data.md) | Gets the data value associated with the cycle, if any. |
| [Index](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Index.md) | Gets the sequential index of the cycle. |
| [IsOpcodeRead](MrKWatkins.EmulatorTestSuites.Z80.Cycle.IsOpcodeRead.md) | Gets a value indicating whether this cycle is reading an opcode. Only set when [Type](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Type.md) is [MemoryRead](MrKWatkins.EmulatorTestSuites.Z80.CycleType.md#fields). |
| [Type](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Type.md) | Gets the type of CPU cycle. |

## Methods

| Name | Description |
| ---- | ----------- |
| [Equals(Cycle)](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Equals.md#mrkwatkins-emulatortestsuites-z80-cycle-equals(mrkwatkins-emulatortestsuites-z80-cycle)) | Indicates whether this [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md) is equal to another [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md). |
| [Equals(Object)](MrKWatkins.EmulatorTestSuites.Z80.Cycle.Equals.md#mrkwatkins-emulatortestsuites-z80-cycle-equals(system-object)) | Determines whether the specified object is equal to this [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md). |
| [GetHashCode()](MrKWatkins.EmulatorTestSuites.Z80.Cycle.GetHashCode.md) | Gets a hash code for this [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md). |
| [ToString()](MrKWatkins.EmulatorTestSuites.Z80.Cycle.ToString.md) | Returns a string representation of this [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md). |

## Operators

| Name | Description |
| ---- | ----------- |
| [op_Equality(Cycle, Cycle)](MrKWatkins.EmulatorTestSuites.Z80.Cycle.op_Equality.md) | Tests if two [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md) instances are equal to each other. |
| [op_Inequality(Cycle, Cycle)](MrKWatkins.EmulatorTestSuites.Z80.Cycle.op_Inequality.md) | Tests if two [Cycle](MrKWatkins.EmulatorTestSuites.Z80.Cycle.md) instances are not equal to each other. |

