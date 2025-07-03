using System.Text;
using MrKWatkins.OakAsm.IO.ZXSpectrum.Tap;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Raxoft;

public sealed class RaxoftTestSuite : ProgramTestSuite<RaxoftTestCase>
{
    [Pure]
    public static RaxoftTestSuite Get(RaxoftTestType type, RaxoftTestVersion version) => new(type, version);

    private RaxoftTestSuite(RaxoftTestType type, RaxoftTestVersion version)
        : base($"{type} {version.ToString().Replace('_', '.')}", new Uri("https://github.com/raxoft/z80test"))
    {
        Version = version;
        Type = type;
    }

    public RaxoftTestType Type { get; }

    public RaxoftTestVersion Version { get; }

    protected override void LoadProgram(byte[] memory)
    {
        var resource = $"{Version}.z80{Type.ToString().ToLowerInvariant()}.tap";

        using var stream = OpenResource(resource);

        var tap = TapFormat.Instance.Read(stream);

        if (!tap.Blocks.Last().TryLoadInto(memory))
        {
            throw new InvalidOperationException($"Could not load {resource}.");
        }
    }

    protected override ushort TestTableStartAddress => Type switch
    {
        RaxoftTestType.Ccf => 0x887F,
        _ => 0x887A
    };

    protected override RaxoftTestCase CreateTestCase(byte[] memory, ushort testTableAddress, ushort testAddress) => new(GetTestCaseName(memory, testAddress), testAddress, memory, TestTableStartAddress);

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