using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>castclass</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Castclass(Type operand)
            => new Emit_Castclass(operand);


        private sealed class Emit_Castclass : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Castclass;

            public Emit_Castclass(Type operand)
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
                if(type is not StackType.IObj)
                    throw new Exception();
                state.EvaluationStack.Push(StackType.Obj(Operand));
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value.ToAssignable(Operand);
                state.EvaluationStack.Push(new StackValue.IObj(resultValue));
            }
        }
    }
}
