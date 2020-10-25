using System;
using System.Collections.Generic;
using PowerEmit.Linq;

namespace PowerEmit
{
    public sealed class CilArgument : CilVariable
    {
        public CilArgument(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
