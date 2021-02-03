using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>starg</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Starg(ArgumentDescriptor operand)
            => new Emit_Starg(operand);


        private sealed class Emit_Starg : ILStreamInstruction<ArgumentDescriptor>
        {
            public override OpCode OpCode => OpCodes.Starg;

            public Emit_Starg(ArgumentDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (short)(ushort)state.Arguments[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);

            public static void ValidateStack(IILValidationState state, ArgumentDescriptor operand)
            {
                var type = state.EvaluationStack.Pop();
                if(!type.IsAssignableTo(operand))
                    throw new Exception();
            }

            public static void Invoke(IILInvocationState state, ArgumentDescriptor operand)
            {
                var value = state.EvaluationStack.Pop();
                if(!value.TryToAssignable(operand).Try(out var valueObj))
                    throw new Exception();
                state.Arguments[operand] = valueObj;
            }
        }
    }
}
