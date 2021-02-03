using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelema</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldelema(Type operand)
            => new Emit_Ldelema(operand);


        private sealed class Emit_Ldelema : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Ldelema;

            public Emit_Ldelema(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                var (array, index) = (types[1], types[0]);
                if(array is not StackType.IObj || array.IsAssignableTo(typeof(Array), PassByKind.Value))
                    throw new Exception();
                if(index is not (StackType.IInt32 or StackType.INativeInt))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.ManagedPtr);
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
