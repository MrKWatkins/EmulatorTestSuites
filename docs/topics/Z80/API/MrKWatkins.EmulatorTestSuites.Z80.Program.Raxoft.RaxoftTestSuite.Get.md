# RaxoftTestSuite.Get Method
## Definition

Gets a test suite instance for the specified [RaxoftTestType](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md) and [RaxoftTestVersion](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestVersion.md).

```c#
public static RaxoftTestSuite Get(RaxoftTestType type, RaxoftTestVersion version = RaxoftTestVersion.MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestVersion);
```

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [RaxoftTestType](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestType.md) | The type of test suite to retrieve. |
| version | [RaxoftTestVersion](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestVersion.md) | The version of the test suite to retrieve. Defaults to [V1_2A](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestVersion.md#fields). |

## Returns

[RaxoftTestSuite](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestSuite.md)

The corresponding [RaxoftTestSuite](MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft.RaxoftTestSuite.md) instance.
