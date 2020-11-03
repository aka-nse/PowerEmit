using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        private abstract class BranchOperation : IILStreamOpCode
        {
            public abstract OpCode OpCode { get; }

            public LabelDescriptor Operand { get; }

            public int ByteSize => OpCode.Size + OpCode.GetOperandSize();
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;


            private protected BranchOperation(LabelDescriptor operand)
            {
                Operand = operand;
            }


            public void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, state.Labels[Operand]);


            public int GetByteSize(ILGeneratorState state) => ByteSize;


            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }
}
