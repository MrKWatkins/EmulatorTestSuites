namespace MrKWatkins.EmulatorTestSuites.Z80.Instruction;

public enum MemoryCycleMethod
{
    /// <summary>
    /// Memory read cycles (MREQ + RD) last for two T-States. Memory write cycles (MREQ + MW) last for one cycle, on the second cycle. (Because first is just MREQ, no MW)
    /// </summary>
    Accurate,

    /// <summary>
    /// Memory read (MREQ + RD) and write (MREQ + MW) cycles last for one T-State on the first T-State.
    /// </summary>
    Start,

    /// <summary>
    /// Memory read (MREQ + RD) and write (MREQ + MW) cycles last for one T-State on the second T-State.
    /// </summary>
    End
}