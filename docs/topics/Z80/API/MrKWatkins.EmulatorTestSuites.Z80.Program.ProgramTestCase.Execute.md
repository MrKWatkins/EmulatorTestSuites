# ProgramTestCase.Execute Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)) | Executes the test case with the specified test output. |
| [Execute&lt;TTestHarness&gt;(TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step if `TTestHarness` is a [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md), or instruction by instruction otherwise. |
| [Execute(Z80TestHarness, TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80testharness-system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed instruction by instruction. |
| [Execute(Z80SteppableTestHarness, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step. |

## Execute&lt;TTestHarness&gt;(TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

Executes the test case with the specified test output.

```c#
public sealed override void Execute<TTestHarness>(TextWriter? testOutput = null)
   where TTestHarness : Z80TestHarness, new();
```

### Type Parameters {id="type-parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

| Name | Description |
| ---- | ----------- |
| TTestHarness | The type of [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) to use. |

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for test output. This will be the output from the test program. |

## Execute&lt;TTestHarness&gt;(TextWriter, TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

Executes the test case with the specified test and debug output. Execution will proceed step by step if `TTestHarness` is a [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md), or instruction by instruction otherwise.

```c#
public new void Execute<TTestHarness>(TextWriter? testOutput, TextWriter? debugOutput)
   where TTestHarness : Z80TestHarness, new();
```

### Type Parameters {id="type-parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

| Name | Description |
| ---- | ----------- |
| TTestHarness | The type of [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) to use. |

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for test output. This will be the output from the test program. |
| debugOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for debug output. This will be the state of the emulator before each instruction. Only used for instruction by instruction execution. |

## Execute(Z80TestHarness, TextWriter, TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80testharness-system-io-textwriter-system-io-textwriter)"}

Executes the test case with the specified test and debug output. Execution will proceed instruction by instruction.

```c#
public new void Execute(Z80TestHarness z80, TextWriter? testOutput = null, TextWriter? debugOutput = null);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80testharness-system-io-textwriter-system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| z80 | [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) | The test harness to use. |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for test output. This will be the output from the test program. |
| debugOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for debug output. This will be the state of the emulator before each instruction. |

## Execute(Z80SteppableTestHarness, TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-system-io-textwriter)"}

Executes the test case with the specified test and debug output. Execution will proceed step by step.

```c#
public new void Execute(Z80SteppableTestHarness z80, TextWriter? testOutput = null);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| z80 | [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md) | The steppable test harness to use. |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for test output. This will be the output from the test program. |

