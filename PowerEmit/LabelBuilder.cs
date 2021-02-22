using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace PowerEmit
{
    public sealed class LabelBuilder
    {
        private readonly Dictionary<ILGenerator, Label> _definedLabels = new Dictionary<ILGenerator, Label>();
        private readonly Dictionary<ILGenerator, Label> _markedLabels  = new Dictionary<ILGenerator, Label>();

        public string Name { get; }

        public LabelBuilder(string name)
            => Name = name;

        public override string ToString() => $"{{LabelBuilder \"{Name}\"}}";

        public Label GetLabel(ILGenerator targetGenerator)
        {
            if(_definedLabels.TryGetValue(targetGenerator, out var value))
                return value;

            var label = targetGenerator.DefineLabel();
            _definedLabels.Add(targetGenerator, label);
            return label;
        }

        public void MarkLabel(ILGenerator targetGenerator)
        {
            if(_markedLabels.ContainsKey(targetGenerator))
                throw ExceptionHelper.AlreadyLabelMarked();

            var label = GetLabel(targetGenerator);
            targetGenerator.MarkLabel(label);
            _markedLabels.Add(targetGenerator, label);
        }
    }
}