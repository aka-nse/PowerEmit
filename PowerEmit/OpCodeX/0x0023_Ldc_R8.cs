using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.r8</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_R8(double operand)
            => new Emit_Ldc_R8(operand);


        private sealed class Emit_Ldc_R8 : ILStreamInstruction<double>
        {
            public override OpCode OpCode => OpCodes.Ldc_R8;

            public Emit_Ldc_R8(double operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(StackType.FromType(typeof(double)));
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(StackValue.FromValue(Operand));
            }
        }
    }
}
