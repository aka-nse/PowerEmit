using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ckfinite</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ckfinite()
            => new Emit_Ckfinite();


        private sealed class Emit_Ckfinite : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ckfinite;

            public Emit_Ckfinite()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not StackType.IFloat)
                    throw new Exception();
                state.EvaluationStack.Push(StackType.Float);
            }

            public override void Invoke(IILInvocationState state)
            {
                if(state.EvaluationStack.Pop() is not StackValue.IFloat value)
                    throw new Exception();
                throw new NotSupportedException();
            }
        }
    }
}
