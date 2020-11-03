using System;
using System.Collections.Generic;
using PowerEmit.Linq;

namespace PowerEmit
{
    public sealed class ArgumentDescriptor : VariableDescriptor
    {
        public ArgumentDescriptor(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
