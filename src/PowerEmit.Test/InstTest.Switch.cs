using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerEmit;

public partial class InstTest
{
    [Theory]
    [MemberData(nameof(GetTestCases_Switch))]
    public void Emit_Switch(TestCase testCase)
        => EmitCore(testCase);


    public static TheoryData<TestCase> GetTestCases_Switch()
    {
        var data = new TheoryData<TestCase>();
        {
            Action<ILGenerator> expected = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.MarkLabel(lbl1);
                gen.MarkLabel(lbl2);
                gen.MarkLabel(lbl3);
                gen.MarkLabel(lbl4);
                gen.Emit(OpCodes.Switch, [lbl1, lbl2, lbl3, lbl4]);
            };
            Action<ILGenerator> actual = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.MarkLabel(lbl1);
                gen.MarkLabel(lbl2);
                gen.MarkLabel(lbl3);
                gen.MarkLabel(lbl4);
                gen.Emit(Inst.Switch((IEnumerable<Label>)[lbl1, lbl2, lbl3, lbl4]));
            };
            data.Add(CreateTestCase("Switch 1", expected, actual, null, null));
        }
        {
            Action<ILGenerator> expected = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl1);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl2);
                gen.Emit(OpCodes.Nop);
                gen.Emit(OpCodes.Switch, [lbl1, lbl2, lbl3, lbl4]);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl3);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl4);
                gen.Emit(OpCodes.Nop);
            };
            Action<ILGenerator> actual = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl1);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl2);
                gen.Emit(OpCodes.Nop);
                gen.Emit(Inst.Switch((IEnumerable<Label>)[lbl1, lbl2, lbl3, lbl4]));
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl3);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl4);
                gen.Emit(OpCodes.Nop);
            };
            data.Add(CreateTestCase("Switch 2", expected, actual, null, null));
        }
        {
            Action<ILGenerator> expected = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.MarkLabel(lbl1);
                gen.MarkLabel(lbl2);
                gen.MarkLabel(lbl3);
                gen.MarkLabel(lbl4);
                gen.Emit(OpCodes.Switch, [lbl1, lbl2, lbl3, lbl4]);
            };
            var lbl1 = new LabelBuilder("lbl1");
            var lbl2 = new LabelBuilder("lbl2");
            var lbl3 = new LabelBuilder("lbl3");
            var lbl4 = new LabelBuilder("lbl4");
            Action<ILGenerator> actual = gen =>
            {
                gen.Emit(Directive.MarkLabel(lbl1));
                gen.Emit(Directive.MarkLabel(lbl2));
                gen.Emit(Directive.MarkLabel(lbl3));
                gen.Emit(Directive.MarkLabel(lbl4));
                gen.Emit(Inst.Switch((IEnumerable<LabelBuilder>)[lbl1, lbl2, lbl3, lbl4]));
            };
            data.Add(CreateTestCase("Switch 3", expected, actual, null, null));
        }
        {
            Action<ILGenerator> expected = gen =>
            {
                var lbl1 = gen.DefineLabel();
                var lbl2 = gen.DefineLabel();
                var lbl3 = gen.DefineLabel();
                var lbl4 = gen.DefineLabel();
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl1);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl2);
                gen.Emit(OpCodes.Nop);
                gen.Emit(OpCodes.Switch, [lbl1, lbl2, lbl3, lbl4]);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl3);
                gen.Emit(OpCodes.Nop);
                gen.MarkLabel(lbl4);
                gen.Emit(OpCodes.Nop);
            };
            var lbl1 = new LabelBuilder("lbl1");
            var lbl2 = new LabelBuilder("lbl2");
            var lbl3 = new LabelBuilder("lbl3");
            var lbl4 = new LabelBuilder("lbl4");
            Action<ILGenerator> actual = gen =>
            {
                gen.Emit(OpCodes.Nop);
                gen.Emit(Directive.MarkLabel(lbl1));
                gen.Emit(OpCodes.Nop);
                gen.Emit(Directive.MarkLabel(lbl2));
                gen.Emit(OpCodes.Nop);
                gen.Emit(Inst.Switch((IEnumerable<LabelBuilder>)[lbl1, lbl2, lbl3, lbl4]));
                gen.Emit(OpCodes.Nop);
                gen.Emit(Directive.MarkLabel(lbl3));
                gen.Emit(OpCodes.Nop);
                gen.Emit(Directive.MarkLabel(lbl4));
                gen.Emit(OpCodes.Nop);
            };
            data.Add(CreateTestCase("Switch 4", expected, actual, null, null));
        }
        return data;
    }
}
