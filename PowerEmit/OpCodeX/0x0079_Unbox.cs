using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>unbox</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Unbox(Type operand)
            => new Emit_Unbox(operand);


        private sealed class Emit_Unbox : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Unbox;

            public Emit_Unbox(Type operand)
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
                state.EvaluationStack.Push(StackType.ManagedPtr);
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
