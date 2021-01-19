using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldind.r8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldind_R8()
            => new Emit_Ldind_R8();


        private sealed class Emit_Ldind_R8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldind_R8;

            public Emit_Ldind_R8()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldobj.ValidateStack(state, typeof(double));

            public override void Invoke(IILInvocationState state)
                => Emit_Ldobj.Invoke(state, typeof(double));
        }
    }
}
