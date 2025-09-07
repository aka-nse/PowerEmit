using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace PowerEmit;

/// <summary>
/// Expresses a single IL instruction emitting action.
/// </summary>
public interface IInst : IILStreamAction
{
    /// <summary>
    /// Gets the opcode of this instruction.
    /// </summary>
    OpCode OpCode { get; }
}

/// <summary>
/// Represents an instruction with a strongly-typed operand.
/// </summary>
/// <typeparam name="T">The type of the operand associated with the instruction.</typeparam>
public interface IInst<T> : IInst
{
    /// <summary>
    /// Gets the operand associated with this instruction.
    /// </summary>
    T Operand { get; }
}

/// <summary>
/// Represents an intermediate language (IL) instruction with an associated operation code.
/// </summary>
/// <remarks>This struct encapsulates an IL instruction, providing its operation code and functionality to emit
/// the instruction to an <see cref="ILGenerator"/>. It also supports equality comparison with other IL stream
/// actions.</remarks>
/// <remarks>
/// Creates a new instance of the <see cref="Inst"/> struct with the specified operation code.
/// </remarks>
/// <param name="opcode"></param>
public readonly partial struct Inst(OpCode opcode) : IInst
{
    /// <inheritdoc />
    public OpCode OpCode { get; } = opcode;

    /// <inheritdoc />
    public readonly int ByteSize => OpCode.Size;

    /// <inheritdoc />
    public readonly void Emit(ILGenerator generator) => generator.Emit(OpCode);

    /// <inheritdoc />
    public readonly bool Equals(IILStreamAction other)
        => other is Inst iOther && OpCode == iOther.OpCode;
}

/// <summary>
/// Represents an intermediate language (IL) instruction with a strongly-typed operand.
/// </summary>
/// <typeparam name="T"></typeparam>
public readonly struct Inst<T>(OpCode opcode, T operand, Action<ILGenerator, OpCode, T>? emitOverride = null) : IInst<T>
{
    /// <inheritdoc />
    public OpCode OpCode { get; } = opcode;

    /// <inheritdoc />
    public T Operand => _operand;
    private readonly T _operand = operand;

    /// <inheritdoc />
    public readonly int ByteSize
        => OpCode.Size + OpCode.OperandType.OperandSize(_operand);

    /// <summary>
    /// Gets the optional override action for emitting this instruction.
    /// </summary>
    public Action<ILGenerator, OpCode, T>? EmitOverride { get; } = emitOverride;

    /// <inheritdoc />
    public readonly void Emit(ILGenerator generator)
    {
        static ref readonly TTo asT<TTo>(in T operand) =>
            ref Unsafe.As<T, TTo>(ref Unsafe.AsRef(operand));

#pragma warning disable format
        if(EmitOverride is not null) EmitOverride(generator, OpCode, Operand);
        else if(typeof(T) == typeof(byte  )) generator.Emit(OpCode, asT<byte  >(_operand));
        else if(typeof(T) == typeof(sbyte )) generator.Emit(OpCode, asT<sbyte >(_operand));
        else if(typeof(T) == typeof(short )) generator.Emit(OpCode, asT<short >(_operand));
        else if(typeof(T) == typeof(ushort)) generator.Emit(OpCode, asT<short >(_operand));
        else if(typeof(T) == typeof(int   )) generator.Emit(OpCode, asT<int   >(_operand));
        else if(typeof(T) == typeof(long  )) generator.Emit(OpCode, asT<long  >(_operand));
        else if(typeof(T) == typeof(float )) generator.Emit(OpCode, asT<float >(_operand));
        else if(typeof(T) == typeof(double)) generator.Emit(OpCode, asT<double>(_operand));
        else if(typeof(T) == typeof(Label )) generator.Emit(OpCode, asT<Label >(_operand));
        else if(typeof(T) == typeof(string)) generator.Emit(OpCode, asT<string>(_operand));
        else if(typeof(T) == typeof(LocalBuilder   )) generator.Emit(OpCode, asT<LocalBuilder   >(_operand));
        else if(typeof(T) == typeof(SignatureHelper)) generator.Emit(OpCode, asT<SignatureHelper>(_operand));
        else if(typeof(T) == typeof(LabelBuilder   )) generator.Emit(OpCode, asT<LabelBuilder   >(_operand).GetLabel(generator));
        else if(Operand is Type            type    ) generator.Emit(OpCode, type);
        else if(Operand is MethodInfo      methInfo) generator.Emit(OpCode, methInfo);
        else if(Operand is FieldInfo       fldInfo ) generator.Emit(OpCode, fldInfo);
        else if(Operand is ConstructorInfo ctorInfo) generator.Emit(OpCode, ctorInfo);
        else if(Operand is Label[]         labels  ) generator.Emit(OpCode, labels);
        else throw ExceptionHelper.InvalidOperandType();
#pragma warning restore format
    }

    /// <inheritdoc />
    public bool Equals(IILStreamAction other)
        => other is Inst<T> iOther
        && OpCode == iOther.OpCode
        && Equals(Operand, iOther.Operand);
}