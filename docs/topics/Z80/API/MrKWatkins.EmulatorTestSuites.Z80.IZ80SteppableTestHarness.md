# IZ80SteppableTestHarness Interface
## Definition

Contract for a Z80 emulator test harness that supports single cycle stepping.

```c#
public interface IZ80SteppableTestHarness : IZ80TestHarness
```

## Remarks

This interface extends [IZ80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80TestHarness.md) with `Step` and `Step(UInt64)` so the interrupt and timing suites can require stepping support without depending on the compatibility base class directly.

The compatibility base class [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md) implements this interface and provides the reusable step helper methods.

## See Also

| Name | Description |
| ---- | ----------- |
| [IZ80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80TestHarness.md) | Shared harness contract used by the suites. |
| [Z80SteppableTestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80SteppableTestHarness.md) | Compatibility base class that implements this interface. |
