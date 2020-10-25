using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PowerEmit
{

    public sealed class Beq_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Beq_S;
        public override OpCode OpCode => OpCodes.Beq;
        internal Beq_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Bge_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Bge_S;
        public override OpCode OpCode => OpCodes.Bge;
        internal Bge_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Bge_Un_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Bge_Un_S;
        public override OpCode OpCode => OpCodes.Bge_Un;
        internal Bge_Un_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Bgt_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Bgt_S;
        public override OpCode OpCode => OpCodes.Bgt;
        internal Bgt_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Bgt_Un_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Bgt_Un_S;
        public override OpCode OpCode => OpCodes.Bgt_Un;
        internal Bgt_Un_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Ble_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Ble_S;
        public override OpCode OpCode => OpCodes.Ble;
        internal Ble_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Ble_Un_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Ble_Un_S;
        public override OpCode OpCode => OpCodes.Ble_Un;
        internal Ble_Un_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Blt_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Blt_S;
        public override OpCode OpCode => OpCodes.Blt;
        internal Blt_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Blt_Un_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Blt_Un_S;
        public override OpCode OpCode => OpCodes.Blt_Un;
        internal Blt_Un_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Bne_Un_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Bne_Un_S;
        public override OpCode OpCode => OpCodes.Bne_Un;
        internal Bne_Un_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Br_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Br_S;
        public override OpCode OpCode => OpCodes.Br;
        internal Br_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Brfalse_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Brfalse_S;
        public override OpCode OpCode => OpCodes.Brfalse;
        internal Brfalse_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Brtrue_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Brtrue_S;
        public override OpCode OpCode => OpCodes.Brtrue;
        internal Brtrue_Opt(CilLabel label) : base(label) {}
    }


    public sealed class Leave_Opt : BranchOptOperation
    {
        protected override OpCode ShortVersionOpCode => OpCodes.Leave_S;
        public override OpCode OpCode => OpCodes.Leave;
        internal Leave_Opt(CilLabel label) : base(label) {}
    }

}
