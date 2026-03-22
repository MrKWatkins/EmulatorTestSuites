using System.Collections.Concurrent;
using MrKWatkins.EmulatorTestSuites.Z80.Program.MarkWoodmass;
using MrKWatkins.OakAsm.IO.ZXSpectrum.Z80Snapshot;

namespace MrKWatkins.EmulatorTestSuites.Z80.Program.Timing;

/// <summary>
/// Richard Butler's 48K Spectrum timing test suite.
/// </summary>
/// <seealso href="https://www.zxspectrum4.net/op_timing.php">Original test suite</seealso>
public sealed class TimingTestSuite : TestSuite
{
    private static readonly string[] TestDescriptions =
    [
        "JR; INC BC; LD BC,(nn);LD (nn),BC",
        "INC dd; DEC dd",
        "NOP; LD r,r; INC r; DEC r",
        "(ADD/ADC/SUB/SBC/AND/XOR/OR/CP) A,r & A,(HL)",
        "EXX; EX AF,AF'; EX DE,HL",
        "; DAA; CPL; CCF; SCF",
        "PUSH dd; POP dd;EX (SP),HL",
        "RLA; RAA; RLCA; RRCA; RLD; RRD",
        "LD HL,nn; LD HL,(nn); LD (nn),HL; LD (HL),n",
        "PUSH; POP; CALL; JP cc; [ALL FLAGS RESET]",
        "PUSH; POP; CALL; JP cc; [ALL FLAGS SET]",
        "RLC/RRC/RL/RR/SLA/SRA/SRL r & (HL)",
        "BIT b,r",
        "SET b,r; RES b,r",
        "IM 0 1 2; LD A,I; LD I,A; LD R,A; LD A,R",
        "LD SP,HL; ADD HL,dd; ADC HL,dd; SBC HL,dd",
        "(ADD/ADC/SUB/SBC/AND/XOR/OR/CP) A,0-3",
        "(ADD/ADC/SUB/SBC/AND/XOR/OR/CP) A,4-7",
        "LD r,n; LD rr,nn;LD A,(nn);LD (nn),A;LD dd,(nn);LD (nn),dd",
        "LD r,(ss); LD (ss),r",
        "PUSH ii;POP ii; LD (ii+n),r; LD (ii+n),n",
        "LD A,(ii+n); LD r,(ii+n)",
        "LD A,(IX+n); LD r,(IX+n); BIT (IX+n);RES (iX+n);SET (IX+n)",
        "LD A,(IY+n); LD r,(IY+n);BIT (IY+n);RES (IY+n);SET (IY+n)",
        "(ADD/ADC/SUB/SBC/AND/XOR/OR/CP) A,(IX+n)",
        "(ADD/ADC/SUB/SBC/AND/XOR/OR/CP) A,(IX+n)",
        "BIT (HL);RES (HL);SET (HL);INC (HL);DEC (HL)",
        "RET; RET cc; RETI; RETN",
        "CALL CC,n; JR cc,n; DJNZ",
        "LDI; LDIR; LDD; LDDR",
        "CPI; CPIR; CPD; CPDR",
        "INI; INIR; IND; INDR",
        "OUTI; OTIR; OUTD; OTDR",
        "RST 18"
        // The original BASIC includes tests 35-37, but the OakCpu port currently omits them.
    ];

    private readonly ConcurrentDictionary<Type, Lazy<TimingType>> timingTypesByHarnessType = new();
    private readonly Lazy<byte[]> memory;
    private readonly Lazy<IReadOnlyList<TimingTestCase>> lazyTestCases;

    /// <summary>
    /// Gets the singleton instance of the <see cref="TimingTestSuite" />.
    /// </summary>
    public static readonly TimingTestSuite Instance = new();

    private TimingTestSuite()
        : base("Timing Tests 48K Spectrum", new Uri("https://www.zxspectrum4.net/op_timing.php"))
    {
        memory = new Lazy<byte[]>(CreateMemory);
        lazyTestCases = new Lazy<IReadOnlyList<TimingTestCase>>(() => EnumerateTestCases().ToList());
    }

    /// <summary>
    /// Gets the test cases in this suite.
    /// </summary>
    public IReadOnlyList<TimingTestCase> TestCases => lazyTestCases.Value;

    internal byte[] BaseMemory => memory.Value;

    [Pure]
    internal TimingType GetTimingType<TTestHarness>()
        where TTestHarness : Z80TestHarness, new() =>
        timingTypesByHarnessType.GetOrAdd(
            typeof(TTestHarness),
            static _ => new Lazy<TimingType>(TimingTestCase.DetectTiming<TTestHarness>, LazyThreadSafetyMode.ExecutionAndPublication)).Value;

    [Pure]
    private static IEnumerable<TimingTestCase> EnumerateTestCases()
    {
        foreach (var contended in new[] { false, true })
        {
            foreach (var (description, index) in TestDescriptions.Select((description, index) => (description, index)))
            {
                yield return new TimingTestCase((byte)(index + 1), description, contended);
            }
        }
    }

    [Pure]
    private byte[] CreateMemory()
    {
        var memory = new byte[65536];

        using var rom = OpenResource(typeof(MarkWoodmassTestSuite), "ZXSpectrum48k.rom");
        rom.ReadExactly(memory, 0, 16384);

        using var program = OpenResource("timing_tests_48k_v1.0.z80");
        var snapshot = Z80SnapshotFormat.Instance.Read(program);
        snapshot.LoadInto(memory);

        return memory;
    }
}
