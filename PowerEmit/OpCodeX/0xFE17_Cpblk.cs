using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>cpblk</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Cpblk()
            => new Emit_Cpblk();


        private sealed class Emit_Cpblk : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Cpblk;

            public Emit_Cpblk()
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
