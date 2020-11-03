using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        public static IILStreamOpCode I4_Opt(int value)
            => new Emit_Ldc_I4_Opt(value);


        private sealed class Emit_Ldc_I4_Opt : IILStreamOpCode
        {
            public OpCode OpCode
                => Value switch
                {
                    -1 => OpCodes.Ldc_I4_M1,
                    0 => OpCodes.Ldc_I4_0,
                    1 => OpCodes.Ldc_I4_1,
                    2 => OpCodes.Ldc_I4_2,
                    3 => OpCodes.Ldc_I4_3,
                    4 => OpCodes.Ldc_I4_4,
                    5 => OpCodes.Ldc_I4_5,
                    6 => OpCodes.Ldc_I4_6,
                    7 => OpCodes.Ldc_I4_7,
                    8 => OpCodes.Ldc_I4_8,
                    _ => (sbyte.MinValue <= Value && Value <= sbyte.MaxValue)
                         ? OpCodes.Ldc_I4_S
                         : OpCodes.Ldc_I4,
                };


            public int ByteSize => OpCode.GetTotalByteSize();
            int? IILStreamAction.ByteSize => ByteSize;


            public int StackBalance => 1;
            int? IILStreamAction.StackBalance => StackBalance;


            public int Value { get; }


            public Emit_Ldc_I4_Opt(int value)
            {
                Value = value;
            }


            public void Emit(ILGeneratorState state)
            {
                if(-1 <= Value && Value <= 8)
                {
                    state.Generator.Emit(OpCode);
                }
                else if(sbyte.MinValue <= Value && Value <= sbyte.MaxValue)
                {
                    state.Generator.Emit(OpCode, (sbyte)Value);
                }
                else
                {
                    state.Generator.Emit(OpCode, Value);
                }
            }


            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }
}