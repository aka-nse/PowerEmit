using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamOpCode Ret()
            => new Emit_Ret();


        private sealed class Emit_Ret : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Ret;

            public int ByteSize => OpCode.Size;
            int? IILStreamAction.ByteSize => ByteSize;

            public int? StackBalance => null;

            public void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode);

            public int GetByteSize(ILGeneratorState state)
                => ByteSize;

            public int GetStackBalance(ILGeneratorState state)
                => state.Owner.ReturnType == typeof(void) ? 0 : -1;
        }
    }
}