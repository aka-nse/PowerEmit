using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public sealed class Ldloc_Opt : ICilOperation
    {
        public OpCode OpCode
            => OpCodes.Ldloc;

        
        public int? ByteSize => null;


        public int StackBalance => 1;
        int? ICilGeneratorAction.StackBalance => StackBalance;


        public CilLocal Local { get; }


        internal Ldloc_Opt(CilLocal local)
        {
            Local = local;
        }


        public void Emit(CilGeneratorState state)
        {
            var index = state.Locals[Local];
            switch(index)
            {
            case 0: state.Generator.Emit(OpCodes.Ldloc_0); return;
            case 1: state.Generator.Emit(OpCodes.Ldloc_1); return;
            case 2: state.Generator.Emit(OpCodes.Ldloc_2); return;
            case 3: state.Generator.Emit(OpCodes.Ldloc_3); return;
            }
            if(index <= byte.MaxValue)
                state.Generator.Emit(OpCodes.Ldloc_S, (byte)index);
            else
                state.Generator.Emit(OpCodes.Ldloc, (short)(ushort)index);
        }


        public int GetByteSize(CilGeneratorState state)
        {
            var index = state.Locals[Local];
            switch(index)
            {
            case 0: return OpCodes.Ldloc_0.GetTotalByteSize();
            case 1: return OpCodes.Ldloc_1.GetTotalByteSize();
            case 2: return OpCodes.Ldloc_2.GetTotalByteSize();
            case 3: return OpCodes.Ldloc_3.GetTotalByteSize();
            }
            return index <= byte.MaxValue
                 ? OpCodes.Ldloc_S.GetTotalByteSize()
                 : OpCodes.Ldloc.GetTotalByteSize();
        }


        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
