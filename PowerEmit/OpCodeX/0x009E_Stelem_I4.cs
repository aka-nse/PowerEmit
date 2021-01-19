using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stelem.i4</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stelem_I4()
            => new Emit_Stelem_I4();


        private sealed class Emit_Stelem_I4 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stelem_I4;

            public Emit_Stelem_I4()
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
