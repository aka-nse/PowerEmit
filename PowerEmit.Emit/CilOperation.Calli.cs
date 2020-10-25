using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    public sealed class Calli : ICilOperation
    {
        public OpCode OpCode => OpCodes.Calli;

        public int? ByteSize => throw new NotImplementedException();

        public int? StackBalance => throw new NotImplementedException();

        public void Emit(CilGeneratorState state) => throw new NotImplementedException();
        public int GetByteSize(CilGeneratorState state) => throw new NotImplementedException();
        public int GetStackBalance(CilGeneratorState state) => throw new NotImplementedException();
    }
}
