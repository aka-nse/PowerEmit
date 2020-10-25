using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public sealed class MarkLabel : ICilGeneratorAction
    {
        public int? ByteSize => 0;
        public int? StackBalance => 0;

        public CilLabel Label { get; }

        internal MarkLabel(CilLabel label)
        {
            Label = label;
        }


        public void Emit(CilGeneratorState state)
        {
            state.Generator.MarkLabel(state.Labels[Label]);
        }

        public int GetByteSize(CilGeneratorState state) => 0;
        public int GetStackBalance(CilGeneratorState state) => 0;
    }
}
