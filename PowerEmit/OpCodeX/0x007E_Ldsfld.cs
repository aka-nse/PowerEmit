using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldsfld</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldsfld(FieldInfo operand)
            => new Emit_Ldsfld(operand);


        private sealed class Emit_Ldsfld : ILStreamInstruction<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldsfld;

            public Emit_Ldsfld(FieldInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                state.EvaluationStack.Push(StackType.FromType(Operand.FieldType));
            }

            public override void Invoke(IILInvocationState state)
            {
                var resultValue = Operand.GetValue(null);
                state.EvaluationStack.Push(StackValue.FromValue(resultValue));
            }
        }
    }
}
