using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public sealed class Ret : ICilOperation
    {
        public OpCode OpCode => OpCodes.Ret;

        public int ByteSize => OpCode.Size;
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int? StackBalance => null;

        public void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode);

        public int GetByteSize(CilGeneratorState state)
            => ByteSize;

        public int GetStackBalance(CilGeneratorState state)
            => state.Owner.ReturnType == typeof(void) ? 0 : -1;
    }
}
