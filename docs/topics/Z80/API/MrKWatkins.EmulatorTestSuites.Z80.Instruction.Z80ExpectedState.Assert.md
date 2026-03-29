# Z80ExpectedState.Assert Method
## Definition

Asserts that the actual Z80 state matches the expected state according to the specified assertions.

```c#
public void Assert(TestAssertions assertionsToRun, IZ80TestHarness z80);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| assertionsToRun | [TestAssertions](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md) | The set of assertions to perform. |
| z80 | [IZ80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80TestHarness.md) | The Z80 test harness containing the actual state to verify. |
