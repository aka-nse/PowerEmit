using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stloc.3</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stloc_3()
            => new Emit_Stloc_3();


        private sealed class Emit_Stloc_3 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stloc_3;

            public Emit_Stloc_3()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stloc.ValidateStack(state, 3);

            public override void Invoke(IILInvocationState state)
                => Emit_Stloc.Invoke(state, 3);
        }
    }
}
