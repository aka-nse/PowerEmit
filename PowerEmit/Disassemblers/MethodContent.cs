using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PowerEmit.Disassemblers
{
    public class MethodContent
    {
        public IReadOnlyList<Type> Arguments { get; }
        public IReadOnlyList<Type> Locals { get; }
        public IReadOnlyCollection<LabelBuilder> Labels { get; }
        public IReadOnlyList<IILStreamAction> ILActions { get; }

        internal MethodContent(
            IReadOnlyList<Type> arguments,
            IReadOnlyList<Type> locals,
            IReadOnlyCollection<LabelBuilder> labels,
            IReadOnlyList<IILStreamAction> ilActions)
        {
            Arguments = arguments;
            Locals = locals;
            Labels = labels;
            ILActions = ilActions;
        }
    }
}