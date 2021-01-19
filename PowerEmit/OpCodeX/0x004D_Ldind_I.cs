using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldind.i</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldind_I()
            => new Emit_Ldind_I();


        private sealed class Emit_Ldind_I : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldind_I;

            public Emit_Ldind_I()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldobj.ValidateStack(state, typeof(nint));

            public override void Invoke(IILInvocationState state)
                => Emit_Ldobj.Invoke(state, typeof(nint));
        }
    }
}
