using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        public static IILStreamOpCode Stloc_Opt(LocalDescriptor local)
            => new Emit_Stloc_Opt(local);


        private sealed class Emit_Stloc_Opt : IILStreamOpCode
        {
            public OpCode OpCode
                => OpCodes.Stloc;


            public int? ByteSize => null;


            public int StackBalance => -1;
            int? IILStreamAction.StackBalance => StackBalance;


            public LocalDescriptor Local { get; }


            internal Emit_Stloc_Opt(LocalDescriptor local)
            {
                Local = local;
            }


            public void Emit(ILGeneratorState state)
            {
                var index = state.Locals[Local];
                switch(index)
                {
                case 0: state.Generator.Emit(OpCodes.Stloc_0); return;
                case 1: state.Generator.Emit(OpCodes.Stloc_1); return;
                case 2: state.Generator.Emit(OpCodes.Stloc_2); return;
                case 3: state.Generator.Emit(OpCodes.Stloc_3); return;
                }
                if(index <= byte.MaxValue)
                    state.Generator.Emit(OpCodes.Stloc_S, (byte)index);
                else
                    state.Generator.Emit(OpCodes.Stloc, (short)(ushort)index);
            }


            public int GetByteSize(ILGeneratorState state)
            {
                var index = state.Locals[Local];
                switch(index)
                {
                case 0: return OpCodes.Stloc_0.GetTotalByteSize();
                case 1: return OpCodes.Stloc_1.GetTotalByteSize();
                case 2: return OpCodes.Stloc_2.GetTotalByteSize();
                case 3: return OpCodes.Stloc_3.GetTotalByteSize();
                }
                return index <= byte.MaxValue
                     ? OpCodes.Stloc_S.GetTotalByteSize()
                     : OpCodes.Stloc.GetTotalByteSize();
            }


            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }
}