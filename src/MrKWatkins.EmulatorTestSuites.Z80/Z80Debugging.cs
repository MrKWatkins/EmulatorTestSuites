using MrKWatkins.OakAsm.Disassembly;
using MrKWatkins.OakAsm.Disassembly.OpcodeReader;
using MrKWatkins.OakAsm.Formatting;
using MrKWatkins.OakAsm.Z80;

namespace MrKWatkins.EmulatorTestSuites.Z80;

/// <summary>
/// Utilities for debugging Z80 emulators by writing debug information.
/// </summary>
public static class Z80Debugging
{
    private static readonly TrieCachedOpcodeReader OpcodeReader = new(new OpcodeInstructionLookup(Z80Assembly.OpcodeDefinitions));

    /// <summary>
    /// Writes debugging information for the specified <see cref="Z80TestHarness" /> to the specified <see cref="TextWriter" />.
    /// </summary>
    /// <param name="z80">The <see cref="Z80TestHarness" /> to be described in the debugging output. </param>
    /// <param name="debug">The <see cref="TextWriter" /> to write debug information to. If <c>null</c>, no output will be written.</param>
    public static void WriteDebugInformation(Z80TestHarness z80, TextWriter debug)
    {
        debug.Write($"0x{z80.RegisterPC:X4}: ");
        WriteOpcodeWithPadding(z80, debug);
        debug.Write(' ');
        WriteRegisters(z80, debug);
        debug.Write(' ');
        WriteFlags(z80, debug);
        debug.WriteLine();
    }

    private static void WriteOpcodeWithPadding(Z80TestHarness z80, TextWriter debug)
    {
        int written;
        if (OpcodeReader.TryRead(new Z80TestHarnessOpcodeByteReader(z80, z80.RegisterPC), out var opcode))
        {
            var opcodeString = AssemblyFormatter.Default.Write(opcode);
            debug.Write(opcodeString);
            written = opcodeString.Length;
        }
        else
        {
            debug.Write("???");
            written = 3;
        }

        for (var f = written; f < 16; f++)
        {
            debug.Write(' ');
        }
    }

    private static void WriteRegisters(Z80TestHarness z80, TextWriter debug)
    {
        debug.Write("PC ");
        debug.Write($"{z80.RegisterPC:X4}");
        debug.Write(" SP ");
        debug.Write($"{z80.RegisterSP:X4}");
        debug.Write(" AF ");
        debug.Write($"{z80.RegisterAF:X4}");
        debug.Write(" BC ");
        debug.Write($"{z80.RegisterBC:X4}");
        debug.Write(" DE ");
        debug.Write($"{z80.RegisterDE:X4}");
        debug.Write(" HL ");
        debug.Write($"{z80.RegisterHL:X4}");
        debug.Write(" IX ");
        debug.Write($"{z80.RegisterIX:X4}");
        debug.Write(" IY ");
        debug.Write($"{z80.RegisterIY:X4}");
        debug.Write(" I ");
        debug.Write($"{z80.RegisterI:X2}");
        debug.Write(" R ");
        debug.Write($"{z80.RegisterR:X2}");
        debug.Write(" WZ ");
        debug.Write($"{z80.RegisterWZ:X4}");
        debug.Write(" Q ");
        debug.Write($"{z80.RegisterQ:X2}");
    }

    private static void WriteFlags(Z80TestHarness z80, TextWriter debug)
    {
        WriteFlag(debug, z80.FlagS, 'S', 's');
        WriteFlag(debug, z80.FlagN, 'N', 'n');
        WriteFlag(debug, z80.FlagPV, 'P', 'p');
        WriteFlag(debug, z80.FlagX, 'X', 'x');
        WriteFlag(debug, z80.FlagH, 'H', 'h');
        WriteFlag(debug, z80.FlagY, 'Y', 'y');
        WriteFlag(debug, z80.FlagN, 'N', 'n');
        WriteFlag(debug, z80.FlagC, 'C', 'c');
    }

    private static void WriteFlag(TextWriter debug, bool flag, char set, char reset) => debug.Write(flag ? set : reset);

    private ref struct Z80TestHarnessOpcodeByteReader(Z80TestHarness z80, ushort startIndex = 0) : IOpcodeByteReader
    {
        private ushort currentIndex = startIndex;

        public byte ReadNext(OpcodeByteType type) => z80.ReadByteFromMemory(currentIndex++);
    }
}