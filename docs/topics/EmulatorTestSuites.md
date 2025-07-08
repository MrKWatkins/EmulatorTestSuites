# Emulator Test Suites

[![Build Status](https://github.com/MrKWatkins/EmulatorTestSuites/actions/workflows/build.yml/badge.svg)](https://github.com/MrKWatkins/EmulatorTestSuites/actions/workflows/build.yml)

<procedure id="zexall-in-rider">
  <img src="zexall-in-rider.png" alt="View of the ZEXALL test suite executed in Jetbrains' Rider" />
  View of the ZEXALL test suite executed in <a href="https://www.jetbrains.com/rider/">Jetbrains' Rider</a>
</procedure>

This repository contains various emulator test suites from around the web and packages them up in a .NET library to make them easier to run.
Various standard emulator tests suites are included. Everything is designed to be agnostic to emulators and unit test frameworks. Implement
a wrapper for your emulator (which does not have to be coded in .NET provided you can wrap it with .NET) and then run the tests via your unit
test framework of choice. Each test can be run independently, even when the original test suite only allows running all their tests in one block.

The test suites are being used to test an emulator I am developing, and the code base is fairly mature. Despite that, the code has not yet reached
version 1.0 and should be treated as a beta release.

## Getting Started

To use the test suites, you will need to:

* Install the relevant NuGet package.
* Implement a test harness class. Each class of tests has an abstract test harness class that it uses to interact with emulators. You will need to create a 
  subclass that wraps your emulator.
* Create unit tests for the test suites you want to run. These can be in the framework of your choosing and will be simple calls to the TestSuite class.

Check the documentation for the suites for details of the test harnesses and example unit test code.

## Test Suites

The following test suites are currently available:

* [](Z80.md)
  * [](DAA.md)
  * [](Fuse.md)
  * [](MarkWoodmass.md)
  * [](Raxoft.md)
  * [](SingleStep.md)
  * [](ZEXALL.md)

## Pull Requests

I'm not accepting pull requests at the current time; I want to get the project to version 1.0 first.

## Bug Reports and Suggestions

Feel free to raise issues for bugs or suggestions; I expect there to be bugs or API design problems I've overlooked that will be revealed when other people start using the tests.

## Licence

Licensed under GPL v3.0. Licence information for the original project behind each test suite can be found on the relevant page and in source control.