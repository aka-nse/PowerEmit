using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>brtrue.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Brtrue_S(LabelDescriptor operand)
            => new Emit_Brtrue_S(operand);


        private sealed class Emit_Brtrue_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Brtrue_S;

            public Emit_Brtrue_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Brtrue.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Brtrue.Invoke(state, Operand);
        }
    }
}
