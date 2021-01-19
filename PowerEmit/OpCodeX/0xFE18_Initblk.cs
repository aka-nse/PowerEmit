using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>initblk</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Initblk()
            => new Emit_Initblk();


        private sealed class Emit_Initblk : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Initblk;

            public Emit_Initblk()
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
