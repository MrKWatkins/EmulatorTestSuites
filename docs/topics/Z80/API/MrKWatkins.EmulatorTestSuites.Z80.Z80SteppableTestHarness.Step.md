# Z80SteppableTestHarness.Step Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Step(UInt64)](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)) | Executes the specified number of CPU steps. |
| [Step()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step) | Executes a single step of the CPU. |

## Step(UInt64) {id="mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)"}

Executes the specified number of CPU steps.

```c#
public void Step(ulong count);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| count | [UInt64](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt64) | The number of steps to execute. |

## Step() {id="mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step"}

Executes a single step of the CPU.

```c#
public abstract void Step();
```

