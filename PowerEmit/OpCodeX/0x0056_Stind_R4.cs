using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stind.r4</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stind_R4()
            => new Emit_Stind_R4();


        private sealed class Emit_Stind_R4 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stind_R4;

            public Emit_Stind_R4()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stobj.ValidateStack(state, typeof(float));

            public override void Invoke(IILInvocationState state)
                => Emit_Stobj.Invoke(state, typeof(float));
        }
    }
}
