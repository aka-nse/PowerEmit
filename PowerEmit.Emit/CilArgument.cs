using System;
using System.Collections.Generic;
using PowerEmit.Emit.Linq;

namespace PowerEmit.Emit
{
    public sealed class CilArgument : CilVariable
    {
        public CilArgument(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
