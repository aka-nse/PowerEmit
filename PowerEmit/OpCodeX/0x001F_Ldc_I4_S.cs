using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static IILStreamInstruction Ldc_I4_S(sbyte operand)
            => new Emit_Ldc_I4_S(operand);


        private sealed class Emit_Ldc_I4_S : ILStreamInstruction<sbyte>
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_S;

            public Emit_Ldc_I4_S(sbyte operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, Operand);
        }
    }
}
