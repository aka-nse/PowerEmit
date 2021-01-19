using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldtoken</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldtoken(MethodInfo operand)
            => new Emit_Ldtoken(operand);

        /// <summary> Creates new instruction item of <c>ldtoken</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldtoken(FieldInfo operand)
            => new Emit_Ldtoken(operand);

        /// <summary> Creates new instruction item of <c>ldtoken</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldtoken(Type operand)
            => new Emit_Ldtoken(operand);


        private sealed class Emit_Ldtoken : ILStreamInstruction<MemberInfo>
        {
            public override OpCode OpCode => OpCodes.Ldtoken;

            public Emit_Ldtoken(MemberInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                switch(Operand)
                {
                case MethodInfo methodInfo:
                    state.Generator.Emit(OpCode, methodInfo);
                    return;
                case FieldInfo fieldInfo:
                    state.Generator.Emit(OpCode, fieldInfo);
                    return;
                case Type type:
                    state.Generator.Emit(OpCode, type);
                    return;
                default:
                    throw new InvalidOperationException();
                }
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
