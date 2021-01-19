using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>bgt</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Bgt(LabelDescriptor operand)
            => new Emit_Bgt(operand);


        private sealed class Emit_Bgt : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Bgt;

            public Emit_Bgt(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit_Br.Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);


            public static void ValidateStack(IILValidationState state, LabelDescriptor operand)
            {
                var types = state.EvaluationStack.Pop(2);
                if(!StackType.AreOrderable(types))
                    throw new Exception();
            }


            public static void Invoke(IILInvocationState state, LabelDescriptor operand)
            {
                var values = state.EvaluationStack.Pop(2);
                if(StackValue.Compare(values) > 0)
                    Emit_Br.BranchTo(state, operand);
            }
        }
    }
}
