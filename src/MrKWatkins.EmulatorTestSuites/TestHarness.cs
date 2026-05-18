using System.Runtime.CompilerServices;

namespace MrKWatkins.EmulatorTestSuites;

/// <summary>
/// Base class for emulator test harnesses.
/// </summary>
/// <typeparam name="TCycle">The type used to represent recorded cycles.</typeparam>
#pragma warning disable CA1001
public abstract class TestHarness<TCycle>
#pragma warning restore CA1001
{
    private AssertionScope? assertionScope;

    /// <summary>
    /// Gets or sets the number of cycles executed.
    /// </summary>
    public ulong TStates
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }

    /// <summary>
    /// Reads a byte from memory.
    /// </summary>
    [Pure]
    public abstract byte ReadByteFromMemory(ushort address);

    /// <summary>
    /// Reads a word in little-endian format from memory.
    /// </summary>
    [Pure]
    public ushort ReadWordFromMemory(ushort address)
    {
        var lsb = ReadByteFromMemory(address);

        address++;
        var msb = ReadByteFromMemory(address);

        return (ushort)((msb << 8) | lsb);
    }

    /// <summary>
    /// Writes a byte to memory.
    /// </summary>
    public abstract void WriteByteToMemory(ushort address, byte value);

    /// <summary>
    /// Writes a word in little-endian format to memory.
    /// </summary>
    public void WriteWordToMemory(ushort address, ushort value)
    {
        WriteByteToMemory(address, (byte)value);

        address++;
        WriteByteToMemory(address, (byte)(value >> 8));
    }

    /// <summary>
    /// Copies a span of bytes into memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting memory address where the bytes will be copied.</param>
    /// <param name="source">The bytes to copy into memory.</param>
    [OverloadResolutionPriority(1)]
    public virtual void CopyToMemory(ushort address, ReadOnlySpan<byte> source)
    {
        foreach (var @byte in source)
        {
            WriteByteToMemory(address, @byte);
            address++;
        }
    }

    /// <summary>
    /// Copies a sequence of bytes into memory starting at the specified address.
    /// </summary>
    /// <param name="address">The starting memory address where the bytes will be copied.</param>
    /// <param name="source">The bytes to copy into memory.</param>
    public virtual void CopyToMemory(ushort address, IReadOnlyList<byte> source)
    {
        foreach (var @byte in source)
        {
            WriteByteToMemory(address, @byte);
            address++;
        }
    }

    /// <summary>
    /// Clears memory.
    /// </summary>
    public virtual void ClearMemory()
    {
        for (var f = 0; f < 65536; f++)
        {
            WriteByteToMemory((ushort)f, 0);
        }
    }

    /// <summary>
    /// Gets or sets whether CPU cycles should be recorded.
    /// </summary>
    public bool RecordCycles
    {
        get => MutableCycles != null;
        set
        {
            if (value)
            {
                MutableCycles ??= [];
            }
            else
            {
                MutableCycles = null;
            }
        }
    }

    /// <summary>
    /// A mutable list of recorded cycles to update when <see cref="RecordCycles" /> is <c>true</c>, <c>null</c> otherwise.
    /// </summary>
    protected internal List<TCycle>? MutableCycles { get; private set; }

    /// <summary>
    /// Gets the recorded CPU cycles. Only available when <see cref="RecordCycles"/> is true.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when cycles are not being recorded.</exception>
    public IReadOnlyList<TCycle> Cycles => MutableCycles ?? throw new InvalidOperationException("Cycles are not being recorded.");

    /// <summary>
    /// Resets the test harness state.
    /// </summary>
    public virtual void Reset()
    {
        TStates = 0;
        MutableCycles?.Clear();
        ClearMemory();
    }

    /// <summary>
    /// Creates an assertion scope that allows multiple <see cref="AssertEqual{T}" /> assertions to be made with just one <see cref="AssertFail" />.
    /// </summary>
    /// <param name="name">Optional name for the scope.</param>
    /// <returns>An <see cref="IDisposable" /> that finishes the scope.</returns>
    /// <exception cref="InvalidOperationException">If a scope has already been started.</exception>
    [MustDisposeResource]
    public IDisposable CreateAssertionScope(string? name = null)
    {
        if (assertionScope != null)
        {
            throw new InvalidOperationException("Cannot create a nested assertion scope.");
        }

        assertionScope = new AssertionScope(this, name);
        return assertionScope;
    }

    /// <summary>
    /// Asserts that the actual value is equal to the expected value. If the values are not equal, an error is reported.
    /// </summary>
    /// <typeparam name="T">The type of the values being compared.</typeparam>
    /// <param name="actual">The actual value to be checked.</param>
    /// <param name="expected">The expected value to compare against.</param>
    /// <param name="message">An interpolated string handler providing a custom error message if the values are not equal.</param>
    public void AssertEqual<T>(T actual, T expected, DefaultInterpolatedStringHandler message)
    {
        if (!EqualityComparer<T>.Default.Equals(actual, expected))
        {
            if (assertionScope != null)
            {
                assertionScope.AddError(message.ToString());
            }
            else
            {
                AssertFail(message.ToString());
            }
        }
    }

    /// <summary>
    /// Signals that a test has failed with the provided error message.
    /// </summary>
    /// <param name="message">The error message indicating why the test failed.</param>
    public abstract void AssertFail(string message);

    private sealed class AssertionScope(TestHarness<TCycle> harness, string? name) : IDisposable
    {
        private readonly List<string> errors = new();

        public void AddError(string error) => errors.Add(error);

        public void Dispose()
        {
            harness.assertionScope = null;

            if (errors.Any())
            {
                var prefix = name != null ? $"{name} failed:{Environment.NewLine}{Environment.NewLine}" : "";

                harness.AssertFail(prefix + string.Join(Environment.NewLine, errors) + Environment.NewLine);
            }
        }
    }
}