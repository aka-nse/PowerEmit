using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    public interface IILStreamLabelMark : IILStreamAction
    {
        LabelDescriptor Label { get; }
    }
}
