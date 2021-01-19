using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stind.i</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stind_I()
            => new Emit_Stind_I();


        private sealed class Emit_Stind_I : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stind_I;

            public Emit_Stind_I()
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
