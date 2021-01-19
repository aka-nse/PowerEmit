using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ceq</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ceq()
            => new Emit_Ceq();


        private sealed class Emit_Ceq : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ceq;

            public Emit_Ceq()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }


            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                if(!StackType.AreEquatable(types))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.FromType(typeof(int)));
            }


            public override void Invoke(IILInvocationState state)
            {
                var values = state.EvaluationStack.Pop(2);
                var eqyality = StackValue.Equals(values);
                state.EvaluationStack.Push(StackValue.FromValue(eqyality));
            }
        }
    }
}
