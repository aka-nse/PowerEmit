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
        [CLSCompliant(false)]
        public static IILStreamInstruction Ldarga(ushort operand)
            => new Emit_Ldarga(operand);


        private sealed class Emit_Ldarga : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Ldarga;

            public Emit_Ldarga(ushort operand)
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
                var argDesc = state.Owner.Arguments[operand];
                state.EvaluationStack.Push(StackType.FromType(argDesc.VariableType.MakeByRefType()));
            }

            public static void Invoke(IILInvocationState state, ushort operand)
            {
                var argDesc = state.Owner.Arguments[operand];
                throw new NotSupportedException();
            }
        }
    }
}
