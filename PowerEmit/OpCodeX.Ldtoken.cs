using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamOpCode Ldtoken(Type operand)
            => new Emit_Ldtoken(operand);


        public static IILStreamOpCode Ldtoken(MethodInfo operand)
            => new Emit_Ldtoken(operand);


        public static IILStreamOpCode Ldtoken(FieldInfo operand)
            => new Emit_Ldtoken(operand);


        private sealed class Emit_Ldtoken : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Ldtoken;


            private MemberInfo _Operand;

            /// <summary></summary>
            public Type? TypeOperand => _Operand as Type;

            /// <summary></summary>
            public MethodInfo? MethodInfoOperand => _Operand as MethodInfo;

            /// <summary></summary>
            public FieldInfo? FieldInfoOperand => _Operand as FieldInfo;


            public int ByteSize => OpCode.Size + OpCode.GetOperandSize();
            int? IILStreamAction.ByteSize => ByteSize;


            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;


            internal Emit_Ldtoken(Type operand) => _Operand = operand;
            internal Emit_Ldtoken(MethodInfo operand) => _Operand = operand;
            internal Emit_Ldtoken(FieldInfo operand) => _Operand = operand;


            public void Emit(ILGeneratorState state)
            {
                switch(_Operand)
                {
                case Type typeOperand:
                    state.Generator.Emit(OpCode, typeOperand);
                    break;
                case MethodInfo methodInfoOperand:
                    state.Generator.Emit(OpCode, methodInfoOperand);
                    break;
                case FieldInfo fieldInfoOperand:
                    state.Generator.Emit(OpCode, fieldInfoOperand);
                    break;
                default:
                    throw new InvalidOperationException();
                }
            }

            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }

}