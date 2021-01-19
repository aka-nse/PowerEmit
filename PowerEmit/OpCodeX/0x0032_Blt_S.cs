using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>blt.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Blt_S(LabelDescriptor operand)
            => new Emit_Blt_S(operand);


        private sealed class Emit_Blt_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Blt_S;

            public Emit_Blt_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Blt.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Blt.Invoke(state, Operand);
        }
    }
}
