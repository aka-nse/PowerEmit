using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public sealed class Ldtoken : ICilOperation
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
        int? ICilGeneratorAction.ByteSize => ByteSize;


        public int StackBalance => OpCode.GetStackBalance();
        int? ICilGeneratorAction.StackBalance => StackBalance;


        internal Ldtoken(Type operand) => _Operand = operand;
        internal Ldtoken(MethodInfo operand) => _Operand = operand;
        internal Ldtoken(FieldInfo operand) => _Operand = operand;


        public void Emit(CilGeneratorState state)
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

        public int GetByteSize(CilGeneratorState state) => ByteSize;
        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
