using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>call</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Call(MethodInfo operand)
            => new Emit_Call(operand);


        private sealed class Emit_Call : ILStreamInstruction<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Call;

            public Emit_Call(MethodInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);

            public static void ValidateStack(IILValidationState state, MethodInfo operand)
            {
                if(operand.IsStatic)
                    ValidateStackStatic(state, operand);
                else
                    ValidateStackInstance(state, operand);
            }

            public static void Invoke(IILInvocationState state, MethodInfo operand)
            {
                if(operand.IsStatic)
                    InvokeStatic(state, operand);
                else
                    InvokeInstance(state, operand);
            }


            private static void ValidateStackStatic(IILValidationState state, MethodInfo operand)
            {
                var argTypes = operand.GetParameterTypesWithInstance();
                var types = state.EvaluationStack.Pop(argTypes.Length);
                Array.Reverse(types);
                foreach(var (argType, type) in Enumerable.Zip(argTypes, types, (x, y) => (x, y)))
                {
                    if(!type.IsAssignableTo(argType, PassByKind.Value))
                        throw new Exception();
                }
                if(operand.ReturnType != typeof(void))
                    state.EvaluationStack.Push(StackType.FromType(operand.ReturnType));
            }


            private static void ValidateStackInstance(IILValidationState state, MethodInfo operand)
            {
                var reqInstType = operand.DeclaringType;
                var reqArgTypes = operand.GetParameters().Select(pInfo => pInfo.ParameterType).ToArray();
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
                if(operand.ReturnType != typeof(void))
                    state.EvaluationStack.Push(StackType.FromType(operand.ReturnType));
            }


            private static void InvokeStatic(IILInvocationState state, MethodInfo operand)
            {
                var argTypes = operand.GetParameters().Select(pInfo => pInfo.ParameterType).ToArray();
                var values = state.EvaluationStack.Pop(argTypes.Length);
                Array.Reverse(values);
                var valueObjs = values.Zip(argTypes, (value, argType) => value.ToAssignable(argType)).ToArray();
                var retval = operand.Invoke(null, valueObjs);
                if(operand.ReturnType != typeof(void))
                    state.EvaluationStack.Push(StackValue.FromValue(retval));
            }

            private static void InvokeInstance(IILInvocationState state, MethodInfo operand)
            {
                var argTypes = operand.GetParameters().Select(pInfo => pInfo.ParameterType).ToArray();
                var values = state.EvaluationStack.Pop(argTypes.Length);
                var instance = state.EvaluationStack.Pop();
                Array.Reverse(values);
                var instanceObj = instance.ToAssignable(operand.DeclaringType);
                var valueObjs = values.Zip(argTypes, (value, argType) => value.ToAssignable(argType)).ToArray();
                var retval = operand.Invoke(instanceObj, valueObjs);
                if(operand.ReturnType != typeof(void))
                    state.EvaluationStack.Push(StackValue.FromValue(retval));
            }
        }
    }
}
