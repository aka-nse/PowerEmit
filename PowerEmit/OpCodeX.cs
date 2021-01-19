using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Provides IL generator actions of default opcodes.
    /// </summary>
    public static partial class OpCodeX
    {
        private abstract class ILStreamInstruction : IILStreamInstruction
        {
            public abstract OpCode OpCode { get; }

            public abstract void Emit(IILEmissionState state);
            public abstract void ValidateStack(IILValidationState state);
            public abstract void Invoke(IILInvocationState state);
        }


        private abstract class ILStreamInstruction<T> : ILStreamInstruction, IILStreamInstruction<T>
        {
            public T Operand { get; }

            public ILStreamInstruction(T operand)
            {
                Operand = operand;
            }
        }
    }
}
