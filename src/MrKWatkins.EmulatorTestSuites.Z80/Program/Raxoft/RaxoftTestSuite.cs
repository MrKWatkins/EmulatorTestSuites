using System.Text;
using MrKWatkins.OakAsm.IO.ZXSpectrum.Tap;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

/// <summary>
/// The Raxoft test suite.
/// </summary>
/// <seealso href="https://mrkwatkins.github.io/EmulatorTestSuites/raxoft.html">Documentation</seealso>
/// <seealso href="https://github.com/raxoft/z80test">Original test suite</seealso>
public sealed class RaxoftTestSuite : ProgramTestSuite<RaxoftTestCase>
{
    /// <summary>
    /// Gets a test suite instance for the specified <see cref="RaxoftTestType" /> and <see cref="RaxoftTestVersion" />.
    /// </summary>
    /// <param name="type">The type of test suite to retrieve.</param>
    /// <param name="version">The version of the test suite to retrieve. Defaults to <see cref="RaxoftTestVersion.V1_2A" />.</param>
    /// <returns>The corresponding <see cref="RaxoftTestSuite"/> instance.</returns>
    /// <exception cref="NotSupportedException">Thrown when <paramref name="type"/> is not supported.</exception>
    [Pure]
    public static RaxoftTestSuite Get(RaxoftTestType type, RaxoftTestVersion version = RaxoftTestVersion.V1_2A) => new(type, version);

    private RaxoftTestSuite(RaxoftTestType type, RaxoftTestVersion version)
        : base($"{type} {version.ToString().Replace('_', '.')}", new Uri("https://github.com/raxoft/z80test"))
    {
        Version = version;
        Type = type;
    }

    /// <summary>
    /// Gets the type of test suite.
    /// </summary>
    public RaxoftTestType Type { get; }

    /// <summary>
    /// Gets the version of the test suite.
    /// </summary>
    public RaxoftTestVersion Version { get; }

    private protected override void LoadProgram(byte[] memory)
    {
        var resource = $"{Version}.z80{Type.ToString().ToLowerInvariant()}.tap";

        using var stream = OpenResource(resource);

        var tap = TapFormat.Instance.Read(stream);

        if (!tap.Blocks[^1].TryLoadInto(memory))
        {
            throw new InvalidOperationException($"Could not load {resource}.");
        }
    }

    private protected override ushort TestTableStartAddress => Type switch
    {
        RaxoftTestType.Ccf => 0x887F,
        _ => 0x887A
    };

    private protected override RaxoftTestCase CreateTestCase(byte[] memory, ushort testTableAddress, ushort testAddress) => new(GetTestCaseName(memory, testAddress), testAddress, memory, TestTableStartAddress);

    [Pure]
    private string GetTestCaseName(byte[] memory, ushort testAddress)
    {
        // The name starts at the end of the test and is a null terminated string.
        var address = testAddress + NameOffset;
        var name = new StringBuilder();

        while (true)
        {
            var character = memory[address];
            if (character == 0)
            {
                break;
            }

            name.Append((char)character);
            address++;
        }

        return name.ToString();
    }

    private byte NameOffset => Type switch
    {
        RaxoftTestType.Ccf => 68,
        _ => 65
    };
}