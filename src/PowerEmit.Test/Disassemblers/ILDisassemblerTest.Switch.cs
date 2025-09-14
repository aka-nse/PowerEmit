using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerEmit.Disassemblers;

public partial class ILDisassemblerTest
{
    [Theory]
    [MemberData(nameof(GetTestCases_Switch))]
    public void Disassemble_Switch(TestCase testCase)
   => DisassembleCore(testCase);


    public static TheoryData<TestCase> GetTestCases_Switch() => [
            CreateTestCase(
                "switch 1",
                static gen =>
                {
                    var lbl_0 = gen.DefineLabel();
                    var lbl_1 = gen.DefineLabel();
                    var lbl_2 = gen.DefineLabel();
                    var lbl_3 = gen.DefineLabel();
                    var lbl_4 = gen.DefineLabel();
                    var lbl_5 = gen.DefineLabel();
                    var lbl_default = gen.DefineLabel();

                    gen.Emit(OpCodes.Ldarg_0);            // IL_0000: ldarg.0
                    gen.Emit(OpCodes.Switch, [lbl_0, lbl_1, lbl_2, lbl_3, lbl_4, lbl_5]);
                                                          // IL_0001: switch (IL_0020, IL_0026, IL_002c, IL_0032, IL_0038, IL_003e)
                    gen.Emit(OpCodes.Br_S, lbl_default);  // IL_001e: br.s IL_0044
                    gen.MarkLabel(lbl_0);                 //
                    gen.Emit(OpCodes.Ldstr, "zero");      // IL_0020: ldstr "zero"
                    gen.Emit(OpCodes.Ret);                // IL_0025: ret
                    gen.MarkLabel(lbl_1);                 //
                    gen.Emit(OpCodes.Ldstr, "one");       // IL_0026: ldstr "one"
                    gen.Emit(OpCodes.Ret);                // IL_002b: ret
                    gen.MarkLabel(lbl_2);                 //
                    gen.Emit(OpCodes.Ldstr, "two");       // IL_002c: ldstr "two"
                    gen.Emit(OpCodes.Ret);                // IL_0031: ret
                    gen.MarkLabel(lbl_3);                 //
                    gen.Emit(OpCodes.Ldstr, "three");     // IL_0032: ldstr "three"
                    gen.Emit(OpCodes.Ret);                // IL_0037: ret
                    gen.MarkLabel(lbl_4);                 //
                    gen.Emit(OpCodes.Ldstr, "four");      // IL_0038: ldstr "four"
                    gen.Emit(OpCodes.Ret);                // IL_003d: ret
                    gen.MarkLabel(lbl_5);                 //
                    gen.Emit(OpCodes.Ldstr, "five");      // IL_003e: ldstr "five"
                    gen.Emit(OpCodes.Ret);                // IL_0043: ret
                    gen.MarkLabel(lbl_default);           //
                    gen.Emit(OpCodes.Ldstr, "");          // IL_0044: ldstr ""
                    gen.Emit(OpCodes.Ret);                // IL_0049: ret
                }),
            CreateTestCase(
                "switch 2",
                static gen =>
                {
                    var lbl_0 = gen.DefineLabel();
                    var lbl_1 = gen.DefineLabel();
                    var lbl_2 = gen.DefineLabel();
                    var lbl_3 = gen.DefineLabel();
                    var lbl_4 = gen.DefineLabel();
                    var lbl_5 = gen.DefineLabel();
                    var lbl_6 = gen.DefineLabel();
                    var lbl_7 = gen.DefineLabel();
                    var lbl_8 = gen.DefineLabel();
                    var lbl_9 = gen.DefineLabel();
                    var lbl_default = gen.DefineLabel();
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Switch, [
                        lbl_0, lbl_1, lbl_2, lbl_3, lbl_4,
                        lbl_5, lbl_6, lbl_7, lbl_8, lbl_9,
                    ]);
                    gen.Emit(OpCodes.Br, lbl_default);
                    gen.MarkLabel(lbl_0);
                    gen.Emit(OpCodes.Ldc_I4_0);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_1);
                    gen.Emit(OpCodes.Ldc_I4_1);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_2);
                    gen.Emit(OpCodes.Ldc_I4_2);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_3);
                    gen.Emit(OpCodes.Ldc_I4_3);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_4);
                    gen.Emit(OpCodes.Ldc_I4_4);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_5);
                    gen.Emit(OpCodes.Ldc_I4_5);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_6);
                    gen.Emit(OpCodes.Ldc_I4_6);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_7);
                    gen.Emit(OpCodes.Ldc_I4_7);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_8);
                    gen.Emit(OpCodes.Ldc_I4_8);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_9);
                    gen.Emit(OpCodes.Ldc_I4_S, (sbyte)9);
                    gen.Emit(OpCodes.Ret);
                    gen.MarkLabel(lbl_default);
                    gen.Emit(OpCodes.Ldc_I4_M1);
                }),
        ];
}
