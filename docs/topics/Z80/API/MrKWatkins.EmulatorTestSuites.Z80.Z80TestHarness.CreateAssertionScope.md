# Z80TestHarness.CreateAssertionScope Method
## Definition

Creates an assertion scope that allows multiple [AssertEqual&lt;T&gt;(T, T, DefaultInterpolatedStringHandler)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertEqual.md) assertions to be made with just one [AssertFail(String)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.AssertFail.md).

```c#
public IDisposable CreateAssertionScope(string? name = null);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [String](https://learn.microsoft.com/en-gb/dotnet/api/System.String) | Optional name for the scope. |

## Returns

[IDisposable](https://learn.microsoft.com/en-gb/dotnet/api/System.IDisposable)

An [IDisposable](https://learn.microsoft.com/en-gb/dotnet/api/System.IDisposable) that finishes the scope.
