using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldstr</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldstr(string operand)
            => new Emit_Ldstr(operand);


        private sealed class Emit_Ldstr : ILStreamInstruction<string>
        {
            public override OpCode OpCode => OpCodes.Ldstr;

            public Emit_Ldstr(string operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(StackType.FromType(typeof(string)));
            }

            public override void Invoke(IILInvocationState state)
            {
                state.EvaluationStack.Push(StackValue.FromValue(Operand));
            }
        }
    }
}
