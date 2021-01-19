using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>jmp</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Jmp(MethodInfo operand)
            => new Emit_Jmp(operand);


        private sealed class Emit_Jmp : ILStreamInstruction<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Jmp;

            public Emit_Jmp(MethodInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                if(state.EvaluationStack.Count != 0)
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                if(state.EvaluationStack.Count != 0)
                    throw new Exception();
                throw new NotImplementedException();
            }
        }
    }
}
