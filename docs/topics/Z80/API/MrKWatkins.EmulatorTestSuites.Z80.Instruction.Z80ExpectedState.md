# Z80ExpectedState Class
## Definition

Represents the expected state of a Z80 after executing an [InstructionTestCase](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestCase.md).

```c#
public class Z80ExpectedState : Z80State
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [Z80ExpectedState()](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80ExpectedState.-ctor.md) |  |

## Properties

| Name | Description |
| ---- | ----------- |
| [Cycles](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80ExpectedState.Cycles.md) | Gets the expected list of cycles that occurred during instruction execution. |
| [IOWrites](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80ExpectedState.IOWrites.md) | Gets the expected list of I/O write events that occurred during instruction execution. |
| [TStates](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80ExpectedState.TStates.md) | Gets the expected number of T-states taken to execute the instruction. |

## Methods

| Name | Description |
| ---- | ----------- |
| [Assert(TestAssertions, Z80TestHarness)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Z80ExpectedState.Assert.md) | Asserts that the actual Z80 state matches the expected state according to the specified assertions. |

