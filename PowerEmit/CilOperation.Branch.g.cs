using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{

    public sealed class Br_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Br_S;
        internal Br_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Brfalse_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Brfalse_S;
        internal Brfalse_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Brtrue_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Brtrue_S;
        internal Brtrue_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Beq_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Beq_S;
        internal Beq_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Bge_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bge_S;
        internal Bge_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Bgt_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bgt_S;
        internal Bgt_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Ble_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Ble_S;
        internal Ble_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Blt_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Blt_S;
        internal Blt_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Bne_Un_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bne_Un_S;
        internal Bne_Un_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Bge_Un_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bge_Un_S;
        internal Bge_Un_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Bgt_Un_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bgt_Un_S;
        internal Bgt_Un_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Ble_Un_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Ble_Un_S;
        internal Ble_Un_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Blt_Un_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Blt_Un_S;
        internal Blt_Un_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Br : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Br;
        internal Br(CilLabel operand) : base(operand) {}
    }


    public sealed class Brfalse : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Brfalse;
        internal Brfalse(CilLabel operand) : base(operand) {}
    }


    public sealed class Brtrue : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Brtrue;
        internal Brtrue(CilLabel operand) : base(operand) {}
    }


    public sealed class Beq : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Beq;
        internal Beq(CilLabel operand) : base(operand) {}
    }


    public sealed class Bge : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bge;
        internal Bge(CilLabel operand) : base(operand) {}
    }


    public sealed class Bgt : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bgt;
        internal Bgt(CilLabel operand) : base(operand) {}
    }


    public sealed class Ble : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Ble;
        internal Ble(CilLabel operand) : base(operand) {}
    }


    public sealed class Blt : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Blt;
        internal Blt(CilLabel operand) : base(operand) {}
    }


    public sealed class Bne_Un : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bne_Un;
        internal Bne_Un(CilLabel operand) : base(operand) {}
    }


    public sealed class Bge_Un : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bge_Un;
        internal Bge_Un(CilLabel operand) : base(operand) {}
    }


    public sealed class Bgt_Un : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Bgt_Un;
        internal Bgt_Un(CilLabel operand) : base(operand) {}
    }


    public sealed class Ble_Un : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Ble_Un;
        internal Ble_Un(CilLabel operand) : base(operand) {}
    }


    public sealed class Blt_Un : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Blt_Un;
        internal Blt_Un(CilLabel operand) : base(operand) {}
    }


    public sealed class Leave_S : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Leave_S;
        internal Leave_S(CilLabel operand) : base(operand) {}
    }


    public sealed class Leave : BranchOperation
    {
        public override OpCode OpCode => OpCodes.Leave;
        internal Leave(CilLabel operand) : base(operand) {}
    }

}
