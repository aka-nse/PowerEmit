using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        private abstract class StatelessOperation<T> : IILStreamOpCode
        {
            public abstract OpCode OpCode { get; }


            public int ByteSize => OpCode.Size + OpCode.GetOperandSize();
            int? IILStreamAction.ByteSize => ByteSize;


            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;


            public T Operand { get; }


            private protected StatelessOperation(T operand)
                => Operand = operand;


            public abstract void Emit(ILGeneratorState state);


            public int GetByteSize(ILGeneratorState state)
                => ByteSize;


            public int GetStackBalance(ILGeneratorState state)
                => StackBalance;
        }
    }
}