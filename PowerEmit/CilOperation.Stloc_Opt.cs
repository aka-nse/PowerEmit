using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public sealed class Stloc_Opt : ICilOperation
    {
        public OpCode OpCode
            => OpCodes.Stloc;

        
        public int? ByteSize => null;


        public int StackBalance => -1;
        int? ICilGeneratorAction.StackBalance => StackBalance;


        public CilLocal Local { get; }


        internal Stloc_Opt(CilLocal local)
        {
            Local = local;
        }


        public void Emit(CilGeneratorState state)
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


        public int GetByteSize(CilGeneratorState state)
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


        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
