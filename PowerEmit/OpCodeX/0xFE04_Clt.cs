using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>clt</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Clt()
            => new Emit_Clt();


        private sealed class Emit_Clt : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Clt;

            public Emit_Clt()
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
                state.EvaluationStack.Push(StackValue.FromValue(orderKey < 0));
            }
        }
    }
}
