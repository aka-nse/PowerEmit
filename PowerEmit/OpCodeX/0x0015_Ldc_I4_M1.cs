using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.m1</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4_M1()
            => new Emit_Ldc_I4_M1();


        private sealed class Emit_Ldc_I4_M1 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_M1;

            public Emit_Ldc_I4_M1()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, -1);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, -1);
        }
    }
}
