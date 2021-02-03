using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4(int operand)
            => new Emit_Ldc_I4(operand);


        private sealed class Emit_Ldc_I4 : ILStreamInstruction<int>
        {
            public override OpCode OpCode => OpCodes.Ldc_I4;

            public Emit_Ldc_I4(int operand)
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


            public static void ValidateStack(IILValidationState state, int value)
            {
                state.EvaluationStack.Push(StackType.Int32);
            }

            public static bool Invoke(IILInvocationState state, int value)
            {
                state.EvaluationStack.Push(StackValue.FromValue(value));
                return true;
            }
        }
    }
}
