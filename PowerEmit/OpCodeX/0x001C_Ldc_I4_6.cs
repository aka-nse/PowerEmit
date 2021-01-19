using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.6</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4_6()
            => new Emit_Ldc_I4_6();


        private sealed class Emit_Ldc_I4_6 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_6;

            public Emit_Ldc_I4_6()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, 6);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, 6);
        }
    }
}
