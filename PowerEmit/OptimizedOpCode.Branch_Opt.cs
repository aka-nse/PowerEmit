using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        private abstract class BranchOptOperation : IILStreamOpCode
        {
            internal const int BrTarget = 4;
            internal const int ShortBrTarget = 1;


            public abstract OpCode OpCode { get; }
            protected abstract OpCode ShortVersionOpCode { get; }


            public int ByteSize => OpCode.GetTotalByteSize();
            int? IILStreamAction.ByteSize => ByteSize;


            public int StackBalance => OpCode.GetStackBalance();
            int? IILStreamAction.StackBalance => StackBalance;


            public LabelDescriptor Operand { get; }


            protected BranchOptOperation(LabelDescriptor operand)
            {
                Operand = operand;
            }


            public void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode);


            public int GetByteSize(ILGeneratorState state)
            {
                var owner = state.Owner;
                if(!owner.Stream.Contains(this))
                {
                    return -1;
                }
                var ops = owner.Stream;
                var markLabel = owner.Stream.FindLabelMark(Operand);
                if(markLabel == null)
                    return BrTarget;

                var labelPos = ops.TakeWhile(x => x != markLabel).Count();
                var branchPos = ops.TakeWhile(x => x != this).Count();
                int offset;
                if(branchPos < labelPos)
                {
                    offset = ops
                            .Skip(branchPos + 1)
                            .Take(labelPos - branchPos - 2)
                            .Select(x => x.GetByteSize(state)).Sum();
                }
                else
                {
                    int getSafeByteSize(IILStreamAction action)
                        => (action is BranchOptOperation brx)
                               ? (brx.OpCode.Size + BrTarget)
                               : action.GetByteSize(state);

                    offset = ops
                            .Skip(labelPos)
                            .Take(branchPos - labelPos)
                            .Select(getSafeByteSize)
                            .Sum();
                    offset = -offset;
                }

                if(sbyte.MinValue <= offset && offset <= sbyte.MinValue)
                    return ShortBrTarget;
                return BrTarget;
            }


            public int GetStackBalance(ILGeneratorState state)
                => StackBalance;
        }
    }
}