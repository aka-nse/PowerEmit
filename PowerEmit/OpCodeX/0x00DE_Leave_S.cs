using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>leave.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Leave_S(LabelDescriptor operand)
            => new Emit_Leave_S(operand);


        private sealed class Emit_Leave_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Leave_S;

            public Emit_Leave_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, state.Labels[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Leave.ValidateStack(state);

            public override void Invoke(IILInvocationState state)
                => Emit_Leave.Invoke(state);
        }
    }
}
