using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace PowerEmit;

partial class Directive
{
    /// <summary>
    /// Marks label at current position.
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public static MarkLabel MarkLabel(Label label) =>
        new MarkLabel_Label(label);


    /// <summary>
    /// Marks label at current position.
    /// </summary>
    /// <param name="labelBuilder"></param>
    /// <returns></returns>
    public static MarkLabel MarkLabel(LabelBuilder labelBuilder) =>
        new MarkLabel_LabelBuilder(labelBuilder);
}


/// <summary>
/// Provides IL directive to mark label at current position.
/// </summary>
public abstract class MarkLabel : Directive
{
    /// <inheritdoc/>
    public override sealed int ByteSize => 0;
    /// <summary>
    /// Gets the label to be marked, or null if a LabelBuilder is used.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public virtual Label? Label => null;

    /// <summary>
    /// Gets the LabelBuilder to be marked, or null if a Label is used.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public virtual LabelBuilder? LabelBuilder => null;
}


file sealed class MarkLabel_Label(Label label) : MarkLabel
{
    public override Label? Label => label;

    public override void Emit(ILGenerator generator) =>
        generator.MarkLabel(label);

    public override bool Equals(IILStreamAction? other)
        => other is MarkLabel_Label mlOther
        && Label == mlOther.Label;

    public override string ToString() =>
        $"label[{label.GetId():X04}]:";

    [ExcludeFromCodeCoverage]
    protected override int GetHashCodeImpl() =>
        Label.GetHashCode();
}


file sealed class MarkLabel_LabelBuilder(LabelBuilder labelBuilder) : MarkLabel
{
    public override LabelBuilder? LabelBuilder => labelBuilder;

    public override void Emit(ILGenerator generator) =>
        labelBuilder.MarkLabel(generator);

    public override bool Equals(IILStreamAction? other) =>
        other is MarkLabel_LabelBuilder mlOther
        && labelBuilder == mlOther.LabelBuilder;

    public override string ToString() =>
        $"{labelBuilder.Name}:";

    [ExcludeFromCodeCoverage]
    protected override int GetHashCodeImpl() =>
        labelBuilder.Name.GetHashCode();
}
