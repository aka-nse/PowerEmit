using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit
{
    public interface IInst : IILStreamAction
    {
        OpCode OpCode { get; }
    }


    public interface IInst<T> : IInst
    {
        T Operand { get; }
    }


    public partial struct Inst : IInst
    {
        public OpCode OpCode { get; }

        public int ByteSize => OpCode.Size;

        public Inst(OpCode opcode)
        {
            OpCode = opcode;
        }

        public void Emit(ILGenerator generator) => generator.Emit(OpCode);

        public bool Equals(IILStreamAction other)
            => other is Inst iOther && OpCode == iOther.OpCode;
    }


    public struct Inst<T> : IInst<T>
    {
        public OpCode OpCode { get; }

        public T Operand => _operand;
        private readonly T _operand;

        public int ByteSize
            => OpCode.Size + OpCode.OperandType.OperandSize(_operand);

        public Action<ILGenerator, OpCode, T>? EmitOverride { get; }

        public Inst(OpCode opcode, T operand, Action<ILGenerator, OpCode, T>? emitOverride = null)
        {
            OpCode = opcode;
            _operand = operand;
            EmitOverride = emitOverride;
        }

        public void Emit(ILGenerator generator)
        {
            ref readonly TTo asT<TTo>(in T operand) => ref Unsafe.As<T, TTo>(ref Unsafe.AsRef(operand));

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

        public bool Equals(IILStreamAction other)
            => other is Inst<T> iOther
            && OpCode == iOther.OpCode
            && Equals(Operand, iOther.Operand);
    }
}