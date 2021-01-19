using System;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace PowerEmit
{
    /// <summary>
    /// Represents a label variable on <see cref="MethodDescription"/> instance.
    /// </summary>
    public class LabelDescriptor
    {
        public string LabelName { get; }

        public LabelDescriptor(string name)
        {
            LabelName = name;
        }

        public override string ToString()
            => $"(label) {LabelName}";
    }
}
