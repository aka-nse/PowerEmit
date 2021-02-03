using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldarga</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldarga(ArgumentDescriptor operand)
            => new Emit_Ldarga(operand);


        private sealed class Emit_Ldarga : ILStreamInstruction<ArgumentDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ldarga;

            public Emit_Ldarga(ArgumentDescriptor operand)
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


            public static void ValidateStack(IILValidationState state, ArgumentDescriptor operand)
            {
                state.EvaluationStack.Push(StackType.FromType(operand.VariableType.MakeByRefType()));
            }

            public static void Invoke(IILInvocationState state, ArgumentDescriptor operand)
            {
                throw new NotSupportedException();
            }
        }
    }
}
