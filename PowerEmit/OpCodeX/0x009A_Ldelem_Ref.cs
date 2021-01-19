using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.ref</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_Ref()
            => new Emit_Ldelem_Ref();


        private sealed class Emit_Ldelem_Ref : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_Ref;

            public Emit_Ldelem_Ref()
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
