using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.r4</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_R4(float operand)
            => new Emit_Ldc_R4(operand);


        private sealed class Emit_Ldc_R4 : ILStreamInstruction<float>
        {
            public override OpCode OpCode => OpCodes.Ldc_R4;

            public Emit_Ldc_R4(float operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(StackType.FromType(typeof(float)));
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(StackValue.FromValue(Operand));
            }
        }
    }
}
