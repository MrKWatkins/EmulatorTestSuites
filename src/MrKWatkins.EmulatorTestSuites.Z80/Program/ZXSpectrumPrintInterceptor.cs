namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

internal sealed class ZXSpectrumPrintInterceptor : PrintInterceptor
{
    private int lineLength;
    private State state;

    internal ZXSpectrumPrintInterceptor(Z80TestHarness z80, ResultWatchingOutput output)
        : base(z80, output)
    {
    }

    internal override void HandlePrintRoutine()
    {
        var character = Z80.RegisterA;
        switch (state)
        {
            case State.Normal:
                WriteNormal(character);
                break;

            case State.TabRead:
                WriteTabRead(character);
                break;

            case State.TabLengthRead:
                WriteTabLengthRead();
                break;
        }
    }

    private void WriteNormal(byte character)
    {
        switch (character)
        {
            // Copyright symbol.
            case 0x7F:
                Output.Write(0xA9);
                lineLength++;
                break;

            // Tab.
            case 0x17:
                state = State.TabRead;
                break;

            // Carriage return.
            case 0x0D:
                Output.WriteLine();
                lineLength = 0;
                break;

            case >= 0x20 and < 0x7F:
                Output.Write(character);
                lineLength++;
                break;
        }
    }

    private void WriteTabRead(byte character)
    {
        var padTo16 = 16 - lineLength;
        var fullPadding = character + padTo16;
        for (var f = 0; f < fullPadding; f++)
        {
            Output.Write((byte)' ');
        }

        lineLength += fullPadding;
        state = State.TabLengthRead;
    }

    private void WriteTabLengthRead() => state = State.Normal;

    private enum State
    {
        Normal,
        TabRead,
        TabLengthRead
    }
}