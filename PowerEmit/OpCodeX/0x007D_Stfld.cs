using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stfld</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Stfld(FieldInfo operand)
            => new Emit_Stfld(operand);


        private sealed class Emit_Stfld : ILStreamInstruction<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Stfld;

            public Emit_Stfld(FieldInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                if(types[1] is not (StackType.O or StackType.ManagedPtr or StackType.NativeInt))
                    throw new Exception();
                if(Operand.FieldType.IsAssignableFrom(types[0].Type))
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                var values = state.EvaluationStack.Pop(2);
                var (obj, value) = (values[1], values[0]);
                switch(obj)
                {
                case StackValue.O:
                    Operand.SetValue(obj, value);
                    return;
                case StackValue.ManagedPtr:
                case StackValue.NativeInt:
                    throw new NotSupportedException();
                default:
                    throw new Exception();
                }
            }
        }
    }
}
