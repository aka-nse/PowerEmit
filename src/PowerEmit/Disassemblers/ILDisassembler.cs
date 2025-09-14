using System.Reflection;

namespace PowerEmit.Disassemblers;

/// <summary>
/// Provides functionality to disassemble a method's IL code into a structured representation.
/// </summary>
public partial class ILDisassembler
{
    /// <summary>
    /// Gets the singleton instance of the default <see cref="ILDisassembler"/>.
    /// </summary>
    public static ILDisassembler Instance { get; } = new ILDisassembler();

    /// <summary>
    /// Creates a new instance of the <see cref="ILDisassembler"/> class.
    /// </summary>
    protected ILDisassembler()
    {
    }

    /// <summary>
    /// Disassembles the specified method and returns its structured representation.
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public virtual MethodContent Disassemble(MethodBase method)
    {
        var entity = new Entity(method);
        return new MethodContent(
            entity.Arguments,
            entity.Locals,
            [.. entity.Labels.OrderBy(static kv => kv.Key).Select(static kv => kv.Value)],
            entity.ILActions
            );
    }


    /// <summary>
    /// This method is defined for unit testing purposes.
    /// </summary>
    private MethodContent Disassemble(Module module, Type[] arguments, Type[] locals, byte[] byteStream)
    {
        var entity = new Entity(module, arguments, locals, byteStream);
        return new MethodContent(
            entity.Arguments,
            entity.Locals,
            [.. entity.Labels.OrderBy(static kv => kv.Key).Select(static kv => kv.Value)],
            entity.ILActions
            );
    }
}