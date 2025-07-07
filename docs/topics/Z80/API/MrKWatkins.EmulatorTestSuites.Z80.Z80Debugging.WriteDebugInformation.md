# Z80Debugging.WriteDebugInformation Method
## Definition

Writes debugging information for the specified [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) to the specified [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter).

```c#
public static void WriteDebugInformation(Z80TestHarness z80, TextWriter? debug);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| z80 | [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) | The [Z80TestHarness](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.md) to be described in the debugging output. |
| debug | [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) | The [TextWriter](https://learn.microsoft.com/en-gb/dotnet/api/System.IO.TextWriter) to write debug information to. If `null`, no output will be written. |

