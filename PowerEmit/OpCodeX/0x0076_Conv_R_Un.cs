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
                StackType resultType = type switch
                {
                    StackType.Int32 or
                    StackType.Int64 or
                    StackType.NativeInt => StackType.F.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.Int32       x => StackValue.FromValue((float)(uint) x.Value),
                    StackValue.Int64       x => StackValue.FromValue((float)(ulong)x.Value),
                    StackValue.NativeInt   x => StackValue.FromValue((float)(nuint)x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
