# Core

[Instruction-based](../Z80/Z80.md#instruction-test-suites) tests for the instructions the Z80N adds to the Z80, written from the
[ZX Spectrum Next FPGA core](https://gitlab.com/SpectrumNext/ZX_Spectrum_Next_FPGA).

## Details

There is no Z80N silicon. The CPU is the T80N core in the ZX Spectrum Next FPGA, so that core is the definitive reference for both the behaviour and the timing
of the instructions it adds, and the tests were written from version 3.02.03 of it:

* `cores/zxnext/src/cpu/t80n_mcode.vhd` gives the machine cycles of each instruction, how many T-states each takes, and the bus activity in each.
* `cores/zxnext/src/cpu/t80n.vhd` gives the behaviour of the instructions the microcode dispatches to the core as Z80N commands.

The T-state totals in the [Extended Z80 instruction set](https://wiki.specnext.dev/Extended_Z80_instruction_set) documentation were used as a cross check. It
warns that its timings are based on limited testing, so the core wins where they disagree.

As well as the registers, flags and interrupt properties, memory, I/O, Next register writes and cycles can all be tested. The opcode has been included in the
name for the test.

## Notes

* `NEXTREG` writes to the Next registers, which are on a bus of their own inside the FPGA rather than on the I/O bus. Writes to them are tested through
  `TestAssertions.NextRegisterWrites` and appear as `CycleType.NextRegisterWrite` cycles rather than as I/O writes.
* The block transfers only write the byte they have read when it does not match A, which is how the ZX Spectrum Next skips transparent pixels. The machine
  cycle still runs when the byte matches; the core reads from the destination instead of writing to it, so `eda4_1` expects a memory read of the destination.
* `ADD HL, A`, `ADD DE, A` and `ADD BC, A` clear the carry flag rather than leaving the flags alone. The core writes the carry from a bit of a temporary that
  its sixteen bit addition never sets, which the wiki also notes.
* The block transfers leave the flags of `LDI`. The wiki says they do not modify any flags, which the core does not agree with; `I_BT` is set unconditionally
  in the microcode they share with `LDI`, and nothing excludes them where the core writes the flags for a block transfer.
* WZ is only asserted where it could be derived from the core. `ADD rr, nn` leaves the immediate in it and `PUSH nn` leaves the low byte of the immediate in Z.

## Original Tests

There are none; the tests were written for this project from the core, which is licensed under the GPL-3.0 licence.
