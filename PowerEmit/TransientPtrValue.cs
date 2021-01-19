using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit
{
    public sealed class TransientPtrValue
    {
        public static bool Equals(TransientPtrValue x, nint y)
            => throw new NotImplementedException();

        public static bool Equals(nint x, TransientPtrValue y)
            => throw new NotImplementedException();

        public static bool Equals(TransientPtrValue x, TransientPtrValue y)
            => throw new NotImplementedException();

        public static int Compare(TransientPtrValue x, TransientPtrValue y)
            => throw new NotImplementedException();

        public static int CompareUnsigned(TransientPtrValue x, TransientPtrValue y)
            => throw new NotImplementedException();
    }
}
