# Z80TestHarness.ExecuteInstruction Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [ExecuteInstruction()](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ExecuteInstruction.md#mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction) | Executes a single instruction. |
| [ExecuteInstruction(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.ExecuteInstruction.md#mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction(system-io-textwriter)) | Executes a single instruction with debug output. |

## ExecuteInstruction() {id="mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction"}

Executes a single instruction.

```c#
public abstract void ExecuteInstruction();
```

## ExecuteInstruction(TextWriter) {id="mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction(system-io-textwriter)"}

Executes a single instruction with debug output.

```c#
public void ExecuteInstruction(TextWriter? debug);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-z80testharness-executeinstruction(system-io-textwriter)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| debug | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional TextWriter for debug output. |

