using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>unbox.any</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Unbox_Any(Type operand)
            => new Emit_Unbox_Any(operand);


        private sealed class Emit_Unbox_Any : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Unbox_Any;

            public Emit_Unbox_Any(Type operand)
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
                if(type is not StackType.IObj objType)
                    throw new Exception();
                if(!(objType.Type?.IsValueType ?? false))
                    throw new Exception();
                state.EvaluationStack.Push(StackType.FromType(objType.Type));
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
