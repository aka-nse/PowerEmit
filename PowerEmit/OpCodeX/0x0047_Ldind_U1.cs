using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldind.u1</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldind_U1()
            => new Emit_Ldind_U1();


        private sealed class Emit_Ldind_U1 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldind_U1;

            public Emit_Ldind_U1()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldobj.ValidateStack(state, typeof(byte));

            public override void Invoke(IILInvocationState state)
                => Emit_Ldobj.Invoke(state, typeof(byte));
        }
    }
}
