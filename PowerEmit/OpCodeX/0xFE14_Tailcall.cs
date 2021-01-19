using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>tail.</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Tailcall()
            => new Emit_Tailcall();


        private sealed class Emit_Tailcall : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Tailcall;

            public Emit_Tailcall()
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
