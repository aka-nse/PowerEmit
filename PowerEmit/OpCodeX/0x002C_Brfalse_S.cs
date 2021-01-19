using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>brfalse.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Brfalse_S(LabelDescriptor operand)
            => new Emit_Brfalse_S(operand);


        private sealed class Emit_Brfalse_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Brfalse_S;

            public Emit_Brfalse_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Brfalse.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Brfalse.Invoke(state, Operand);
        }
    }
}
