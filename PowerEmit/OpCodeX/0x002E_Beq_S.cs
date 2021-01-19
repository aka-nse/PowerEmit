using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>beq.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Beq_S(LabelDescriptor operand)
            => new Emit_Beq_S(operand);


        private sealed class Emit_Beq_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Beq_S;

            public Emit_Beq_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Beq.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Beq.Invoke(state, Operand);
        }
    }
}
