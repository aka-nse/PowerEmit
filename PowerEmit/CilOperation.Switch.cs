 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public sealed class Switch : ICilOperation
    {
        public OpCode OpCode => OpCodes.Switch;

        public IReadOnlyList<CilLabel> Operand { get; }

        public int ByteSize => throw new NotImplementedException();
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance => OpCode.GetStackBalance();
        int? ICilGeneratorAction.StackBalance => StackBalance;

        internal Switch(IEnumerable<CilLabel> operand)
        {
            Operand = operand.ToList().AsReadOnly();
        }

        public void Emit(CilGeneratorState state) => state.Generator.Emit(OpCode, Operand.Select(label => state.Labels[label]).ToArray());
        public int GetByteSize(CilGeneratorState state) => ByteSize;
        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
