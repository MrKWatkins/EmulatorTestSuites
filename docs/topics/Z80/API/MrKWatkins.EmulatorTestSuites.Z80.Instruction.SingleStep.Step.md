# Step Class
## Definition

Represents a single step in a [SingleStepTestCase](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.SingleStepTestCase.md) containing input state and expected output state.

```c#
public sealed class Step
```

## Properties

| Name | Description |
| ---- | ----------- |
| [Expected](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Step.Expected.md) | Gets the expected state of the Z80 after executing this step. |
| [Index](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Step.Index.md) | Gets the zero-based index of this step within the test case. |
| [Input](MrKWatkins.EmulatorTestSuites.Z80.Instruction.SingleStep.Step.Input.md) | Gets the input state of the Z80 for this step. |

