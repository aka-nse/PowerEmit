using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        public static IILStreamOpCode Starg_Opt(ArgumentDescriptor argument)
            => new Emit_Starg_Opt(argument);


        private sealed class Emit_Starg_Opt : IILStreamOpCode
        {
            public OpCode OpCode
                => OpCodes.Starg;


            int? IILStreamAction.ByteSize => null;


            int? IILStreamAction.StackBalance => -1;


            public ArgumentDescriptor Argument { get; }


            internal Emit_Starg_Opt(ArgumentDescriptor argument)
            {
                Argument = argument;
            }


            public void Emit(ILGeneratorState state)
            {
                var index = state.Arguments[Argument];
                if(index <= byte.MaxValue)
                    state.Generator.Emit(OpCodes.Starg_S, (byte)index);
                else
                    state.Generator.Emit(OpCodes.Starg, (short)(ushort)index);
            }


            public int GetByteSize(ILGeneratorState state)
                => state.Arguments[Argument] <= byte.MaxValue
                 ? OpCodes.Starg_S.GetTotalByteSize()
                 : OpCodes.Starg.GetTotalByteSize();


            public int GetStackBalance(ILGeneratorState state)
                => throw new NotImplementedException();
        }
    }
}