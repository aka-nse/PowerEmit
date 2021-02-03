using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.i8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_I8()
            => new Emit_Ldelem_I8();


        private sealed class Emit_Ldelem_I8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_I8;

            public Emit_Ldelem_I8()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldelem.ValidateStack(state, StackType.Int64);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldelem.Invoke(state, StackType.Int64);
        }
    }
}
