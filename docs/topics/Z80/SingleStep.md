# Single Step

[Instruction-based](Z80.md#instruction-test-suites) tests from the [Single Step Tests](https://github.com/SingleStepTests) project.

## Details

The suite contains tests for every instruction, documented and undocumented. Each test contains 1000 steps that test the instruction with various inputs.
As well as the registers, flags and interrupt properties memory, I/O and cycles can all be tested. The opcode has been included in the name for the test.

## Notes

* The cycles are incorrect for DD 36 - LD (IY + d), n, FD 36 - LD (IY + d), n, E3 - EX (SP), HL, DD E3 - EX (SP), IX, FD E3 - EX (SP), IY,
  ED 67 - RRD and ED 6F - RLD. This is a known issue; details can be found at [](https://github.com/SingleStepTests/z80/issues/3).
* The tests do not move onto the next opcode after a HALT, so PC will differ if your emulator does this.
* A few tests, namely ED B2 (CPIR), ED B3 (OTIR), ED B9 (CPDR), ED BA (INDR) and ED BB (OTDR), disagree with the [Fuse test suite](Fuse.md) for
  some flags and WZ.

## Original Tests

The original tests can be found at [](https://github.com/SingleStepTests/z80/). Licensed under MIT licence. Copyright © 2024 SingleStepTests.