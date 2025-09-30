using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit;

/// <summary>
/// Provides shorthands structured IL stream such as for, foreach, etc.
/// </summary>
public abstract partial class ILShorthand : IILStreamAction
{
    /// <inheritdoc />
    public abstract int ByteSize { get; }

    /// <inheritdoc />
    public abstract void Emit(ILGenerator generator);

    /// <inheritdoc />
    public abstract bool Equals(IILStreamAction? other);

    /// <inheritdoc />
    protected abstract int GetHashCodeImpl();

    /// <inheritdoc />
    public sealed override int GetHashCode() =>
        GetHashCodeImpl();
}
