using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    internal static class ExceptionHelper
    {
        internal static InvalidCastException InvalidOperandType()
            => new InvalidCastException("The operand type is not supported.");


        internal static InvalidOperationException AlreadyLabelMarked()
            => new InvalidOperationException("A label has already been marked to teh specified IL generator.");

    }
}
