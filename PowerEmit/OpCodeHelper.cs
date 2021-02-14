using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit
{
    internal static class OpCodeHelper
    {
        public static int OperandSize<T>(this OperandType operandType, T operand) 
            => operandType switch
            {
                OperandType.InlineBrTarget => 4,
                OperandType.InlineField => 4,
                OperandType.InlineI => 4,
                OperandType.InlineI8 => 8,
                OperandType.InlineMethod => 4,
                OperandType.InlineNone => 0,
                OperandType.InlineR => 8,
                OperandType.InlineSig => 4,
                OperandType.InlineString => 4,
                OperandType.InlineSwitch => 4 + 4 * Unsafe.As<T, Label[]>(ref operand).Length,
                OperandType.InlineTok => 4,
                OperandType.InlineType => 4,
                OperandType.InlineVar => 4,
                OperandType.ShortInlineBrTarget => 1,
                OperandType.ShortInlineI => 1,
                OperandType.ShortInlineR => 4,
                OperandType.ShortInlineVar => 1,
                _ => throw new InvalidOperationException(),
            };


        public static int GetTotalByteSize<T>(this OpCode opcode, T operand)
            => opcode.Size + opcode.OperandType.OperandSize(operand);
    }
}
