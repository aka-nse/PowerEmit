using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldnull</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldnull()
            => new Emit_Ldnull();


        private sealed class Emit_Ldnull : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldnull;

            public Emit_Ldnull()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => state.EvaluationStack.Push(StackType.FromType(null));

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(StackValue.FromValue(null));
            }
        }
    }
}
