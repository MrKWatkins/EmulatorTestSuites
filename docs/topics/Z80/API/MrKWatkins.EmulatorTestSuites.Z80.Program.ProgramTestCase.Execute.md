# ProgramTestCase.Execute Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)) | Executes the test case with the specified test output. |
| [Execute&lt;TTestHarness&gt;(TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. |

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

Executes the test case with the specified test and debug output.

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
| debugOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional writer for debug output. This will be the state of the emulator before each instruction. |

