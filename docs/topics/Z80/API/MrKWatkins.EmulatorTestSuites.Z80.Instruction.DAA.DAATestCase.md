# DAATestCase Class
## Definition

A test case from the [DAATestSuite](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestSuite.md).

```c#
public sealed class DAATestCase : InstructionTestCase
```

## Properties

| Name | Description |
| ---- | ----------- |
| [Expected](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestCase.Expected.md) | Gets the expected Z80 state after executing the DAA instruction. |
| [Input](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestCase.Input.md) | Gets the initial Z80 state for this test case. |
| [Name](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestCase.Name.md) | Gets the name of the test case, which is the same as its ID. |
| [OpcodeName](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestCase.OpcodeName.md) | Gets the opcode name for the test case. |

## Methods

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.DAA.DAATestCase.Execute.md) | Executes this test case using the specified [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) type. |

