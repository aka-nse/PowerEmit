using System;
using System.Collections.Generic;
using PowerEmit.Linq;

namespace PowerEmit
{
    public sealed class LocalDescriptor : VariableDescriptor
    {
        public LocalDescriptor(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
