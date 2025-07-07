# ProgramTestSuite&lt;TTestCase&gt; Class
## Definition

Base class for program-based test suites that provide `TTestCase`s for Z80 emulator implementations.

```c#
public abstract class ProgramTestSuite<TTestCase> : TestSuite
   where TTestCase : TestCase
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TTestCase | The type of test cases provided by this test suite. |

## Properties

| Name | Description |
| ---- | ----------- |
| [TestCases](MrKWatkins.EmulatorTestSuites.Z80.Program.ProgramTestSuite-1.TestCases.md) | Gets the list of test cases in this test suite. |

## See Also

[Documentation](https://mrkwatkins.github.io/EmulatorTestSuites/z80.html#program-test-suites)
