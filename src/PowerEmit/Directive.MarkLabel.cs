using System.Reflection.Emit;

namespace PowerEmit;

partial class Directive
{
    /// <summary>
    /// Marks label at current position.
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public static MarkLabel MarkLabel(Label label) => new (label);


    /// <summary>
    /// Marks label at current position.
    /// </summary>
    /// <param name="labelBuilder"></param>
    /// <returns></returns>
    public static MarkLabel MarkLabel(LabelBuilder labelBuilder) => new (labelBuilder);
}

/// <summary>
/// Provides IL directive to mark label at current position.
/// </summary>
public sealed class MarkLabel : Directive
{
    private readonly Label _label;
    private readonly LabelBuilder? _labelBuilder;

    /// <inheritdoc/>
    public override int ByteSize => 0;

    /// <summary>
    /// Gets the label to be marked, or null if a LabelBuilder is used.
    /// </summary>
    public Label? Label => _labelBuilder is null ? _label : null;

    /// <summary>
    /// Gets the LabelBuilder to be marked, or null if a Label is used.
    /// </summary>
    public LabelBuilder? LabelBuilder => _labelBuilder;


    internal MarkLabel(Label label)
        => _label = label;

    internal MarkLabel(LabelBuilder labelBuilder)
        => _labelBuilder = labelBuilder;

    /// <inheritdoc/>
    public override void Emit(ILGenerator generator)
    {
        if(LabelBuilder is LabelBuilder validLabelBuilder)
            validLabelBuilder.MarkLabel(generator);
        else if(Label is Label validLabel)
            generator.MarkLabel(validLabel);
        else
            throw new InvalidOperationException();
    }

    /// <inheritdoc/>
    public override bool Equals(IILStreamAction? other)
        => other is MarkLabel mlOther
        && Label == mlOther.Label
        && LabelBuilder == mlOther.LabelBuilder;

    /// <inheritdoc/>
    public override string ToString()
    {
        if(Label is { } label)
        {
            return $"label[{label.GetId():X04}]:";
        }
        else if(LabelBuilder is { } labelBuilder)
        {
            return $"{labelBuilder.Name}:";
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    /// <inheritdoc/>
    protected override int GetHashCodeImpl()
    {
        if(_label is { } label)
        {
            return label.GetHashCode();
        }
        if(_labelBuilder is { } labelBuilder)
        {
            return labelBuilder.Name.GetHashCode();
        }
        return 0;
    }
}