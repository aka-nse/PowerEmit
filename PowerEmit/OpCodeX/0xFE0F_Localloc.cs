using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>localloc</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Localloc()
            => new Emit_Localloc();


        private sealed class Emit_Localloc : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Localloc;

            public Emit_Localloc()
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
