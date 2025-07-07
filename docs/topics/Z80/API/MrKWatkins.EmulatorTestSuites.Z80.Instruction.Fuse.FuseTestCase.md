# FuseTestCase Class
## Definition

A test case from the [FuseTestSuite](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse.FuseTestSuite.md).

```c#
public sealed class FuseTestCase : InstructionTestCase
```

## Properties

| Name | Description |
| ---- | ----------- |
| [Expected](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse.FuseTestCase.Expected.md) | Gets the expected Z80 state after executing the DAA instruction. |
| [Input](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse.FuseTestCase.Input.md) | Gets the initial Z80 state for this test case. |
| [OpcodeName](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse.FuseTestCase.OpcodeName.md) | Gets the name of the opcode being tested. |

## Methods

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.Fuse.FuseTestCase.Execute.md) | Executes this test case using the specified [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) type. |

