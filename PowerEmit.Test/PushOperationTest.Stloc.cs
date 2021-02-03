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
        [MemberData(nameof(TestArgs_Stloc))]
        private void PushTest_Stloc(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Stloc()
        {
            var locNums_s = new[] { 0, 1, 2, 3, 4, 127, };
            foreach(var locNum in locNums_s)
            {
                yield return CreateArgs(
                    $"ldloc.s {locNum}",
                    gen => gen.Emit(OpCodes.Stloc_S, (byte)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Stloc_S(loc!));
                    }
                );
            }

            var locNums = new[] { 0, 1, 2, 3, 4, 127, 128, 65535, };
            foreach(var locNum in locNums)
            {
                yield return CreateArgs(
                    $"ldloc {locNum}",
                    gen => gen.Emit(OpCodes.Stloc, (short)(ushort)locNum),
                    desc =>
                    {
                        var loc = default(LocalDescriptor);
                        for(var i = 0; i <= locNum; ++i)
                            loc = desc.AddLocal(typeof(int), $"loc{i}");
                        desc.Stream.Add(OpCodeX.Stloc(loc!));
                    }
                );
            }

            yield break;
        }
    }
}
