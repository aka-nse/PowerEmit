using System.Reflection.Emit;
using PowerEmit.Internals;

namespace PowerEmit;

/// <summary>
/// Provides labels lazy marking management for IL generation.
/// </summary>
/// <remarks>
/// This type is provided to define IL actions using labels without depending on a specific <see cref="ILGenerator"/> instance.
/// An instance of this type corresponds to a single label within the IL stream.
/// Using this type, it is not possible to mark more than one label within a single <see cref="ILGenerator"/> instance.
/// </remarks>
public class LabelBuilder
{
    internal sealed class StreamIndexLabelBuilder(int streamIndex)
        : LabelBuilder
    {
        public int StreamIndex { get; set; } = streamIndex;
        private protected override string NameCore => $"IL_{StreamIndex:X04}";
    }


    private readonly Dictionary<ILGenerator, Label> _definedLabels = [];
    private readonly Dictionary<ILGenerator, Label> _markedLabels  = [];

    private LabelBuilder()
    {
        NameCore = default!;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="LabelBuilder"/> class with the specified name.
    /// </summary>
    /// <param name="name"></param>
    public LabelBuilder(string name)
    {
        NameCore = name;
    }

    /// <summary>
    /// Gets the name associated with the current instance.
    /// </summary>
    public string Name => NameCore;
    private protected virtual string NameCore { get; }

    /// <summary>
    /// Gets a value indicating whether the label has been marked in any IL generator.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Name;

    /// <summary>
    /// Retrieves a previously defined label for the specified <see cref="ILGenerator"/> or defines a new label if none exists.
    /// </summary>
    /// <remarks>
    /// This method ensures that each <see cref="ILGenerator"/> is associated with a unique label.
    /// If the label for the specified <see cref="ILGenerator"/> has already been defined, it is returned.
    /// Otherwise, a new label is defined and stored for future retrieval.
    /// </remarks>
    /// <param name="targetGenerator">The <see cref="ILGenerator"/> for which the label is retrieved or defined.</param>
    /// <returns>
    /// The <see cref="Label"/> associated with the specified <see cref="ILGenerator"/>.
    /// If no label was previously defined, a new label is created and returned.
    /// </returns>
    public Label GetLabel(ILGenerator targetGenerator)
    {
        if(_definedLabels.TryGetValue(targetGenerator, out var value))
            return value;

        var label = targetGenerator.DefineLabel();
        _definedLabels.Add(targetGenerator, label);
        return label;
    }

    /// <summary>
    /// Marks a label in the specified <see cref="ILGenerator"/> to indicate a position in the emitted IL code.
    /// </summary>
    /// <remarks>
    /// This method ensures that each <see cref="ILGenerator"/> can have its label marked only once. 
    /// Attempting to mark a label for the same <see cref="ILGenerator"/> multiple times will result in an exception.
    /// </remarks>
    /// <param name="targetGenerator">The <see cref="ILGenerator"/> in which the label will be marked.</param>
    public void MarkLabel(ILGenerator targetGenerator)
    {
        if(_markedLabels.ContainsKey(targetGenerator))
            throw ExceptionHelper.AlreadyLabelMarked();

        var label = GetLabel(targetGenerator);
        targetGenerator.MarkLabel(label);
        _markedLabels.Add(targetGenerator, label);
    }

    internal void RegisterLabelExternal(ILGenerator targetGenerator, Label label)
    {
        if(_definedLabels.ContainsKey(targetGenerator))
        {
            throw new ArgumentException("A label for the specified ILGenerator has already been registered.");
        }
        else
        {
            _definedLabels.Add(targetGenerator, label);
        }
    }
}
