using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.r8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_R8()
            => new Emit_Conv_R8();


        private sealed class Emit_Conv_R8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_R8;

            public Emit_Conv_R8()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                IStackType resultType = type switch
                {
                    StackType.IInt32 or
                    StackType.IInt64 or
                    StackType.INativeInt or
                    StackType.IFloat => StackType.Float,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.IInt32       x => StackValue.FromValue((double)x.Value),
                    StackValue.IInt64       x => StackValue.FromValue((double)x.Value),
                    StackValue.INativeInt   x => StackValue.FromValue((double)x.Value),
                    StackValue.IFloat x => StackValue.FromValue((double)x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
