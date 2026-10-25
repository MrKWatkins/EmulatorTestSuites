# ZX Spectrum

[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.EmulatorTestSuites.ZXSpectrum)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.ZXSpectrum)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.EmulatorTestSuites.ZXSpectrum)](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.ZXSpectrum)

Test suites for [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum) emulators.

## Getting Started

Start by installing the [NuGet package](https://www.nuget.org/packages/MrKWatkins.EmulatorTestSuites.ZXSpectrum) into your test project:

```
dotnet add package MrKWatkins.EmulatorTestSuites.ZXSpectrum
```

You will then need to create a concrete implementation of the `ZXSpectrumTestHarness` abstract base class. A Spectrum harness composes a Z80 harness rather
than inheriting from it, because the ZX Spectrum contains a Z80 CPU:

```c#
public sealed class MySpectrumTestHarness : ZXSpectrumTestHarness
{
    public override Z80TestHarness Z80 { get; } = new MyZ80TestHarness();

    public override void StartFrame()
    {
        // Synchronise the emulator to the start of a Spectrum frame.
    }
}
```

If your emulator supports cycle or T-state stepping, expose a `Z80SteppableTestHarness` from `Z80`. If it only supports instruction-level execution, expose a
regular `Z80TestHarness`; the Spectrum timing tests will use step execution when available and instruction execution otherwise.

Lastly, add unit tests in the framework of your choosing. For example, using [NUnit](https://nunit.org/) to run the timing tests:

```c#
public sealed class TimingTests
{
    [TestCaseSource(nameof(TestCases))]
    public void Timing(TimingTestCase testCase) => testCase.Execute<MySpectrumTestHarness>(TestContext.Progress);

    [Pure]
    public static IEnumerable<TimingTestCase> TestCases() => TimingTestSuite.Instance.TestCases;
}
```

## Timing Tests

The [Timing](Timing.md) test suite runs a Spectrum timing program and compares the measured R register, loop counter and stack pointer values with the expected
values embedded in the test data. It automatically detects whether the emulator behaves like an early-timing or late-timing machine. The 35-37 variants settle
from the 48K ROM/BASIC prompt snapshot and then execute the original BASIC statements directly, so they need Spectrum-specific machine timing, including
floating-bus behaviour.

The available test suites are:

* [Timing](Timing.md)
