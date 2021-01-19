using System;
using System.Collections.Generic;


namespace PowerEmit
{
    /// <summary>
    /// Represents an argument on <see cref="MethodDescription"/> instance.
    /// </summary>
    public sealed class ArgumentDescriptor : VariableDescriptor
    {
        internal ArgumentDescriptor(Type variableType, string name)
            : base(variableType, name)
        {
        }

        public override string ToString()
            => $"(arg) {VariableType} {Name}";
    }
}
