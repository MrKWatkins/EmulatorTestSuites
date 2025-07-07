# InstructionTestSuiteOptions.AssertionsToRunOverrides Property
## Definition

Gets or initializes a dictionary of test-specific assertion overrides. Keys are test IDs, and values are the specific assertions to run for that test. Defaults to an empty dictionary.

```c#
public IReadOnlyDictionary<string, TestAssertions> AssertionsToRunOverrides { get; init; }
```

## Property Value

[IReadOnlyDictionary&lt;String, TestAssertions&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyDictionary-2)
