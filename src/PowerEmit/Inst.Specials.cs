using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit;

public partial struct Inst
{
    /// <summary> Gets emitter to emit switch. </summary>
    /// <param name="operand"> The operand to emit. </param>
    /// <returns> The built emitter. </returns>
    public static Inst<ImmutableArray<Label>> Switch(IEnumerable<Label> operand)
        => Switch(operand.ToImmutableArray());


    /// <summary> Gets emitter to emit switch. </summary>
    /// <param name="operand"> The operand to emit. </param>
    /// <returns> The built emitter. </returns>
    public static Inst<ImmutableArray<LabelBuilder>> Switch(IEnumerable<LabelBuilder> operand)
        => Switch(operand.ToImmutableArray());


    /// <summary> Gets emitter to emit call. </summary>
    /// <param name="methodInfo"></param>
    /// <param name="optionalParameterTypes"></param>
    /// <returns> The built emitter. </returns>
    public static Inst<CallInfo> Call(MethodInfo methodInfo, Type[]? optionalParameterTypes)
        => new(
            OpCodes.Call,
            new (methodInfo, optionalParameterTypes),
            (generator, opcode, operand) => generator.EmitCall(opcode, operand.MethodInfo, optionalParameterTypes));


    /// <summary> Gets emitter to emit callvirt. </summary>
    /// <param name="methodInfo"></param>
    /// <param name="optionalParameterTypes"></param>
    /// <returns> The built emitter. </returns>
    public static Inst<CallInfo> Callvirt(MethodInfo methodInfo, Type[]? optionalParameterTypes)
        => new(
            OpCodes.Callvirt,
            new (methodInfo, optionalParameterTypes),
            (generator, opcode, operand) => generator.EmitCall(opcode, operand.MethodInfo, optionalParameterTypes));

    #region

    // NOTE:
    //     Following factories are place holders for ILDisassembler auto-generated code.
    //     They never do nothing, so do not call them.

    internal static Inst<ConstructorInfo> Jmp(ConstructorInfo operand)
        => throw new NotSupportedException();

    internal static Inst<ConstructorInfo> Callvirt(ConstructorInfo operand)
        => throw new NotSupportedException();

    internal static Inst<MethodInfo> Newobj(MethodInfo operand)
        => throw new NotSupportedException();

    internal static Inst<ConstructorInfo> Ldftn(ConstructorInfo operand)
        => throw new NotSupportedException();

    internal static Inst<ConstructorInfo> Ldvirtftn(ConstructorInfo operand)
        => throw new NotSupportedException();

    #endregion
}

/// <summary>
/// Represents information required to emit a method call instruction,
/// including the target method and optional parameter types.
/// </summary>
/// <param name="MethodInfo"></param>
/// <param name="OptionalParameterTypes"></param>
public sealed record class CallInfo(MethodInfo MethodInfo, Type[]? OptionalParameterTypes);