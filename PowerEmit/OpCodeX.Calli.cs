using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        private sealed class Calli : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Calli;

            public int? ByteSize => throw new NotImplementedException();

            public int? StackBalance => throw new NotImplementedException();

            public void Emit(ILGeneratorState state) => throw new NotImplementedException();
            public int GetByteSize(ILGeneratorState state) => throw new NotImplementedException();
            public int GetStackBalance(ILGeneratorState state) => throw new NotImplementedException();
        }
    }
}