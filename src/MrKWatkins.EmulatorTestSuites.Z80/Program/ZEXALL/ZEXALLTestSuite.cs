using System.Text;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program.ZEXALL;

public sealed class ZEXALLTestSuite : ProgramTestSuite<ZEXALLTestCase>
{
    internal const ushort StartAddress = 0x0100;
    public static readonly ZEXALLTestSuite ZEXALL = new(ZEXALLTestType.ZEXALL);
    public static readonly ZEXALLTestSuite ZEXDOC = new(ZEXALLTestType.ZEXDOC);

    [Pure]
    public static ZEXALLTestSuite Get(ZEXALLTestType type) => type switch
    {
        ZEXALLTestType.ZEXALL => ZEXALL,
        ZEXALLTestType.ZEXDOC => ZEXDOC,
        _ => throw new NotSupportedException($"The {nameof(ZEXALLTestType)} {type} is not supported.")
    };

    private ZEXALLTestSuite(ZEXALLTestType type)
        : base(type.ToString(), new Uri("https://github.com/agn453/ZEXALL"))
    {
        Type = type;
    }

    public ZEXALLTestType Type { get; }

    private protected override void LoadProgram(byte[] memory)
    {
        using var stream = OpenResource($"{Type.ToString().ToLowerInvariant()}.bin");

        _ = stream.Read(memory.AsSpan(StartAddress));
    }

    private protected override ushort TestTableStartAddress => 0x013A;

    private protected override ZEXALLTestCase CreateTestCase(byte[] memory, ushort testTableAddress, ushort testAddress) => new(GetTestCaseName(memory, testAddress), testAddress, memory);

    [Pure]
    private static string GetTestCaseName(byte[] memory, ushort testCaseAddress)
    {
        // The name starts at the end of the test and is a null terminated string.
        var address = testCaseAddress + 65;
        var name = new StringBuilder();

        while (true)
        {
            var character = memory[address];
            if (character == 0x2E)
            {
                break;
            }

            name.Append((char)character);
            address++;
        }

        return name.ToString();
    }
}