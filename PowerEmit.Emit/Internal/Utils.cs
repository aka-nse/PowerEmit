using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit.Emit
{
    internal static class Utils
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            var tmp = rhs;
            rhs = lhs;
            lhs = tmp;
        }
    }
}
