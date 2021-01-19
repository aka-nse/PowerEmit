using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>div.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Div_Un()
            => new Emit_Div_Un();


        private sealed class Emit_Div_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Div_Un;

            public Emit_Div_Un()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                StackType resultType = (types[1], types[0]) switch
                {
                    (StackType.Int32    , StackType.Int32    ) => StackType.Int32    .Instance,
                    (StackType.Int32    , StackType.NativeInt) => StackType.NativeInt.Instance,
                    (StackType.Int64    , StackType.Int64    ) => StackType.Int64    .Instance,
                    (StackType.NativeInt, StackType.Int32    ) => StackType.NativeInt.Instance,
                    (StackType.NativeInt, StackType.NativeInt) => StackType.NativeInt.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                unchecked
                {
                    var values = state.EvaluationStack.Pop(2);
                    var resultValue = (values[1], values[0]) switch
                    {
                        (StackValue.Int32       x, StackValue.Int32       y) => StackValue.FromValue((uint)  x.Value / (uint)  y.Value),
                        (StackValue.Int32       x, StackValue.NativeInt   y) => StackValue.FromValue((uint)  x.Value / (nuint) y.Value),
                        (StackValue.Int64       x, StackValue.Int64       y) => StackValue.FromValue((ulong) x.Value / (ulong) y.Value),
                        (StackValue.NativeInt   x, StackValue.Int32       y) => StackValue.FromValue((nuint) x.Value / (uint)  y.Value),
                        (StackValue.NativeInt   x, StackValue.NativeInt   y) => StackValue.FromValue((nuint) x.Value / (nuint) y.Value),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
