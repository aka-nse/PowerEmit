using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>prefix6</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Prefix6()
            => new Emit_Prefix6();


        private sealed class Emit_Prefix6 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Prefix6;

            public Emit_Prefix6()
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
