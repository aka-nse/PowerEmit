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
        [MemberData(nameof(TestArgs_Stloc_Opt))]
        private void PushTest_Stloc_Opt(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Stloc_Opt()
        {
            yield return CreateArgs(
                "stloc.0",
                gen => gen.Emit(OpCodes.Stloc_0),
                desc =>
                {
                    var loc0 = desc.AddLocal(typeof(int), "loc0");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc0));
                }
            );
            yield return CreateArgs(
                "stloc.1",
                gen => gen.Emit(OpCodes.Stloc_1),
                desc =>
                {
                    var loc0 = desc.AddLocal(typeof(int), "loc0");
                    var loc1 = desc.AddLocal(typeof(int), "loc1");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc1));
                }
            );
            yield return CreateArgs(
                "stloc.2",
                gen => gen.Emit(OpCodes.Stloc_2),
                desc =>
                {
                    var loc0 = desc.AddLocal(typeof(int), "loc0");
                    var loc1 = desc.AddLocal(typeof(int), "loc1");
                    var loc2 = desc.AddLocal(typeof(int), "loc2");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc2));
                }
            );
            yield return CreateArgs(
                "stloc.3",
                gen => gen.Emit(OpCodes.Stloc_3),
                desc =>
                {
                    var loc0 = desc.AddLocal(typeof(int), "loc0");
                    var loc1 = desc.AddLocal(typeof(int), "loc1");
                    var loc2 = desc.AddLocal(typeof(int), "loc2");
                    var loc3 = desc.AddLocal(typeof(int), "loc3");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc3));
                }
            );
            yield return CreateArgs(
                "stloc.s 4",
                gen => gen.Emit(OpCodes.Stloc_S, (byte)4),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 4; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield return CreateArgs(
                "stloc.s 127",
                gen => gen.Emit(OpCodes.Stloc_S, (byte)127),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 127; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield return CreateArgs(
                "stloc.s 128",
                gen => gen.Emit(OpCodes.Stloc_S, (byte)128),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 128; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield return CreateArgs(
                "stloc.s 255",
                gen => gen.Emit(OpCodes.Stloc_S, (byte)255),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 255; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield return CreateArgs(
                "stloc 256",
                gen => gen.Emit(OpCodes.Stloc, (short)256),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 256; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield return CreateArgs(
                "stloc 65535",
                gen => gen.Emit(OpCodes.Stloc, unchecked((short)(ushort)65535)),
                desc =>
                {
                    var loc = default(LocalDescriptor);
                    for(var i = 0; i <= 65535; ++i)
                        loc = desc.AddLocal(typeof(int), $"loc{i}");
                    desc.Stream.Add(OpCodeX.Stloc_X(loc!));
                }
            );
            yield break;
        }
    }
}
