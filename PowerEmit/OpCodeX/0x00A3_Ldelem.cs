using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem(Type operand)
            => new Emit_Ldelem(operand);


        private sealed class Emit_Ldelem : ILStreamInstruction<Type>
        {
            public override OpCode OpCode => OpCodes.Ldelem;

            public Emit_Ldelem(Type operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, StackType.FromType(Operand));

            public override void Invoke(IILInvocationState state)
                => Invoke(state, StackType.FromType(Operand));

            public static void ValidateStack(IILValidationState state, IStackType? resultType)
            {
                var types = state.EvaluationStack.Pop(2);
                var (array, index) = (types[1] as StackType.IObj, types[0]);
                if(array is null || array.IsAssignableTo(typeof(Array), PassByKind.Reference))
                    throw new Exception();
                if(index is not (StackType.IInt32 or StackType.INativeInt))
                    throw new Exception();
                resultType ??= StackType.FromType(array.Type!.GetElementType());
                state.EvaluationStack.Push(resultType);
            }

            public static void Invoke(IILInvocationState state, IStackType? resultType)
            {
                throw new NotSupportedException();
            }
        }
    }
}
