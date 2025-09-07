using Xunit;

namespace PowerEmit.Disassemblers;

public class ILDeoptimizerTest
{
    [Theory]
    [MemberData(nameof(DeoptimizeSingleTestCases))]
    public void DeoptimizeSingle(IILStreamAction input, IILStreamAction expected)
    {
        var actual = ILDeoptimizer.Deoptimize(input);
        Assert.Equal(expected, actual);
    }

    public static TheoryData<IILStreamAction, IILStreamAction> DeoptimizeSingleTestCases()
    {
        var label = new LabelBuilder("foobar");
        return new()
        {
            // deoptimization targets
            { Inst.Ldarg_S(0), Inst.Ldarg(0) },
            { Inst.Ldarga_S(0), Inst.Ldarga(0) },
            { Inst.Ldloc_S(0), Inst.Ldloc(0) },
            { Inst.Ldloca_S(0), Inst.Ldloca(0) },
            { Inst.Starg_S(0), Inst.Starg(0) },
            { Inst.Stloc_S(0), Inst.Stloc(0) },
            { Inst.Ldc_I4_S(42), Inst.Ldc_I4(42) },
            { Inst.Br_S(label), Inst.Br(label) },
            { Inst.Brfalse_S(label), Inst.Brfalse(label) },
            { Inst.Brtrue_S(label), Inst.Brtrue(label) },
            { Inst.Beq_S(label), Inst.Beq(label) },
            { Inst.Bge_S(label), Inst.Bge(label) },
            { Inst.Bgt_S(label), Inst.Bgt(label) },
            { Inst.Ble_S(label), Inst.Ble(label) },
            { Inst.Blt_S(label), Inst.Blt(label) },
            { Inst.Bne_Un_S(label), Inst.Bne_Un(label) },
            { Inst.Bge_Un_S(label), Inst.Bge_Un(label) },
            { Inst.Bgt_Un_S(label), Inst.Bgt_Un(label) },
            { Inst.Ble_Un_S(label), Inst.Ble_Un(label) },
            { Inst.Blt_Un_S(label), Inst.Blt_Un(label) },
            { Inst.Ldarg_0(), Inst.Ldarg(0) },
            { Inst.Ldarg_1(), Inst.Ldarg(1) },
            { Inst.Ldarg_2(), Inst.Ldarg(2) },
            { Inst.Ldarg_3(), Inst.Ldarg(3) },
            { Inst.Ldloc_0(), Inst.Ldloc(0) },
            { Inst.Ldloc_1(), Inst.Ldloc(1) },
            { Inst.Ldloc_2(), Inst.Ldloc(2) },
            { Inst.Ldloc_3(), Inst.Ldloc(3) },
            { Inst.Stloc_0(), Inst.Stloc(0) },
            { Inst.Stloc_1(), Inst.Stloc(1) },
            { Inst.Stloc_2(), Inst.Stloc(2) },
            { Inst.Stloc_3(), Inst.Stloc(3) },
            { Inst.Ldc_I4_M1(), Inst.Ldc_I4(-1) },
            { Inst.Ldc_I4_0(), Inst.Ldc_I4(0) },
            { Inst.Ldc_I4_1(), Inst.Ldc_I4(1) },
            { Inst.Ldc_I4_2(), Inst.Ldc_I4(2) },
            { Inst.Ldc_I4_3(), Inst.Ldc_I4(3) },
            { Inst.Ldc_I4_4(), Inst.Ldc_I4(4) },
            { Inst.Ldc_I4_5(), Inst.Ldc_I4(5) },
            { Inst.Ldc_I4_6(), Inst.Ldc_I4(6) },
            { Inst.Ldc_I4_7(), Inst.Ldc_I4(7) },
            { Inst.Ldc_I4_8(), Inst.Ldc_I4(8) },

            // undeoptimizable instructions (should be returned as-is)
            { Inst.Nop(), Inst.Nop() },
            { Inst.Ret(), Inst.Ret() },
            { Inst.Unaligned(1), Inst.Unaligned(1) },
            { Inst.Br(label), Inst.Br(label) },
            { Inst.Ldc_I4(42), Inst.Ldc_I4(42) },
            { Inst.Ldstr("hello, world"), Inst.Ldstr("hello, world") },
            { InvalidInst.Invalid_sbyte, InvalidInst.Invalid_sbyte },
            { Directive.MarkLabel(label), Directive.MarkLabel(label) },
        };
    }
}

file class InvalidInst
{
    public static readonly Inst<sbyte> Invalid_sbyte = new(System.Reflection.Emit.OpCodes.Nop, 0);
}
