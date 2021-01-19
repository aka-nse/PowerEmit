using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>readonly.</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Readonly()
            => new Emit_Readonly();


        private sealed class Emit_Readonly : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Readonly;

            public Emit_Readonly()
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
