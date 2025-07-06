# ProgramTestCase.Execute Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)) |  |
| [Execute&lt;TTestHarness&gt;(TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)) |  |

## Execute&lt;TTestHarness&gt;(TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

```c#
public sealed override void Execute<TTestHarness>(TextWriter? testOutput = null)
   where TTestHarness : Z80TestHarness, new();
```

### Type Parameters {id="type-parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

| Name | Description |
| ---- | ----------- |
| TTestHarness |  |

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) |  |

## Execute&lt;TTestHarness&gt;(TextWriter, TextWriter) {id="mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

```c#
public new void Execute<TTestHarness>(TextWriter? testOutput, TextWriter? debugOutput)
   where TTestHarness : Z80TestHarness, new();
```

### Type Parameters {id="type-parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

| Name | Description |
| ---- | ----------- |
| TTestHarness |  |

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) |  |
| debugOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) |  |

