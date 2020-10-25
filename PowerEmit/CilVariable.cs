using System;
using System.Collections.Generic;

namespace PowerEmit
{
    public abstract class CilVariable
    {
        public Type VariableType { get; }


        public string Name { get; }

        
        private protected CilVariable(Type variableType, string name)
        {
            VariableType = variableType;
            Name = name;
        }
    }
}
