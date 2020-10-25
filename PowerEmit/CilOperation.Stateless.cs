using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public abstract class StatelessOperation<T> : ICilOperation
    {
        public abstract OpCode OpCode { get; }


        public int ByteSize => OpCode.Size + OpCode.GetOperandSize();
        int? ICilGeneratorAction.ByteSize => ByteSize;


        public int StackBalance => OpCode.GetStackBalance();
        int? ICilGeneratorAction.StackBalance => StackBalance;


        public T Operand { get; }


        private protected StatelessOperation(T operand)
            => Operand = operand;


        public abstract void Emit(CilGeneratorState state);


        public int GetByteSize(CilGeneratorState state)
            => ByteSize;


        public int GetStackBalance(CilGeneratorState state)
            => StackBalance;
    }
}
