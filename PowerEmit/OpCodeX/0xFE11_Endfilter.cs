using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>endfilter</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Endfilter()
            => new Emit_Endfilter();


        private sealed class Emit_Endfilter : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Endfilter;

            public Emit_Endfilter()
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
