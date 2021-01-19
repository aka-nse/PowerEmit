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
        [CLSCompliant(false)]
        public static IILStreamInstruction Ldloca(ushort operand)
            => new Emit_Ldloca(operand);


        private sealed class Emit_Ldloca : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Ldloca;

            public Emit_Ldloca(ushort operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }

            public static void ValidateStack(IILValidationState state, ushort operand)
            {
                var locDesc = state.Owner.Locals[operand];
                state.EvaluationStack.Push(StackType.FromType(locDesc.VariableType.MakeByRefType()));
            }

            public static void Invoke(IILInvocationState state, ushort operand)
            {
                var locDesc = state.Owner.Locals[operand];
                throw new NotSupportedException();
            }
        }
    }
}
