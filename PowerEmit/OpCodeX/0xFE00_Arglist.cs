using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>arglist</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Arglist()
            => new Emit_Arglist();


        private sealed class Emit_Arglist : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Arglist;

            public Emit_Arglist()
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
