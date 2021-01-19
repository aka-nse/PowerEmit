using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PowerEmit.Disassemblies
{
    public class OptimizedILDisassemberTest : ILDisassemblerTest
    {
        public override ILDisassembler GetDisassembler(MethodInfo methodInfo)
            => new OptimizedILDisassembler(methodInfo);
    }
}
