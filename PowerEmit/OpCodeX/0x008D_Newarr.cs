using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>newarr</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Newarr(Type operand)
            => new Emit_Newarr(operand);


        private sealed class Emit_Newarr : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Newarr;

            public Emit_Newarr(Type operand)
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
                if(type is not (StackType.Int32 or StackType.NativeInt))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.FromType(Operand.MakeArrayType()));
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
