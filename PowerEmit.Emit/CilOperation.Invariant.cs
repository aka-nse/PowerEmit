using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public abstract class InvariantOperation : ICilOperation
    {
        public abstract OpCode OpCode { get; }

        public int ByteSize => OpCode.GetTotalByteSize();
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance => OpCode.GetStackBalance();
        int? ICilGeneratorAction.StackBalance => StackBalance;

        private protected InvariantOperation()
        {
        }


        public void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode);


        public int GetByteSize(CilGeneratorState state)
            => ByteSize;


        public int GetStackBalance(CilGeneratorState state)
            => StackBalance;
    }
}
