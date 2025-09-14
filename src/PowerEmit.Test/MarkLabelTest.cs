using System;
using System.Reflection.Emit;
using Xunit;

namespace PowerEmit;

public class MarkLabelTest
{
    [Fact]
    public void WithLabel()
    {
        var expectedBuilder = new Builder(typeof(void), Type.EmptyTypes);
        {
            var label = expectedBuilder.ILGenerator.DefineLabel();
            expectedBuilder.ILGenerator.Emit(OpCodes.Br, label);
            expectedBuilder.ILGenerator.MarkLabel(label);
            expectedBuilder.ILGenerator.Emit(OpCodes.Ret);
        }

        var actualBuilder = new Builder(typeof(void), Type.EmptyTypes);
        {
            var label1 = actualBuilder.ILGenerator.DefineLabel();
            var label2 = actualBuilder.ILGenerator.DefineLabel();
            var directive = Directive.MarkLabel(label1);
            actualBuilder.ILGenerator.Emit(Inst.Br(label1));
            actualBuilder.ILGenerator.Emit(directive);
            actualBuilder.ILGenerator.Emit(Inst.Ret());

            Assert.True(Directive.MarkLabel(label1).Equals(directive));
            Assert.True(Directive.MarkLabel(label1).Equals((object)directive));
            Assert.False(Directive.MarkLabel(label2).Equals(directive));
            Assert.False(Directive.MarkLabel(label2).Equals((object)directive));
            Assert.False(Directive.MarkLabel(label2).Equals(new object()));
        }

        var expectedBytes = expectedBuilder.GetBuiltILBytes();
        var actualBytes = actualBuilder.GetBuiltILBytes();
        Assert.Equal(expectedBytes, actualBytes);
    }


    [Fact]
    public void WithLabelBuilder()
    {
        var expectedBuilder = new Builder(typeof(void), Type.EmptyTypes);
        {
            var label = expectedBuilder.ILGenerator.DefineLabel();
            expectedBuilder.ILGenerator.Emit(OpCodes.Br, label);
            expectedBuilder.ILGenerator.MarkLabel(label);
            expectedBuilder.ILGenerator.Emit(OpCodes.Ret);
        }

        var actualBuilder = new Builder(typeof(void), Type.EmptyTypes);
        {
            var label1 = new LabelBuilder("lbl_1");
            var label2 = new LabelBuilder("lbl_2");
            var directive = Directive.MarkLabel(label1);
            actualBuilder.ILGenerator.Emit(Inst.Br(label1));
            actualBuilder.ILGenerator.Emit(directive);
            actualBuilder.ILGenerator.Emit(Inst.Ret());

            Assert.True(Directive.MarkLabel(label1).Equals(directive));
            Assert.True(Directive.MarkLabel(label1).Equals((object)directive));
            Assert.False(Directive.MarkLabel(label2).Equals(directive));
            Assert.False(Directive.MarkLabel(label2).Equals((object)directive));
            Assert.False(Directive.MarkLabel(label2).Equals(Inst.Ret()));
            Assert.False(Directive.MarkLabel(label2).Equals(new object()));
        }

        var expectedBytes = expectedBuilder.GetBuiltILBytes();
        var actualBytes = actualBuilder.GetBuiltILBytes();
        Assert.Equal(expectedBytes, actualBytes);
    }
}
