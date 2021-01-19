using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldvirtftn</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldvirtftn(MethodInfo operand)
            => new Emit_Ldvirtftn(operand);


        private sealed class Emit_Ldvirtftn : ILStreamInstruction<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Ldvirtftn;

            public Emit_Ldvirtftn(MethodInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
