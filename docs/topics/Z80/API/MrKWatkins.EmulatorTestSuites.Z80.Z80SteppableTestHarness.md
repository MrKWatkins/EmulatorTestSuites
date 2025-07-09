# Z80SteppableTestHarness Class
## Definition

Base class for a Z80 emulator test harness that supports single cycle stepping. Implement this class to use it with the test suites.

```c#
public abstract class Z80SteppableTestHarness : Z80TestHarness
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [Z80SteppableTestHarness()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.-ctor.md) |  |

## Methods

| Name | Description |
| ---- | ----------- |
| [Step(UInt64)](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)) | Executes CPU steps until the specified number of T-states are reached. |
| [Step()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step) | Executes a single step of the CPU. |

