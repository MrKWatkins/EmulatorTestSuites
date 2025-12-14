# ProgramTestCase Class
## Definition

Base class for Z80 test cases that execute a full program and verify the results.

```c#
public abstract class ProgramTestCase : TestCase
```

## Methods

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter)) | Executes the test case with the specified test output. |
| [Execute&lt;TTestHarness&gt;(TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step if `TTestHarness` is a [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md), or instruction by instruction otherwise. |
| [Execute(Z80TestHarness, TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80testharness-system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed instruction by instruction. |
| [Execute(Z80SteppableTestHarness, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step. |

