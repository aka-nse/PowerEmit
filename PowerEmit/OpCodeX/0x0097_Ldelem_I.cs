using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.i</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_I()
            => new Emit_Ldelem_I();


        private sealed class Emit_Ldelem_I : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_I;

            public Emit_Ldelem_I()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
