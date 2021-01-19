using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarg</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static IILStreamInstruction Ldarg(ushort operand)
            => new Emit_Ldarg(operand);


        private sealed class Emit_Ldarg : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Ldarg;

            public Emit_Ldarg(ushort operand)
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


            public static void ValidateStack(IILValidationState state, ushort argVar)
            {
                var argDesc = state.Owner.Arguments[argVar];
                state.EvaluationStack.Push(StackType.FromType(argDesc.VariableType));
            }

            public static void Invoke(IILInvocationState state, ushort argVar)
            {
                var arg = state.Arguments[argVar];
                state.EvaluationStack.Push(StackValue.FromValue(arg));
            }
        }
    }
}
