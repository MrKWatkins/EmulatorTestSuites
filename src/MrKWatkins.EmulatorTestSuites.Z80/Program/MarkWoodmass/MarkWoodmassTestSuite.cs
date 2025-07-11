using System.Text;
using MrKWatkins.OakAsm.IO.ZXSpectrum.Tap;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;

/// <summary>
/// Mark Woodmass's test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/markwoodmass.html">Documentation</seealso>
/// <seealso href="https://worldofspectrum.org/forums/discussion/20345">Original test suite</seealso>
public sealed class MarkWoodmassTestSuite : ProgramTestSuite<MarkWoodmassTestCase>
{
    /// <summary>
    /// Gets the <see cref="MarkWoodmassTestType.Flags" /> test suite that tests the flags for various DD/FD/CB instructions.
    /// </summary>
    public static readonly MarkWoodmassTestSuite Flags = new(MarkWoodmassTestType.Flags);

    /// <summary>
    /// Gets the <see cref="MarkWoodmassTestType.Memptr" /> test suite that tests MEMPTR (<see cref="Z80TestHarness.RegisterWZ">WZ</see>) implementations.
    /// </summary>
    public static readonly MarkWoodmassTestSuite Memptr = new(MarkWoodmassTestType.Memptr);

    /// <summary>
    /// Gets a test suite instance for the specified <see cref="MarkWoodmassTestType" />.
    /// </summary>
    /// <param name="type">The type of test suite to retrieve.</param>
    /// <returns>The corresponding <see cref="MarkWoodmassTestSuite"/> instance.</returns>
    /// <exception cref="NotSupportedException">Thrown when <paramref name="type"/> is not supported.</exception>
    [Pure]
    public static MarkWoodmassTestSuite Get(MarkWoodmassTestType type) => type switch
    {
        MarkWoodmassTestType.Flags => Flags,
        MarkWoodmassTestType.Memptr => Memptr,
        _ => throw new NotSupportedException($"The {nameof(MarkWoodmassTestType)} {type} is not supported.")
    };

    private MarkWoodmassTestSuite(MarkWoodmassTestType type)
        : base(type.ToString(), new Uri("https://worldofspectrum.org/forums/discussion/20345"))
    {
        Type = type;
    }

    /// <summary>
    /// Gets the type of test suite.
    /// </summary>
    public MarkWoodmassTestType Type { get; }

    private protected override void LoadProgram(byte[] memory)
    {
        LoadRom(memory);
        LoadTests(memory);
    }

    private void LoadRom(byte[] memory)
    {
        using var stream = OpenResource("ZXSpectrum48k.rom");

        _ = stream.Read(memory);
    }

    private void LoadTests(byte[] memory)
    {
        using var stream = OpenResource("z80tests.tap");

        var tap = TapFormat.Instance.Read(stream);

        if (!tap.Blocks[^1].TryLoadInto(memory))
        {
            throw new InvalidOperationException("Could not load z80tests.tap.");
        }
    }

    private protected override ushort TestTableStartAddress => Type switch
    {
        MarkWoodmassTestType.Flags => 0x822B,
        _ => 0x8407
    };

    private ushort StartAddress => Type switch
    {
        MarkWoodmassTestType.Flags => 0x8057,
        _ => 0x805F
    };

    private protected override MarkWoodmassTestCase CreateTestCase(byte[] memory, ushort testTableAddress, ushort testAddress) =>
        new(GetTestCaseName(memory, testTableAddress), testAddress, memory, StartAddress, testTableAddress, MoveToNextTestCaseInTable(memory, testTableAddress));

    private protected override ushort MoveToNextTestCaseInTable(byte[] memory, ushort testTableAddress)
    {
        // Skip over the test address.
        testTableAddress += 2;

        // Skip over the test name.
        while (true)
        {
            testTableAddress++;
            if (memory[testTableAddress] == 0xFF)
            {
                break;
            }
        }

        // Skip over the 0xFF.
        testTableAddress++;

        return testTableAddress;
    }

    [Pure]
    private static string GetTestCaseName(byte[] memory, ushort testTableAddress)
    {
        // The name starts after the pointer to the test.
        var address = testTableAddress + 2;
        var name = new StringBuilder();

        while (true)
        {
            var character = memory[address];
            if (character == 0xFF)
            {
                break;
            }

            name.Append((char)character);
            address++;
        }

        return name.ToString();
    }
}