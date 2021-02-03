using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>newobj</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Newobj(ConstructorInfo operand)
            => new Emit_Newobj(operand);


        private sealed class Emit_Newobj : ILStreamInstruction<ConstructorInfo>
        {
            public override OpCode OpCode => OpCodes.Newobj;

            public Emit_Newobj(ConstructorInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var reqInstType = Operand.DeclaringType;
                var reqArgTypes = Operand.GetParameters().Select(pInfo => pInfo.ParameterType).ToArray();
                var actArgTypes = state.EvaluationStack.Pop(reqArgTypes.Length);
                Array.Reverse(actArgTypes);
                var actInstType = state.EvaluationStack.Pop();

                if(!actInstType.IsAssignableTo(reqInstType, PassByKind.Reference))
                    throw new Exception();
                foreach(var (reqArgType, actArgType) in Enumerable.Zip(reqArgTypes, actArgTypes, (x, y) => (x, y)))
                {
                    if(!actArgType.IsAssignableTo(reqArgType, PassByKind.Value))
                        throw new Exception();
                }
                state.EvaluationStack.Push(StackType.FromType(Operand.DeclaringType));
            }

            public override void Invoke(IILInvocationState state)
            {
                if(Operand.IsStatic)
                    throw new Exception();

                var argTypes = Operand.GetParameters().Select(pInfo => pInfo.ParameterType).ToArray();
                var values = state.EvaluationStack.Pop(argTypes.Length);
                Array.Reverse(values);
                var valueObjs = values.Zip(argTypes, (value, argType) => value.ToAssignable(argType)).ToArray();
                var retval = Operand.Invoke(null, valueObjs);
                state.EvaluationStack.Push(StackValue.FromValue(retval));
            }
        }
    }
}
