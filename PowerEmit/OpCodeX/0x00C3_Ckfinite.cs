using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ckfinite</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ckfinite()
            => new Emit_Ckfinite();


        private sealed class Emit_Ckfinite : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ckfinite;

            public Emit_Ckfinite()
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
