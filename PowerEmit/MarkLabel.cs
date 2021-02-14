using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class Directive
    {
        /// <summary>
        /// Marks label at current position.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public static MarkLabel MarkLabel(Label label) => new MarkLabel(label);


        /// <summary>
        /// Marks label at current position.
        /// </summary>
        /// <param name="labelBuilder"></param>
        /// <returns></returns>
        public static MarkLabel MarkLabel(LabelBuilder labelBuilder) => new MarkLabel(labelBuilder);
    }


    public sealed class MarkLabel : Directive
    {
        private readonly Label _label;
        private readonly LabelBuilder? _labelBuilder;

        public override int ByteSize => 0;

        public Label? Label => _labelBuilder is null ? _label : null;
        public LabelBuilder? LabelBuilder => _labelBuilder;


        internal MarkLabel(Label label)
            => _label = label;

        internal MarkLabel(LabelBuilder labelBuilder)
            => _labelBuilder = labelBuilder;

        public Label GetLabel(ILGenerator generator)
            => _labelBuilder is not null ? _labelBuilder.GetLabel(generator) : _label;

        public override void Emit(ILGenerator generator)
            => generator.MarkLabel(GetLabel(generator));

        public override bool Equals(IILStreamAction other)
            => other is MarkLabel mlOther
            && Label == mlOther.Label
            && LabelBuilder == mlOther.LabelBuilder;
    }
}
