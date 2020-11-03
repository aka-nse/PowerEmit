using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamOpCode Nop()
            => new Emit_Nop();

        private sealed class Emit_Nop : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Nop;
            public Emit_Nop() {}
        }


        public static IILStreamOpCode Break()
            => new Emit_Break();

        private sealed class Emit_Break : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Break;
            public Emit_Break() {}
        }


        public static IILStreamOpCode Ldarg_0()
            => new Emit_Ldarg_0();

        private sealed class Emit_Ldarg_0 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldarg_0;
            public Emit_Ldarg_0() {}
        }


        public static IILStreamOpCode Ldarg_1()
            => new Emit_Ldarg_1();

        private sealed class Emit_Ldarg_1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldarg_1;
            public Emit_Ldarg_1() {}
        }


        public static IILStreamOpCode Ldarg_2()
            => new Emit_Ldarg_2();

        private sealed class Emit_Ldarg_2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldarg_2;
            public Emit_Ldarg_2() {}
        }


        public static IILStreamOpCode Ldarg_3()
            => new Emit_Ldarg_3();

        private sealed class Emit_Ldarg_3 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldarg_3;
            public Emit_Ldarg_3() {}
        }


        public static IILStreamOpCode Ldloc_0()
            => new Emit_Ldloc_0();

        private sealed class Emit_Ldloc_0 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldloc_0;
            public Emit_Ldloc_0() {}
        }


        public static IILStreamOpCode Ldloc_1()
            => new Emit_Ldloc_1();

        private sealed class Emit_Ldloc_1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldloc_1;
            public Emit_Ldloc_1() {}
        }


        public static IILStreamOpCode Ldloc_2()
            => new Emit_Ldloc_2();

        private sealed class Emit_Ldloc_2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldloc_2;
            public Emit_Ldloc_2() {}
        }


        public static IILStreamOpCode Ldloc_3()
            => new Emit_Ldloc_3();

        private sealed class Emit_Ldloc_3 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldloc_3;
            public Emit_Ldloc_3() {}
        }


        public static IILStreamOpCode Stloc_0()
            => new Emit_Stloc_0();

        private sealed class Emit_Stloc_0 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stloc_0;
            public Emit_Stloc_0() {}
        }


        public static IILStreamOpCode Stloc_1()
            => new Emit_Stloc_1();

        private sealed class Emit_Stloc_1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stloc_1;
            public Emit_Stloc_1() {}
        }


        public static IILStreamOpCode Stloc_2()
            => new Emit_Stloc_2();

        private sealed class Emit_Stloc_2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stloc_2;
            public Emit_Stloc_2() {}
        }


        public static IILStreamOpCode Stloc_3()
            => new Emit_Stloc_3();

        private sealed class Emit_Stloc_3 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stloc_3;
            public Emit_Stloc_3() {}
        }


        public static IILStreamOpCode Ldnull()
            => new Emit_Ldnull();

        private sealed class Emit_Ldnull : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldnull;
            public Emit_Ldnull() {}
        }


        public static IILStreamOpCode Ldc_I4_M1()
            => new Emit_Ldc_I4_M1();

        private sealed class Emit_Ldc_I4_M1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_M1;
            public Emit_Ldc_I4_M1() {}
        }


        public static IILStreamOpCode Ldc_I4_0()
            => new Emit_Ldc_I4_0();

        private sealed class Emit_Ldc_I4_0 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_0;
            public Emit_Ldc_I4_0() {}
        }


        public static IILStreamOpCode Ldc_I4_1()
            => new Emit_Ldc_I4_1();

        private sealed class Emit_Ldc_I4_1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_1;
            public Emit_Ldc_I4_1() {}
        }


        public static IILStreamOpCode Ldc_I4_2()
            => new Emit_Ldc_I4_2();

        private sealed class Emit_Ldc_I4_2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_2;
            public Emit_Ldc_I4_2() {}
        }


        public static IILStreamOpCode Ldc_I4_3()
            => new Emit_Ldc_I4_3();

        private sealed class Emit_Ldc_I4_3 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_3;
            public Emit_Ldc_I4_3() {}
        }


        public static IILStreamOpCode Ldc_I4_4()
            => new Emit_Ldc_I4_4();

        private sealed class Emit_Ldc_I4_4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_4;
            public Emit_Ldc_I4_4() {}
        }


        public static IILStreamOpCode Ldc_I4_5()
            => new Emit_Ldc_I4_5();

        private sealed class Emit_Ldc_I4_5 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_5;
            public Emit_Ldc_I4_5() {}
        }


        public static IILStreamOpCode Ldc_I4_6()
            => new Emit_Ldc_I4_6();

        private sealed class Emit_Ldc_I4_6 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_6;
            public Emit_Ldc_I4_6() {}
        }


        public static IILStreamOpCode Ldc_I4_7()
            => new Emit_Ldc_I4_7();

        private sealed class Emit_Ldc_I4_7 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_7;
            public Emit_Ldc_I4_7() {}
        }


        public static IILStreamOpCode Ldc_I4_8()
            => new Emit_Ldc_I4_8();

        private sealed class Emit_Ldc_I4_8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_8;
            public Emit_Ldc_I4_8() {}
        }


        public static IILStreamOpCode Dup()
            => new Emit_Dup();

        private sealed class Emit_Dup : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Dup;
            public Emit_Dup() {}
        }


        public static IILStreamOpCode Pop()
            => new Emit_Pop();

        private sealed class Emit_Pop : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Pop;
            public Emit_Pop() {}
        }


        public static IILStreamOpCode Ldind_I1()
            => new Emit_Ldind_I1();

        private sealed class Emit_Ldind_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_I1;
            public Emit_Ldind_I1() {}
        }


        public static IILStreamOpCode Ldind_U1()
            => new Emit_Ldind_U1();

        private sealed class Emit_Ldind_U1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_U1;
            public Emit_Ldind_U1() {}
        }


        public static IILStreamOpCode Ldind_I2()
            => new Emit_Ldind_I2();

        private sealed class Emit_Ldind_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_I2;
            public Emit_Ldind_I2() {}
        }


        public static IILStreamOpCode Ldind_U2()
            => new Emit_Ldind_U2();

        private sealed class Emit_Ldind_U2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_U2;
            public Emit_Ldind_U2() {}
        }


        public static IILStreamOpCode Ldind_I4()
            => new Emit_Ldind_I4();

        private sealed class Emit_Ldind_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_I4;
            public Emit_Ldind_I4() {}
        }


        public static IILStreamOpCode Ldind_U4()
            => new Emit_Ldind_U4();

        private sealed class Emit_Ldind_U4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_U4;
            public Emit_Ldind_U4() {}
        }


        public static IILStreamOpCode Ldind_I8()
            => new Emit_Ldind_I8();

        private sealed class Emit_Ldind_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_I8;
            public Emit_Ldind_I8() {}
        }


        public static IILStreamOpCode Ldind_I()
            => new Emit_Ldind_I();

        private sealed class Emit_Ldind_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_I;
            public Emit_Ldind_I() {}
        }


        public static IILStreamOpCode Ldind_R4()
            => new Emit_Ldind_R4();

        private sealed class Emit_Ldind_R4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_R4;
            public Emit_Ldind_R4() {}
        }


        public static IILStreamOpCode Ldind_R8()
            => new Emit_Ldind_R8();

        private sealed class Emit_Ldind_R8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_R8;
            public Emit_Ldind_R8() {}
        }


        public static IILStreamOpCode Ldind_Ref()
            => new Emit_Ldind_Ref();

        private sealed class Emit_Ldind_Ref : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldind_Ref;
            public Emit_Ldind_Ref() {}
        }


        public static IILStreamOpCode Stind_Ref()
            => new Emit_Stind_Ref();

        private sealed class Emit_Stind_Ref : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_Ref;
            public Emit_Stind_Ref() {}
        }


        public static IILStreamOpCode Stind_I1()
            => new Emit_Stind_I1();

        private sealed class Emit_Stind_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_I1;
            public Emit_Stind_I1() {}
        }


        public static IILStreamOpCode Stind_I2()
            => new Emit_Stind_I2();

        private sealed class Emit_Stind_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_I2;
            public Emit_Stind_I2() {}
        }


        public static IILStreamOpCode Stind_I4()
            => new Emit_Stind_I4();

        private sealed class Emit_Stind_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_I4;
            public Emit_Stind_I4() {}
        }


        public static IILStreamOpCode Stind_I8()
            => new Emit_Stind_I8();

        private sealed class Emit_Stind_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_I8;
            public Emit_Stind_I8() {}
        }


        public static IILStreamOpCode Stind_R4()
            => new Emit_Stind_R4();

        private sealed class Emit_Stind_R4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_R4;
            public Emit_Stind_R4() {}
        }


        public static IILStreamOpCode Stind_R8()
            => new Emit_Stind_R8();

        private sealed class Emit_Stind_R8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_R8;
            public Emit_Stind_R8() {}
        }


        public static IILStreamOpCode Add()
            => new Emit_Add();

        private sealed class Emit_Add : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Add;
            public Emit_Add() {}
        }


        public static IILStreamOpCode Sub()
            => new Emit_Sub();

        private sealed class Emit_Sub : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Sub;
            public Emit_Sub() {}
        }


        public static IILStreamOpCode Mul()
            => new Emit_Mul();

        private sealed class Emit_Mul : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Mul;
            public Emit_Mul() {}
        }


        public static IILStreamOpCode Div()
            => new Emit_Div();

        private sealed class Emit_Div : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Div;
            public Emit_Div() {}
        }


        public static IILStreamOpCode Div_Un()
            => new Emit_Div_Un();

        private sealed class Emit_Div_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Div_Un;
            public Emit_Div_Un() {}
        }


        public static IILStreamOpCode Rem()
            => new Emit_Rem();

        private sealed class Emit_Rem : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Rem;
            public Emit_Rem() {}
        }


        public static IILStreamOpCode Rem_Un()
            => new Emit_Rem_Un();

        private sealed class Emit_Rem_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Rem_Un;
            public Emit_Rem_Un() {}
        }


        public static IILStreamOpCode And()
            => new Emit_And();

        private sealed class Emit_And : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.And;
            public Emit_And() {}
        }


        public static IILStreamOpCode Or()
            => new Emit_Or();

        private sealed class Emit_Or : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Or;
            public Emit_Or() {}
        }


        public static IILStreamOpCode Xor()
            => new Emit_Xor();

        private sealed class Emit_Xor : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Xor;
            public Emit_Xor() {}
        }


        public static IILStreamOpCode Shl()
            => new Emit_Shl();

        private sealed class Emit_Shl : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Shl;
            public Emit_Shl() {}
        }


        public static IILStreamOpCode Shr()
            => new Emit_Shr();

        private sealed class Emit_Shr : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Shr;
            public Emit_Shr() {}
        }


        public static IILStreamOpCode Shr_Un()
            => new Emit_Shr_Un();

        private sealed class Emit_Shr_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Shr_Un;
            public Emit_Shr_Un() {}
        }


        public static IILStreamOpCode Neg()
            => new Emit_Neg();

        private sealed class Emit_Neg : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Neg;
            public Emit_Neg() {}
        }


        public static IILStreamOpCode Not()
            => new Emit_Not();

        private sealed class Emit_Not : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Not;
            public Emit_Not() {}
        }


        public static IILStreamOpCode Conv_I1()
            => new Emit_Conv_I1();

        private sealed class Emit_Conv_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_I1;
            public Emit_Conv_I1() {}
        }


        public static IILStreamOpCode Conv_I2()
            => new Emit_Conv_I2();

        private sealed class Emit_Conv_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_I2;
            public Emit_Conv_I2() {}
        }


        public static IILStreamOpCode Conv_I4()
            => new Emit_Conv_I4();

        private sealed class Emit_Conv_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_I4;
            public Emit_Conv_I4() {}
        }


        public static IILStreamOpCode Conv_I8()
            => new Emit_Conv_I8();

        private sealed class Emit_Conv_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_I8;
            public Emit_Conv_I8() {}
        }


        public static IILStreamOpCode Conv_R4()
            => new Emit_Conv_R4();

        private sealed class Emit_Conv_R4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_R4;
            public Emit_Conv_R4() {}
        }


        public static IILStreamOpCode Conv_R8()
            => new Emit_Conv_R8();

        private sealed class Emit_Conv_R8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_R8;
            public Emit_Conv_R8() {}
        }


        public static IILStreamOpCode Conv_U4()
            => new Emit_Conv_U4();

        private sealed class Emit_Conv_U4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_U4;
            public Emit_Conv_U4() {}
        }


        public static IILStreamOpCode Conv_U8()
            => new Emit_Conv_U8();

        private sealed class Emit_Conv_U8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_U8;
            public Emit_Conv_U8() {}
        }


        public static IILStreamOpCode Conv_R_Un()
            => new Emit_Conv_R_Un();

        private sealed class Emit_Conv_R_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_R_Un;
            public Emit_Conv_R_Un() {}
        }


        public static IILStreamOpCode Throw()
            => new Emit_Throw();

        private sealed class Emit_Throw : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Throw;
            public Emit_Throw() {}
        }


        public static IILStreamOpCode Conv_Ovf_I1_Un()
            => new Emit_Conv_Ovf_I1_Un();

        private sealed class Emit_Conv_Ovf_I1_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I1_Un;
            public Emit_Conv_Ovf_I1_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_I2_Un()
            => new Emit_Conv_Ovf_I2_Un();

        private sealed class Emit_Conv_Ovf_I2_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I2_Un;
            public Emit_Conv_Ovf_I2_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_I4_Un()
            => new Emit_Conv_Ovf_I4_Un();

        private sealed class Emit_Conv_Ovf_I4_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I4_Un;
            public Emit_Conv_Ovf_I4_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_I8_Un()
            => new Emit_Conv_Ovf_I8_Un();

        private sealed class Emit_Conv_Ovf_I8_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I8_Un;
            public Emit_Conv_Ovf_I8_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_U1_Un()
            => new Emit_Conv_Ovf_U1_Un();

        private sealed class Emit_Conv_Ovf_U1_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U1_Un;
            public Emit_Conv_Ovf_U1_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_U2_Un()
            => new Emit_Conv_Ovf_U2_Un();

        private sealed class Emit_Conv_Ovf_U2_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U2_Un;
            public Emit_Conv_Ovf_U2_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_U4_Un()
            => new Emit_Conv_Ovf_U4_Un();

        private sealed class Emit_Conv_Ovf_U4_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U4_Un;
            public Emit_Conv_Ovf_U4_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_U8_Un()
            => new Emit_Conv_Ovf_U8_Un();

        private sealed class Emit_Conv_Ovf_U8_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U8_Un;
            public Emit_Conv_Ovf_U8_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_I_Un()
            => new Emit_Conv_Ovf_I_Un();

        private sealed class Emit_Conv_Ovf_I_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I_Un;
            public Emit_Conv_Ovf_I_Un() {}
        }


        public static IILStreamOpCode Conv_Ovf_U_Un()
            => new Emit_Conv_Ovf_U_Un();

        private sealed class Emit_Conv_Ovf_U_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U_Un;
            public Emit_Conv_Ovf_U_Un() {}
        }


        public static IILStreamOpCode Ldlen()
            => new Emit_Ldlen();

        private sealed class Emit_Ldlen : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldlen;
            public Emit_Ldlen() {}
        }


        public static IILStreamOpCode Ldelem_I1()
            => new Emit_Ldelem_I1();

        private sealed class Emit_Ldelem_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_I1;
            public Emit_Ldelem_I1() {}
        }


        public static IILStreamOpCode Ldelem_U1()
            => new Emit_Ldelem_U1();

        private sealed class Emit_Ldelem_U1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_U1;
            public Emit_Ldelem_U1() {}
        }


        public static IILStreamOpCode Ldelem_I2()
            => new Emit_Ldelem_I2();

        private sealed class Emit_Ldelem_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_I2;
            public Emit_Ldelem_I2() {}
        }


        public static IILStreamOpCode Ldelem_U2()
            => new Emit_Ldelem_U2();

        private sealed class Emit_Ldelem_U2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_U2;
            public Emit_Ldelem_U2() {}
        }


        public static IILStreamOpCode Ldelem_I4()
            => new Emit_Ldelem_I4();

        private sealed class Emit_Ldelem_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_I4;
            public Emit_Ldelem_I4() {}
        }


        public static IILStreamOpCode Ldelem_U4()
            => new Emit_Ldelem_U4();

        private sealed class Emit_Ldelem_U4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_U4;
            public Emit_Ldelem_U4() {}
        }


        public static IILStreamOpCode Ldelem_I8()
            => new Emit_Ldelem_I8();

        private sealed class Emit_Ldelem_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_I8;
            public Emit_Ldelem_I8() {}
        }


        public static IILStreamOpCode Ldelem_I()
            => new Emit_Ldelem_I();

        private sealed class Emit_Ldelem_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_I;
            public Emit_Ldelem_I() {}
        }


        public static IILStreamOpCode Ldelem_R4()
            => new Emit_Ldelem_R4();

        private sealed class Emit_Ldelem_R4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_R4;
            public Emit_Ldelem_R4() {}
        }


        public static IILStreamOpCode Ldelem_R8()
            => new Emit_Ldelem_R8();

        private sealed class Emit_Ldelem_R8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_R8;
            public Emit_Ldelem_R8() {}
        }


        public static IILStreamOpCode Ldelem_Ref()
            => new Emit_Ldelem_Ref();

        private sealed class Emit_Ldelem_Ref : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ldelem_Ref;
            public Emit_Ldelem_Ref() {}
        }


        public static IILStreamOpCode Stelem_I()
            => new Emit_Stelem_I();

        private sealed class Emit_Stelem_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_I;
            public Emit_Stelem_I() {}
        }


        public static IILStreamOpCode Stelem_I1()
            => new Emit_Stelem_I1();

        private sealed class Emit_Stelem_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_I1;
            public Emit_Stelem_I1() {}
        }


        public static IILStreamOpCode Stelem_I2()
            => new Emit_Stelem_I2();

        private sealed class Emit_Stelem_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_I2;
            public Emit_Stelem_I2() {}
        }


        public static IILStreamOpCode Stelem_I4()
            => new Emit_Stelem_I4();

        private sealed class Emit_Stelem_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_I4;
            public Emit_Stelem_I4() {}
        }


        public static IILStreamOpCode Stelem_I8()
            => new Emit_Stelem_I8();

        private sealed class Emit_Stelem_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_I8;
            public Emit_Stelem_I8() {}
        }


        public static IILStreamOpCode Stelem_R4()
            => new Emit_Stelem_R4();

        private sealed class Emit_Stelem_R4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_R4;
            public Emit_Stelem_R4() {}
        }


        public static IILStreamOpCode Stelem_R8()
            => new Emit_Stelem_R8();

        private sealed class Emit_Stelem_R8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_R8;
            public Emit_Stelem_R8() {}
        }


        public static IILStreamOpCode Stelem_Ref()
            => new Emit_Stelem_Ref();

        private sealed class Emit_Stelem_Ref : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stelem_Ref;
            public Emit_Stelem_Ref() {}
        }


        public static IILStreamOpCode Conv_Ovf_I1()
            => new Emit_Conv_Ovf_I1();

        private sealed class Emit_Conv_Ovf_I1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I1;
            public Emit_Conv_Ovf_I1() {}
        }


        public static IILStreamOpCode Conv_Ovf_U1()
            => new Emit_Conv_Ovf_U1();

        private sealed class Emit_Conv_Ovf_U1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U1;
            public Emit_Conv_Ovf_U1() {}
        }


        public static IILStreamOpCode Conv_Ovf_I2()
            => new Emit_Conv_Ovf_I2();

        private sealed class Emit_Conv_Ovf_I2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I2;
            public Emit_Conv_Ovf_I2() {}
        }


        public static IILStreamOpCode Conv_Ovf_U2()
            => new Emit_Conv_Ovf_U2();

        private sealed class Emit_Conv_Ovf_U2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U2;
            public Emit_Conv_Ovf_U2() {}
        }


        public static IILStreamOpCode Conv_Ovf_I4()
            => new Emit_Conv_Ovf_I4();

        private sealed class Emit_Conv_Ovf_I4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I4;
            public Emit_Conv_Ovf_I4() {}
        }


        public static IILStreamOpCode Conv_Ovf_U4()
            => new Emit_Conv_Ovf_U4();

        private sealed class Emit_Conv_Ovf_U4 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U4;
            public Emit_Conv_Ovf_U4() {}
        }


        public static IILStreamOpCode Conv_Ovf_I8()
            => new Emit_Conv_Ovf_I8();

        private sealed class Emit_Conv_Ovf_I8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I8;
            public Emit_Conv_Ovf_I8() {}
        }


        public static IILStreamOpCode Conv_Ovf_U8()
            => new Emit_Conv_Ovf_U8();

        private sealed class Emit_Conv_Ovf_U8 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U8;
            public Emit_Conv_Ovf_U8() {}
        }


        public static IILStreamOpCode Ckfinite()
            => new Emit_Ckfinite();

        private sealed class Emit_Ckfinite : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ckfinite;
            public Emit_Ckfinite() {}
        }


        public static IILStreamOpCode Conv_U2()
            => new Emit_Conv_U2();

        private sealed class Emit_Conv_U2 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_U2;
            public Emit_Conv_U2() {}
        }


        public static IILStreamOpCode Conv_U1()
            => new Emit_Conv_U1();

        private sealed class Emit_Conv_U1 : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_U1;
            public Emit_Conv_U1() {}
        }


        public static IILStreamOpCode Conv_I()
            => new Emit_Conv_I();

        private sealed class Emit_Conv_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_I;
            public Emit_Conv_I() {}
        }


        public static IILStreamOpCode Conv_Ovf_I()
            => new Emit_Conv_Ovf_I();

        private sealed class Emit_Conv_Ovf_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_I;
            public Emit_Conv_Ovf_I() {}
        }


        public static IILStreamOpCode Conv_Ovf_U()
            => new Emit_Conv_Ovf_U();

        private sealed class Emit_Conv_Ovf_U : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_Ovf_U;
            public Emit_Conv_Ovf_U() {}
        }


        public static IILStreamOpCode Add_Ovf()
            => new Emit_Add_Ovf();

        private sealed class Emit_Add_Ovf : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Add_Ovf;
            public Emit_Add_Ovf() {}
        }


        public static IILStreamOpCode Add_Ovf_Un()
            => new Emit_Add_Ovf_Un();

        private sealed class Emit_Add_Ovf_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Add_Ovf_Un;
            public Emit_Add_Ovf_Un() {}
        }


        public static IILStreamOpCode Mul_Ovf()
            => new Emit_Mul_Ovf();

        private sealed class Emit_Mul_Ovf : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Mul_Ovf;
            public Emit_Mul_Ovf() {}
        }


        public static IILStreamOpCode Mul_Ovf_Un()
            => new Emit_Mul_Ovf_Un();

        private sealed class Emit_Mul_Ovf_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Mul_Ovf_Un;
            public Emit_Mul_Ovf_Un() {}
        }


        public static IILStreamOpCode Sub_Ovf()
            => new Emit_Sub_Ovf();

        private sealed class Emit_Sub_Ovf : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Sub_Ovf;
            public Emit_Sub_Ovf() {}
        }


        public static IILStreamOpCode Sub_Ovf_Un()
            => new Emit_Sub_Ovf_Un();

        private sealed class Emit_Sub_Ovf_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Sub_Ovf_Un;
            public Emit_Sub_Ovf_Un() {}
        }


        public static IILStreamOpCode Endfinally()
            => new Emit_Endfinally();

        private sealed class Emit_Endfinally : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Endfinally;
            public Emit_Endfinally() {}
        }


        public static IILStreamOpCode Stind_I()
            => new Emit_Stind_I();

        private sealed class Emit_Stind_I : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Stind_I;
            public Emit_Stind_I() {}
        }


        public static IILStreamOpCode Conv_U()
            => new Emit_Conv_U();

        private sealed class Emit_Conv_U : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Conv_U;
            public Emit_Conv_U() {}
        }


        public static IILStreamOpCode Arglist()
            => new Emit_Arglist();

        private sealed class Emit_Arglist : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Arglist;
            public Emit_Arglist() {}
        }


        public static IILStreamOpCode Ceq()
            => new Emit_Ceq();

        private sealed class Emit_Ceq : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Ceq;
            public Emit_Ceq() {}
        }


        public static IILStreamOpCode Cgt()
            => new Emit_Cgt();

        private sealed class Emit_Cgt : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Cgt;
            public Emit_Cgt() {}
        }


        public static IILStreamOpCode Cgt_Un()
            => new Emit_Cgt_Un();

        private sealed class Emit_Cgt_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Cgt_Un;
            public Emit_Cgt_Un() {}
        }


        public static IILStreamOpCode Clt()
            => new Emit_Clt();

        private sealed class Emit_Clt : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Clt;
            public Emit_Clt() {}
        }


        public static IILStreamOpCode Clt_Un()
            => new Emit_Clt_Un();

        private sealed class Emit_Clt_Un : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Clt_Un;
            public Emit_Clt_Un() {}
        }


        public static IILStreamOpCode Localloc()
            => new Emit_Localloc();

        private sealed class Emit_Localloc : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Localloc;
            public Emit_Localloc() {}
        }


        public static IILStreamOpCode Endfilter()
            => new Emit_Endfilter();

        private sealed class Emit_Endfilter : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Endfilter;
            public Emit_Endfilter() {}
        }


        public static IILStreamOpCode Volatile()
            => new Emit_Volatile();

        private sealed class Emit_Volatile : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Volatile;
            public Emit_Volatile() {}
        }


        public static IILStreamOpCode Tailcall()
            => new Emit_Tailcall();

        private sealed class Emit_Tailcall : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Tailcall;
            public Emit_Tailcall() {}
        }


        public static IILStreamOpCode Cpblk()
            => new Emit_Cpblk();

        private sealed class Emit_Cpblk : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Cpblk;
            public Emit_Cpblk() {}
        }


        public static IILStreamOpCode Initblk()
            => new Emit_Initblk();

        private sealed class Emit_Initblk : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Initblk;
            public Emit_Initblk() {}
        }


        public static IILStreamOpCode Rethrow()
            => new Emit_Rethrow();

        private sealed class Emit_Rethrow : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Rethrow;
            public Emit_Rethrow() {}
        }


        public static IILStreamOpCode Refanytype()
            => new Emit_Refanytype();

        private sealed class Emit_Refanytype : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Refanytype;
            public Emit_Refanytype() {}
        }


        public static IILStreamOpCode Readonly()
            => new Emit_Readonly();

        private sealed class Emit_Readonly : InvariantOperation
        {
            public override OpCode OpCode => OpCodes.Readonly;
            public Emit_Readonly() {}
        }


    }
}
