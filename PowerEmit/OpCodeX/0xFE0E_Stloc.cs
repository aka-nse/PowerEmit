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
        public static IILStreamInstruction Stloc(LocalDescriptor operand)
            => new Emit_Stloc(operand);


        private sealed class Emit_Stloc : ILStreamInstruction<LocalDescriptor>
        {
            public override OpCode OpCode => OpCodes.Stloc;

            public Emit_Stloc(LocalDescriptor operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, (short)(ushort)state.Locals[Operand]);
            }

            public override void ValidateStack(IILValidationState state)
                => ValidateStack(state, Operand);

            public override void Invoke(IILInvocationState state)
                => Invoke(state, Operand);


            public static void ValidateStack(IILValidationState state, int argIndex)
                => ValidateStack(state, state.Locals.ReverseLookup(argIndex));

            public static void ValidateStack(IILValidationState state, LocalDescriptor operand)
            {
                var type = state.EvaluationStack.Pop();
                if(!type.IsAssignableTo(operand))
                    throw new Exception();
            }


            public static void Invoke(IILInvocationState state, int argIndex)
                => Invoke(state, state.Locals.ReverseLookup(argIndex));

            public static void Invoke(IILInvocationState state, LocalDescriptor operand)
            {
                var value = state.EvaluationStack.Pop();
                if(!value.TryToAssignable(operand).Try(out var valueObj))
                    throw new Exception();
                state.Locals[operand] = valueObj;
            }
        }
    }
}
