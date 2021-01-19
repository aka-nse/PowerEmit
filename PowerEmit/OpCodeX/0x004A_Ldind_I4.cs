using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldind.i4</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldind_I4()
            => new Emit_Ldind_I4();


        private sealed class Emit_Ldind_I4 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldind_I4;

            public Emit_Ldind_I4()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldobj.ValidateStack(state, typeof(int));

            public override void Invoke(IILInvocationState state)
                => Emit_Ldobj.Invoke(state, typeof(int));
        }
    }
}
