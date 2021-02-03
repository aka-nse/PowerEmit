using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>throw</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Throw()
            => new Emit_Throw();


        private sealed class Emit_Throw : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Throw;

            public Emit_Throw()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(type is not StackType.IObj)
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                if(value is not StackValue.IObj)
                    throw new Exception();
                state.ThrowError(value.ObjectValue ?? new NullReferenceException());
            }
        }
    }
}
