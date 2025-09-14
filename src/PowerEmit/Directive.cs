using System.Reflection.Emit;

namespace PowerEmit;

/// <summary>
/// Provides a base class for directives that can be emitted to an IL stream.
/// </summary>
public abstract partial class Directive : IILStreamAction
{
    /// <inheritdoc />
    public abstract int ByteSize { get; }

    /// <inheritdoc />
    public abstract void Emit(ILGenerator generator);

    /// <inheritdoc />
    public abstract bool Equals(IILStreamAction? other);

    /// <inheritdoc />
    public sealed override bool Equals(object? obj)
        => obj is IILStreamAction other && Equals(other);

    /// <inheritdoc />
    protected abstract int GetHashCodeImpl();

    /// <inheritdoc />
    public sealed override int GetHashCode() =>
        GetHashCodeImpl();
}