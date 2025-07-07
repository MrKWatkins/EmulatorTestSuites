# TestCase Class
## Definition

Base class for test cases that validate Z80 emulator implementations.

```c#
public abstract class TestCase
```

## Properties

| Name | Description |
| ---- | ----------- |
| [Id](MrKWatkins.EmulatorTestSuites.Z80.TestCase.Id.md) | Gets the unique identifier for this test case. |
| [Name](MrKWatkins.EmulatorTestSuites.Z80.TestCase.Name.md) | Gets the display name of the test case. By default, returns the [Id](MrKWatkins.EmulatorTestSuites.Z80.TestCase.Id.md). |

## Methods

| Name | Description |
| ---- | ----------- |
| [Execute&lt;TTestHarness&gt;(TextWriter)](MrKWatkins.EmulatorTestSuites.Z80.TestCase.Execute.md) | Executes this test case using the specified [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) type. |
| [ToString()](MrKWatkins.EmulatorTestSuites.Z80.TestCase.ToString.md) | Returns a string representation of this [TestCase](MrKWatkins.EmulatorTestSuites.Z80.TestCase.md). |

