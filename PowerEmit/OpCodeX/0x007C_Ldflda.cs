using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldflda</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldflda(FieldInfo operand)
            => new Emit_Ldflda(operand);


        private sealed class Emit_Ldflda : ILStreamInstruction<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldflda;

            public Emit_Ldflda(FieldInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not (StackType.O or StackType.ManagedPtr or StackType.NativeInt))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.ManagedPtr.Instance);
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
