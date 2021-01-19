using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloc.2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldloc_2()
            => new Emit_Ldloc_2();


        private sealed class Emit_Ldloc_2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldloc_2;

            public Emit_Ldloc_2()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldloc.ValidateStack(state, 2);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldloc.Invoke(state, 2);
        }
    }
}
