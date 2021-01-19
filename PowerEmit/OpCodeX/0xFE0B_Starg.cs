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
        [CLSCompliant(false)]
        public static IILStreamInstruction Starg(ushort operand)
            => new Emit_Starg(operand);


        private sealed class Emit_Starg : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Starg;

            public Emit_Starg(ushort operand)
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

            public static void ValidateStack(IILValidationState state, ushort argVar)
            {
                var argDesc = state.Owner.Arguments[argVar];

                var type = state.EvaluationStack.Pop();
                if(!type.IsAssignableTo(argDesc))
                    throw new Exception();
            }

            public static void Invoke(IILInvocationState state, ushort argVar)
            {
                var argDesc = state.Owner.Arguments[argVar];

                var value = state.EvaluationStack.Pop();
                if(!value.TryToAssignable(argDesc).Try(out var valueObj))
                    throw new Exception();
                state.Arguments[argVar] = valueObj;
            }
        }
    }
}
