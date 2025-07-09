# Z80SteppableTestHarness.Step Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [Step(UInt64)](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)) | Executes CPU steps until the specified number of T-states are reached. |
| [Step()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step) | Executes a single step of the CPU. |

## Step(UInt64) {id="mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)"}

Executes CPU steps until the specified number of T-states are reached.

```c#
public void Step(ulong tStates);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| tStates | [UInt64](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt64) | The target T-states to reach. |

## Step() {id="mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step"}

Executes a single step of the CPU.

```c#
public abstract void Step();
```

