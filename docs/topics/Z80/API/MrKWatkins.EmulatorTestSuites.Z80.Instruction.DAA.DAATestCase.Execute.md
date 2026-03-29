# DAATestCase.Execute Method
## Definition

Executes this test case using the specified [IZ80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80TestHarness.md) type.

```c#
public override void Execute<TTestHarness>(TextWriter? testOutput = null)
   where TTestHarness : IZ80TestHarness, new();
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TTestHarness | The type of [IZ80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.IZ80TestHarness.md) to use for execution. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| testOutput | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | Optional [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) for test output. If `null`, no output will be written. |
