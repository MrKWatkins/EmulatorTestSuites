# Timing

Tests from the [ZXSpectrum4.net](https://www.zxspectrum4.net) team's 48K ZX Spectrum timing test suite.

## Details

The packaged suite currently includes 34 regular timing groups in both uncontended and contended forms, plus four ROM/BASIC-backed variants (35 uncontended, and 35-37 contended), for 72 test cases in total.

Each test runs the bundled program on a `ZXSpectrumTestHarness`, reads back the measured values for the R register, loop counter and stack pointer from the
composed Z80 harness, and compares them with the expected values embedded in the test data.

The suite automatically detects whether the emulator behaves like an early-timing or late-timing machine and then uses the matching expected values.

## Notes

* There are two sets of tests, contended and uncontended. The contended tests require ZX Spectrum memory/IO contention to be implemented to pass.
* Note that despite the naming some of the uncontended tests also require contention to pass. They are 22 "LD A,(ii+n); LD r,(ii+n)", 32 "INI; INIR; IND; INDR", 33 "OUTI; OTIR; OUTD; OTDR" and 34 "RST 18".
* Tests 35, 36 and 37 require a 48K-style floating bus implementation as well as the usual Spectrum timing behaviour to pass.
* The test harness must expose `StartFrame()` so the tests can synchronise to a Spectrum frame. If the composed Z80 harness is steppable, the tests will use step execution; otherwise they run instruction-by-instruction.

## Original Tests

The original tests can be found at [https://www.zxspectrum4.net/op_timing.php](https://www.zxspectrum4.net/op_timing.php).

The tests require the ZX Spectrum 48k ROM. ZX Spectrum ROMs are included. Amstrad have given their permission to distribute the ROM;
full details can be found at [https://worldofspectrum.net/app/themes/wosc-classic/static/legacy/amstrad-roms.txt](https://worldofspectrum.net/app/themes/wosc-classic/static/legacy/amstrad-roms.txt). Copyright © Amstrad
and Sinclair.
