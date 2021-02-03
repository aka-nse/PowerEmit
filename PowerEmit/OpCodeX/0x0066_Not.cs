using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>not</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Not()
            => new Emit_Not();


        private sealed class Emit_Not : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Not;

            public Emit_Not()
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
                    StackType.IInt32     => StackType.Int32    ,
                    StackType.IInt64     => StackType.Int64    ,
                    StackType.INativeInt => StackType.NativeInt,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.IInt32     x => StackValue.FromValue(~x.Value),
                    StackValue.IInt64     x => StackValue.FromValue(~x.Value),
                    StackValue.INativeInt x => StackValue.FromValue(~x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
