using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.0</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4_0()
            => new Emit_Ldc_I4_0();


        private sealed class Emit_Ldc_I4_0 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_0;

            public Emit_Ldc_I4_0()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, 0);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, 0);
        }
    }
}
