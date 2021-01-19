using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldfld</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldfld(FieldInfo operand)
            => new Emit_Ldfld(operand);


        private sealed class Emit_Ldfld : ILStreamInstruction<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldfld;

            public Emit_Ldfld(FieldInfo operand)
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
                state.EvaluationStack.Push(StackType.FromType(Operand.FieldType));
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                var resultValue = default(object);
                switch(value)
                {
                case StackValue.O:
                    resultValue = Operand.GetValue(value.ObjectValue);
                    break;
                case StackValue.ManagedPtr:
                case StackValue.NativeInt:
                    throw new NotSupportedException();
                default:
                    throw new Exception();
                }
                state.EvaluationStack.Push(StackValue.FromValue(resultValue));
            }
        }
    }
}
