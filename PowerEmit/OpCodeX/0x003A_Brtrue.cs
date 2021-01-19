using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>brtrue</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Brtrue(LabelDescriptor operand)
            => new Emit_Brtrue(operand);


        private sealed class Emit_Brtrue : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Brtrue;

            public Emit_Brtrue(LabelDescriptor operand)
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
                if(state.EvaluationStack.Pop() is not StackType.Int32)
                    throw new Exception();
            }


            public static void Invoke(IILInvocationState state, LabelDescriptor operand)
            {
                var value = state.EvaluationStack.Pop();
                if(value is not StackValue.Int32 intValue)
                    throw new Exception();

                if(intValue.Value != 0)
                    Emit_Br.BranchTo(state, operand);
            }
        }
    }
}
