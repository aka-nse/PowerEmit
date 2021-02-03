using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.u1</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_U1()
            => new Emit_Ldelem_U1();


        private sealed class Emit_Ldelem_U1 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_U1;

            public Emit_Ldelem_U1()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldelem.ValidateStack(state, StackType.Int32);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldelem.Invoke(state, StackType.Int32);
        }
    }
}
