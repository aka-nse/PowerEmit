using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ret</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ret()
            => new Emit_Ret();


        private sealed class Emit_Ret : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ret;

            public Emit_Ret()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var returnType = state.Owner.ReturnType;
                if(returnType == typeof(void))
                {
                    if(state.EvaluationStack.Count != 0)
                        throw new Exception();
                }
                else
                {
                    var type = state.EvaluationStack.Pop();
                    if(!type.IsAssignableTo(returnType))
                        throw new Exception();
                }
            }

            public override void Invoke(IILInvocationState state)
            {
                var returnType = state.Owner.ReturnType;
                if(returnType == typeof(void))
                {
                    if(state.EvaluationStack.Count != 0)
                        throw new Exception();
                }
                else
                {
                    var value = state.EvaluationStack.Pop();
                    var valueObj = value.ToAssignable(returnType);
                    state.SetReturnValue(valueObj);
                }
                state.MoveTo(state.Owner.Stream.Count);
            }
        }
    }
}
