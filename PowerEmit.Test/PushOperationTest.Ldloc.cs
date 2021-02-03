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
        [MemberData(nameof(TestArgs_Ldloc))]
        private void PushTest_Ldloc(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Ldloc()
        {
            var locNums_s = new[] { 0, 1, 2, 3, 4, 127, };
            foreach(var locNum in locNums_s)
            {
                yield return CreateArgs(
                    $"ldloc.s {locNum}",
                    gen => gen.Emit(OpCodes.Ldloc_S, (byte)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Ldloc_S(loc!));
                    }
                );
            }
            foreach(var locNum in locNums_s)
            {
                yield return CreateArgs(
                    $"ldloca.s {locNum}",
                    gen => gen.Emit(OpCodes.Ldloca_S, (byte)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Ldloca_S(loc!));
                    }
                );
            }

            var locNums = new[] { 0, 1, 2, 3, 4, 127, 128, 65535, };
            foreach(var locNum in locNums)
            {
                yield return CreateArgs(
                    $"ldloc {locNum}",
                    gen => gen.Emit(OpCodes.Ldloc, (short)(ushort)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Ldloc(loc!));
                    }
                );
            }
            foreach(var locNum in locNums)
            {
                yield return CreateArgs(
                    $"ldloca {locNum}",
                    gen => gen.Emit(OpCodes.Ldloca, (short)(ushort)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Ldloca(loc!));
                    }
                );
            }

            yield break;
        }
    }
}
