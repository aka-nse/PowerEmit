using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>calli</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Calli(int operand)
            => new Emit_Calli(operand);


        private sealed class Emit_Calli : ILStreamInstruction<int>
        {
            public override OpCode OpCode => OpCodes.Calli;

            public Emit_Calli(int operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotSupportedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
