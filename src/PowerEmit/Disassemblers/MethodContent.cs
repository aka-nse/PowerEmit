using System.Text;

namespace PowerEmit.Disassemblers;

/// <summary>
/// Represents the content of a method, including its arguments, local variables, labels, and intermediate language (IL) actions.
/// </summary>
/// <remarks>
/// This class provides a read-only view of the components that define a method's structure and behavior.
/// It is primarily used in scenarios involving dynamic method generation or analysis of IL streams.
/// </remarks>
public class MethodContent
{
    /// <summary>
    /// Gets the list of argument types for the method.
    /// </summary>
    public IReadOnlyList<Type> Arguments { get; }

    /// <summary>
    /// Gets the list of local variable types used within the method.
    /// </summary>
    public IReadOnlyList<Type> Locals { get; }

    /// <summary>
    /// Gets the collection of label builders used for branching and control flow within the method.
    /// </summary>
    public IReadOnlyCollection<LabelBuilder> Labels { get; }

    /// <summary>
    /// Gets the collection of intermediate language (IL) stream actions associated with this instance.
    /// </summary>
    public IReadOnlyList<IILStreamAction> ILActions { get; }

    internal MethodContent(
        IReadOnlyList<Type> arguments,
        IReadOnlyList<Type> locals,
        IReadOnlyCollection<LabelBuilder> labels,
        IReadOnlyList<IILStreamAction> ilActions)
    {
        Arguments = arguments;
        Locals = locals;
        Labels = labels;
        ILActions = ilActions;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"params ({string.Join(", ", Arguments)})");
        sb.AppendLine($"locals ({string.Join(", ", Locals)})");
        sb.AppendLine("{");
        foreach(var action in ILActions)
        {
            if(action is MarkLabel)
            {
                sb.Append($"    {action}: ");
            }
            else
            {
                sb.AppendLine($"{action}");
            }
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
}