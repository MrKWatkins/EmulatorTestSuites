# Z80TestHarness.AssertEqual Method
## Definition

Asserts that the actual value is equal to the expected value. If the values are not equal, an error is reported.

```c#
public void AssertEqual<T>(T? actual, T? expected, DefaultInterpolatedStringHandler message);
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| T | The type of the values being compared. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| actual | T | The actual value to be checked. |
| expected | T | The expected value to compare against. |
| message | [DefaultInterpolatedStringHandler](https://learn.microsoft.com/en-gb/dotnet/api/System.Runtime.CompilerServices.DefaultInterpolatedStringHandler) | An interpolated string handler providing a custom error message if the values are not equal. |

