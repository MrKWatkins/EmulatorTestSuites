# IZ80TestHarness Interface
## Definition

Contract for a Z80 emulator test harness.

```c#
public interface IZ80TestHarness
```

## Remarks

This interface defines the harness surface consumed by the Z80 test suites.

The compatibility base class [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) implements this interface and provides the reusable helper behavior for register projections, memory helpers, I/O plumbing, cycle recording, assertion scopes, and debug output.

## See Also

| Name | Description |
| ---- | ----------- |
| [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) | Compatibility base class that implements this interface and provides shared helper implementations. |
| [IZ80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80SteppableTestHarness.md) | Extends this contract with single-cycle stepping support. |
