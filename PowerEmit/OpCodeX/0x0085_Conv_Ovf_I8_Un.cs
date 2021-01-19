using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.i8.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_I8_Un()
            => new Emit_Conv_Ovf_I8_Un();


        private sealed class Emit_Conv_Ovf_I8_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I8_Un;

            public Emit_Conv_Ovf_I8_Un()
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
                    StackType.F => StackType.Int64.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                checked
                {
                    var value = state.EvaluationStack.Pop();
                    var resultValue = value switch
                    {
                        StackValue.Int32       x => StackValue.FromValue((long)unchecked((uint) x.Value)),
                        StackValue.Int64       x => StackValue.FromValue((long)unchecked((ulong)x.Value)),
                        StackValue.NativeInt   x => StackValue.FromValue((long)unchecked((nuint)x.Value)),
                        StackValue.F x => StackValue.FromValue((long)Math.Abs(Math.Truncate(x.Value))),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
