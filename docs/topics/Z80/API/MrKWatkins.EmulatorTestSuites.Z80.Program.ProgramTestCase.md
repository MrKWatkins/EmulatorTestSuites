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
| [Execute&lt;TTestHarness&gt;(TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute-1(system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step if `TTestHarness` is an [IZ80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80SteppableTestHarness.md), or instruction by instruction otherwise. |
| [Execute(IZ80TestHarness, TextWriter, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-iz80testharness-system-io-textwriter-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed instruction by instruction. |
| [Execute(IZ80SteppableTestHarness, TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestCase.Execute.md#mrkwatkins-emulatortestsuites-z80-program-programtestcase-execute(mrkwatkins-emulatortestsuites-z80-iz80steppabletestharness-system-io-textwriter)) | Executes the test case with the specified test and debug output. Execution will proceed step by step. |
