using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>mkrefany</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Mkrefany(Type operand)
            => new Emit_Mkrefany(operand);


        private sealed class Emit_Mkrefany : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Mkrefany;

            public Emit_Mkrefany(Type operand)
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
                if(type is not (StackType.IManagedPtr or StackType.INativeInt))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.UserValue(typeof(TypedReference)));
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
