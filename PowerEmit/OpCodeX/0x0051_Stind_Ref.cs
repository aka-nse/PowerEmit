using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stind.ref</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stind_Ref()
            => new Emit_Stind_Ref();


        private sealed class Emit_Stind_Ref : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stind_Ref;

            public Emit_Stind_Ref()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stobj.ValidateStack(state, typeof(object));

            public override void Invoke(IILInvocationState state)
                => Emit_Stobj.Invoke(state, typeof(object));
        }
    }
}
