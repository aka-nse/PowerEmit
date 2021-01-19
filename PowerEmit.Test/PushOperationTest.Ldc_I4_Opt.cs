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
        [MemberData(nameof(TestArgs_Ldc_I4_Opt))]
        private void PushTest_Ldc_I4_Opt(TestCase testCase)
            => PushTestCore(testCase);


        public static IEnumerable<object[]> TestArgs_Ldc_I4_Opt()
        {
            yield return CreateArgs(
                "ldc.i4.m1",
                gen => gen.Emit(OpCodes.Ldc_I4_M1),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(-1))
            );
            yield return CreateArgs(
                "ldc.i4.0",
                gen => gen.Emit(OpCodes.Ldc_I4_0),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(0))
            );
            yield return CreateArgs(
                "ldc.i4.1",
                gen => gen.Emit(OpCodes.Ldc_I4_1),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(1))
            );
            yield return CreateArgs(
                "ldc.i4.2",
                gen => gen.Emit(OpCodes.Ldc_I4_2),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(2))
            );
            yield return CreateArgs(
                "ldc.i4.3",
                gen => gen.Emit(OpCodes.Ldc_I4_3),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(3))
            );
            yield return CreateArgs(
                "ldc.i4.4",
                gen => gen.Emit(OpCodes.Ldc_I4_4),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(4))
            );
            yield return CreateArgs(
                "ldc.i4.5",
                gen => gen.Emit(OpCodes.Ldc_I4_5),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(5))
            );
            yield return CreateArgs(
                "ldc.i4.6",
                gen => gen.Emit(OpCodes.Ldc_I4_6),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(6))
            );
            yield return CreateArgs(
                "ldc.i4.7",
                gen => gen.Emit(OpCodes.Ldc_I4_7),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(7))
            );
            yield return CreateArgs(
                "ldc.i4.8",
                gen => gen.Emit(OpCodes.Ldc_I4_8),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(8))
            );
            yield return CreateArgs(
                "ldc.i4.s 9",
                gen => gen.Emit(OpCodes.Ldc_I4_S, (sbyte)9),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(9))
            );
            yield return CreateArgs(
                "ldc.i4.s -2",
                gen => gen.Emit(OpCodes.Ldc_I4_S, (sbyte)-2),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(-2))
            );
            yield return CreateArgs(
                "ldc.i4.s 127",
                gen => gen.Emit(OpCodes.Ldc_I4_S, (sbyte)127),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(127))
            );
            yield return CreateArgs(
                "ldc.i4.s -128",
                gen => gen.Emit(OpCodes.Ldc_I4_S, (sbyte)-128),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(-128))
            );
            yield return CreateArgs(
                "ldc.i4 128",
                gen => gen.Emit(OpCodes.Ldc_I4, 128),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(128))
            );
            yield return CreateArgs(
                "ldc.i4 -129",
                gen => gen.Emit(OpCodes.Ldc_I4, -129),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_X(-129))
            );
            yield break;
        }
    }
}
