using System;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>nop</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Nop()
            => new Emit_Nop();


        private sealed class Emit_Nop : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Nop;

            public Emit_Nop()
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
            }
        }
    }
}
