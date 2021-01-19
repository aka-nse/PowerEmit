using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>prefix5</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Prefix5()
            => new Emit_Prefix5();


        private sealed class Emit_Prefix5 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Prefix5;

            public Emit_Prefix5()
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
