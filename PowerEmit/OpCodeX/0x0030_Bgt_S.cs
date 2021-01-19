using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>bgt.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Bgt_S(LabelDescriptor operand)
            => new Emit_Bgt_S(operand);


        private sealed class Emit_Bgt_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Bgt_S;

            public Emit_Bgt_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Bgt.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Bgt.Invoke(state, Operand);
        }
    }
}
