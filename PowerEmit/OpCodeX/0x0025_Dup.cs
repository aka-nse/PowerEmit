using System;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>dup</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Dup()
            => new Emit_Dup();


        private sealed class Emit_Dup : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Dup;

            public Emit_Dup()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(state.EvaluationStack.Peek());
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(state.EvaluationStack.Peek());
            }
        }
    }
}
