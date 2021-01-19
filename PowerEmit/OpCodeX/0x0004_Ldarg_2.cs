using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarg.2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldarg_2()
            => new Emit_Ldarg_2();


        private sealed class Emit_Ldarg_2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldarg_2;

            public Emit_Ldarg_2()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldarg.ValidateStack(state, 2);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldarg.Invoke(state, 2);
        }
    }
}
