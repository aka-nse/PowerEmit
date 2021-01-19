using System;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>break</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Break()
            => new Emit_Break();


        private sealed class Emit_Break : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Break;

            public Emit_Break()
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
