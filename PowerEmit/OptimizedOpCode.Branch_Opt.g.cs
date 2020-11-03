using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OptimizedOpCode
    {
        public static IILStreamOpCode Beq_Opt(LabelDescriptor label)
            => Beq_Opt(label);


        private sealed class Emit_Beq_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Beq_S;
            public override OpCode OpCode => OpCodes.Beq;
            internal Emit_Beq_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Bge_Opt(LabelDescriptor label)
            => Bge_Opt(label);


        private sealed class Emit_Bge_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Bge_S;
            public override OpCode OpCode => OpCodes.Bge;
            internal Emit_Bge_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Bge_Un_Opt(LabelDescriptor label)
            => Bge_Un_Opt(label);


        private sealed class Emit_Bge_Un_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Bge_Un_S;
            public override OpCode OpCode => OpCodes.Bge_Un;
            internal Emit_Bge_Un_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Bgt_Opt(LabelDescriptor label)
            => Bgt_Opt(label);


        private sealed class Emit_Bgt_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Bgt_S;
            public override OpCode OpCode => OpCodes.Bgt;
            internal Emit_Bgt_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Bgt_Un_Opt(LabelDescriptor label)
            => Bgt_Un_Opt(label);


        private sealed class Emit_Bgt_Un_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Bgt_Un_S;
            public override OpCode OpCode => OpCodes.Bgt_Un;
            internal Emit_Bgt_Un_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Ble_Opt(LabelDescriptor label)
            => Ble_Opt(label);


        private sealed class Emit_Ble_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Ble_S;
            public override OpCode OpCode => OpCodes.Ble;
            internal Emit_Ble_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Ble_Un_Opt(LabelDescriptor label)
            => Ble_Un_Opt(label);


        private sealed class Emit_Ble_Un_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Ble_Un_S;
            public override OpCode OpCode => OpCodes.Ble_Un;
            internal Emit_Ble_Un_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Blt_Opt(LabelDescriptor label)
            => Blt_Opt(label);


        private sealed class Emit_Blt_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Blt_S;
            public override OpCode OpCode => OpCodes.Blt;
            internal Emit_Blt_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Blt_Un_Opt(LabelDescriptor label)
            => Blt_Un_Opt(label);


        private sealed class Emit_Blt_Un_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Blt_Un_S;
            public override OpCode OpCode => OpCodes.Blt_Un;
            internal Emit_Blt_Un_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Bne_Un_Opt(LabelDescriptor label)
            => Bne_Un_Opt(label);


        private sealed class Emit_Bne_Un_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Bne_Un_S;
            public override OpCode OpCode => OpCodes.Bne_Un;
            internal Emit_Bne_Un_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Br_Opt(LabelDescriptor label)
            => Br_Opt(label);


        private sealed class Emit_Br_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Br_S;
            public override OpCode OpCode => OpCodes.Br;
            internal Emit_Br_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Brfalse_Opt(LabelDescriptor label)
            => Brfalse_Opt(label);


        private sealed class Emit_Brfalse_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Brfalse_S;
            public override OpCode OpCode => OpCodes.Brfalse;
            internal Emit_Brfalse_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Brtrue_Opt(LabelDescriptor label)
            => Brtrue_Opt(label);


        private sealed class Emit_Brtrue_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Brtrue_S;
            public override OpCode OpCode => OpCodes.Brtrue;
            internal Emit_Brtrue_Opt(LabelDescriptor label) : base(label) {}
        }

        public static IILStreamOpCode Leave_Opt(LabelDescriptor label)
            => Leave_Opt(label);


        private sealed class Emit_Leave_Opt : BranchOptOperation
        {
            protected override OpCode ShortVersionOpCode => OpCodes.Leave_S;
            public override OpCode OpCode => OpCodes.Leave;
            internal Emit_Leave_Opt(LabelDescriptor label) : base(label) {}
        }

    }
}
