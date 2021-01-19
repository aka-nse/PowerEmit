using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>clt.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Clt_Un()
            => new Emit_Clt_Un();


        private sealed class Emit_Clt_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Clt_Un;

            public Emit_Clt_Un()
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
                var orderKey = StackValue.Compare_Un(values);
                state.EvaluationStack.Push(StackValue.FromValue(orderKey < 0));
            }
        }
    }
}
