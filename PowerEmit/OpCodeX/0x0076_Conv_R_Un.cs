using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.r.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_R_Un()
            => new Emit_Conv_R_Un();


        private sealed class Emit_Conv_R_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_R_Un;

            public Emit_Conv_R_Un()
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
                    StackType.INativeInt => StackType.Float,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.IInt32       x => StackValue.FromValue((float)(uint) x.Value),
                    StackValue.IInt64       x => StackValue.FromValue((float)(ulong)x.Value),
                    StackValue.INativeInt   x => StackValue.FromValue((float)(nuint)x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
