using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>shr.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Shr_Un()
            => new Emit_Shr_Un();


        private sealed class Emit_Shr_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Shr_Un;

            public Emit_Shr_Un()
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
                    (StackType.Int32    , StackType.NativeInt) => StackType.Int32    .Instance,
                    (StackType.Int64    , StackType.Int32    ) => StackType.Int64    .Instance,
                    (StackType.Int64    , StackType.NativeInt) => StackType.Int64    .Instance,
                    (StackType.NativeInt, StackType.Int32    ) => StackType.NativeInt.Instance,
                    (StackType.NativeInt, StackType.NativeInt) => StackType.NativeInt.Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var values = state.EvaluationStack.Pop(2);
                var resultValue = (values[1], values[0]) switch
                {
                    (StackValue.Int32     x, StackValue.Int32     y) => StackValue.FromValue((uint) x.Value << (int)y.Value),
                    (StackValue.Int32     x, StackValue.NativeInt y) => StackValue.FromValue((uint) x.Value << (int)y.Value),
                    (StackValue.Int64     x, StackValue.Int32     y) => StackValue.FromValue((ulong)x.Value << (int)y.Value),
                    (StackValue.Int64     x, StackValue.NativeInt y) => StackValue.FromValue((ulong)x.Value << (int)y.Value),
                    (StackValue.NativeInt x, StackValue.Int32     y) => StackValue.FromValue((nuint)x.Value << (int)y.Value),
                    (StackValue.NativeInt x, StackValue.NativeInt y) => StackValue.FromValue((nuint)x.Value << (int)y.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
