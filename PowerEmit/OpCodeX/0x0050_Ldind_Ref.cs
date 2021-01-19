using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldind.ref</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldind_Ref()
            => new Emit_Ldind_Ref();


        private sealed class Emit_Ldind_Ref : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldind_Ref;

            public Emit_Ldind_Ref()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldobj.ValidateStack(state, typeof(object));

            public override void Invoke(IILInvocationState state)
                => Emit_Ldobj.Invoke(state, typeof(object));

        }
    }
}
