using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldlen</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldlen()
            => new Emit_Ldlen();


        private sealed class Emit_Ldlen : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldlen;

            public Emit_Ldlen()
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
