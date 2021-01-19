using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>endfinally</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Endfinally()
            => new Emit_Endfinally();


        private sealed class Emit_Endfinally : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Endfinally;

            public Emit_Endfinally()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
