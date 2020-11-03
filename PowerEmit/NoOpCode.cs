using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    public static class NoOpCode
    {
        public static IILStreamLabelMark MarkLabel(LabelDescriptor label)
            => new Push_MarkLabel(label);


        private sealed class Push_MarkLabel : IILStreamLabelMark
        {
            public int? ByteSize => 0;
            public int? StackBalance => 0;

            public LabelDescriptor Label { get; }

            internal Push_MarkLabel(LabelDescriptor label)
            {
                Label = label;
            }


            public void Emit(ILGeneratorState state)
            {
                state.Generator.MarkLabel(state.Labels[Label]);
            }

            public int GetByteSize(ILGeneratorState state) => 0;
            public int GetStackBalance(ILGeneratorState state) => 0;
        }
    }
}
