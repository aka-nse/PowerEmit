using System.Reflection.Emit;

namespace PowerEmit;

/// <summary>
/// Expresses an action that can be emitted to an IL stream.
/// </summary>
public interface IILStreamAction : IEquatable<IILStreamAction>
{
    /// <summary>
    /// Gets the byte size to be emmitted, which includes both of the opcode size and operand size.
    /// </summary>
    int ByteSize { get; }

    /// <summary>
    /// Emits the action to the given IL stream to the <see cref="ILGenerator"/>.
    /// </summary>
    /// <param name="generator"></param>
    void Emit(ILGenerator generator);
}


/// <summary>
/// Provides extension methods for emitting IL instructions using an <see cref="ILGenerator"/>.
/// </summary>
public static class ILStreamAction
{
    /// <summary>
    /// Emits the specified IL action to the given IL generator.
    /// </summary>
    /// <typeparam name="TILAction"></typeparam>
    /// <param name="generator"></param>
    /// <param name="inst"></param>
    /// <returns></returns>
    public static ILGenerator Emit<TILAction>(this ILGenerator generator, TILAction inst)
        where TILAction : IILStreamAction
    {
        inst.Emit(generator);
        return generator;
    }
}