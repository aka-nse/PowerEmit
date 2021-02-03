using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>starg.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Starg_S(ArgumentDescriptor operand)
            => new Emit_Starg_S(operand);


        private sealed class Emit_Starg_S : ILStreamInstruction<ArgumentDescriptor>
        {
            public override OpCode OpCode => OpCodes.Starg_S;

            public Emit_Starg_S(ArgumentDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (byte)state.Arguments[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Starg.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Starg.Invoke(state, Operand);
        }
    }
}
