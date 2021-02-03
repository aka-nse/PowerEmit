using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stelem</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Stelem(Type operand)
            => new Emit_Stelem(operand);


        private sealed class Emit_Stelem : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Stelem;

            public Emit_Stelem(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, (arrayType, value) => arrayType.GetElementType()!.IsAssignableFrom(Operand));

            public override void Invoke(IILInvocationState state)
                => Invoke(state, (array, value) => throw new NotImplementedException());

            public static void ValidateStack(IILValidationState state, Func<Type, IStackType, bool> isAssignable)
            {
                var types = state.EvaluationStack.Pop(3);
                var (array, index, value) = (types[2] as StackType.IObj, types[1], types[0]);
                if(array is null || array.IsAssignableTo(typeof(Array), PassByKind.Reference))
                    throw new Exception();
                if(index is not (StackType.IInt32 or StackType.INativeInt))
                    throw new Exception();
                if(!isAssignable(array.Type!, value))
                    throw new Exception();
            }

            public static void Invoke(IILInvocationState state, Func<Array, StackValue, object?> getAssigningValue)
            {
                throw new NotSupportedException();
            }
        }
    }
}
