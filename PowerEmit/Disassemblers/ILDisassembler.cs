using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PowerEmit.Disassemblers
{
    public partial class ILDisassembler
    {
        public static ILDisassembler Instance { get; } = new ILDisassembler();

        protected ILDisassembler()
        {
        }

        public virtual MethodContent Disassemble(MethodBase method)
        {
            var entity = new Entity(method);
            return new MethodContent(
                entity.Arguments,
                entity.Locals,
                entity.Labels.Values.ToList(),
                entity.ILActions
                );
        }
    }
}