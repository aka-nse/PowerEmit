using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloc.0</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldloc_0()
            => new Emit_Ldloc_0();


        private sealed class Emit_Ldloc_0 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldloc_0;

            public Emit_Ldloc_0()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldloc.ValidateStack(state, 0);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldloc.Invoke(state, 0);
        }
    }
}
