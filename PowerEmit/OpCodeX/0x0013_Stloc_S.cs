using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stloc.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Stloc_S(LocalDescriptor operand)
            => new Emit_Stloc_S(operand);


        private sealed class Emit_Stloc_S : ILStreamInstruction<LocalDescriptor>
        {
            public override OpCode OpCode => OpCodes.Stloc_S;

            public Emit_Stloc_S(LocalDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (byte)state.Locals[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stloc.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Stloc.Invoke(state, Operand);
        }
    }
}
