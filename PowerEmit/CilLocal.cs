using System;
using System.Collections.Generic;
using PowerEmit.Linq;

namespace PowerEmit
{
    public sealed class CilLocal : CilVariable
    {
        public CilLocal(Type variableType, string name)
            : base(variableType, name)
        {
        }
    }
}
