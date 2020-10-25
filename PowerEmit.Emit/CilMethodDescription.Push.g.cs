using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using PowerEmit.Emit.Linq;

namespace PowerEmit.Emit
{
    partial class CilMethodDescription
    {

        /// <summary>
        /// Pushes a new arglist operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Arglist Push_Arglist()
        {
            var op = new Arglist();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ceq operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ceq Push_Ceq()
        {
            var op = new Ceq();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new cgt operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Cgt Push_Cgt()
        {
            var op = new Cgt();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new cgt.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Cgt_Un Push_Cgt_Un()
        {
            var op = new Cgt_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new clt operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Clt Push_Clt()
        {
            var op = new Clt();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new clt.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Clt_Un Push_Clt_Un()
        {
            var op = new Clt_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldftn operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldftn Push_Ldftn(MethodInfo operand)
        {
            var op = new Ldftn(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldvirtftn operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldvirtftn Push_Ldvirtftn(MethodInfo operand)
        {
            var op = new Ldvirtftn(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg Push_Ldarg(short operand)
        {
            var op = new Ldarg(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarga operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarga Push_Ldarga(short operand)
        {
            var op = new Ldarga(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new starg operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Starg Push_Starg(short operand)
        {
            var op = new Starg(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc Push_Ldloc(short operand)
        {
            var op = new Ldloc(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloca operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloca Push_Ldloca(short operand)
        {
            var op = new Ldloca(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc Push_Stloc(short operand)
        {
            var op = new Stloc(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new localloc operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Localloc Push_Localloc()
        {
            var op = new Localloc();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new endfilter operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Endfilter Push_Endfilter()
        {
            var op = new Endfilter();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new unaligned. operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Unaligned Push_Unaligned(byte operand)
        {
            var op = new Unaligned(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new volatile. operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Volatile Push_Volatile()
        {
            var op = new Volatile();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new tail. operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Tailcall Push_Tailcall()
        {
            var op = new Tailcall();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new initobj operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Initobj Push_Initobj(Type operand)
        {
            var op = new Initobj(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new constrained. operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Constrained Push_Constrained(Type operand)
        {
            var op = new Constrained(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new cpblk operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Cpblk Push_Cpblk()
        {
            var op = new Cpblk();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new initblk operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Initblk Push_Initblk()
        {
            var op = new Initblk();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new rethrow operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Rethrow Push_Rethrow()
        {
            var op = new Rethrow();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new sizeof operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Sizeof Push_Sizeof(Type operand)
        {
            var op = new Sizeof(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new refanytype operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Refanytype Push_Refanytype()
        {
            var op = new Refanytype();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new readonly. operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Readonly Push_Readonly()
        {
            var op = new Readonly();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new nop operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Nop Push_Nop()
        {
            var op = new Nop();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new break operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Break Push_Break()
        {
            var op = new Break();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg.0 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg_0 Push_Ldarg_0()
        {
            var op = new Ldarg_0();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg.1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg_1 Push_Ldarg_1()
        {
            var op = new Ldarg_1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg.2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg_2 Push_Ldarg_2()
        {
            var op = new Ldarg_2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg.3 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg_3 Push_Ldarg_3()
        {
            var op = new Ldarg_3();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc.0 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc_0 Push_Ldloc_0()
        {
            var op = new Ldloc_0();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc.1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc_1 Push_Ldloc_1()
        {
            var op = new Ldloc_1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc.2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc_2 Push_Ldloc_2()
        {
            var op = new Ldloc_2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc.3 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc_3 Push_Ldloc_3()
        {
            var op = new Ldloc_3();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc.0 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc_0 Push_Stloc_0()
        {
            var op = new Stloc_0();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc.1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc_1 Push_Stloc_1()
        {
            var op = new Stloc_1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc.2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc_2 Push_Stloc_2()
        {
            var op = new Stloc_2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc.3 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc_3 Push_Stloc_3()
        {
            var op = new Stloc_3();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarg.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarg_S Push_Ldarg_S(byte operand)
        {
            var op = new Ldarg_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldarga.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldarga_S Push_Ldarga_S(byte operand)
        {
            var op = new Ldarga_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new starg.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Starg_S Push_Starg_S(byte operand)
        {
            var op = new Starg_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloc.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloc_S Push_Ldloc_S(byte operand)
        {
            var op = new Ldloc_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldloca.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldloca_S Push_Ldloca_S(byte operand)
        {
            var op = new Ldloca_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stloc.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stloc_S Push_Stloc_S(byte operand)
        {
            var op = new Stloc_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldnull operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldnull Push_Ldnull()
        {
            var op = new Ldnull();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.m1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_M1 Push_Ldc_I4_M1()
        {
            var op = new Ldc_I4_M1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.0 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_0 Push_Ldc_I4_0()
        {
            var op = new Ldc_I4_0();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_1 Push_Ldc_I4_1()
        {
            var op = new Ldc_I4_1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_2 Push_Ldc_I4_2()
        {
            var op = new Ldc_I4_2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.3 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_3 Push_Ldc_I4_3()
        {
            var op = new Ldc_I4_3();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_4 Push_Ldc_I4_4()
        {
            var op = new Ldc_I4_4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.5 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_5 Push_Ldc_I4_5()
        {
            var op = new Ldc_I4_5();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.6 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_6 Push_Ldc_I4_6()
        {
            var op = new Ldc_I4_6();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.7 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_7 Push_Ldc_I4_7()
        {
            var op = new Ldc_I4_7();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4_8 Push_Ldc_I4_8()
        {
            var op = new Ldc_I4_8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        [CLSCompliant(false)]
        public Ldc_I4_S Push_Ldc_I4_S(sbyte operand)
        {
            var op = new Ldc_I4_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I4 Push_Ldc_I4(int operand)
        {
            var op = new Ldc_I4(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_I8 Push_Ldc_I8(long operand)
        {
            var op = new Ldc_I8(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_R4 Push_Ldc_R4(float operand)
        {
            var op = new Ldc_R4(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldc.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldc_R8 Push_Ldc_R8(double operand)
        {
            var op = new Ldc_R8(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new dup operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Dup Push_Dup()
        {
            var op = new Dup();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new pop operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Pop Push_Pop()
        {
            var op = new Pop();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new jmp operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Jmp Push_Jmp(MethodInfo operand)
        {
            var op = new Jmp(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new call operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Call Push_Call(MethodInfo operand)
        {
            var op = new Call(operand);
            _operations.Add(op);
            return op;
        }


        /* calli was skipped. */


        /// <summary>
        /// Pushes a new ret operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ret Push_Ret()
        {
            var op = new Ret();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new br.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Br_S Push_Br_S(CilLabel operand)
        {
            var op = new Br_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new brfalse.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Brfalse_S Push_Brfalse_S(CilLabel operand)
        {
            var op = new Brfalse_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new brtrue.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Brtrue_S Push_Brtrue_S(CilLabel operand)
        {
            var op = new Brtrue_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new beq.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Beq_S Push_Beq_S(CilLabel operand)
        {
            var op = new Beq_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bge.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bge_S Push_Bge_S(CilLabel operand)
        {
            var op = new Bge_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bgt.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bgt_S Push_Bgt_S(CilLabel operand)
        {
            var op = new Bgt_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ble.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ble_S Push_Ble_S(CilLabel operand)
        {
            var op = new Ble_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new blt.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Blt_S Push_Blt_S(CilLabel operand)
        {
            var op = new Blt_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bne.un.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bne_Un_S Push_Bne_Un_S(CilLabel operand)
        {
            var op = new Bne_Un_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bge.un.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bge_Un_S Push_Bge_Un_S(CilLabel operand)
        {
            var op = new Bge_Un_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bgt.un.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bgt_Un_S Push_Bgt_Un_S(CilLabel operand)
        {
            var op = new Bgt_Un_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ble.un.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ble_Un_S Push_Ble_Un_S(CilLabel operand)
        {
            var op = new Ble_Un_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new blt.un.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Blt_Un_S Push_Blt_Un_S(CilLabel operand)
        {
            var op = new Blt_Un_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new br operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Br Push_Br(CilLabel operand)
        {
            var op = new Br(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new brfalse operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Brfalse Push_Brfalse(CilLabel operand)
        {
            var op = new Brfalse(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new brtrue operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Brtrue Push_Brtrue(CilLabel operand)
        {
            var op = new Brtrue(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new beq operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Beq Push_Beq(CilLabel operand)
        {
            var op = new Beq(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bge operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bge Push_Bge(CilLabel operand)
        {
            var op = new Bge(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bgt operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bgt Push_Bgt(CilLabel operand)
        {
            var op = new Bgt(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ble operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ble Push_Ble(CilLabel operand)
        {
            var op = new Ble(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new blt operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Blt Push_Blt(CilLabel operand)
        {
            var op = new Blt(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bne.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bne_Un Push_Bne_Un(CilLabel operand)
        {
            var op = new Bne_Un(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bge.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bge_Un Push_Bge_Un(CilLabel operand)
        {
            var op = new Bge_Un(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new bgt.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Bgt_Un Push_Bgt_Un(CilLabel operand)
        {
            var op = new Bgt_Un(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ble.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ble_Un Push_Ble_Un(CilLabel operand)
        {
            var op = new Ble_Un(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new blt.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Blt_Un Push_Blt_Un(CilLabel operand)
        {
            var op = new Blt_Un(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new switch operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Switch Push_Switch(IEnumerable<CilLabel> operand)
        {
            var op = new Switch(operand);
            _operations.Add(op);
            return op;
        }
        
        
        /// <summary>
        /// Pushes a new switch operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Switch Push_Switch(params CilLabel[] operand)
        {
            var op = new Switch(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_I1 Push_Ldind_I1()
        {
            var op = new Ldind_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.u1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_U1 Push_Ldind_U1()
        {
            var op = new Ldind_U1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_I2 Push_Ldind_I2()
        {
            var op = new Ldind_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.u2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_U2 Push_Ldind_U2()
        {
            var op = new Ldind_U2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_I4 Push_Ldind_I4()
        {
            var op = new Ldind_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.u4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_U4 Push_Ldind_U4()
        {
            var op = new Ldind_U4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_I8 Push_Ldind_I8()
        {
            var op = new Ldind_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_I Push_Ldind_I()
        {
            var op = new Ldind_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_R4 Push_Ldind_R4()
        {
            var op = new Ldind_R4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_R8 Push_Ldind_R8()
        {
            var op = new Ldind_R8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldind.ref operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldind_Ref Push_Ldind_Ref()
        {
            var op = new Ldind_Ref();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.ref operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_Ref Push_Stind_Ref()
        {
            var op = new Stind_Ref();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_I1 Push_Stind_I1()
        {
            var op = new Stind_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_I2 Push_Stind_I2()
        {
            var op = new Stind_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_I4 Push_Stind_I4()
        {
            var op = new Stind_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_I8 Push_Stind_I8()
        {
            var op = new Stind_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_R4 Push_Stind_R4()
        {
            var op = new Stind_R4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_R8 Push_Stind_R8()
        {
            var op = new Stind_R8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new add operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Add Push_Add()
        {
            var op = new Add();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new sub operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Sub Push_Sub()
        {
            var op = new Sub();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new mul operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Mul Push_Mul()
        {
            var op = new Mul();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new div operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Div Push_Div()
        {
            var op = new Div();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new div.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Div_Un Push_Div_Un()
        {
            var op = new Div_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new rem operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Rem Push_Rem()
        {
            var op = new Rem();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new rem.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Rem_Un Push_Rem_Un()
        {
            var op = new Rem_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new and operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public And Push_And()
        {
            var op = new And();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new or operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Or Push_Or()
        {
            var op = new Or();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new xor operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Xor Push_Xor()
        {
            var op = new Xor();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new shl operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Shl Push_Shl()
        {
            var op = new Shl();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new shr operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Shr Push_Shr()
        {
            var op = new Shr();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new shr.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Shr_Un Push_Shr_Un()
        {
            var op = new Shr_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new neg operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Neg Push_Neg()
        {
            var op = new Neg();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new not operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Not Push_Not()
        {
            var op = new Not();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_I1 Push_Conv_I1()
        {
            var op = new Conv_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_I2 Push_Conv_I2()
        {
            var op = new Conv_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_I4 Push_Conv_I4()
        {
            var op = new Conv_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_I8 Push_Conv_I8()
        {
            var op = new Conv_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_R4 Push_Conv_R4()
        {
            var op = new Conv_R4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_R8 Push_Conv_R8()
        {
            var op = new Conv_R8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.u4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_U4 Push_Conv_U4()
        {
            var op = new Conv_U4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.u8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_U8 Push_Conv_U8()
        {
            var op = new Conv_U8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new callvirt operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Callvirt Push_Callvirt(MethodInfo operand)
        {
            var op = new Callvirt(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new cpobj operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Cpobj Push_Cpobj(Type operand)
        {
            var op = new Cpobj(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldobj operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldobj Push_Ldobj(Type operand)
        {
            var op = new Ldobj(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldstr operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldstr Push_Ldstr(string operand)
        {
            var op = new Ldstr(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new newobj operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Newobj Push_Newobj(ConstructorInfo operand)
        {
            var op = new Newobj(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new castclass operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Castclass Push_Castclass(Type operand)
        {
            var op = new Castclass(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new isinst operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Isinst Push_Isinst(Type operand)
        {
            var op = new Isinst(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.r.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_R_Un Push_Conv_R_Un()
        {
            var op = new Conv_R_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new unbox operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Unbox Push_Unbox(Type operand)
        {
            var op = new Unbox(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new throw operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Throw Push_Throw()
        {
            var op = new Throw();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldfld operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldfld Push_Ldfld(FieldInfo operand)
        {
            var op = new Ldfld(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldflda operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldflda Push_Ldflda(FieldInfo operand)
        {
            var op = new Ldflda(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stfld operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stfld Push_Stfld(FieldInfo operand)
        {
            var op = new Stfld(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldsfld operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldsfld Push_Ldsfld(FieldInfo operand)
        {
            var op = new Ldsfld(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldsflda operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldsflda Push_Ldsflda(FieldInfo operand)
        {
            var op = new Ldsflda(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stsfld operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stsfld Push_Stsfld(FieldInfo operand)
        {
            var op = new Stsfld(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stobj operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stobj Push_Stobj(Type operand)
        {
            var op = new Stobj(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i1.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I1_Un Push_Conv_Ovf_I1_Un()
        {
            var op = new Conv_Ovf_I1_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i2.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I2_Un Push_Conv_Ovf_I2_Un()
        {
            var op = new Conv_Ovf_I2_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i4.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I4_Un Push_Conv_Ovf_I4_Un()
        {
            var op = new Conv_Ovf_I4_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i8.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I8_Un Push_Conv_Ovf_I8_Un()
        {
            var op = new Conv_Ovf_I8_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u1.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U1_Un Push_Conv_Ovf_U1_Un()
        {
            var op = new Conv_Ovf_U1_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u2.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U2_Un Push_Conv_Ovf_U2_Un()
        {
            var op = new Conv_Ovf_U2_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u4.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U4_Un Push_Conv_Ovf_U4_Un()
        {
            var op = new Conv_Ovf_U4_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u8.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U8_Un Push_Conv_Ovf_U8_Un()
        {
            var op = new Conv_Ovf_U8_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I_Un Push_Conv_Ovf_I_Un()
        {
            var op = new Conv_Ovf_I_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U_Un Push_Conv_Ovf_U_Un()
        {
            var op = new Conv_Ovf_U_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new box operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Box Push_Box(Type operand)
        {
            var op = new Box(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new newarr operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Newarr Push_Newarr(Type operand)
        {
            var op = new Newarr(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldlen operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldlen Push_Ldlen()
        {
            var op = new Ldlen();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelema operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelema Push_Ldelema(Type operand)
        {
            var op = new Ldelema(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_I1 Push_Ldelem_I1()
        {
            var op = new Ldelem_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.u1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_U1 Push_Ldelem_U1()
        {
            var op = new Ldelem_U1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_I2 Push_Ldelem_I2()
        {
            var op = new Ldelem_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.u2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_U2 Push_Ldelem_U2()
        {
            var op = new Ldelem_U2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_I4 Push_Ldelem_I4()
        {
            var op = new Ldelem_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.u4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_U4 Push_Ldelem_U4()
        {
            var op = new Ldelem_U4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_I8 Push_Ldelem_I8()
        {
            var op = new Ldelem_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_I Push_Ldelem_I()
        {
            var op = new Ldelem_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_R4 Push_Ldelem_R4()
        {
            var op = new Ldelem_R4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_R8 Push_Ldelem_R8()
        {
            var op = new Ldelem_R8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem.ref operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem_Ref Push_Ldelem_Ref()
        {
            var op = new Ldelem_Ref();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_I Push_Stelem_I()
        {
            var op = new Stelem_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_I1 Push_Stelem_I1()
        {
            var op = new Stelem_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_I2 Push_Stelem_I2()
        {
            var op = new Stelem_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_I4 Push_Stelem_I4()
        {
            var op = new Stelem_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_I8 Push_Stelem_I8()
        {
            var op = new Stelem_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.r4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_R4 Push_Stelem_R4()
        {
            var op = new Stelem_R4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.r8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_R8 Push_Stelem_R8()
        {
            var op = new Stelem_R8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem.ref operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem_Ref Push_Stelem_Ref()
        {
            var op = new Stelem_Ref();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldelem operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldelem Push_Ldelem(Type operand)
        {
            var op = new Ldelem(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stelem operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stelem Push_Stelem(Type operand)
        {
            var op = new Stelem(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new unbox.any operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Unbox_Any Push_Unbox_Any(Type operand)
        {
            var op = new Unbox_Any(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I1 Push_Conv_Ovf_I1()
        {
            var op = new Conv_Ovf_I1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U1 Push_Conv_Ovf_U1()
        {
            var op = new Conv_Ovf_U1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I2 Push_Conv_Ovf_I2()
        {
            var op = new Conv_Ovf_I2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U2 Push_Conv_Ovf_U2()
        {
            var op = new Conv_Ovf_U2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I4 Push_Conv_Ovf_I4()
        {
            var op = new Conv_Ovf_I4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u4 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U4 Push_Conv_Ovf_U4()
        {
            var op = new Conv_Ovf_U4();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I8 Push_Conv_Ovf_I8()
        {
            var op = new Conv_Ovf_I8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u8 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U8 Push_Conv_Ovf_U8()
        {
            var op = new Conv_Ovf_U8();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new refanyval operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Refanyval Push_Refanyval(Type operand)
        {
            var op = new Refanyval(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ckfinite operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ckfinite Push_Ckfinite()
        {
            var op = new Ckfinite();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new mkrefany operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Mkrefany Push_Mkrefany(Type operand)
        {
            var op = new Mkrefany(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new ldtoken operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldtoken Push_Ldtoken(Type operand)
        {
            var op = new Ldtoken(operand);
            _operations.Add(op);
            return op;
        }
        
        
        /// <summary>
        /// Pushes a new ldtoken operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldtoken Push_Ldtoken(FieldInfo operand)
        {
            var op = new Ldtoken(operand);
            _operations.Add(op);
            return op;
        }
        
        
        /// <summary>
        /// Pushes a new ldtoken operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Ldtoken Push_Ldtoken(MethodInfo operand)
        {
            var op = new Ldtoken(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.u2 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_U2 Push_Conv_U2()
        {
            var op = new Conv_U2();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.u1 operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_U1 Push_Conv_U1()
        {
            var op = new Conv_U1();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_I Push_Conv_I()
        {
            var op = new Conv_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_I Push_Conv_Ovf_I()
        {
            var op = new Conv_Ovf_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.ovf.u operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_Ovf_U Push_Conv_Ovf_U()
        {
            var op = new Conv_Ovf_U();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new add.ovf operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Add_Ovf Push_Add_Ovf()
        {
            var op = new Add_Ovf();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new add.ovf.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Add_Ovf_Un Push_Add_Ovf_Un()
        {
            var op = new Add_Ovf_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new mul.ovf operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Mul_Ovf Push_Mul_Ovf()
        {
            var op = new Mul_Ovf();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new mul.ovf.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Mul_Ovf_Un Push_Mul_Ovf_Un()
        {
            var op = new Mul_Ovf_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new sub.ovf operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Sub_Ovf Push_Sub_Ovf()
        {
            var op = new Sub_Ovf();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new sub.ovf.un operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Sub_Ovf_Un Push_Sub_Ovf_Un()
        {
            var op = new Sub_Ovf_Un();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new endfinally operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Endfinally Push_Endfinally()
        {
            var op = new Endfinally();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new leave operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Leave Push_Leave(CilLabel operand)
        {
            var op = new Leave(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new leave.s operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Leave_S Push_Leave_S(CilLabel operand)
        {
            var op = new Leave_S(operand);
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new stind.i operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Stind_I Push_Stind_I()
        {
            var op = new Stind_I();
            _operations.Add(op);
            return op;
        }


        /// <summary>
        /// Pushes a new conv.u operation entry onto IL operation queue of this description.
        /// </summary>
        /// <returns></returns>
        public Conv_U Push_Conv_U()
        {
            var op = new Conv_U();
            _operations.Add(op);
            return op;
        }

    }
}
