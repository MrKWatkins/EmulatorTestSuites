# InstructionTestSuite&lt;TTestCase&gt;.GetTestCases Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [GetTestCases()](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases) | Gets all the test cases using the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md). |
| [GetTestCases(TestAssertions)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-testassertions)) | Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md). |
| [GetTestCases(IReadOnlyDictionary&lt;String, TestAssertions&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(system-collections-generic-ireadonlydictionary((system-string-mrkwatkins-emulatortestsuites-z80-instruction-testassertions)))) | Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md) for specific tests. |
| [GetTestCases(InstructionTestSuiteOptions)](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.GetTestCases.md#mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuiteoptions)) | Gets all the test cases using the specified [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md). |

## GetTestCases() {id="mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases"}

Gets all the test cases using the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md).

```c#
public IEnumerable<TTestCase> GetTestCases();
```

## Returns {id="returns-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases"}

[IEnumerable&lt;TTestCase&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1)

A sequence of test cases.
## GetTestCases(TestAssertions) {id="mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-testassertions)"}

Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md).

```c#
public IEnumerable<TTestCase> GetTestCases(TestAssertions assertionsToRun);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-testassertions)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertionsToRun | [TestAssertions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md) |  |

## Returns {id="returns-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-testassertions)"}

[IEnumerable&lt;TTestCase&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1)

A sequence of test cases.
## GetTestCases(IReadOnlyDictionary&lt;String, TestAssertions&gt;) {id="mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(system-collections-generic-ireadonlydictionary((system-string-mrkwatkins-emulatortestsuites-z80-instruction-testassertions)))"}

Gets all the test cases, overriding the [AssertionsToRun](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.AssertionsToRun.md) on the [DefaultOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuite-1.DefaultOptions.md) for specific tests.

```c#
public IEnumerable<TTestCase> GetTestCases(IReadOnlyDictionary<string, TestAssertions> assertionsToRunOverrides);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(system-collections-generic-ireadonlydictionary((system-string-mrkwatkins-emulatortestsuites-z80-instruction-testassertions)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertionsToRunOverrides | [IReadOnlyDictionary&lt;String, TestAssertions&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2) |  |

## Returns {id="returns-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(system-collections-generic-ireadonlydictionary((system-string-mrkwatkins-emulatortestsuites-z80-instruction-testassertions)))"}

[IEnumerable&lt;TTestCase&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1)

A sequence of test cases.
## GetTestCases(InstructionTestSuiteOptions) {id="mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuiteoptions)"}

Gets all the test cases using the specified [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md).

```c#
public abstract IEnumerable<TTestCase> GetTestCases(InstructionTestSuiteOptions options);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuiteoptions)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| options | [InstructionTestSuiteOptions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.InstructionTestSuiteOptions.md) |  |

## Returns {id="returns-mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuite-1-gettestcases(mrkwatkins-emulatortestsuites-z80-instruction-instructiontestsuiteoptions)"}

[IEnumerable&lt;TTestCase&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IEnumerable-1)

A sequence of test cases.
