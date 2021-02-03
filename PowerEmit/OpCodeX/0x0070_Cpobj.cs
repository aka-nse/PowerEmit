using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>cpobj</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Cpobj(Type operand)
            => new Emit_Cpobj(operand);


        private sealed class Emit_Cpobj : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Cpobj;

            public Emit_Cpobj(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                static bool cpobj(StackType[] types)
                {
                    if(types[0] is not StackType.INativeInt && types[0] is not StackType.IManagedPtr)
                        return false;
                    if(types[1] is not StackType.INativeInt && types[1] is not StackType.IManagedPtr)
                        return false;
                    return true;
                }

                var types = state.EvaluationStack.Pop(2);
                if(types[0] is not (StackType.INativeInt or StackType.IManagedPtr))
                    throw new Exception();
                if(types[1] is not (StackType.INativeInt or StackType.IManagedPtr))
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotSupportedException();
            }
        }
    }
}
