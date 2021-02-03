﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>conv.ovf.i2.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Conv_Ovf_I2_Un()
            => new Emit_Conv_Ovf_I2_Un();


        private sealed class Emit_Conv_Ovf_I2_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I2_Un;

            public Emit_Conv_Ovf_I2_Un()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var type = state.EvaluationStack.Pop();
                IStackType resultType = type switch
                {
                    StackType.IInt32 or
                    StackType.IInt64 or
                    StackType.INativeInt or
                    StackType.IFloat => StackType.Int32,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                checked
                {
                    var value = state.EvaluationStack.Pop();
                    var resultValue = value switch
                    {
                        StackValue.IInt32     x => StackValue.FromValue((short)unchecked((uint) x.Value)),
                        StackValue.IInt64     x => StackValue.FromValue((short)unchecked((ulong)x.Value)),
                        StackValue.INativeInt x => StackValue.FromValue((short)unchecked((nuint)x.Value)),
                        StackValue.IFloat x => StackValue.FromValue((short)Math.Abs(Math.Truncate(x.Value))),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
