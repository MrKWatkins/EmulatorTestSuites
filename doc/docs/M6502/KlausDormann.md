# Klaus Dormann

[Program-based](M6502.md#program-test-suites) tests from Klaus Dormann for the original NMOS 6502.

## Details

The current package includes Klaus Dormann's `6502_functional_test` program as a single `KlausDormannTestCase`.

It exercises the documented NMOS 6502 opcodes and addressing modes by running a full program rather than isolated one-instruction scenarios. This makes it a good
complement to the [Single Step](SingleStep.md) suite once your emulator can execute longer sequences reliably.

## Harness Notes

This suite does not report success via printed output. Instead, it reaches a terminal self-loop when it completes:

* instruction-driven harnesses treat the self-loop at `$3469` as success;
* steppable harnesses detect the same terminal loop at `$346C`, because they observe the repeated opcode fetch at the next opcode boundary.

If your emulator supports true step-by-step execution, implement `M6502SteppableTestHarness` so the suite can run your step emulator directly rather than routing
through `ExecuteInstruction()`.

## Example

```c#
public sealed class KlausDormannTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Test(KlausDormannTestCase testCase) => testCase.Execute<MyM6502EmulatorTestHarness>(TestContext.Progress);

    [Pure]
    public static IEnumerable<KlausDormannTestCase> TestCases() => KlausDormannTestSuite.Instance.TestCases;
}
```

## Original Tests

The original tests can be found at [github.com/Klaus2m5/6502_65C02_functional_tests](https://github.com/Klaus2m5/6502_65C02_functional_tests).

The packaged binary used here is `bin_files/6502_functional_test.bin`, and the success loop address was taken from the matching listing file.

Licensed under GPL-3.0. Copyright © 2012-2020 Klaus Dormann.
