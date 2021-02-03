using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.u8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_U8()
            => new Emit_Conv_Ovf_U8();


        private sealed class Emit_Conv_Ovf_U8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U8;

            public Emit_Conv_Ovf_U8()
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
                    StackType.IFloat => StackType.Int64,
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
                        StackValue.IInt32     x => StackValue.FromValue((ulong)x.Value),
                        StackValue.IInt64     x => StackValue.FromValue((ulong)x.Value),
                        StackValue.INativeInt x => StackValue.FromValue((ulong)x.Value),
                        StackValue.IFloat x => StackValue.FromValue((ulong)Math.Truncate(x.Value)),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
