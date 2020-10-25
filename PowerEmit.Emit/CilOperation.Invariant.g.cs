using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PowerEmit.Emit
{

    public sealed class Nop : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Nop;
        public Nop() {}
    }


    public sealed class Break : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Break;
        public Break() {}
    }


    public sealed class Ldarg_0 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldarg_0;
        public Ldarg_0() {}
    }


    public sealed class Ldarg_1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldarg_1;
        public Ldarg_1() {}
    }


    public sealed class Ldarg_2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldarg_2;
        public Ldarg_2() {}
    }


    public sealed class Ldarg_3 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldarg_3;
        public Ldarg_3() {}
    }


    public sealed class Ldloc_0 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldloc_0;
        public Ldloc_0() {}
    }


    public sealed class Ldloc_1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldloc_1;
        public Ldloc_1() {}
    }


    public sealed class Ldloc_2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldloc_2;
        public Ldloc_2() {}
    }


    public sealed class Ldloc_3 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldloc_3;
        public Ldloc_3() {}
    }


    public sealed class Stloc_0 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stloc_0;
        public Stloc_0() {}
    }


    public sealed class Stloc_1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stloc_1;
        public Stloc_1() {}
    }


    public sealed class Stloc_2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stloc_2;
        public Stloc_2() {}
    }


    public sealed class Stloc_3 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stloc_3;
        public Stloc_3() {}
    }


    public sealed class Ldnull : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldnull;
        public Ldnull() {}
    }


    public sealed class Ldc_I4_M1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_M1;
        public Ldc_I4_M1() {}
    }


    public sealed class Ldc_I4_0 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_0;
        public Ldc_I4_0() {}
    }


    public sealed class Ldc_I4_1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_1;
        public Ldc_I4_1() {}
    }


    public sealed class Ldc_I4_2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_2;
        public Ldc_I4_2() {}
    }


    public sealed class Ldc_I4_3 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_3;
        public Ldc_I4_3() {}
    }


    public sealed class Ldc_I4_4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_4;
        public Ldc_I4_4() {}
    }


    public sealed class Ldc_I4_5 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_5;
        public Ldc_I4_5() {}
    }


    public sealed class Ldc_I4_6 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_6;
        public Ldc_I4_6() {}
    }


    public sealed class Ldc_I4_7 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_7;
        public Ldc_I4_7() {}
    }


    public sealed class Ldc_I4_8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_8;
        public Ldc_I4_8() {}
    }


    public sealed class Dup : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Dup;
        public Dup() {}
    }


    public sealed class Pop : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Pop;
        public Pop() {}
    }


    public sealed class Ldind_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_I1;
        public Ldind_I1() {}
    }


    public sealed class Ldind_U1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_U1;
        public Ldind_U1() {}
    }


    public sealed class Ldind_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_I2;
        public Ldind_I2() {}
    }


    public sealed class Ldind_U2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_U2;
        public Ldind_U2() {}
    }


    public sealed class Ldind_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_I4;
        public Ldind_I4() {}
    }


    public sealed class Ldind_U4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_U4;
        public Ldind_U4() {}
    }


    public sealed class Ldind_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_I8;
        public Ldind_I8() {}
    }


    public sealed class Ldind_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_I;
        public Ldind_I() {}
    }


    public sealed class Ldind_R4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_R4;
        public Ldind_R4() {}
    }


    public sealed class Ldind_R8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_R8;
        public Ldind_R8() {}
    }


    public sealed class Ldind_Ref : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldind_Ref;
        public Ldind_Ref() {}
    }


    public sealed class Stind_Ref : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_Ref;
        public Stind_Ref() {}
    }


    public sealed class Stind_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_I1;
        public Stind_I1() {}
    }


    public sealed class Stind_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_I2;
        public Stind_I2() {}
    }


    public sealed class Stind_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_I4;
        public Stind_I4() {}
    }


    public sealed class Stind_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_I8;
        public Stind_I8() {}
    }


    public sealed class Stind_R4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_R4;
        public Stind_R4() {}
    }


    public sealed class Stind_R8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_R8;
        public Stind_R8() {}
    }


    public sealed class Add : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Add;
        public Add() {}
    }


    public sealed class Sub : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Sub;
        public Sub() {}
    }


    public sealed class Mul : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Mul;
        public Mul() {}
    }


    public sealed class Div : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Div;
        public Div() {}
    }


    public sealed class Div_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Div_Un;
        public Div_Un() {}
    }


    public sealed class Rem : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Rem;
        public Rem() {}
    }


    public sealed class Rem_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Rem_Un;
        public Rem_Un() {}
    }


    public sealed class And : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.And;
        public And() {}
    }


    public sealed class Or : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Or;
        public Or() {}
    }


    public sealed class Xor : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Xor;
        public Xor() {}
    }


    public sealed class Shl : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Shl;
        public Shl() {}
    }


    public sealed class Shr : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Shr;
        public Shr() {}
    }


    public sealed class Shr_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Shr_Un;
        public Shr_Un() {}
    }


    public sealed class Neg : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Neg;
        public Neg() {}
    }


    public sealed class Not : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Not;
        public Not() {}
    }


    public sealed class Conv_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_I1;
        public Conv_I1() {}
    }


    public sealed class Conv_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_I2;
        public Conv_I2() {}
    }


    public sealed class Conv_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_I4;
        public Conv_I4() {}
    }


    public sealed class Conv_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_I8;
        public Conv_I8() {}
    }


    public sealed class Conv_R4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_R4;
        public Conv_R4() {}
    }


    public sealed class Conv_R8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_R8;
        public Conv_R8() {}
    }


    public sealed class Conv_U4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_U4;
        public Conv_U4() {}
    }


    public sealed class Conv_U8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_U8;
        public Conv_U8() {}
    }


    public sealed class Conv_R_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_R_Un;
        public Conv_R_Un() {}
    }


    public sealed class Throw : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Throw;
        public Throw() {}
    }


    public sealed class Conv_Ovf_I1_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I1_Un;
        public Conv_Ovf_I1_Un() {}
    }


    public sealed class Conv_Ovf_I2_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I2_Un;
        public Conv_Ovf_I2_Un() {}
    }


    public sealed class Conv_Ovf_I4_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I4_Un;
        public Conv_Ovf_I4_Un() {}
    }


    public sealed class Conv_Ovf_I8_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I8_Un;
        public Conv_Ovf_I8_Un() {}
    }


    public sealed class Conv_Ovf_U1_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U1_Un;
        public Conv_Ovf_U1_Un() {}
    }


    public sealed class Conv_Ovf_U2_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U2_Un;
        public Conv_Ovf_U2_Un() {}
    }


    public sealed class Conv_Ovf_U4_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U4_Un;
        public Conv_Ovf_U4_Un() {}
    }


    public sealed class Conv_Ovf_U8_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U8_Un;
        public Conv_Ovf_U8_Un() {}
    }


    public sealed class Conv_Ovf_I_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I_Un;
        public Conv_Ovf_I_Un() {}
    }


    public sealed class Conv_Ovf_U_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U_Un;
        public Conv_Ovf_U_Un() {}
    }


    public sealed class Ldlen : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldlen;
        public Ldlen() {}
    }


    public sealed class Ldelem_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_I1;
        public Ldelem_I1() {}
    }


    public sealed class Ldelem_U1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_U1;
        public Ldelem_U1() {}
    }


    public sealed class Ldelem_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_I2;
        public Ldelem_I2() {}
    }


    public sealed class Ldelem_U2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_U2;
        public Ldelem_U2() {}
    }


    public sealed class Ldelem_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_I4;
        public Ldelem_I4() {}
    }


    public sealed class Ldelem_U4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_U4;
        public Ldelem_U4() {}
    }


    public sealed class Ldelem_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_I8;
        public Ldelem_I8() {}
    }


    public sealed class Ldelem_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_I;
        public Ldelem_I() {}
    }


    public sealed class Ldelem_R4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_R4;
        public Ldelem_R4() {}
    }


    public sealed class Ldelem_R8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_R8;
        public Ldelem_R8() {}
    }


    public sealed class Ldelem_Ref : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ldelem_Ref;
        public Ldelem_Ref() {}
    }


    public sealed class Stelem_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_I;
        public Stelem_I() {}
    }


    public sealed class Stelem_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_I1;
        public Stelem_I1() {}
    }


    public sealed class Stelem_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_I2;
        public Stelem_I2() {}
    }


    public sealed class Stelem_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_I4;
        public Stelem_I4() {}
    }


    public sealed class Stelem_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_I8;
        public Stelem_I8() {}
    }


    public sealed class Stelem_R4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_R4;
        public Stelem_R4() {}
    }


    public sealed class Stelem_R8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_R8;
        public Stelem_R8() {}
    }


    public sealed class Stelem_Ref : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stelem_Ref;
        public Stelem_Ref() {}
    }


    public sealed class Conv_Ovf_I1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I1;
        public Conv_Ovf_I1() {}
    }


    public sealed class Conv_Ovf_U1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U1;
        public Conv_Ovf_U1() {}
    }


    public sealed class Conv_Ovf_I2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I2;
        public Conv_Ovf_I2() {}
    }


    public sealed class Conv_Ovf_U2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U2;
        public Conv_Ovf_U2() {}
    }


    public sealed class Conv_Ovf_I4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I4;
        public Conv_Ovf_I4() {}
    }


    public sealed class Conv_Ovf_U4 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U4;
        public Conv_Ovf_U4() {}
    }


    public sealed class Conv_Ovf_I8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I8;
        public Conv_Ovf_I8() {}
    }


    public sealed class Conv_Ovf_U8 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U8;
        public Conv_Ovf_U8() {}
    }


    public sealed class Ckfinite : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ckfinite;
        public Ckfinite() {}
    }


    public sealed class Conv_U2 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_U2;
        public Conv_U2() {}
    }


    public sealed class Conv_U1 : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_U1;
        public Conv_U1() {}
    }


    public sealed class Conv_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_I;
        public Conv_I() {}
    }


    public sealed class Conv_Ovf_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_I;
        public Conv_Ovf_I() {}
    }


    public sealed class Conv_Ovf_U : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_Ovf_U;
        public Conv_Ovf_U() {}
    }


    public sealed class Add_Ovf : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Add_Ovf;
        public Add_Ovf() {}
    }


    public sealed class Add_Ovf_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Add_Ovf_Un;
        public Add_Ovf_Un() {}
    }


    public sealed class Mul_Ovf : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Mul_Ovf;
        public Mul_Ovf() {}
    }


    public sealed class Mul_Ovf_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Mul_Ovf_Un;
        public Mul_Ovf_Un() {}
    }


    public sealed class Sub_Ovf : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Sub_Ovf;
        public Sub_Ovf() {}
    }


    public sealed class Sub_Ovf_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Sub_Ovf_Un;
        public Sub_Ovf_Un() {}
    }


    public sealed class Endfinally : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Endfinally;
        public Endfinally() {}
    }


    public sealed class Stind_I : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Stind_I;
        public Stind_I() {}
    }


    public sealed class Conv_U : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Conv_U;
        public Conv_U() {}
    }


    public sealed class Arglist : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Arglist;
        public Arglist() {}
    }


    public sealed class Ceq : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Ceq;
        public Ceq() {}
    }


    public sealed class Cgt : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Cgt;
        public Cgt() {}
    }


    public sealed class Cgt_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Cgt_Un;
        public Cgt_Un() {}
    }


    public sealed class Clt : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Clt;
        public Clt() {}
    }


    public sealed class Clt_Un : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Clt_Un;
        public Clt_Un() {}
    }


    public sealed class Localloc : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Localloc;
        public Localloc() {}
    }


    public sealed class Endfilter : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Endfilter;
        public Endfilter() {}
    }


    public sealed class Volatile : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Volatile;
        public Volatile() {}
    }


    public sealed class Tailcall : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Tailcall;
        public Tailcall() {}
    }


    public sealed class Cpblk : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Cpblk;
        public Cpblk() {}
    }


    public sealed class Initblk : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Initblk;
        public Initblk() {}
    }


    public sealed class Rethrow : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Rethrow;
        public Rethrow() {}
    }


    public sealed class Refanytype : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Refanytype;
        public Refanytype() {}
    }


    public sealed class Readonly : InvariantOperation
    {
        public override OpCode OpCode => OpCodes.Readonly;
        public Readonly() {}
    }

}
