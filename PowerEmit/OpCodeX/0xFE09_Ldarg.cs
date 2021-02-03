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
        public static IILStreamInstruction Ldarg(ArgumentDescriptor operand)
            => new Emit_Ldarg(operand);


        private sealed class Emit_Ldarg : ILStreamInstruction<ArgumentDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ldarg;

            public Emit_Ldarg(ArgumentDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (short)(ushort)state.Arguments[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);


            public static void ValidateStack(IILValidationState state, int argIndex)
                => ValidateStack(state, state.Arguments.ReverseLookup(argIndex));

            public static void ValidateStack(IILValidationState state, ArgumentDescriptor operand)
            {
                state.EvaluationStack.Push(StackType.FromType(operand.VariableType));
            }

            public static void Invoke(IILInvocationState state, int argIndex)
                => Invoke(state, state.Arguments.ReverseLookup(argIndex));

            public static void Invoke(IILInvocationState state, ArgumentDescriptor operand)
            {
                var arg = state.Arguments[operand];
                state.EvaluationStack.Push(StackValue.FromValue(arg));
            }
        }
    }
}
