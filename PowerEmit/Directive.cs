#pragma warning disable CS0659
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public abstract partial class Directive : IILStreamAction
    {
        public abstract int ByteSize { get; }
        public abstract void Emit(ILGenerator generator);
        public abstract bool Equals(IILStreamAction other);

        public override bool Equals(object obj)
            => obj is IILStreamAction other && Equals(other);
    }
}
