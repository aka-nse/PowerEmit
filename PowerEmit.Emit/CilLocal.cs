using System;
using System.Collections.Generic;
using PowerEmit.Emit.Linq;

namespace PowerEmit.Emit
{
    public sealed class CilLocal : CilVariable
    {
        public CilLocal(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
