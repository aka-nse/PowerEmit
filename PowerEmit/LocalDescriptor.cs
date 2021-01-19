using System;
using System.Collections.Generic;


namespace PowerEmit
{
    /// <summary>
    /// Represents a local variable on <see cref="MethodDescription"/> instance.
    /// </summary>
    public sealed class LocalDescriptor : VariableDescriptor
    {
        internal LocalDescriptor(Type variableType, string name)
            : base(variableType, name)
        {
        }

        public override string ToString()
            => $"(local) {VariableType} {Name}";
    }
}
