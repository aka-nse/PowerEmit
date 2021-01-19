using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarga.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldarga_S(byte operand)
            => new Emit_Ldarga_S(operand);


        private sealed class Emit_Ldarga_S : ILStreamInstruction<byte>
        {
            public override OpCode OpCode => OpCodes.Ldarga_S;

            public Emit_Ldarga_S(byte operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Ldarga.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ldarga.Invoke(state, Operand);
        }
    }
}
