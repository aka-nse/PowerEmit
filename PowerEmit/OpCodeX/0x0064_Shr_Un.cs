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
                IStackType resultType = (types[1], types[0]) switch
                {
                    (StackType.IInt32    , StackType.IInt32    ) => StackType.Int32    ,
                    (StackType.IInt32    , StackType.INativeInt) => StackType.Int32    ,
                    (StackType.IInt64    , StackType.IInt32    ) => StackType.Int64    ,
                    (StackType.IInt64    , StackType.INativeInt) => StackType.Int64    ,
                    (StackType.INativeInt, StackType.IInt32    ) => StackType.NativeInt,
                    (StackType.INativeInt, StackType.INativeInt) => StackType.NativeInt,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var values = state.EvaluationStack.Pop(2);
                var resultValue = (values[1], values[0]) switch
                {
                    (StackValue.IInt32     x, StackValue.IInt32     y) => StackValue.FromValue((uint) x.Value << (int)y.Value),
                    (StackValue.IInt32     x, StackValue.INativeInt y) => StackValue.FromValue((uint) x.Value << (int)y.Value),
                    (StackValue.IInt64     x, StackValue.IInt32     y) => StackValue.FromValue((ulong)x.Value << (int)y.Value),
                    (StackValue.IInt64     x, StackValue.INativeInt y) => StackValue.FromValue((ulong)x.Value << (int)y.Value),
                    (StackValue.INativeInt x, StackValue.IInt32     y) => StackValue.FromValue((nuint)x.Value << (int)y.Value),
                    (StackValue.INativeInt x, StackValue.INativeInt y) => StackValue.FromValue((nuint)x.Value << (int)y.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
