using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloc</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static IILStreamInstruction Ldloc(ushort operand)
            => new Emit_Ldloc(operand);


        private sealed class Emit_Ldloc : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Ldloc;

            public Emit_Ldloc(ushort operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);

            public static void ValidateStack(IILValidationState state, ushort locVar)
            {
                var locDesc = state.Owner.Locals[locVar];
                state.EvaluationStack.Push(StackType.FromType(locDesc.VariableType));
            }

            public static void Invoke(IILInvocationState state, ushort locVar)
            {
                var loc = state.Locals[locVar];
                state.EvaluationStack.Push(StackValue.FromValue(loc));
            }
        }
    }
}
