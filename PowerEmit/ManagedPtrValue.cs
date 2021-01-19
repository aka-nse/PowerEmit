using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit
{
    public sealed class ManagedPtrValue
    {
        public static bool Equals(ManagedPtrValue x, nint y)
            => throw new NotImplementedException();

        public static bool Equals(nint x, ManagedPtrValue y)
            => throw new NotImplementedException();

        public static bool Equals(ManagedPtrValue x, ManagedPtrValue y)
            => throw new NotImplementedException();

        public static int Compare(ManagedPtrValue x, ManagedPtrValue y)
            => throw new NotImplementedException();

        public static int CompareUnsigned(ManagedPtrValue x, ManagedPtrValue y)
            => throw new NotImplementedException();

        public static ManagedPtrValue Add(nint      x, ManagedPtrValue y) => throw new NotImplementedException();
        public static ManagedPtrValue Add(ManagedPtrValue x, nint      y) => throw new NotImplementedException();

        public static ManagedPtrValue Add_Ovf(nint     x, ManagedPtrValue y) => throw new NotImplementedException();
        public static ManagedPtrValue Add_Ovf(ManagedPtrValue x, nint    y) => throw new NotImplementedException();

        public static ManagedPtrValue Add_Ovf_Un(nint      x, ManagedPtrValue y) => throw new NotImplementedException();
        public static ManagedPtrValue Add_Ovf_Un(ManagedPtrValue x, nint      y) => throw new NotImplementedException();
        
        public static ManagedPtrValue Sub(ManagedPtrValue x, nint      y) => throw new NotImplementedException();
        public static nint      Sub(ManagedPtrValue x, ManagedPtrValue y) => throw new NotImplementedException();
        
        public static ManagedPtrValue Sub_Ovf(ManagedPtrValue x, nint      y) => throw new NotImplementedException();
        public static nint      Sub_Ovf(ManagedPtrValue x, ManagedPtrValue y) => throw new NotImplementedException();
        
        public static ManagedPtrValue Sub_Ovf_Un(ManagedPtrValue x, nint      y) => throw new NotImplementedException();
        public static nint      Sub_Ovf_Un(ManagedPtrValue x, ManagedPtrValue y) => throw new NotImplementedException();
    }
}
