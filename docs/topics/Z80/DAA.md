# DAA

[Instruction-based](Z80.md#instruction-test-suites) tests for the output of the DAA instruction for all combinations of the A register and the N, C and H flags.

## Details

The DAA instruction is one of the more complicated Z80 instructions. It adjusts the accumulator for [BCD](https://en.wikipedia.org/wiki/Binary-coded_decimal)
addition, based on the accumulator's value and the N, C and H flags. This suite tests every possible combination of A, N, C and H.

## Original Tests

The original tests can be found at [](https://github.com/ruyrybeyro/daatable). Licensed under BSD-3-Clause licence. Copyright © 2019, Rui Ribeiro.