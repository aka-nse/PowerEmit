using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Emit
{
    partial class PushOperationTest
    {
        public static IEnumerable<object[]> TestArgs_Opt()
        {
            // Ldarg
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_0),
                desc =>
                {
                    var arg0 = new CilArgument(typeof(int), "arg0");
                    desc.AddArgument(arg0);
                    desc.Push_Ldarg_Opt(arg0);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_1),
                desc =>
                {
                    var arg0 = new CilArgument(typeof(int), "arg0");
                    var arg1 = new CilArgument(typeof(int), "arg1");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.Push_Ldarg_Opt(arg1);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_2),
                desc =>
                {
                    var arg0 = new CilArgument(typeof(int), "arg0");
                    var arg1 = new CilArgument(typeof(int), "arg1");
                    var arg2 = new CilArgument(typeof(int), "arg2");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.AddArgument(arg2);
                    desc.Push_Ldarg_Opt(arg2);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_3),
                desc =>
                {
                    var arg0 = new CilArgument(typeof(int), "arg0");
                    var arg1 = new CilArgument(typeof(int), "arg1");
                    var arg2 = new CilArgument(typeof(int), "arg2");
                    var arg3 = new CilArgument(typeof(int), "arg3");
                    desc.AddArgument(arg0);
                    desc.AddArgument(arg1);
                    desc.AddArgument(arg2);
                    desc.AddArgument(arg3);
                    desc.Push_Ldarg_Opt(arg3);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)4),
                desc =>
                {
                    var arg = default(CilArgument);
                    for(var i = 0; i <= 4; ++i)
                    {
                        arg = new CilArgument(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Push_Ldarg_Opt(arg);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg_S, (byte)127),
                desc =>
                {
                    var arg = default(CilArgument);
                    for(var i = 0; i <= 127; ++i)
                    {
                        arg = new CilArgument(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Push_Ldarg_Opt(arg);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg, (ushort)256),
                desc =>
                {
                    var arg = default(CilArgument);
                    for(var i = 0; i <= 256; ++i)
                    {
                        arg = new CilArgument(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Push_Ldarg_Opt(arg);
                }
            );
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg, unchecked((short)(ushort)65535)),
                desc =>
                {
                    var arg = default(CilArgument);
                    for(var i = 0; i <= 65535; ++i)
                    {
                        arg = new CilArgument(typeof(int), $"arg{i}");
                        desc.AddArgument(arg);
                    }
                    desc.Push_Ldarg_Opt(arg);
                }
            );
            yield break;
        }
    }
}
