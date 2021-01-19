using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>blt.un.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Blt_Un_S(LabelDescriptor operand)
            => new Emit_Blt_Un_S(operand);


        private sealed class Emit_Blt_Un_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Blt_Un_S;

            public Emit_Blt_Un_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Blt_Un.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Blt_Un.Invoke(state, Operand);
        }
    }
}
