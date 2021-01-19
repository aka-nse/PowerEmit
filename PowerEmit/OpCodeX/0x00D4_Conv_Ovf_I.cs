using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.i</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_I()
            => new Emit_Conv_Ovf_I();


        private sealed class Emit_Conv_Ovf_I : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I;

            public Emit_Conv_Ovf_I()
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
