using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public interface IILStreamAction : IEquatable<IILStreamAction>
    {
        int ByteSize { get; }
        void Emit(ILGenerator generator);
    }


    public static class ILStreamAction
    {
        public static ILGenerator Emit<TILAction>(this ILGenerator generator, TILAction inst)
            where TILAction : IILStreamAction
        {
            inst.Emit(generator);
            return generator;
        }
    }
}
