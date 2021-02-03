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
        public static IILStreamInstruction Ldloc(LocalDescriptor operand)
            => new Emit_Ldloc(operand);


        private sealed class Emit_Ldloc : ILStreamInstruction<LocalDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ldloc;

            public Emit_Ldloc(LocalDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (short)(ushort)state.Locals[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);


            public static void ValidateStack(IILValidationState state, int argIndex)
                => ValidateStack(state, state.Locals.ReverseLookup(argIndex));

            public static void ValidateStack(IILValidationState state, LocalDescriptor operand)
            {
                state.EvaluationStack.Push(StackType.FromType(operand.VariableType));
            }


            public static void Invoke(IILInvocationState state, int argIndex)
                => Invoke(state, state.Locals.ReverseLookup(argIndex));

            public static void Invoke(IILInvocationState state, LocalDescriptor operand)
            {
                state.EvaluationStack.Push(StackValue.FromValue(operand));
            }
        }
    }
}
