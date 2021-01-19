using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>cgt</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Cgt()
            => new Emit_Cgt();


        private sealed class Emit_Cgt : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Cgt;

            public Emit_Cgt()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                if(!StackType.AreOrderable(types))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.FromType(typeof(int)));
            }

            public override void Invoke(IILInvocationState state)
            {
                var values = state.EvaluationStack.Pop(2);
                var orderKey = StackValue.Compare(values);
                state.EvaluationStack.Push(StackValue.FromValue(orderKey > 0));
            }
        }
    }
}
