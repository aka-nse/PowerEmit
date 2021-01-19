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
        [MemberData(nameof(TestArgs_Starg_Opt))]
        private void PushTest_Starg_Opt(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Starg_Opt()
        {
            yield return CreateArgs(
                "starg.s 0",
                gen => gen.Emit(OpCodes.Starg_S, (byte)0),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    desc.Stream.Add(OpCodeX.Starg_X(arg0));
                }
            );
            yield return CreateArgs(
                "starg.s 1",
                gen => gen.Emit(OpCodes.Starg_S, (byte)1),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    var arg1 = desc.AddArgument(typeof(int), "arg1");
                    desc.Stream.Add(OpCodeX.Starg_X(arg1));
                }
            );
            yield return CreateArgs(
                "starg.s 255",
                gen => gen.Emit(OpCodes.Starg_S, (byte)255),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 255; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Starg_X(arg!));
                }
            );
            yield return CreateArgs(
                "starg 256",
                gen => gen.Emit(OpCodes.Starg, (short)256),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 256; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Starg_X(arg!));
                }
            );
            yield return CreateArgs(
                "starg 65535",
                gen => gen.Emit(OpCodes.Starg, unchecked((short)(ushort)65535)),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 65535; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Starg_X(arg!));
                }
            );
            yield break;
        }
    }
}
