using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        private static object[] CreateArgs(OpCode opcode, Action<ILGenerator> expected, Action<CilMethodDescription> actual)
            => new object[] { opcode, expected, actual };


        private ITestOutputHelper Output { get; }


        public PushOperationTest(ITestOutputHelper output)
            => Output = output;


        [Theory]
        [MemberData(nameof(TestArgs_Basic))]
        [MemberData(nameof(TestArgs_Branch))]
        [MemberData(nameof(TestArgs_Opt))]
        public void PushTest(OpCode opcode, Action<ILGenerator> expected, Action<CilMethodDescription> actual)
        {
            Output.WriteLine(opcode.Name);

            var builder1 = new Builder(typeof(void));
            var gen1 = builder1.Method.GetILGenerator();
            expected(gen1);
            var expectedByteArray = builder1.GetILBytes();

            var builder2 = new Builder(typeof(void));
            var desc = new CilMethodDescription(typeof(void));
            actual(desc);
            desc.BuildMethod(builder2.Method);
            var actualByteArray = builder2.GetILBytes();

            Assert.Equal(expectedByteArray, actualByteArray);
        }

    }
}
