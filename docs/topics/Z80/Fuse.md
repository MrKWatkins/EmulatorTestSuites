# Fuse

[Instruction-based](Z80.md#instruction-test-suites) tests from the [Fuse emulator](https://fuse-emulator.sourceforge.net/) project.

## Details

The suite contains tests for every instruction, documented and undocumented. As well as the registers, flags and interrupt properties memory, I/O and cycles
can all be tested. The behaviour of DD FD is also tested. The opcode has been included in the name for the test.

## Notes

* Fuse does not read the offset byte after DJNZ or a conditional JR if the jump does not proceed. This means it misses a read cycle compared to the Z80. Cycles
  will differ if your emulator always reads the offset.
* Fuse does not move onto the next opcode after a HALT, so PC will differ if your emulator does this.
* A few tests, namely edb2_1 - CPIR, edb3_1 - OTIR, edb9_2 - CPDR, edba_1 - INDR and edbb_1 - OTDR, disagree with the [Single Step test suite](SingleStep.md)
  for some flags and WZ.

## Original Tests

The original tests can be found at [](https://sourceforge.net/p/fuse-emulator/fuse/ci/master/tree/z80/tests/). Licensed under GPL-2.0 licence. Copyright © Philip Kendall.