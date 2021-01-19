using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldc.i4.4</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldc_I4_4()
            => new Emit_Ldc_I4_4();


        private sealed class Emit_Ldc_I4_4 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_4;

            public Emit_Ldc_I4_4()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldc_I4.ValidateStack(state, 4);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldc_I4.Invoke(state, 4);
        }
    }
}
