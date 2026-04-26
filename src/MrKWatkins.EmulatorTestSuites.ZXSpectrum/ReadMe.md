# ZX Spectrum

[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.EmulatorTestSuites.ZXSpectrum)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.ZXSpectrum)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.EmulatorTestSuites.ZXSpectrum)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.ZXSpectrum)

> Test suites for [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum) emulators.

This package contains emulator test suites that depend on ZX Spectrum machine behaviour such as ULA timing, contention, frame alignment and floating-bus behaviour.

The code has not yet reached version 1.0 and should be treated as an alpha release.

## Getting Started

To use the test suites, you will need to:

* Install the relevant NuGet package.
* Implement a test harness class. Each class of tests has an abstract test harness class that it uses to interact with emulators. You will need to create a
  subclass that wraps your emulator.
* Create unit tests for the test suites you want to run. These can be in the framework of your choosing and will be simple calls to the test suite class.

Check the [documentation](https://mrkwatkins.github.io/EmulatorTestSuites/zxspectrum.html) for details of the test harnesses and example unit test code.

## Licence

Licensed under GPL v3.0. Licence information for the original project behind each test suite can be found on the relevant page and in source control.
