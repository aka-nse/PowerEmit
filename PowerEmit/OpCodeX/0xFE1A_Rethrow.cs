using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>rethrow</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Rethrow()
            => new Emit_Rethrow();


        private sealed class Emit_Rethrow : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Rethrow;

            public Emit_Rethrow()
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
