using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Represents IL stream action which means marking label.
    /// </summary>
    public interface IILStreamLabelMark : IILStreamAction
    {
        /// <summary>
        /// Gets the specified label descriptor.
        /// </summary>
        LabelDescriptor Label { get; }
    }
}
