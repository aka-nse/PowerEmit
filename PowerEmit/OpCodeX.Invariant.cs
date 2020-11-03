using System;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        private abstract class InvariantOperation : IILStreamOpCode
        {
            public abstract OpCode OpCode { get; }

            public int ByteSize => OpCode.GetTotalByteSize();
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;

            private protected InvariantOperation()
            {
            }


            public void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode);


            public int GetByteSize(ILGeneratorState state)
                => ByteSize;


            public int GetStackBalance(ILGeneratorState state)
                => StackBalance;
        }
    }
}