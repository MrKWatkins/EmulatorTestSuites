# DAATestCase.Execute Method
## Definition

Executes this test case using the specified [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) type.

```c#
public override void Execute<TTestHarness>(TextWriter? testOutput = null)
   where TTestHarness : Z80TestHarness, new();
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TTestHarness | The type of [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) to use for execution. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) for test output. If `null`, no output will be written. |

