# Timing

[Program-based](Z80.md#program-test-suites) tests from the [ZXSpectrum4.net](https://www.zxspectrum4.net) team's 48K ZX Spectrum timing test suite.

## Details

The packaged suite currently includes 34 timing groups, each in both uncontended and contended forms, for 68 test cases in total.

Each test runs the bundled program, reads back the measured values for the R register, loop counter and stack pointer, and compares them with the
expected values embedded in the test data.

The suite automatically detects whether the emulator behaves like an early-timing or late-timing machine and then uses the matching expected values.

## Notes

* There are two sets of tests, contended and uncontended. The contended tests are designed for the ZX Spectrum specifically; they require memory/IO contention to be implemented to pass.
* Note that despite the naming some of the uncontended tests also require contention to pass! They are 22 "LD A,(ii+n); LD r,(ii+n)", 32 "INI; INIR; IND; INDR", 33 "OUTI; OTIR; OUTD; OTDR" and 34 "RST 18".

## Original Tests

The original tests can be found at [https://www.zxspectrum4.net/op_timing.php](https://www.zxspectrum4.net/op_timing.php).

The tests require the ZX Spectrum 48k ROM. ZX Spectrum ROMs are included. Amstrad have given their permission to distribute the ROM;
full details can be found at [https://worldofspectrum.net/app/themes/wosc-classic/static/legacy/amstrad-roms.txt](https://worldofspectrum.net/app/themes/wosc-classic/static/legacy/amstrad-roms.txt). Copyright © Amstrad
and Sinclair.
