using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PowerEmit;

public class OpCodeHelperTest
{
    public static TheoryData<OperandType, object, int> OperandSizeTestCase()
        => new() {
            { OperandType.InlineBrTarget, default(int), 4 },
            { OperandType.InlineField, default(int), 4 },
            { OperandType.InlineI, default(int), 4 },
            { OperandType.InlineI8, default(long), 8 },
            { OperandType.InlineMethod, default(int), 4 },
            { OperandType.InlineNone, null!, 0 },
            { OperandType.InlineR, default(double), 8 },
            { OperandType.InlineSig, default(int), 4 },
            { OperandType.InlineString, default(int), 4 },
            { OperandType.InlineSwitch, Array.Empty<Label>(), 4 },
            { OperandType.InlineSwitch, new Label[3], 4 + 4 * 3 },
            { OperandType.InlineTok, default(int), 4 },
            { OperandType.InlineType, default(int), 4 },
            { OperandType.InlineVar, default(short), 2 },
            { OperandType.ShortInlineBrTarget, default(sbyte), 1 },
            { OperandType.ShortInlineI, default(sbyte), 1 },
            { OperandType.ShortInlineR, default(float), 4 },
            { OperandType.ShortInlineVar, default(byte), 1 },
        };

    [Theory]
    [MemberData(nameof(OperandSizeTestCase))]
    public void OperandSize<T>(OperandType operandType, T operand, int expected) =>
        Assert.Equal(expected, operandType.OperandSize(operand));

    [Fact]
    public void OperandSize_InvalidOperationException() =>
        Assert.Throws<InvalidOperationException>(() => ((OperandType)int.MinValue).OperandSize(0));
}
