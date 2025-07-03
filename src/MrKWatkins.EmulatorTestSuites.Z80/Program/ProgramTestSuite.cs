using System.Buffers.Binary;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

public abstract class ProgramTestSuite<TTestCase> : TestSuite
    where TTestCase : TestCase
{
    private readonly Lazy<IReadOnlyList<TTestCase>> lazyTestCases;

    private protected ProgramTestSuite(string name, Uri source)
        : base(name, source)
    {
        lazyTestCases = new Lazy<IReadOnlyList<TTestCase>>(() => EnumerateTestCases().ToList());
    }

    protected abstract ushort TestTableStartAddress { get; }

    public IReadOnlyList<TTestCase> TestCases => lazyTestCases.Value;

    [Pure]
    private IEnumerable<TTestCase> EnumerateTestCases()
    {
        var memory = new byte[65536];
        LoadProgram(memory);

        // The test table consists of a series of pointers to the actual test cases, followed by 0x0000;
        var testTableAddress = TestTableStartAddress;
        while (true)
        {
            var testAddress = BinaryPrimitives.ReadUInt16LittleEndian(memory.AsSpan(testTableAddress));
            if (testAddress == 0)
            {
                break;
            }

            yield return CreateTestCase(memory, testTableAddress, testAddress);
            testTableAddress = MoveToNextTestCaseInTable(memory, testTableAddress);
        }
    }

    [Pure]
    protected abstract TTestCase CreateTestCase(byte[] memory, ushort testTableAddress, ushort testAddress);

    [Pure]
    protected virtual ushort MoveToNextTestCaseInTable(byte[] memory, ushort testTableAddress) => (ushort)(testTableAddress + 2);

    protected abstract void LoadProgram(byte[] memory);
}