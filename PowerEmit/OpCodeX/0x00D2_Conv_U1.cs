using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.u1</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_U1()
            => new Emit_Conv_U1();


        private sealed class Emit_Conv_U1 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_U1;

            public Emit_Conv_U1()
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
