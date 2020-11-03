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
        private static object[] CreateArgs(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => new object[] { testname, expected, actual };

        private static object[] CreateArgs(OpCode opcode, Action<ILGenerator> expected, Action<MethodDescription> actual)
            => CreateArgs(opcode.Name ?? "unspecified", expected, actual);


        private ITestOutputHelper Output { get; }


        public PushOperationTest(ITestOutputHelper output)
            => Output = output;


        private void PushTestCore(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
        {
            Output.WriteLine(testname);
            returnType ??= typeof(void);
            parameterTypes ??= Array.Empty<Type>();

            var builder1 = new Builder(returnType, parameterTypes);
            var gen1 = builder1.Method.GetILGenerator();
            expected(gen1);
            var expectedByteArray = builder1.GetILBytes();

            var builder2 = new Builder(returnType, parameterTypes);
            var desc = new MethodDescription(returnType);
            actual(desc);
            desc.BuildMethod(builder2.Method);
            var actualByteArray = builder2.GetILBytes();

            Assert.Equal(expectedByteArray, actualByteArray);
        }

    }
}
