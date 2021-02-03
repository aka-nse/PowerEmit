using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stobj</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Stobj(Type operand)
            => new Emit_Stobj(operand);


        private sealed class Emit_Stobj : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Stobj;

            public Emit_Stobj(Type operand)
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
                => Invoke(state, Operand);

            public static void ValidateStack(IILValidationState state, Type operand)
            {
                var types = state.EvaluationStack.Pop(2);
                if(types[1] is not StackType.IManagedPtr)
                    throw new Exception();
            }

            public static void Invoke(IILInvocationState state, Type operand)
            {
                throw new NotSupportedException();
            }
        }
    }
}
