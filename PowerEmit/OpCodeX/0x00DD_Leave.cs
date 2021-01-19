using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>leave</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Leave(LabelDescriptor operand)
            => new Emit_Leave(operand);


        private sealed class Emit_Leave : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Leave;

            public Emit_Leave(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, state.Labels[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, default);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, default);

            public static void ValidateStack(IILValidationState state, int? dummy = default)
            {
            }

            public static void Invoke(IILInvocationState state, int? dummy = default)
            {
                throw new NotSupportedException();
            }
        }
    }
}
