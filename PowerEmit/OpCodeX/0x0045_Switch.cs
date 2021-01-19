using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>switch</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Switch(IEnumerable<LabelDescriptor> operand)
            => new Emit_Switch(operand);


        private sealed class Emit_Switch : ILStreamInstruction<IEnumerable<LabelDescriptor>>
        {
            public override OpCode OpCode => OpCodes.Switch;

            public Emit_Switch(IEnumerable<LabelDescriptor> operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                var actualOperand = Operand.Select(label => state.Labels[label]).ToArray();
                state.Generator.Emit(OpCode, actualOperand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not StackType.Int32)
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                if(value is not StackValue.Int32 intValue)
                    throw new Exception();

                var target = Operand.ElementAtOrDefault(intValue.Value);
                if(target is null)
                    throw new Exception();
                Emit_Br.BranchTo(state, target);
            }
        }
    }
}
