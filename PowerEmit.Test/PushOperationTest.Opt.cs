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
        [MemberData(nameof(TestArgs_Opt))]
        private void PushTest_Opt(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => PushTestCore(testname, expected, actual, returnType, parameterTypes);


        public static IEnumerable<object[]> TestArgs_Opt()
        {
            // Ldarg
            yield return CreateArgs(
                "Ldarg -> 0",
                gen => gen.Emit(OpCodes.Ldarg_0),
                desc =>
                {
                    var arg0 = new ArgumentDescriptor(typeof(int), "arg0");
                    desc.AddArgument(arg0);
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg0));
                }
            );
            yield return CreateArgs(
                "Ldarg -> 1",
                gen => gen.Emit(OpCodes.Ldarg_1),
                desc =>
                {
                    var arg0 = new ArgumentDescriptor(typeof(int), "arg0");
                    var arg1 = new ArgumentDescriptor(typeof(int), "arg1");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg1));
                }
            );
            yield return CreateArgs(
                "Ldarg -> 2",
                gen => gen.Emit(OpCodes.Ldarg_2),
                desc =>
                {
                    var arg0 = new ArgumentDescriptor(typeof(int), "arg0");
                    var arg1 = new ArgumentDescriptor(typeof(int), "arg1");
                    var arg2 = new ArgumentDescriptor(typeof(int), "arg2");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.AddArgument(arg2);
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg2));
                }
            );
            yield return CreateArgs(
                "Ldarg -> 3",
                gen => gen.Emit(OpCodes.Ldarg_3),
                desc =>
                {
                    var arg0 = new ArgumentDescriptor(typeof(int), "arg0");
                    var arg1 = new ArgumentDescriptor(typeof(int), "arg1");
                    var arg2 = new ArgumentDescriptor(typeof(int), "arg2");
                    var arg3 = new ArgumentDescriptor(typeof(int), "arg3");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.AddArgument(arg2);
                    desc.AddArgument(arg3);
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg3));
                }
            );
            yield return CreateArgs(
                "Ldarg -> S 1",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)4),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 4; ++i)
                    {
                        arg = new ArgumentDescriptor(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg!));
                }
            );
            yield return CreateArgs(
                "Ldarg -> S 2",
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)127),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 127; ++i)
                    {
                        arg = new ArgumentDescriptor(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg!));
                }
            );
            yield return CreateArgs(
                "Ldarg -> L 1",
                gen => gen.Emit(OpCodes.Ldarg, (short)256),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 256; ++i)
                    {
                        arg = new ArgumentDescriptor(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg!));
                }
            );
            yield return CreateArgs(
                "Ldarg -> L 2",
                gen => gen.Emit(OpCodes.Ldarg, unchecked((short)(ushort)65535)),
                desc =>
                {
                    var arg = default(ArgumentDescriptor);
                    for(var i = 0; i <= 65535; ++i)
                    {
                        arg = new ArgumentDescriptor(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Stream.Add(OptimizedOpCode.Ldarg_Opt(arg!));
                }
            );
            yield break;
        }
    }
}
