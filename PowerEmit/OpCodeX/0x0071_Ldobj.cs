using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldobj</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldobj(Type operand)
            => new Emit_Ldobj(operand);


        private sealed class Emit_Ldobj : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Ldobj;

            public Emit_Ldobj(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }

            public static void ValidateStack(IILValidationState state, Type operand)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not (StackType.INativeInt or StackType.IManagedPtr))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.FromType(operand));
            }

            public static void Invoke(IILInvocationState state, Type operand)
            {
                throw new NotSupportedException();
            }
        }
    }
}
