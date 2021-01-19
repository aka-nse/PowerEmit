using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.5</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4_5()
            => new Emit_Ldc_I4_5();


        private sealed class Emit_Ldc_I4_5 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_5;

            public Emit_Ldc_I4_5()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, 5);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, 5);
        }
    }
}
