# Emulator Test Suites

[![Build Status](https://github.com/MrKWatkins/EmulatorTestSuites/actions/workflows/build.yml/badge.svg)](https://github.com/MrKWatkins/EmulatorTestSuites/actions/workflows/build.yml)

> Test suites for emulator developers.

This repository contains various emulator test suites from around the web and packages them up in a C# library to make them easier to run.

The code has not yet reached version 1.0 and should be treated as an alpha release.

## Getting Started

To use the test suites, you will need to:

* Install the relevant NuGet package.
* Implement a test harness class. Each class of tests has an abstract test harness class that it uses to interact with emulators. You will need to create a
  subclass that wraps your emulator.
* Create unit tests for the test suites you want to run. These can be in the framework of your choosing and will be simple calls to the TestSuite class.

Check the [documentation](https://mrkwatkins.github.io/EmulatorTestSuites/) for details of the test harnesses and example unit test code.

## Pull Requests

I'm not accepting pull requests at the current time; I want to get the project to version 1.0 first.

Feel free to raise issues for bugs or suggestions; I expect there to be bugs or API design problems I've overlooked that will be revealed when other people start using the tests.

## Licence

Licensed under GPL v3.0. Licence information for the original project behind each test suite can be found on the relevant page and in source control.

## Building and documentation

Build and Test compiles the solution, runs its tests and validates the complete documentation on pushes and pull requests. Release runs the same validation,
then publishes the prepared packages and documentation. Leave the version blank for the next minor release, or enter an explicit stable version.
Both publication options default to true. Turn **publish-packages** off to update only documentation without creating a package or release tag.
The API reference then uses the latest released source; `api-ref` can select corrected XML comments from another commit.

Preview with `python3 docs/preview.py` or **Preview documentation** in a JetBrains IDE, with Docker and the .NET 10 SDK installed.
Open `http://localhost:5173/EmulatorTestSuites/`. Generated API pages and site output remain ignored build artifacts.

Configure NuGet trusted publishing for repository `EmulatorTestSuites`, workflow `release.yml`, environment `github-pages`, owner `MrKWatkins` and all five packages.
Set GitHub Pages to **GitHub Actions**, and allow `main` to deploy to the `github-pages` environment. No stored NuGet API key is required.
