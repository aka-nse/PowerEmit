using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit.Disassemblers
{
    public partial class ILDisassemblerTest
    {
        [Theory]
        [MemberData(nameof(GetTestCases_Integration))]
        public void Emit_Integration(TestCase testCase)
            => DisassembleCore(testCase);


        public static IEnumerable<object[]> GetTestCases_Integration()
        {
            #region int Add(int, int)
            yield return CreateTestCase(
                "int Add(int, int)",
                gen =>
                {
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Add);
                    gen.Emit(OpCodes.Ret);
                },
                typeof(int),
                new[] { typeof(int), typeof(int), }
                );
            #endregion

            #region int Sum(int[] array)
            yield return CreateTestCase(
                "int Sum(int[] array)",
                gen =>
                {
                    var retval = gen.DeclareLocal(typeof(int));
                    var i = gen.DeclareLocal(typeof(int));
                    var il_0000 = gen.DefineLabel();
                    var il_0001 = gen.DefineLabel();
                    var il_0002 = gen.DefineLabel();
                    var il_0003 = gen.DefineLabel();
                    var il_0004 = gen.DefineLabel();
                    var il_0006 = gen.DefineLabel();
                    var il_0007 = gen.DefineLabel();
                    var il_0008 = gen.DefineLabel();
                    var il_0009 = gen.DefineLabel();
                    var il_000a = gen.DefineLabel();
                    var il_000b = gen.DefineLabel();
                    var il_000c = gen.DefineLabel();
                    var il_000d = gen.DefineLabel();
                    var il_000e = gen.DefineLabel();
                    var il_000f = gen.DefineLabel();
                    var il_0010 = gen.DefineLabel();
                    var il_0011 = gen.DefineLabel();
                    var il_0012 = gen.DefineLabel();
                    var il_0013 = gen.DefineLabel();
                    var il_0014 = gen.DefineLabel();
                    var il_0016 = gen.DefineLabel();
                    var il_0017 = gen.DefineLabel();
                    gen.MarkLabel(il_0000); gen.Emit(OpCodes.Ldc_I4_0);
                    gen.MarkLabel(il_0001); gen.Emit(OpCodes.Stloc, retval);
                    gen.MarkLabel(il_0002); gen.Emit(OpCodes.Ldc_I4_0);
                    gen.MarkLabel(il_0003); gen.Emit(OpCodes.Stloc, i);
                    gen.MarkLabel(il_0004); gen.Emit(OpCodes.Br_S, il_0010);
                    gen.MarkLabel(il_0006); gen.Emit(OpCodes.Ldloc, retval);
                    gen.MarkLabel(il_0007); gen.Emit(OpCodes.Ldarg_0);
                    gen.MarkLabel(il_0008); gen.Emit(OpCodes.Ldloc, i);
                    gen.MarkLabel(il_0009); gen.Emit(OpCodes.Ldelem_I4);
                    gen.MarkLabel(il_000a); gen.Emit(OpCodes.Add);
                    gen.MarkLabel(il_000b); gen.Emit(OpCodes.Stloc, retval);
                    gen.MarkLabel(il_000c); gen.Emit(OpCodes.Ldloc, i);
                    gen.MarkLabel(il_000d); gen.Emit(OpCodes.Ldc_I4_1);
                    gen.MarkLabel(il_000e); gen.Emit(OpCodes.Add);
                    gen.MarkLabel(il_000f); gen.Emit(OpCodes.Stloc, i);
                    gen.MarkLabel(il_0010); gen.Emit(OpCodes.Ldloc, i);
                    gen.MarkLabel(il_0011); gen.Emit(OpCodes.Ldarg_0);
                    gen.MarkLabel(il_0012); gen.Emit(OpCodes.Ldlen);
                    gen.MarkLabel(il_0013); gen.Emit(OpCodes.Conv_I4);
                    gen.MarkLabel(il_0014); gen.Emit(OpCodes.Blt_S, il_0006);
                    gen.MarkLabel(il_0016); gen.Emit(OpCodes.Ldloc, retval);
                    gen.MarkLabel(il_0017); gen.Emit(OpCodes.Ret);
                },
                typeof(int),
                new[] { typeof(int[]), }
                );
            #endregion

            yield break;
        }
    }
}