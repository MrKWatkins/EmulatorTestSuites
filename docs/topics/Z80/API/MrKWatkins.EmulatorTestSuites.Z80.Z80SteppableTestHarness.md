# Z80SteppableTestHarness Class
## Definition

Compatibility base class for a Z80 emulator test harness that supports single cycle stepping. Implement this class to use it with the test suites, or implement [IZ80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80SteppableTestHarness.md) directly.

```c#
public abstract class Z80SteppableTestHarness : Z80TestHarness, IZ80SteppableTestHarness
```

## Constructors

| Name | Description |
| ---- | ----------- |
| [Z80SteppableTestHarness()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.-ctor.md) |  |

## Methods

| Name | Description |
| ---- | ----------- |
| [Step(UInt64)](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step(system-uint64)) | Executes the specified number of CPU steps. |
| [Step()](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.Step.md#mrkwatkins-emulatortestsuites-z80-z80steppabletestharness-step) | Executes a single step of the CPU. |
