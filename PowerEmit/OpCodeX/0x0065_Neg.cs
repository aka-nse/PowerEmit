using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>neg</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Neg()
            => new Emit_Neg();


        private sealed class Emit_Neg : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Neg;

            public Emit_Neg()
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
                    StackType.IInt32       => StackType.Int32    ,
                    StackType.IInt64       => StackType.Int64    ,
                    StackType.INativeInt   => StackType.NativeInt,
                    StackType.IFloat       => StackType.Float    ,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = value switch
                {
                    StackValue.IInt32       x => StackValue.FromValue(-x.Value),
                    StackValue.IInt64       x => StackValue.FromValue(-x.Value),
                    StackValue.INativeInt   x => StackValue.FromValue(-x.Value),
                    StackValue.IFloat x => StackValue.FromValue(-x.Value),
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultValue);
            }
        }
    }
}
