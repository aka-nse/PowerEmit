using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ble.s</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ble_S(LabelDescriptor operand)
            => new Emit_Ble_S(operand);


        private sealed class Emit_Ble_S : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ble_S;

            public Emit_Ble_S(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => Emit_Ble.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Ble.Invoke(state, Operand);
        }
    }
}
