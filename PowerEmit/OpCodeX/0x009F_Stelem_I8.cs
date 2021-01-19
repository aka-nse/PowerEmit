using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stelem.i8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stelem_I8()
            => new Emit_Stelem_I8();


        private sealed class Emit_Stelem_I8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stelem_I8;

            public Emit_Stelem_I8()
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
