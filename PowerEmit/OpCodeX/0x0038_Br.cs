using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>br</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Br(LabelDescriptor operand)
            => new Emit_Br(operand);


        private sealed class Emit_Br : ILStreamInstruction<LabelDescriptor>
        {
            public override OpCode OpCode => OpCodes.Br;

            public Emit_Br(LabelDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
                => Emit(state, OpCode, Operand);

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);


            public static void Emit(IILEmissionState state, OpCode opcode, LabelDescriptor label)
            {
                state.Generator.Emit(opcode, state.Labels[label]);
            }

            public static void ValidateStack(IILValidationState state, LabelDescriptor operand)
            {
            }

            public static void Invoke(IILInvocationState state, LabelDescriptor operand)
            {
                BranchTo(state, operand);
            }

            public static void BranchTo(IILInvocationState state, LabelDescriptor label)
            {
                var stream = state.Owner.Stream;
                var target = stream.FirstOrDefault(a => a is IILStreamLabelMark mark && mark.Label == label);
                if(target is null)
                    throw new Exception();
                var newPos = stream.IndexOf(target);
                state.MoveTo(newPos);
            }
        }
    }
}
