# Klaus Dormann Functional

> Functional tests from Klaus Dormann for the original NMOS 6502

## The Test Suite

This suite includes Klaus Dormann's `6502_functional_test`, which exercises the documented NMOS 6502 opcodes and addressing modes as a full program.

The packaged test uses the prebuilt `6502_functional_test.bin` image from the upstream repository and treats the terminal self-loop at `$3469` as success. Any
other terminal self-loop is treated as a failure trap.

## Original Tests

The original tests can be found at https://github.com/Klaus2m5/6502_65C02_functional_tests.

The specific binary used here is `bin_files/6502_functional_test.bin`, and the success address was taken from
`bin_files/6502_functional_test.lst`.

Licensed under GPL-3.0. Copyright © 2012-2020 Klaus Dormann.
