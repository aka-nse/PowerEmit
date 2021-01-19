using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>refanytype</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Refanytype()
            => new Emit_Refanytype();


        private sealed class Emit_Refanytype : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Refanytype;

            public Emit_Refanytype()
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
