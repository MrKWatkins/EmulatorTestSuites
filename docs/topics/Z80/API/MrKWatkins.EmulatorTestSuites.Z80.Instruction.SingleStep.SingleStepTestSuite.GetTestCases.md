# SingleStepTestSuite.GetTestCases Method
## Definition

Gets all the test cases using the specified [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md).

```c#
public override IEnumerable<SingleStepTestCase> GetTestCases(InstructionTestSuiteOptions options);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md) |  |

## Returns

[IEnumerable&lt;SingleStepTestCase&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1)

A sequence of test cases.
