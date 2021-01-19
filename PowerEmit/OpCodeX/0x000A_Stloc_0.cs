using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stloc.0</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stloc_0()
            => new Emit_Stloc_0();


        private sealed class Emit_Stloc_0 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stloc_0;

            public Emit_Stloc_0()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stloc.ValidateStack(state, 0);

            public override void Invoke(IILInvocationState state)
                => Emit_Stloc.Invoke(state, 0);
        }
    }
}
