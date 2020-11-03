using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace PowerEmit
{
    public interface IILStreamAction
    {
        /// <summary>
        /// Gets a bytesize of sum of opcode and operand.
        /// Returns <c>null</c> if it is flexible.
        /// </summary>
        public int? ByteSize { get; }


        /// <summary>
        /// Gets a stack balance of opcode.
        /// Returns <c>null</c> if it is flexible.
        /// </summary>
        public int? StackBalance { get; }


        /// <summary>
        /// Emits this action to the <see cref="ILGenerator"/> instance.
        /// </summary>
        /// <param name="state"></param>
        public void Emit(ILGeneratorState state);

        /// <summary>
        /// Calculates actual byte size of this operation in the specified method.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// This operation is unstuck in the specified method definition.
        /// However, this exception is not always thrown even if the conditions are met.
        /// </exception>
        public int GetByteSize(ILGeneratorState state);

        /// <summary>
        /// Calculates actual stack balance of this operation in the specified method.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// This operation is unstuck in the specified method definition.
        /// However, this exception is not always thrown even if the conditions are met.
        /// </exception>
        public int GetStackBalance(ILGeneratorState state);
    }
}
