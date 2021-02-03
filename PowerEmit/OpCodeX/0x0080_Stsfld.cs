﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stsfld</c>. </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static IILStreamInstruction Stsfld(FieldInfo operand)
            => new Emit_Stsfld(operand);


        private sealed class Emit_Stsfld : ILStreamInstruction<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Stsfld;

            public Emit_Stsfld(FieldInfo operand)
                : base(operand)
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode, Operand);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                if(!type.IsAssignableTo(Operand.FieldType, PassByKind.Value))
                    throw new Exception();
            }

            public override void Invoke(IILInvocationState state)
            {
                var value = state.EvaluationStack.Pop();
                Operand.SetValue(null, value.ObjectValue);
            }
        }
    }
}
