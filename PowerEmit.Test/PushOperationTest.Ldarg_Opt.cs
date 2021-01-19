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
        [MemberData(nameof(TestArgs_Ldarg_Opt))]
        private void PushTest_Ldarg_Opt(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Ldarg_Opt()
        {
            yield return CreateArgs(
                "ldarg.0",
                gen => gen.Emit(OpCodes.Ldarg_0),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg0));
                }
            );
            yield return CreateArgs(
                "ldarg.1",
                gen => gen.Emit(OpCodes.Ldarg_1),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    var arg1 = desc.AddArgument(typeof(int), "arg1");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg1));
                }
            );
            yield return CreateArgs(
                "ldarg.2",
                gen => gen.Emit(OpCodes.Ldarg_2),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    var arg1 = desc.AddArgument(typeof(int), "arg1");
                    var arg2 = desc.AddArgument(typeof(int), "arg2");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg2));
                }
            );
            yield return CreateArgs(
                "ldarg.3",
                gen => gen.Emit(OpCodes.Ldarg_3),
                desc =>
                {
                    var arg0 = desc.AddArgument(typeof(int), "arg0");
                    var arg1 = desc.AddArgument(typeof(int), "arg1");
                    var arg2 = desc.AddArgument(typeof(int), "arg2");
                    var arg3 = desc.AddArgument(typeof(int), "arg3");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg3));
                }
            );
            yield return CreateArgs(
                "ldarg.s 4",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)4),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 4; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield return CreateArgs(
                "ldarg.s 127",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)127),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 127; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield return CreateArgs(
                "ldarg.s 128",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)128),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 128; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield return CreateArgs(
                "ldarg.s 255",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)255),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 255; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield return CreateArgs(
                "ldarg 256",
                gen => gen.Emit(OpCodes.Ldarg, (short)256),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 256; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield return CreateArgs(
                "ldarg 65535",
                gen => gen.Emit(OpCodes.Ldarg, unchecked((short)(ushort)65535)),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 65535; ++i)
                        arg = desc.AddArgument(typeof(int), $"arg{i}");
                    desc.Stream.Add(OpCodeX.Ldarg_X(arg!));
                }
            );
            yield break;
        }
    }
}
