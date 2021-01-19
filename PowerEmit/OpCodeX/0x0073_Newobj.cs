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
                if(Operand.IsStatic)
                    throw new Exception();

                var argTypes = Operand.GetParameters().Select(pi => pi.ParameterType).ToArray();
                var types = state.EvaluationStack.Pop(argTypes.Length);
                Array.Reverse(types);
                foreach(var (argType, type) in Enumerable.Zip(argTypes, types, (x, y) => (x, y)))
                {
                    if(!type.IsAssignableTo(argType))
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
