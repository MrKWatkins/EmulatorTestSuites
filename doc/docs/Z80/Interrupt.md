# Interrupt

Standalone interrupt and HALT behaviour tests for steppable Z80 emulators.

## Details

These tests exercise interrupt acceptance and related edge cases at micro-step level rather than as simple before/after instruction checks.

The packaged cases cover:

* Interrupt modes 0, 1 and 2.
* Interrupts being ignored when disabled.
* Interrupts being deferred by `EI`.
* `HALT` repeatedly reading the next opcode without advancing `PC`.
* Interrupts releasing `HALT` correctly.
* Overlapped instructions completing before interrupt handling takes over.

The suite requires a steppable emulator because it advances one CPU step at a time and checks the recorded cycle type after each step.

## Notes

* These tests are standalone shared tests, not part of the instruction or program suite families.
* The suite enables `RecordCycles` automatically before execution.
* The programs are encoded directly as raw bytes in the shared suite, with comments indicating the corresponding opcodes.

## Original Tests

Originally based on [https://github.com/floooh/chips-test/blob/master/tests/z80-int.c](https://github.com/floooh/chips-test/blob/master/tests/z80-int.c).
