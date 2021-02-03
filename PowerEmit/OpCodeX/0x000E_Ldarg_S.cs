using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarg.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldarg_S(ArgumentDescriptor operand)
            => new Emit_Ldarg_S(operand);


        private sealed class Emit_Ldarg_S : ILStreamInstruction<ArgumentDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ldarg_S;

            public Emit_Ldarg_S(ArgumentDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (byte)state.Arguments[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldarg.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldarg.Invoke(state, Operand);
        }
    }
}
