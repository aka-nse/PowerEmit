using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.i.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_I_Un()
            => new Emit_Conv_Ovf_I_Un();


        private sealed class Emit_Conv_Ovf_I_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I_Un;

            public Emit_Conv_Ovf_I_Un()
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
                    StackType.F => StackType.NativeInt.Instance,
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
                        StackValue.Int32       x => StackValue.FromValue((nint)unchecked((uint) x.Value)),
                        StackValue.Int64       x => StackValue.FromValue((nint)unchecked((ulong)x.Value)),
                        StackValue.NativeInt   x => StackValue.FromValue((nint)unchecked((nuint)x.Value)),
                        StackValue.F x => StackValue.FromValue((nint)Math.Abs(Math.Truncate(x.Value))),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
