using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Represents IL stream action which binds an opcode and corresponding operand.
    /// </summary>
    public interface IILStreamInstruction : IILStreamAction
    {
        /// <summary>
        /// Gets opcode of this oeration.
        /// If there are some candidates, returns most typical one.
        /// </summary>
        OpCode OpCode { get; }
    }

    /// <summary>
    /// Represents <see cref="IILStreamInstruction"/> which has operand.
    /// </summary>
    public interface IILStreamInstruction<T> : IILStreamInstruction
    {
        T Operand { get; }
    }
}
