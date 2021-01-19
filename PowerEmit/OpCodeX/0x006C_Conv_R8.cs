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
                StackType resultType = type switch
                {
                    StackType.Int32 or
                    StackType.Int64 or
                    StackType.NativeInt or
                    StackType.F => StackType.F.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.Int32       x => StackValue.FromValue((double)x.Value),
                    StackValue.Int64       x => StackValue.FromValue((double)x.Value),
                    StackValue.NativeInt   x => StackValue.FromValue((double)x.Value),
                    StackValue.F x => StackValue.FromValue((double)x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
