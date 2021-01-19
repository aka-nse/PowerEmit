using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.u</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_U()
            => new Emit_Conv_U();


        private sealed class Emit_Conv_U : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_U;

            public Emit_Conv_U()
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
