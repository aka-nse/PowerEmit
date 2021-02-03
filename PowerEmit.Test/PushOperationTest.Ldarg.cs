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
        [MemberData(nameof(TestArgs_Ldarg))]
        private void PushTest_Ldarg(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Ldarg()
        {
            var argNums_s = new[] { 0, 1, 2, 3, 4, 127, };
            foreach(var argNum in argNums_s)
            {
                yield return CreateArgs(
                    $"ldarg.s {argNum}",
                    gen => gen.Emit(OpCodes.Ldarg_S, (byte)argNum),
                    desc =>
                    {
                        var arg = default(ArgumentDescriptor);
                        for(var i = 0; i <= argNum; ++i)
                            arg = desc.AddArgument(typeof(int), $"arg{i}");
                        desc.Stream.Add(OpCodeX.Ldarg_S(arg!));
                    }
                );
            }
            foreach(var argNum in argNums_s)
            {
                yield return CreateArgs(
                    $"ldarga.s {argNum}",
                    gen => gen.Emit(OpCodes.Ldarga_S, (byte)argNum),
                    desc =>
                    {
                        var arg = default(ArgumentDescriptor);
                        for(var i = 0; i <= argNum; ++i)
                            arg = desc.AddArgument(typeof(int), $"arg{i}");
                        desc.Stream.Add(OpCodeX.Ldarga_S(arg!));
                    }
                );
            }

            var argNums = new[] { 0, 1, 2, 3, 4, 127, 128, 65535, };
            foreach(var argNum in argNums)
            {
                yield return CreateArgs(
                    $"ldarg {argNum}",
                    gen => gen.Emit(OpCodes.Ldarg, (short)(ushort)argNum),
                    desc =>
                    {
                        var arg = default(ArgumentDescriptor);
                        for(var i = 0; i <= argNum; ++i)
                            arg = desc.AddArgument(typeof(int), $"arg{i}");
                        desc.Stream.Add(OpCodeX.Ldarg(arg!));
                    }
                );
            }
            foreach(var argNum in argNums)
            {
                yield return CreateArgs(
                    $"ldarga {argNum}",
                    gen => gen.Emit(OpCodes.Ldarga, (short)(ushort)argNum),
                    desc =>
                    {
                        var arg = default(ArgumentDescriptor);
                        for(var i = 0; i <= argNum; ++i)
                            arg = desc.AddArgument(typeof(int), $"arg{i}");
                        desc.Stream.Add(OpCodeX.Ldarga(arg!));
                    }
                );
            }

            yield break;
        }
    }
}
