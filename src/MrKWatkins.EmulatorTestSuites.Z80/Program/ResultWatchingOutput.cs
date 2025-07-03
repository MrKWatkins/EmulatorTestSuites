namespace MrKWatkins.EmulatorTestSuites.Z80.Program;

internal sealed class ResultWatchingOutput
{
    private readonly string passedString;
    private readonly string errorString;
    private readonly string? skippedString;
    private readonly TextWriter? output;
    private int errorIndex;
    private int passedIndex;
    private int skippedIndex;

    internal ResultWatchingOutput(TextWriter? output, string passedString, string errorString, string? skippedString)
    {
        this.passedString = passedString;
        this.errorString = errorString;
        this.skippedString = skippedString;
        this.output = output;
    }

    internal ProgramTestResult Result { get; private set; }

    internal void WriteLine()
    {
        errorIndex = 0;
        passedIndex = 0;
        skippedIndex = 0;
        output?.WriteLine();
    }

    internal void Write(byte asciiCharacter)
    {
        var character = (char)asciiCharacter;

        output?.Write(character);

        if (Result != ProgramTestResult.None)
        {
            return;
        }

        if (CheckForString(character, errorString, ref errorIndex))
        {
            Result = ProgramTestResult.Failed;
        }
        else if (CheckForString(character, passedString, ref passedIndex))
        {
            Result = ProgramTestResult.Passed;
        }
        else if (skippedString != null && CheckForString(character, skippedString, ref skippedIndex))
        {
            Result = ProgramTestResult.Skipped;
        }
    }

    [MustUseReturnValue]
    private static bool CheckForString(char character, string toCheck, ref int index)
    {
        // Does the current character match where we are in the string?
        if (character != toCheck[index])
        {
            // No, reset our match.
            index = 0;
            return false;
        }

        // Yes. If we've matched all the characters in the string we have a failure.
        if (index == toCheck.Length - 1)
        {
            index = 0;
            return true;
        }

        // Not at the end of the string yet, carry on matching.
        index++;
        return false;
    }
}