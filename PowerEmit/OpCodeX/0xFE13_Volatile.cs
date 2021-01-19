using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>volatile.</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Volatile()
            => new Emit_Volatile();


        private sealed class Emit_Volatile : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Volatile;

            public Emit_Volatile()
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
