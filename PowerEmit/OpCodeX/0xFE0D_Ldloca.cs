using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldloca</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldloca(LocalDescriptor operand)
            => new Emit_Ldloca(operand);


        private sealed class Emit_Ldloca : ILStreamInstruction<LocalDescriptor>
        {
            public override OpCode OpCode => OpCodes.Ldloca;

            public Emit_Ldloca(LocalDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (short)(ushort)state.Locals[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }

            public static void ValidateStack(IILValidationState state, LocalDescriptor operand)
            {
                state.EvaluationStack.Push(StackType.FromType(operand.VariableType.MakeByRefType()));
            }

            public static void Invoke(IILInvocationState state, LocalDescriptor operand)
            {
                throw new NotSupportedException();
            }
        }
    }
}
