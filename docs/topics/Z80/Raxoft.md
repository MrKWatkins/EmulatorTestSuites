# Raxoft

[Program-based](Z80.md#program-test-suites) tests from the [Raxoft test suite](https://github.com/raxoft/z80test).

## Details

The suite has six variants which test various instructions:

1. Full - tests all flags and registers.
2. Doc - tests all registers but only officially documented flags.
3. Flags - tests all flags, ignores registers.
4. DocFlags - tests documented flags only, ignores registers.
5. Ccf - tests all flags after executing CCF after each instruction tested.
6. Memptr - tests all flags after executing BIT N, (HL) after each instruction tested.

Two versions of the test suite are currently included, 1.0 and 1.2a.

## Original Tests

The original tests can be found at [](https://github.com/raxoft/z80test). Licensed under MIT licence. Copyright © 2012-2023 Patrik Rak.
