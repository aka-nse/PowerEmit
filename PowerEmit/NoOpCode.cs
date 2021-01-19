using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Provides IL generator actions without specified opcode emittion.
    /// </summary>
    public static class NoOpCode
    {
        /// <summary>
        /// Obtains a label marking action.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static IILStreamLabelMark MarkLabel(LabelDescriptor label)
            => new Push_MarkLabel(label);


        private sealed class Push_MarkLabel : IILStreamLabelMark
        {
            public int StackBalance => 0;

            public LabelDescriptor Label { get; }

            internal Push_MarkLabel(LabelDescriptor label)
            {
                Label = label;
            }


            public void Emit(ILGenerationState state, ILGenerator generator)
                => generator.MarkLabel(state.Labels[Label]);

            public void Emit(IILEmissionState state)
                => state.Generator.MarkLabel(state.Labels[Label]);

            public void ValidateStack(IILValidationState state)
            {
            }

            public void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }

            public override string ToString() => Label.LabelName + ":";
        }
    }
}
