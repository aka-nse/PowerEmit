using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>refanyval</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Refanyval(Type operand)
            => new Emit_Refanyval(operand);


        private sealed class Emit_Refanyval : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Refanyval;

            public Emit_Refanyval(Type operand)
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
                if(type is not StackType.IUserValue uvType || !uvType.IsAssignableTo(typeof(TypedReference), PassByKind.Value))
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
