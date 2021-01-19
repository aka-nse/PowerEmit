using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarg.3</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldarg_3()
            => new Emit_Ldarg_3();


        private sealed class Emit_Ldarg_3 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldarg_3;

            public Emit_Ldarg_3()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldarg.ValidateStack(state, 3);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldarg.Invoke(state, 3);
        }
    }
}
