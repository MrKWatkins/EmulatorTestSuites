# InstructionTestSuite&lt;TTestCase&gt; Class
## Definition

Base class for instruction-based test suites that provide `TTestCase`s for Z80 emulator implementations.

```c#
public abstract class InstructionTestSuite<TTestCase> : TestSuite
   where TTestCase : InstructionTestCase
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TTestCase | The type of test cases provided by this test suite. |

## Properties

| Name | Description |
| ---- | ----------- |
| [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md) | The default [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md) for the test suite. |

## Methods

| Name | Description |
| ---- | ----------- |
| [GetTestCases()](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases) | Gets all the test cases using the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md). |
| [GetTestCases(TestAssertions)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-testassertions)) | Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md). |
| [GetTestCases(IReadOnlyDictionary&lt;String, TestAssertions&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(system-collections-generic-ireadonlydictionary((system-string-mrkwatkins-emulatortestsuites-z80-instruction-testassertions)))) | Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md) for specific tests. |
| [GetTestCases(InstructionTestSuiteOptions)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuiteoptions)) | Gets all the test cases using the specified [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md). |

## See Also

[Documentation](https://mrkwatkins.github.io/EmulatorTestSuites/z80.html#instruction-test-suites)
