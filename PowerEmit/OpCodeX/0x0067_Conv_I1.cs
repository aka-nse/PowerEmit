using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.i1</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_I1()
            => new Emit_Conv_I1();


        private sealed class Emit_Conv_I1 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_I1;

            public Emit_Conv_I1()
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
                    StackType.IFloat => StackType.Int32,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                unchecked
                {
                    var value = state.EvaluationStack.Pop();
                    var resultValue = value switch
                    {
                        StackValue.IInt32       x => StackValue.FromValue((sbyte)x.Value),
                        StackValue.IInt64       x => StackValue.FromValue((sbyte)x.Value),
                        StackValue.INativeInt   x => StackValue.FromValue((sbyte)x.Value),
                        StackValue.IFloat x => StackValue.FromValue((sbyte)x.Value),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
