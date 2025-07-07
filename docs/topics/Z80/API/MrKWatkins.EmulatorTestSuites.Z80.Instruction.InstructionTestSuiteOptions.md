# InstructionTestSuiteOptions Record
## Definition

Represents configuration options for [InstructionTestSuite&lt;TTestCase&gt;](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.md)s, controlling which assertions to run and how memory cycles are handled.

```c#
public sealed record InstructionTestSuiteOptions : IEquatable<InstructionTestSuiteOptions>
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [InstructionTestSuiteOptions()](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.-ctor.md) |  |

## Properties

| Name | Description |
| ---- | ----------- |
| [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) | Gets or initializes the default set of [TestAssertions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md) to run for all tests. Defaults to running all available assertions. |
| [AssertionsToRunOverrides](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRunOverrides.md) | Gets or initializes a dictionary of test-specific assertion overrides. Keys are test IDs, and values are the specific assertions to run for that test. Defaults to an empty dictionary. |
| [MemoryCycleMethod](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.MemoryCycleMethod.md) | Gets or initializes the method used for handling memory cycles during test execution. Defaults to using the [Start](MrKWatkins.EmulatorTestSuites.Z80.Instruction.MemoryCycleMethod.md#fields) method. |

