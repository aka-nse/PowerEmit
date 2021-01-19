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
                StackType resultType = type switch
                {
                    StackType.Int32     => StackType.Int32      .Instance,
                    StackType.Int64     => StackType.Int64      .Instance,
                    StackType.NativeInt => StackType.NativeInt  .Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.Int32     x => StackValue.FromValue(~x.Value),
                    StackValue.Int64     x => StackValue.FromValue(~x.Value),
                    StackValue.NativeInt x => StackValue.FromValue(~x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
