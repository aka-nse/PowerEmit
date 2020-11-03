using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamOpCode Br_S(LabelDescriptor operand)
            => new Emit_Br_S(operand);

        private sealed class Emit_Br_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Br_S;
            internal Emit_Br_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Brfalse_S(LabelDescriptor operand)
            => new Emit_Brfalse_S(operand);

        private sealed class Emit_Brfalse_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Brfalse_S;
            internal Emit_Brfalse_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Brtrue_S(LabelDescriptor operand)
            => new Emit_Brtrue_S(operand);

        private sealed class Emit_Brtrue_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Brtrue_S;
            internal Emit_Brtrue_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Beq_S(LabelDescriptor operand)
            => new Emit_Beq_S(operand);

        private sealed class Emit_Beq_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Beq_S;
            internal Emit_Beq_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bge_S(LabelDescriptor operand)
            => new Emit_Bge_S(operand);

        private sealed class Emit_Bge_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bge_S;
            internal Emit_Bge_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bgt_S(LabelDescriptor operand)
            => new Emit_Bgt_S(operand);

        private sealed class Emit_Bgt_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bgt_S;
            internal Emit_Bgt_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Ble_S(LabelDescriptor operand)
            => new Emit_Ble_S(operand);

        private sealed class Emit_Ble_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Ble_S;
            internal Emit_Ble_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Blt_S(LabelDescriptor operand)
            => new Emit_Blt_S(operand);

        private sealed class Emit_Blt_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Blt_S;
            internal Emit_Blt_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bne_Un_S(LabelDescriptor operand)
            => new Emit_Bne_Un_S(operand);

        private sealed class Emit_Bne_Un_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bne_Un_S;
            internal Emit_Bne_Un_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bge_Un_S(LabelDescriptor operand)
            => new Emit_Bge_Un_S(operand);

        private sealed class Emit_Bge_Un_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bge_Un_S;
            internal Emit_Bge_Un_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bgt_Un_S(LabelDescriptor operand)
            => new Emit_Bgt_Un_S(operand);

        private sealed class Emit_Bgt_Un_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bgt_Un_S;
            internal Emit_Bgt_Un_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Ble_Un_S(LabelDescriptor operand)
            => new Emit_Ble_Un_S(operand);

        private sealed class Emit_Ble_Un_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Ble_Un_S;
            internal Emit_Ble_Un_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Blt_Un_S(LabelDescriptor operand)
            => new Emit_Blt_Un_S(operand);

        private sealed class Emit_Blt_Un_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Blt_Un_S;
            internal Emit_Blt_Un_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Br(LabelDescriptor operand)
            => new Emit_Br(operand);

        private sealed class Emit_Br : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Br;
            internal Emit_Br(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Brfalse(LabelDescriptor operand)
            => new Emit_Brfalse(operand);

        private sealed class Emit_Brfalse : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Brfalse;
            internal Emit_Brfalse(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Brtrue(LabelDescriptor operand)
            => new Emit_Brtrue(operand);

        private sealed class Emit_Brtrue : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Brtrue;
            internal Emit_Brtrue(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Beq(LabelDescriptor operand)
            => new Emit_Beq(operand);

        private sealed class Emit_Beq : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Beq;
            internal Emit_Beq(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bge(LabelDescriptor operand)
            => new Emit_Bge(operand);

        private sealed class Emit_Bge : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bge;
            internal Emit_Bge(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bgt(LabelDescriptor operand)
            => new Emit_Bgt(operand);

        private sealed class Emit_Bgt : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bgt;
            internal Emit_Bgt(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Ble(LabelDescriptor operand)
            => new Emit_Ble(operand);

        private sealed class Emit_Ble : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Ble;
            internal Emit_Ble(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Blt(LabelDescriptor operand)
            => new Emit_Blt(operand);

        private sealed class Emit_Blt : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Blt;
            internal Emit_Blt(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bne_Un(LabelDescriptor operand)
            => new Emit_Bne_Un(operand);

        private sealed class Emit_Bne_Un : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bne_Un;
            internal Emit_Bne_Un(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bge_Un(LabelDescriptor operand)
            => new Emit_Bge_Un(operand);

        private sealed class Emit_Bge_Un : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bge_Un;
            internal Emit_Bge_Un(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Bgt_Un(LabelDescriptor operand)
            => new Emit_Bgt_Un(operand);

        private sealed class Emit_Bgt_Un : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Bgt_Un;
            internal Emit_Bgt_Un(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Ble_Un(LabelDescriptor operand)
            => new Emit_Ble_Un(operand);

        private sealed class Emit_Ble_Un : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Ble_Un;
            internal Emit_Ble_Un(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Blt_Un(LabelDescriptor operand)
            => new Emit_Blt_Un(operand);

        private sealed class Emit_Blt_Un : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Blt_Un;
            internal Emit_Blt_Un(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Leave_S(LabelDescriptor operand)
            => new Emit_Leave_S(operand);

        private sealed class Emit_Leave_S : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Leave_S;
            internal Emit_Leave_S(LabelDescriptor operand) : base(operand) {}
        }

        public static IILStreamOpCode Leave(LabelDescriptor operand)
            => new Emit_Leave(operand);

        private sealed class Emit_Leave : BranchOperation
        {
            public override OpCode OpCode => OpCodes.Leave;
            internal Emit_Leave(LabelDescriptor operand) : base(operand) {}
        }

    }
}
