# Z80

[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.EmulatorTestSuites.Z80)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.Z80)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.EmulatorTestSuites.Z80)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.Z80)

> Test suites for [Zilog Z80 CPU](https://en.wikipedia.org/wiki/Zilog_Z80) emulators.

This repository contains various Z80 emulator test suites from around the web and packages them up in a C# library to make them easier to run.

The code has not yet reached version 1.0 and should be treated as an alpha release.

## Getting Started

To use the test suites, you will need to:

* Install the relevant NuGet package.
* Implement a test harness class. Each class of tests has an abstract test harness class that it uses to interact with emulators. You will need to create a
  subclass that wraps your emulator.
* Create unit tests for the test suites you want to run. These can be in the framework of your choosing and will be simple calls to the TestSuite class.

Check the [documentation](https://mrkwatkins.github.io/EmulatorTestSuites/z80.html) for details of the test harnesses and example unit test code.

## Licence

Licensed under GPL v3.0. Licence information for the original project behind each test suite can be found on the relevant page and in source control.