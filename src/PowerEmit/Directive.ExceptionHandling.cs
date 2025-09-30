using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace PowerEmit;

#region BeginScope

partial class Directive
{
    /// <summary>
    /// Begins an scope.
    /// </summary>
    /// <returns></returns>
    public static BeginScope BeginScope() =>
        new();
}

/// <summary>
/// Provides IL directive to begin an scope.
/// </summary>
public sealed class BeginScope() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.BeginScope();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginScope;

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(BeginScope);
}

#endregion

#region EndScope

partial class Directive
{
    /// <summary>
    /// Ends an scope.
    /// </summary>
    /// <returns></returns>
    public static EndScope EndScope() =>
        new();
}

/// <summary>
/// Provides IL directive to end an scope.
/// </summary>
public sealed class EndScope() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.EndScope();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is EndScope;

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(EndScope);
}

#endregion


#region BeginExceptionBlock

partial class Directive
{
    /// <summary>
    /// Begins an exception unfiltered block.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static BeginExceptionBlock BeginExceptionBlock(string name) =>
        new(name);
}

/// <summary>
/// Provides IL directive to begin an exception unfiltered block.
/// </summary>
/// <param name="name"></param>
public sealed class BeginExceptionBlock(string name) : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <summary>
    /// Gets the label that marks the beginning of the exception block.
    /// </summary>
    public LabelBuilder Label { get; } =
        new LabelBuilder($"BeginExceptionBlock_{name}");

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator)
    {
        var label = generator.BeginExceptionBlock();
        Label.RegisterLabelExternal(generator, label);
    }

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginExceptionBlock xother && Label == xother.Label;

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(BeginExceptionBlock);
}

#endregion

#region EndExceptionBlock

partial class Directive
{
    /// <summary>
    /// Ends an exception block.
    /// </summary>
    /// <returns></returns>
    public static EndExceptionBlock EndExceptionBlock() =>
        new();
}

/// <summary>
/// Provides IL directive to end an exception block.
/// </summary>
public sealed class EndExceptionBlock() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.EndExceptionBlock();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is EndExceptionBlock;

    /// <inheritdoc/>
    public override string ToString() =>
        $"EndExceptionBlock";
}

#endregion


#region BeginCatchBlock

partial class Directive
{
    /// <summary>
    /// Begins a catch block for the specified exception type.
    /// </summary>
    /// <param name="exceptionType"></param>
    /// <returns></returns>
    public static BeginCatchBlock BeginCatchBlock(Type exceptionType) =>
        new (exceptionType);
}

/// <summary>
/// Provides IL directive to begin a catch block for the specified exception type.
/// </summary>
/// <param name="exceptionType"></param>
public sealed class BeginCatchBlock(Type exceptionType) : Directive
{
    /// <summary>
    /// Gets the type of the exception to be caught.
    /// </summary>
    public Type ExceptionType { get; } =
        exceptionType ?? throw new ArgumentNullException(nameof(exceptionType));

    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.BeginCatchBlock(ExceptionType);

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginCatchBlock bcbOther
        && ExceptionType == bcbOther.ExceptionType;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public override int GetHashCode() =>
        HashHelper.Combine(typeof(BeginCatchBlock), ExceptionType);

    /// <inheritdoc/>
    public override string ToString() =>
        $"{nameof(BeginCatchBlock)} {ExceptionType}";
}

#endregion


#region BeginExceptFilterBlock

partial class Directive
{
    /// <summary>
    /// Begins an exception filter block.
    /// </summary>
    /// <returns></returns>
    public static BeginExceptFilterBlock BeginExceptFilterBlock() =>
        new ();
}

/// <summary>
/// Provides IL directive to begin an exception filter block.
/// </summary>
public sealed class BeginExceptFilterBlock() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.BeginExceptFilterBlock();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginExceptFilterBlock;

    /// <inheritdoc/>
    [ExcludeFromCodeCoverage]
    public override int GetHashCode() =>
        HashHelper.Combine(base.GetHashCode(), typeof(BeginExceptFilterBlock));

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(BeginExceptFilterBlock);
}

#endregion


#region BeginFaultBlock

partial class Directive
{
    /// <summary>
    /// Begins an exception fault block.
    /// </summary>
    /// <returns></returns>
    public static BeginFaultBlock BeginFaultBlock() =>
        new();
}

/// <summary>
/// Provides IL directive to begin an exception fault block.
/// </summary>
public sealed class BeginFaultBlock() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.BeginFaultBlock();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginFaultBlock;

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(BeginFaultBlock);
}

#endregion


#region BeginFinallyBlock

partial class Directive
{
    /// <summary>
    /// Begins an exception finally block.
    /// </summary>
    /// <returns></returns>
    public static BeginFinallyBlock BeginFinallyBlock() =>
        new();
}

/// <summary>
/// Provides IL directive to begin an exception finally block.
/// </summary>
public sealed class BeginFinallyBlock() : Directive
{
    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator) =>
        generator.BeginFinallyBlock();

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other) =>
        other is BeginFinallyBlock;

    /// <inheritdoc/>
    public override string ToString() =>
        nameof(BeginFinallyBlock);
}

#endregion
