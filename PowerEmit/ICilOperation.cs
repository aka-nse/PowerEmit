using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public interface ICilOperation : ICilGeneratorAction
    {
        /// <summary>
        /// Gets opcode of this oeration.
        /// If there are some candidates, returns most typical one.
        /// </summary>
        public OpCode OpCode { get; }
    }
}
