using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>prefixref</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Prefixref()
            => new Emit_Prefixref();


        private sealed class Emit_Prefixref : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Prefixref;

            public Emit_Prefixref()
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
