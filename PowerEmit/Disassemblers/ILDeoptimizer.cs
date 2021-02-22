using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit.Disassemblers
{
    public class ILDeoptimizer
    {
        public static ILDeoptimizer Instance { get; } = new ILDeoptimizer();


        protected ILDeoptimizer()
        {
        }


        public virtual IList<IILStreamAction> Deoptimize(IReadOnlyList<IILStreamAction> stream)
        {
            var newStream = new List<IILStreamAction>();
            foreach(var action in stream)
            {
                if(Deoptimize(action) is IILStreamAction newAction)
                    newStream.Add(newAction);
            }
            return newStream;
        }


        private static IILStreamAction? Deoptimize(IILStreamAction action)
            => action switch
            {
                IInst<byte> inst => inst.OpCode.Value switch
                {
                    OpCodeConst.Ldarg_S  => Inst.Ldarg (inst.Operand),
                    OpCodeConst.Ldarga_S => Inst.Ldarga(inst.Operand),
                    OpCodeConst.Ldloc_S  => Inst.Ldloc (inst.Operand),
                    OpCodeConst.Ldloca_S => Inst.Ldloca(inst.Operand),
                    OpCodeConst.Starg_S  => Inst.Starg (inst.Operand),
                    OpCodeConst.Stloc_S  => Inst.Stloc (inst.Operand),
                    _ => action,
                },
                IInst<LabelBuilder> inst => inst.OpCode.Value switch
                {
                    OpCodeConst.Br_S      => Inst.Br     (inst.Operand),
                    OpCodeConst.Brfalse_S => Inst.Brfalse(inst.Operand),
                    OpCodeConst.Brtrue_S  => Inst.Brtrue (inst.Operand),
                    OpCodeConst.Beq_S     => Inst.Beq    (inst.Operand),
                    OpCodeConst.Bge_S     => Inst.Bge    (inst.Operand),
                    OpCodeConst.Bgt_S     => Inst.Bgt    (inst.Operand),
                    OpCodeConst.Ble_S     => Inst.Ble    (inst.Operand),
                    OpCodeConst.Blt_S     => Inst.Blt    (inst.Operand),
                    OpCodeConst.Bne_Un_S  => Inst.Bne_Un (inst.Operand),
                    OpCodeConst.Bge_Un_S  => Inst.Bge_Un (inst.Operand),
                    OpCodeConst.Bgt_Un_S  => Inst.Bgt_Un (inst.Operand),
                    OpCodeConst.Ble_Un_S  => Inst.Ble_Un (inst.Operand),
                    OpCodeConst.Blt_Un_S  => Inst.Blt_Un (inst.Operand),
                    _ => action,
                },
                IInst inst => inst.OpCode.Value switch
                {
                    OpCodeConst.Ldarg_0 => Inst.Ldarg(0),
                    OpCodeConst.Ldarg_1 => Inst.Ldarg(1),
                    OpCodeConst.Ldarg_2 => Inst.Ldarg(2),
                    OpCodeConst.Ldarg_3 => Inst.Ldarg(3),
                    OpCodeConst.Ldloc_0 => Inst.Ldloc(0),
                    OpCodeConst.Ldloc_1 => Inst.Ldloc(1),
                    OpCodeConst.Ldloc_2 => Inst.Ldloc(2),
                    OpCodeConst.Ldloc_3 => Inst.Ldloc(3),
                    OpCodeConst.Stloc_0 => Inst.Stloc(0),
                    OpCodeConst.Stloc_1 => Inst.Stloc(1),
                    OpCodeConst.Stloc_2 => Inst.Stloc(2),
                    OpCodeConst.Stloc_3 => Inst.Stloc(3),
                    OpCodeConst.Ldc_I4_M1 => Inst.Ldc_I4(-1),
                    OpCodeConst.Ldc_I4_0  => Inst.Ldc_I4(0),
                    OpCodeConst.Ldc_I4_1  => Inst.Ldc_I4(1),
                    OpCodeConst.Ldc_I4_2  => Inst.Ldc_I4(2),
                    OpCodeConst.Ldc_I4_3  => Inst.Ldc_I4(3),
                    OpCodeConst.Ldc_I4_4  => Inst.Ldc_I4(4),
                    OpCodeConst.Ldc_I4_5  => Inst.Ldc_I4(5),
                    OpCodeConst.Ldc_I4_6  => Inst.Ldc_I4(6),
                    OpCodeConst.Ldc_I4_7  => Inst.Ldc_I4(7),
                    OpCodeConst.Ldc_I4_8  => Inst.Ldc_I4(8),
                    _ => action,
                },
                _ => action,
            };
    }
}
