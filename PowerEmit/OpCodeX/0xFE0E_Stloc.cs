using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stloc</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static IILStreamInstruction Stloc(ushort operand)
            => new Emit_Stloc(operand);


        private sealed class Emit_Stloc : ILStreamInstruction<ushort>
        {
            public override OpCode OpCode => OpCodes.Stloc;

            public Emit_Stloc(ushort operand)
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

            public static void ValidateStack(IILValidationState state, ushort locVar)
            {
                var locDesc = state.Owner.Locals[locVar];
                var type = state.EvaluationStack.Pop();
                if(!type.IsAssignableTo(locDesc))
                    throw new Exception();
            }

            public static void Invoke(IILInvocationState state, ushort locVar)
            {
                var locDesc = state.Owner.Locals[locVar];
                var value = state.EvaluationStack.Pop();
                if(!value.TryToAssignable(locDesc).Try(out var valueObj))
                    throw new Exception();
                state.Locals[locVar] = valueObj;
            }
        }
    }
}
