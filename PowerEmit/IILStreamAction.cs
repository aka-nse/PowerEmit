using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace PowerEmit
{
    /// <summary>
    /// Represents some action for IL stream.
    /// </summary>
    public interface IILStreamAction
    {
        /// <summary>
        /// Emits this action to the <see cref="ILGenerator"/> instance.
        /// </summary>
        /// <param name="state"></param>
        void Emit(IILEmissionState state);

        /// <summary>
        /// Validates stack balance for emission.
        /// </summary>
        /// <param name="state"></param>
        /// <exception cref="Exception"></exception>
        void ValidateStack(IILValidationState state);

        /// <summary>
        /// Operates this IL action for dynamic invocation.
        /// </summary>
        /// <param name="state"></param>
        /// <returns> If <c>false</c> the method invocation will be terminated by the action. </returns>
        void Invoke(IILInvocationState state);
    }
}
