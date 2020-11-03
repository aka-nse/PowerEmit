using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        [Theory]
        [MemberData(nameof(TestArgs_Integration))]
        private void PushTest_Integration(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => PushTestCore(testname, expected, actual, returnType, parameterTypes);


        public static IEnumerable<object[]> TestArgs_Integration()
        {
            yield return CreateArgs(
                "AddInt32",
                gen => {
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Add);
                    gen.Emit(OpCodes.Ret);
                },
                desc => {
                    desc.Stream.Add(OpCodeX.Ldarg_0());
                    desc.Stream.Add(OpCodeX.Ldarg_1());
                    desc.Stream.Add(OpCodeX.Add());
                    desc.Stream.Add(OpCodeX.Ret());
                },
                typeof(int), new Type[] { typeof(int), typeof(int) });

            yield break;
        }
    }
}
