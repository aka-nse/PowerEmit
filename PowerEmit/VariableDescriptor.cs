using System;
using System.Collections.Generic;

namespace PowerEmit
{
    public abstract class VariableDescriptor
    {
        public Type VariableType { get; }


        public string Name { get; }

        
        private protected VariableDescriptor(Type variableType, string name)
        {
            VariableType = variableType;
            Name = name;
        }
    }
}
