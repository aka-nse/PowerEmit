using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i8</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I8(long operand)
            => new Emit_Ldc_I8(operand);


        private sealed class Emit_Ldc_I8 : ILStreamInstruction<long>
        {
            public override OpCode OpCode => OpCodes.Ldc_I8;

            public Emit_Ldc_I8(long operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(StackType.FromType(typeof(long)));
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(StackValue.FromValue(Operand));
            }
        }
    }
}
