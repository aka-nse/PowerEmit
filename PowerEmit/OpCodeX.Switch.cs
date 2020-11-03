 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamAction Switch(IEnumerable<LabelDescriptor> operand)
            => new Emit_Switch(operand);

        private sealed class Emit_Switch : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Switch;

            public IReadOnlyList<LabelDescriptor> Operand { get; }

            public int ByteSize => throw new NotImplementedException();
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;

            internal Emit_Switch(IEnumerable<LabelDescriptor> operand)
            {
                Operand = operand.ToList().AsReadOnly();
            }

            public void Emit(ILGeneratorState state) => state.Generator.Emit(OpCode, Operand.Select(label => state.Labels[label]).ToArray());
            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }

}