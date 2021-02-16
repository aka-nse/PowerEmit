using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Xunit;

namespace PowerEmit
{
    public partial class InstTest
    {
        [Theory]
        [MemberData(nameof(GetTestCases_Integration))]
        public void Emit_Integration(TestCase testCase)
            => EmitCore(testCase);


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
                gen =>
                {
                    gen.Emit(Inst.Ldarg_0());
                    gen.Emit(Inst.Ldarg_1());
                    gen.Emit(Inst.Add());
                    gen.Emit(Inst.Ret());
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
                gen =>
                {
                    var retval = gen.DeclareLocal(typeof(int));
                    var i = gen.DeclareLocal(typeof(int));
                    var il_0000 = new LabelBuilder("il_0000");
                    var il_0001 = new LabelBuilder("il_0001");
                    var il_0002 = new LabelBuilder("il_0002");
                    var il_0003 = new LabelBuilder("il_0003");
                    var il_0004 = new LabelBuilder("il_0004");
                    var il_0006 = new LabelBuilder("il_0006");
                    var il_0007 = new LabelBuilder("il_0007");
                    var il_0008 = new LabelBuilder("il_0008");
                    var il_0009 = new LabelBuilder("il_0009");
                    var il_000a = new LabelBuilder("il_000a");
                    var il_000b = new LabelBuilder("il_000b");
                    var il_000c = new LabelBuilder("il_000c");
                    var il_000d = new LabelBuilder("il_000d");
                    var il_000e = new LabelBuilder("il_000e");
                    var il_000f = new LabelBuilder("il_000f");
                    var il_0010 = new LabelBuilder("il_0010");
                    var il_0011 = new LabelBuilder("il_0011");
                    var il_0012 = new LabelBuilder("il_0012");
                    var il_0013 = new LabelBuilder("il_0013");
                    var il_0014 = new LabelBuilder("il_0014");
                    var il_0016 = new LabelBuilder("il_0016");
                    var il_0017 = new LabelBuilder("il_0017");
                    il_0000.MarkLabel(gen); gen.Emit(Inst.Ldc_I4_0());
                    il_0001.MarkLabel(gen); gen.Emit(Inst.Stloc(retval));
                    il_0002.MarkLabel(gen); gen.Emit(Inst.Ldc_I4_0());
                    il_0003.MarkLabel(gen); gen.Emit(Inst.Stloc(i));
                    il_0004.MarkLabel(gen); gen.Emit(Inst.Br_S(il_0010));
                    il_0006.MarkLabel(gen); gen.Emit(Inst.Ldloc(retval));
                    il_0007.MarkLabel(gen); gen.Emit(Inst.Ldarg_0());
                    il_0008.MarkLabel(gen); gen.Emit(Inst.Ldloc(i));
                    il_0009.MarkLabel(gen); gen.Emit(Inst.Ldelem_I4());
                    il_000a.MarkLabel(gen); gen.Emit(Inst.Add());
                    il_000b.MarkLabel(gen); gen.Emit(Inst.Stloc(retval));
                    il_000c.MarkLabel(gen); gen.Emit(Inst.Ldloc(i));
                    il_000d.MarkLabel(gen); gen.Emit(Inst.Ldc_I4_1());
                    il_000e.MarkLabel(gen); gen.Emit(Inst.Add());
                    il_000f.MarkLabel(gen); gen.Emit(Inst.Stloc(i));
                    il_0010.MarkLabel(gen); gen.Emit(Inst.Ldloc(i));
                    il_0011.MarkLabel(gen); gen.Emit(Inst.Ldarg_0());
                    il_0012.MarkLabel(gen); gen.Emit(Inst.Ldlen());
                    il_0013.MarkLabel(gen); gen.Emit(Inst.Conv_I4());
                    il_0014.MarkLabel(gen); gen.Emit(Inst.Blt_S(il_0006));
                    il_0016.MarkLabel(gen); gen.Emit(Inst.Ldloc(retval));
                    il_0017.MarkLabel(gen); gen.Emit(Inst.Ret());
                },
                typeof(int),
                new[] { typeof(int[]), }
                );
            #endregion

            yield break;
        }
    }
}