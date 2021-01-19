using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>bge.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Bge_S(LabelDescriptor operand)
            => new Emit_Bge_S(operand);


        private sealed class Emit_Bge_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Bge_S;

            public Emit_Bge_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Bge.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Bge.Invoke(state, Operand);
        }
    }
}
