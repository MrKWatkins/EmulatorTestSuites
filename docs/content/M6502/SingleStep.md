# Single Step

[Instruction-based](M6502.md) tests from the [Single Step Tests](https://github.com/SingleStepTests) project.

## Details

The suite currently packages the base `6502/v1` dataset from the `SingleStepTests/65x02` repository. It contains one test case per opcode, and each opcode
contains 10,000 one-instruction scenarios with initial state, expected final state, memory changes, and per-cycle bus activity.

These tests validate:

* registers `A`, `X`, `Y`, `S`, `P`, and `PC`;
* memory after a single instruction; and
* the read/write cycles performed while executing that instruction.

The suite currently exposes 256 `SingleStepTestCase` instances, one for each opcode in the base 6502 set:

```c#
var testCases = SingleStepTestSuite.Instance.GetTestCases();
```

Each `SingleStepTestCase` executes all 10,000 scenarios for that opcode. The optional `TextWriter` passed to `Execute` writes simple progress output, which is
useful when running the larger opcode tests in a unit test runner.

## Harness Notes

The 6502 Single Step tests are stricter than simple register-only tests:

* `P` is compared as a full byte, so your harness must expose the processor status register exactly as your emulator uses it for execution.
* cycle assertions compare the sequence of read and write bus accesses, including the address and data for each cycle.
* there is no separate I/O model in this suite; all bus activity is represented as `CycleType.Read` and `CycleType.Write`.

If your emulator already tracks bus access internally, mapping that information into `Cycle` instances in `MutableCycles` is usually the easiest way to make
the suite pass.

## Example

It is often useful to start with a small subset of opcodes while bringing an emulator up:

```c#
public sealed class LoadAccumulatorTests
{
    [TestCaseSource(nameof(TestCases))]
    public void SingleStep(SingleStepTestCase testCase) => testCase.Execute<MyM6502EmulatorTestHarness>();

    [Pure]
    public static IEnumerable<SingleStepTestCase> TestCases() =>
        SingleStepTestSuite.Instance.GetTestCases().Where(t => t.Id is "a9" or "a5" or "ad");
}
```

## Original Tests

The original tests can be found at [github.com/SingleStepTests/65x02/tree/main/6502](https://github.com/SingleStepTests/65x02/tree/main/6502).
Licensed under MIT licence. Copyright © 2024 Thomas Harte et al.
