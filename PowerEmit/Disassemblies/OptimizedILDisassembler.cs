using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Disassemblies
{
    public class OptimizedILDisassembler : ILDisassembler
    {
        public OptimizedILDisassembler(MethodBase method)
            : base(method)
        {
        }


        protected override void DisassembleNextOpCode(int currentIndex, short opcode)
        {
            switch(opcode)
            {
            #region Ldarg
            case OpCodeConst.Ldarg_0: PushOperation(OpCodeX.Ldarg_X(GetArgument(0))); return;
            case OpCodeConst.Ldarg_1: PushOperation(OpCodeX.Ldarg_X(GetArgument(1))); return;
            case OpCodeConst.Ldarg_2: PushOperation(OpCodeX.Ldarg_X(GetArgument(2))); return;
            case OpCodeConst.Ldarg_3: PushOperation(OpCodeX.Ldarg_X(GetArgument(3))); return;
            case OpCodeConst.Ldarg_S: PushOperation(OpCodeX.Ldarg_X(GetArgument(ReadStreamHead<byte>()))); return;
            case OpCodeConst.Ldarg:   PushOperation(OpCodeX.Ldarg_X(GetArgument(ReadStreamHead<short>()))); return;
            #endregion

            #region Ldc_I4
            case OpCodeConst.Ldc_I4_M1: PushOperation(OpCodeX.Ldc_I4_X(-1)); return;
            case OpCodeConst.Ldc_I4_0:  PushOperation(OpCodeX.Ldc_I4_X( 0)); return;
            case OpCodeConst.Ldc_I4_1:  PushOperation(OpCodeX.Ldc_I4_X( 1)); return;
            case OpCodeConst.Ldc_I4_2:  PushOperation(OpCodeX.Ldc_I4_X( 2)); return;
            case OpCodeConst.Ldc_I4_3:  PushOperation(OpCodeX.Ldc_I4_X( 3)); return;
            case OpCodeConst.Ldc_I4_4:  PushOperation(OpCodeX.Ldc_I4_X( 4)); return;
            case OpCodeConst.Ldc_I4_5:  PushOperation(OpCodeX.Ldc_I4_X( 5)); return;
            case OpCodeConst.Ldc_I4_6:  PushOperation(OpCodeX.Ldc_I4_X( 6)); return;
            case OpCodeConst.Ldc_I4_7:  PushOperation(OpCodeX.Ldc_I4_X( 7)); return;
            case OpCodeConst.Ldc_I4_8:  PushOperation(OpCodeX.Ldc_I4_X( 8)); return;
            case OpCodeConst.Ldc_I4_S:  PushOperation(OpCodeX.Ldc_I4_X(ReadStreamHead<sbyte>())); return;
            case OpCodeConst.Ldc_I4:    PushOperation(OpCodeX.Ldc_I4_X(ReadStreamHead<int>())); return;
            #endregion

            #region Ldloc
            case OpCodeConst.Ldloc_0: PushOperation(OpCodeX.Ldloc_X(GetLocal(0))); return;
            case OpCodeConst.Ldloc_1: PushOperation(OpCodeX.Ldloc_X(GetLocal(1))); return;
            case OpCodeConst.Ldloc_2: PushOperation(OpCodeX.Ldloc_X(GetLocal(2))); return;
            case OpCodeConst.Ldloc_3: PushOperation(OpCodeX.Ldloc_X(GetLocal(3))); return;
            case OpCodeConst.Ldloc_S: PushOperation(OpCodeX.Ldloc_X(GetLocal(ReadStreamHead<byte>()))); return;
            case OpCodeConst.Ldloc:   PushOperation(OpCodeX.Ldloc_X(GetLocal(ReadStreamHead<short>()))); return;
            #endregion

            #region Starg
            case OpCodeConst.Starg_S: PushOperation(OpCodeX.Starg_X(GetArgument(ReadStreamHead<byte>()))); return;
            case OpCodeConst.Starg: PushOperation(OpCodeX.Starg_X(GetArgument(ReadStreamHead<short>()))); return;
            #endregion

            #region Stloc
            case OpCodeConst.Stloc_0: PushOperation(OpCodeX.Stloc_X(GetLocal(0))); return;
            case OpCodeConst.Stloc_1: PushOperation(OpCodeX.Stloc_X(GetLocal(1))); return;
            case OpCodeConst.Stloc_2: PushOperation(OpCodeX.Stloc_X(GetLocal(2))); return;
            case OpCodeConst.Stloc_3: PushOperation(OpCodeX.Stloc_X(GetLocal(3))); return;
            case OpCodeConst.Stloc_S: PushOperation(OpCodeX.Stloc_X(GetLocal(ReadStreamHead<byte>()))); return;
            case OpCodeConst.Stloc: PushOperation(OpCodeX.Stloc_X(GetLocal(ReadStreamHead<short>()))); return;
            #endregion

#if false
#region branches
            case OpCodeConst.Beq_S:     PushOperation(OptimizedOpCode.Beq_Opt    (GetOrAddLabel(currentIndex + OpCodes.Beq_S    .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Beq:       PushOperation(OptimizedOpCode.Beq_Opt    (GetOrAddLabel(currentIndex + OpCodes.Beq      .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Bge_S:     PushOperation(OptimizedOpCode.Bge_Opt    (GetOrAddLabel(currentIndex + OpCodes.Bge_S    .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Bge:       PushOperation(OptimizedOpCode.Bge_Opt    (GetOrAddLabel(currentIndex + OpCodes.Bge      .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Bge_Un_S:  PushOperation(OptimizedOpCode.Bge_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bge_Un_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Bge_Un:    PushOperation(OptimizedOpCode.Bge_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bge_Un   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Bgt_S:     PushOperation(OptimizedOpCode.Bgt_Opt    (GetOrAddLabel(currentIndex + OpCodes.Bgt_S    .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Bgt:       PushOperation(OptimizedOpCode.Bgt_Opt    (GetOrAddLabel(currentIndex + OpCodes.Bgt      .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Bgt_Un_S:  PushOperation(OptimizedOpCode.Bgt_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bgt_Un_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Bgt_Un:    PushOperation(OptimizedOpCode.Bgt_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bgt_Un   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Ble_S:     PushOperation(OptimizedOpCode.Ble_Opt    (GetOrAddLabel(currentIndex + OpCodes.Ble_S    .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Ble:       PushOperation(OptimizedOpCode.Ble_Opt    (GetOrAddLabel(currentIndex + OpCodes.Ble      .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Ble_Un_S:  PushOperation(OptimizedOpCode.Ble_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Ble_Un_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Ble_Un:    PushOperation(OptimizedOpCode.Ble_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Ble_Un   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Blt_S:     PushOperation(OptimizedOpCode.Blt_Opt    (GetOrAddLabel(currentIndex + OpCodes.Blt_S    .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Blt:       PushOperation(OptimizedOpCode.Blt_Opt    (GetOrAddLabel(currentIndex + OpCodes.Blt      .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Blt_Un_S:  PushOperation(OptimizedOpCode.Blt_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Blt_Un_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Blt_Un:    PushOperation(OptimizedOpCode.Blt_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Blt_Un   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Bne_Un_S:  PushOperation(OptimizedOpCode.Bne_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bne_Un_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Bne_Un:    PushOperation(OptimizedOpCode.Bne_Un_Opt (GetOrAddLabel(currentIndex + OpCodes.Bne_Un   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Br_S:      PushOperation(OptimizedOpCode.Br_Opt     (GetOrAddLabel(currentIndex + OpCodes.Br_S     .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Br:        PushOperation(OptimizedOpCode.Br_Opt     (GetOrAddLabel(currentIndex + OpCodes.Br       .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Brfalse_S: PushOperation(OptimizedOpCode.Brfalse_Opt(GetOrAddLabel(currentIndex + OpCodes.Brfalse_S.GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Brfalse:   PushOperation(OptimizedOpCode.Brfalse_Opt(GetOrAddLabel(currentIndex + OpCodes.Brfalse  .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Brtrue_S:  PushOperation(OptimizedOpCode.Brtrue_Opt (GetOrAddLabel(currentIndex + OpCodes.Brtrue_S .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Brtrue:    PushOperation(OptimizedOpCode.Brtrue_Opt (GetOrAddLabel(currentIndex + OpCodes.Brtrue   .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
            case OpCodeConst.Leave_S:   PushOperation(OptimizedOpCode.Leave_Opt  (GetOrAddLabel(currentIndex + OpCodes.Leave_S  .GetTotalByteSize() + ReadStreamHead<sbyte>()))); return;
            case OpCodeConst.Leave:     PushOperation(OptimizedOpCode.Leave_Opt  (GetOrAddLabel(currentIndex + OpCodes.Leave    .GetTotalByteSize() + ReadStreamHead<int  >()))); return;
#endregion
#endif

            default:
                base.DisassembleNextOpCode(currentIndex, opcode);
                return;
            }
        }
    }
}






















