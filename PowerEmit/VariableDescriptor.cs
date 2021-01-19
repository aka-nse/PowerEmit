using System;
using System.Collections.Generic;

namespace PowerEmit
{
    /// <summary>
    /// Represents a variable on <see cref="MethodDescription"/> instance.
    /// </summary>
    public abstract class VariableDescriptor
    {
        /// <summary>
        /// Gets the variable type.
        /// </summary>
        public Type VariableType { get; }


        /// <summary>
        /// Gets the variable name.
        /// </summary>
        public string Name { get; }

        
        private protected VariableDescriptor(Type variableType, string name)
        {
            VariableType = variableType;
            Name = name;
        }
    }
}
