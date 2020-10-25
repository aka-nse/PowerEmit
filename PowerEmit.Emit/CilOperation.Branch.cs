using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public abstract class BranchOperation : ICilOperation
    {
        public abstract OpCode OpCode { get; }

        public CilLabel Operand { get; }

        public int ByteSize => OpCode.Size + OpCode.GetOperandSize();
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance => OpCode.GetStackBalance();
        int? ICilGeneratorAction.StackBalance => StackBalance;


        private protected BranchOperation(CilLabel operand)
        {
            Operand = operand;
        }


        public void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, state.Labels[Operand]);


        public int GetByteSize(CilGeneratorState state) => ByteSize;


        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
