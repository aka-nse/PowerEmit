using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.r4</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_R4()
            => new Emit_Ldelem_R4();


        private sealed class Emit_Ldelem_R4 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_R4;

            public Emit_Ldelem_R4()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldelem.ValidateStack(state, StackType.Float);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldelem.Invoke(state, StackType.Float);
        }
    }
}
