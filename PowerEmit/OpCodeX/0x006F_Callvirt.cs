using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>callvirt</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Callvirt(MethodInfo operand)
            => new Emit_Callvirt(operand);


        private sealed class Emit_Callvirt : ILStreamInstruction<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Callvirt;

            public Emit_Callvirt(MethodInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Call.ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Emit_Call.Invoke(state, Operand);
        }
    }
}
