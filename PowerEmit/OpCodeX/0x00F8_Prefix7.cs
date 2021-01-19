using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>prefix7</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Prefix7()
            => new Emit_Prefix7();


        private sealed class Emit_Prefix7 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Prefix7;

            public Emit_Prefix7()
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
