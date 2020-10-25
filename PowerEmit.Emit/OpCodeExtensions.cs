using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PowerEmit.Emit
{
    /// <summary>
    ///     Provides OpCode utilities.
    /// </summary>
    public static class OpCodeExtensions
    {
        /// <summary>
        ///     Gets a byte size of sum of opcode and operand.
        ///     Throws <see cref="ArgumentOutOfRangeException"/> if the opcode requires variable length operand.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int GetTotalByteSize(in this OpCode code)
            => code.Size + code.GetOperandSize();


        /// <summary>
        ///     Gets a byte size of operand for each opcode.
        ///     Throws <see cref="ArgumentOutOfRangeException"/> if the opcode requires variable length operand.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int GetOperandSize(in this OpCode code)
        {
            switch(code.OperandType)
            {
            case OperandType.InlineNone:
                return 0;
            case OperandType.ShortInlineBrTarget:
            case OperandType.ShortInlineI:
            case OperandType.ShortInlineVar:
                return 1;
            case OperandType.InlineVar:
                return 2;
            case OperandType.InlineBrTarget:
            case OperandType.InlineField:
            case OperandType.InlineI:
            case OperandType.InlineMethod:
            case OperandType.InlineSig:
            case OperandType.InlineString:
            case OperandType.InlineTok:
            case OperandType.InlineType:
            case OperandType.ShortInlineR:
                return 4;
            case OperandType.InlineI8:
            case OperandType.InlineR:
                return 8;
            case OperandType.InlineSwitch:
#pragma warning disable CS0618
            case OperandType.InlinePhi:
#pragma warning restore CS0618
                throw new ArgumentOutOfRangeException();
            default:
                throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary>
        ///     Gets a stack balance of opcode.
        ///     Throws <see cref="ArgumentOutOfRangeException"/> if the opcode requires variable length operand.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static int GetStackBalance(in this OpCode code)
        {
            var balance = 0;
            switch(code.StackBehaviourPop)
            {
            case StackBehaviour.Pop0:
                balance -= 0;
                break;
            case StackBehaviour.Pop1:
            case StackBehaviour.Popi:
            case StackBehaviour.Popref:
                balance -= 1;
                break;
            case StackBehaviour.Pop1_pop1:
            case StackBehaviour.Popi_pop1:
            case StackBehaviour.Popi_popi:
            case StackBehaviour.Popi_popi8:
            case StackBehaviour.Popi_popr4:
            case StackBehaviour.Popi_popr8:
            case StackBehaviour.Popref_pop1:
            case StackBehaviour.Popref_popi:
                balance -= 2;
                break;
            case StackBehaviour.Popi_popi_popi:
            case StackBehaviour.Popref_popi_pop1:
            case StackBehaviour.Popref_popi_popi:
            case StackBehaviour.Popref_popi_popi8:
            case StackBehaviour.Popref_popi_popr4:
            case StackBehaviour.Popref_popi_popr8:
            case StackBehaviour.Popref_popi_popref:
                balance -= 3;
                break;
            case StackBehaviour.Varpop:
                throw new ArgumentOutOfRangeException();
            case StackBehaviour.Push0:
            case StackBehaviour.Push1:
            case StackBehaviour.Push1_push1:
            case StackBehaviour.Pushi:
            case StackBehaviour.Pushi8:
            case StackBehaviour.Pushr4:
            case StackBehaviour.Pushr8:
            case StackBehaviour.Pushref:
            case StackBehaviour.Varpush:
            default:
                throw new ArgumentOutOfRangeException();
            }

            switch(code.StackBehaviourPush)
            {
            case StackBehaviour.Push0:
                balance += 0;
                break;
            case StackBehaviour.Push1:
            case StackBehaviour.Pushi:
            case StackBehaviour.Pushi8:
            case StackBehaviour.Pushr4:
            case StackBehaviour.Pushr8:
            case StackBehaviour.Pushref:
            case StackBehaviour.Varpush:
                balance += 1;
                break;
            case StackBehaviour.Push1_push1:
                balance += 2;
                break;
            case StackBehaviour.Pop0:
            case StackBehaviour.Pop1:
            case StackBehaviour.Pop1_pop1:
            case StackBehaviour.Popi:
            case StackBehaviour.Popi_pop1:
            case StackBehaviour.Popi_popi:
            case StackBehaviour.Popi_popi_popi:
            case StackBehaviour.Popi_popi8:
            case StackBehaviour.Popi_popr4:
            case StackBehaviour.Popi_popr8:
            case StackBehaviour.Popref:
            case StackBehaviour.Popref_pop1:
            case StackBehaviour.Popref_popi:
            case StackBehaviour.Popref_popi_pop1:
            case StackBehaviour.Popref_popi_popi:
            case StackBehaviour.Popref_popi_popi8:
            case StackBehaviour.Popref_popi_popr4:
            case StackBehaviour.Popref_popi_popr8:
            case StackBehaviour.Popref_popi_popref:
            case StackBehaviour.Varpop:
            default:
                throw new ArgumentOutOfRangeException();
            }

            return balance;
        }
    }
}
