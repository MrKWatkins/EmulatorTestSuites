# Z80N

[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.EmulatorTestSuites.Z80N)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.Z80N)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.EmulatorTestSuites.Z80N)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.Z80N)

> Test suites for [Z80N](https://wiki.specnext.dev/Extended_Z80_instruction_set) emulators.

The Z80N is the Z80 variant in the [ZX Spectrum Next](https://www.specnext.com). It adds instructions in the unused `ED` prefixed
opcodes and is otherwise a Z80, so emulators for it should pass the test suites in
[MrKWatkins.EmulatorTestSuites.Z80](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.Z80) as well as the suites here,
which only cover the instructions the Z80N adds.

The code has not yet reached version 1.0 and should be treated as an alpha release.

## Getting Started

To use the test suites, you will need to:

* Install the relevant NuGet package.
* Implement a test harness class. Each class of tests has an abstract test harness class that it uses to interact with emulators. You will need to create a
  subclass that wraps your emulator. The Z80N suites use the Z80 test harnesses; Z80N emulators should call `WriteNextRegister`
  on the harness when they write to a Next register.
* Create unit tests for the test suites you want to run. These can be in the framework of your choosing and will be simple calls to the test suite class.

Check the [documentation](https://mrkwatkins.github.io/EmulatorTestSuites/Z80N/Z80N.html) for details of the test harnesses and example unit test code.

## Licence

Licensed under GPL v3.0. Licence information for the original project behind each test suite can be found on the relevant page and in source control.
