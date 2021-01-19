using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>pop</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Pop()
            => new Emit_Pop();


        private sealed class Emit_Pop : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Pop;

            public Emit_Pop()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Pop();
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Pop();
            }
        }
    }
}
