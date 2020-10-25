using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public sealed class Starg_Opt : ICilOperation
    {
        public OpCode OpCode
            => OpCodes.Starg;


        int? ICilGeneratorAction.ByteSize => null;


        int? ICilGeneratorAction.StackBalance => -1;


        public CilArgument Argument { get; }


        internal Starg_Opt(CilArgument argument)
        {
            Argument = argument;
        }


        public void Emit(CilGeneratorState state)
        {
            var index = state.Arguments[Argument];
            if(index <= byte.MaxValue)
                state.Generator.Emit(OpCodes.Starg_S, (byte)index);
            else
                state.Generator.Emit(OpCodes.Starg, (short)(ushort)index);
        }


        public int GetByteSize(CilGeneratorState state)
            => state.Arguments[Argument] <= byte.MaxValue
             ? OpCodes.Starg_S.GetTotalByteSize()
             : OpCodes.Starg.GetTotalByteSize();


        public int GetStackBalance(CilGeneratorState state)
            => throw new NotImplementedException();
    }
}
