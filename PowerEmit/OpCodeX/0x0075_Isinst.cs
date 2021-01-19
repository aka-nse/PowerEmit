using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>isinst</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Isinst(Type operand)
            => new Emit_Isinst(operand);


        private sealed class Emit_Isinst : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Isinst;

            public Emit_Isinst(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not StackType.O)
                    throw new Exception();
                state.EvaluationStack.Push(new StackType.O(Operand));
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value.TryToAssignable(Operand).GetOrDefault();
                state.EvaluationStack.Push(new StackValue.O(resultValue));
            }
        }
    }
}
