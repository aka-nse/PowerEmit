#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Xunit;

namespace PowerEmit
{
    public partial class PushOperationTest
    {
        [Theory]
        [MemberData(nameof(TestArgs_Basic))]
        private void PushTest_Basic(string testname, Action<ILGenerator> expected, Action<MethodDescription> actual, Type? returnType = null, Type[]? parameterTypes = null)
            => PushTestCore(testname, expected, actual, returnType, parameterTypes);


        public static IEnumerable<object[]> TestArgs_Basic()
        {
            yield return CreateArgs(
                OpCodes.Arglist,
                gen => gen.Emit(OpCodes.Arglist),
                desc => desc.Stream.Add(OpCodeX.Arglist()));
            yield return CreateArgs(
                OpCodes.Ceq,
                gen => gen.Emit(OpCodes.Ceq),
                desc => desc.Stream.Add(OpCodeX.Ceq()));
            yield return CreateArgs(
                OpCodes.Cgt,
                gen => gen.Emit(OpCodes.Cgt),
                desc => desc.Stream.Add(OpCodeX.Cgt()));
            yield return CreateArgs(
                OpCodes.Cgt_Un,
                gen => gen.Emit(OpCodes.Cgt_Un),
                desc => desc.Stream.Add(OpCodeX.Cgt_Un()));
            yield return CreateArgs(
                OpCodes.Clt,
                gen => gen.Emit(OpCodes.Clt),
                desc => desc.Stream.Add(OpCodeX.Clt()));
            yield return CreateArgs(
                OpCodes.Clt_Un,
                gen => gen.Emit(OpCodes.Clt_Un),
                desc => desc.Stream.Add(OpCodeX.Clt_Un()));
            yield return CreateArgs(
                OpCodes.Ldftn,
                gen => gen.Emit(OpCodes.Ldftn, MockType.MethodInfo),
                desc => desc.Stream.Add(OpCodeX.Ldftn(MockType.MethodInfo)));
            yield return CreateArgs(
                OpCodes.Ldvirtftn,
                gen => gen.Emit(OpCodes.Ldvirtftn, MockType.MethodInfo),
                desc => desc.Stream.Add(OpCodeX.Ldvirtftn(MockType.MethodInfo)));
            yield return CreateArgs(
                OpCodes.Ldarg,
                gen => gen.Emit(OpCodes.Ldarg, default(short)),
                desc => desc.Stream.Add(OpCodeX.Ldarg(default(short))));
            yield return CreateArgs(
                OpCodes.Ldarga,
                gen => gen.Emit(OpCodes.Ldarga, default(short)),
                desc => desc.Stream.Add(OpCodeX.Ldarga(default(short))));
            yield return CreateArgs(
                OpCodes.Starg,
                gen => gen.Emit(OpCodes.Starg, default(short)),
                desc => desc.Stream.Add(OpCodeX.Starg(default(short))));
            yield return CreateArgs(
                OpCodes.Ldloc,
                gen => gen.Emit(OpCodes.Ldloc, default(short)),
                desc => desc.Stream.Add(OpCodeX.Ldloc(default(short))));
            yield return CreateArgs(
                OpCodes.Ldloca,
                gen => gen.Emit(OpCodes.Ldloca, default(short)),
                desc => desc.Stream.Add(OpCodeX.Ldloca(default(short))));
            yield return CreateArgs(
                OpCodes.Stloc,
                gen => gen.Emit(OpCodes.Stloc, default(short)),
                desc => desc.Stream.Add(OpCodeX.Stloc(default(short))));
            yield return CreateArgs(
                OpCodes.Localloc,
                gen => gen.Emit(OpCodes.Localloc),
                desc => desc.Stream.Add(OpCodeX.Localloc()));
            yield return CreateArgs(
                OpCodes.Endfilter,
                gen => gen.Emit(OpCodes.Endfilter),
                desc => desc.Stream.Add(OpCodeX.Endfilter()));
            yield return CreateArgs(
                OpCodes.Unaligned,
                gen => gen.Emit(OpCodes.Unaligned, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Unaligned(default(byte))));
            yield return CreateArgs(
                OpCodes.Volatile,
                gen => gen.Emit(OpCodes.Volatile),
                desc => desc.Stream.Add(OpCodeX.Volatile()));
            yield return CreateArgs(
                OpCodes.Tailcall,
                gen => gen.Emit(OpCodes.Tailcall),
                desc => desc.Stream.Add(OpCodeX.Tailcall()));
            yield return CreateArgs(
                OpCodes.Initobj,
                gen => gen.Emit(OpCodes.Initobj, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Initobj(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Constrained,
                gen => gen.Emit(OpCodes.Constrained, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Constrained(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Cpblk,
                gen => gen.Emit(OpCodes.Cpblk),
                desc => desc.Stream.Add(OpCodeX.Cpblk()));
            yield return CreateArgs(
                OpCodes.Initblk,
                gen => gen.Emit(OpCodes.Initblk),
                desc => desc.Stream.Add(OpCodeX.Initblk()));
            yield return CreateArgs(
                OpCodes.Rethrow,
                gen => gen.Emit(OpCodes.Rethrow),
                desc => desc.Stream.Add(OpCodeX.Rethrow()));
            yield return CreateArgs(
                OpCodes.Sizeof,
                gen => gen.Emit(OpCodes.Sizeof, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Sizeof(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Refanytype,
                gen => gen.Emit(OpCodes.Refanytype),
                desc => desc.Stream.Add(OpCodeX.Refanytype()));
            yield return CreateArgs(
                OpCodes.Readonly,
                gen => gen.Emit(OpCodes.Readonly),
                desc => desc.Stream.Add(OpCodeX.Readonly()));
            yield return CreateArgs(
                OpCodes.Nop,
                gen => gen.Emit(OpCodes.Nop),
                desc => desc.Stream.Add(OpCodeX.Nop()));
            yield return CreateArgs(
                OpCodes.Break,
                gen => gen.Emit(OpCodes.Break),
                desc => desc.Stream.Add(OpCodeX.Break()));
            yield return CreateArgs(
                OpCodes.Ldarg_0,
                gen => gen.Emit(OpCodes.Ldarg_0),
                desc => desc.Stream.Add(OpCodeX.Ldarg_0()));
            yield return CreateArgs(
                OpCodes.Ldarg_1,
                gen => gen.Emit(OpCodes.Ldarg_1),
                desc => desc.Stream.Add(OpCodeX.Ldarg_1()));
            yield return CreateArgs(
                OpCodes.Ldarg_2,
                gen => gen.Emit(OpCodes.Ldarg_2),
                desc => desc.Stream.Add(OpCodeX.Ldarg_2()));
            yield return CreateArgs(
                OpCodes.Ldarg_3,
                gen => gen.Emit(OpCodes.Ldarg_3),
                desc => desc.Stream.Add(OpCodeX.Ldarg_3()));
            yield return CreateArgs(
                OpCodes.Ldloc_0,
                gen => gen.Emit(OpCodes.Ldloc_0),
                desc => desc.Stream.Add(OpCodeX.Ldloc_0()));
            yield return CreateArgs(
                OpCodes.Ldloc_1,
                gen => gen.Emit(OpCodes.Ldloc_1),
                desc => desc.Stream.Add(OpCodeX.Ldloc_1()));
            yield return CreateArgs(
                OpCodes.Ldloc_2,
                gen => gen.Emit(OpCodes.Ldloc_2),
                desc => desc.Stream.Add(OpCodeX.Ldloc_2()));
            yield return CreateArgs(
                OpCodes.Ldloc_3,
                gen => gen.Emit(OpCodes.Ldloc_3),
                desc => desc.Stream.Add(OpCodeX.Ldloc_3()));
            yield return CreateArgs(
                OpCodes.Stloc_0,
                gen => gen.Emit(OpCodes.Stloc_0),
                desc => desc.Stream.Add(OpCodeX.Stloc_0()));
            yield return CreateArgs(
                OpCodes.Stloc_1,
                gen => gen.Emit(OpCodes.Stloc_1),
                desc => desc.Stream.Add(OpCodeX.Stloc_1()));
            yield return CreateArgs(
                OpCodes.Stloc_2,
                gen => gen.Emit(OpCodes.Stloc_2),
                desc => desc.Stream.Add(OpCodeX.Stloc_2()));
            yield return CreateArgs(
                OpCodes.Stloc_3,
                gen => gen.Emit(OpCodes.Stloc_3),
                desc => desc.Stream.Add(OpCodeX.Stloc_3()));
            yield return CreateArgs(
                OpCodes.Ldarg_S,
                gen => gen.Emit(OpCodes.Ldarg_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Ldarg_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Ldarga_S,
                gen => gen.Emit(OpCodes.Ldarga_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Ldarga_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Starg_S,
                gen => gen.Emit(OpCodes.Starg_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Starg_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Ldloc_S,
                gen => gen.Emit(OpCodes.Ldloc_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Ldloc_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Ldloca_S,
                gen => gen.Emit(OpCodes.Ldloca_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Ldloca_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Stloc_S,
                gen => gen.Emit(OpCodes.Stloc_S, default(byte)),
                desc => desc.Stream.Add(OpCodeX.Stloc_S(default(byte))));
            yield return CreateArgs(
                OpCodes.Ldnull,
                gen => gen.Emit(OpCodes.Ldnull),
                desc => desc.Stream.Add(OpCodeX.Ldnull()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_M1,
                gen => gen.Emit(OpCodes.Ldc_I4_M1),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_M1()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_0,
                gen => gen.Emit(OpCodes.Ldc_I4_0),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_0()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_1,
                gen => gen.Emit(OpCodes.Ldc_I4_1),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_1()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_2,
                gen => gen.Emit(OpCodes.Ldc_I4_2),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_2()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_3,
                gen => gen.Emit(OpCodes.Ldc_I4_3),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_3()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_4,
                gen => gen.Emit(OpCodes.Ldc_I4_4),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_4()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_5,
                gen => gen.Emit(OpCodes.Ldc_I4_5),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_5()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_6,
                gen => gen.Emit(OpCodes.Ldc_I4_6),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_6()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_7,
                gen => gen.Emit(OpCodes.Ldc_I4_7),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_7()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_8,
                gen => gen.Emit(OpCodes.Ldc_I4_8),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_8()));
            yield return CreateArgs(
                OpCodes.Ldc_I4_S,
                gen => gen.Emit(OpCodes.Ldc_I4_S, default(sbyte)),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4_S(default(sbyte))));
            yield return CreateArgs(
                OpCodes.Ldc_I4,
                gen => gen.Emit(OpCodes.Ldc_I4, default(int)),
                desc => desc.Stream.Add(OpCodeX.Ldc_I4(default(int))));
            yield return CreateArgs(
                OpCodes.Ldc_I8,
                gen => gen.Emit(OpCodes.Ldc_I8, default(long)),
                desc => desc.Stream.Add(OpCodeX.Ldc_I8(default(long))));
            yield return CreateArgs(
                OpCodes.Ldc_R4,
                gen => gen.Emit(OpCodes.Ldc_R4, default(float)),
                desc => desc.Stream.Add(OpCodeX.Ldc_R4(default(float))));
            yield return CreateArgs(
                OpCodes.Ldc_R8,
                gen => gen.Emit(OpCodes.Ldc_R8, default(double)),
                desc => desc.Stream.Add(OpCodeX.Ldc_R8(default(double))));
            yield return CreateArgs(
                OpCodes.Dup,
                gen => gen.Emit(OpCodes.Dup),
                desc => desc.Stream.Add(OpCodeX.Dup()));
            yield return CreateArgs(
                OpCodes.Pop,
                gen => gen.Emit(OpCodes.Pop),
                desc => desc.Stream.Add(OpCodeX.Pop()));
            yield return CreateArgs(
                OpCodes.Jmp,
                gen => gen.Emit(OpCodes.Jmp, MockType.MethodInfo),
                desc => desc.Stream.Add(OpCodeX.Jmp(MockType.MethodInfo)));
            yield return CreateArgs(
                OpCodes.Call,
                gen => gen.Emit(OpCodes.Call, MockType.MethodInfo),
                desc => desc.Stream.Add(OpCodeX.Call(MockType.MethodInfo)));
            yield return CreateArgs(
                OpCodes.Ret,
                gen => gen.Emit(OpCodes.Ret),
                desc => desc.Stream.Add(OpCodeX.Ret()));
            yield return CreateArgs(
                OpCodes.Ldind_I1,
                gen => gen.Emit(OpCodes.Ldind_I1),
                desc => desc.Stream.Add(OpCodeX.Ldind_I1()));
            yield return CreateArgs(
                OpCodes.Ldind_U1,
                gen => gen.Emit(OpCodes.Ldind_U1),
                desc => desc.Stream.Add(OpCodeX.Ldind_U1()));
            yield return CreateArgs(
                OpCodes.Ldind_I2,
                gen => gen.Emit(OpCodes.Ldind_I2),
                desc => desc.Stream.Add(OpCodeX.Ldind_I2()));
            yield return CreateArgs(
                OpCodes.Ldind_U2,
                gen => gen.Emit(OpCodes.Ldind_U2),
                desc => desc.Stream.Add(OpCodeX.Ldind_U2()));
            yield return CreateArgs(
                OpCodes.Ldind_I4,
                gen => gen.Emit(OpCodes.Ldind_I4),
                desc => desc.Stream.Add(OpCodeX.Ldind_I4()));
            yield return CreateArgs(
                OpCodes.Ldind_U4,
                gen => gen.Emit(OpCodes.Ldind_U4),
                desc => desc.Stream.Add(OpCodeX.Ldind_U4()));
            yield return CreateArgs(
                OpCodes.Ldind_I8,
                gen => gen.Emit(OpCodes.Ldind_I8),
                desc => desc.Stream.Add(OpCodeX.Ldind_I8()));
            yield return CreateArgs(
                OpCodes.Ldind_I,
                gen => gen.Emit(OpCodes.Ldind_I),
                desc => desc.Stream.Add(OpCodeX.Ldind_I()));
            yield return CreateArgs(
                OpCodes.Ldind_R4,
                gen => gen.Emit(OpCodes.Ldind_R4),
                desc => desc.Stream.Add(OpCodeX.Ldind_R4()));
            yield return CreateArgs(
                OpCodes.Ldind_R8,
                gen => gen.Emit(OpCodes.Ldind_R8),
                desc => desc.Stream.Add(OpCodeX.Ldind_R8()));
            yield return CreateArgs(
                OpCodes.Ldind_Ref,
                gen => gen.Emit(OpCodes.Ldind_Ref),
                desc => desc.Stream.Add(OpCodeX.Ldind_Ref()));
            yield return CreateArgs(
                OpCodes.Stind_Ref,
                gen => gen.Emit(OpCodes.Stind_Ref),
                desc => desc.Stream.Add(OpCodeX.Stind_Ref()));
            yield return CreateArgs(
                OpCodes.Stind_I1,
                gen => gen.Emit(OpCodes.Stind_I1),
                desc => desc.Stream.Add(OpCodeX.Stind_I1()));
            yield return CreateArgs(
                OpCodes.Stind_I2,
                gen => gen.Emit(OpCodes.Stind_I2),
                desc => desc.Stream.Add(OpCodeX.Stind_I2()));
            yield return CreateArgs(
                OpCodes.Stind_I4,
                gen => gen.Emit(OpCodes.Stind_I4),
                desc => desc.Stream.Add(OpCodeX.Stind_I4()));
            yield return CreateArgs(
                OpCodes.Stind_I8,
                gen => gen.Emit(OpCodes.Stind_I8),
                desc => desc.Stream.Add(OpCodeX.Stind_I8()));
            yield return CreateArgs(
                OpCodes.Stind_R4,
                gen => gen.Emit(OpCodes.Stind_R4),
                desc => desc.Stream.Add(OpCodeX.Stind_R4()));
            yield return CreateArgs(
                OpCodes.Stind_R8,
                gen => gen.Emit(OpCodes.Stind_R8),
                desc => desc.Stream.Add(OpCodeX.Stind_R8()));
            yield return CreateArgs(
                OpCodes.Add,
                gen => gen.Emit(OpCodes.Add),
                desc => desc.Stream.Add(OpCodeX.Add()));
            yield return CreateArgs(
                OpCodes.Sub,
                gen => gen.Emit(OpCodes.Sub),
                desc => desc.Stream.Add(OpCodeX.Sub()));
            yield return CreateArgs(
                OpCodes.Mul,
                gen => gen.Emit(OpCodes.Mul),
                desc => desc.Stream.Add(OpCodeX.Mul()));
            yield return CreateArgs(
                OpCodes.Div,
                gen => gen.Emit(OpCodes.Div),
                desc => desc.Stream.Add(OpCodeX.Div()));
            yield return CreateArgs(
                OpCodes.Div_Un,
                gen => gen.Emit(OpCodes.Div_Un),
                desc => desc.Stream.Add(OpCodeX.Div_Un()));
            yield return CreateArgs(
                OpCodes.Rem,
                gen => gen.Emit(OpCodes.Rem),
                desc => desc.Stream.Add(OpCodeX.Rem()));
            yield return CreateArgs(
                OpCodes.Rem_Un,
                gen => gen.Emit(OpCodes.Rem_Un),
                desc => desc.Stream.Add(OpCodeX.Rem_Un()));
            yield return CreateArgs(
                OpCodes.And,
                gen => gen.Emit(OpCodes.And),
                desc => desc.Stream.Add(OpCodeX.And()));
            yield return CreateArgs(
                OpCodes.Or,
                gen => gen.Emit(OpCodes.Or),
                desc => desc.Stream.Add(OpCodeX.Or()));
            yield return CreateArgs(
                OpCodes.Xor,
                gen => gen.Emit(OpCodes.Xor),
                desc => desc.Stream.Add(OpCodeX.Xor()));
            yield return CreateArgs(
                OpCodes.Shl,
                gen => gen.Emit(OpCodes.Shl),
                desc => desc.Stream.Add(OpCodeX.Shl()));
            yield return CreateArgs(
                OpCodes.Shr,
                gen => gen.Emit(OpCodes.Shr),
                desc => desc.Stream.Add(OpCodeX.Shr()));
            yield return CreateArgs(
                OpCodes.Shr_Un,
                gen => gen.Emit(OpCodes.Shr_Un),
                desc => desc.Stream.Add(OpCodeX.Shr_Un()));
            yield return CreateArgs(
                OpCodes.Neg,
                gen => gen.Emit(OpCodes.Neg),
                desc => desc.Stream.Add(OpCodeX.Neg()));
            yield return CreateArgs(
                OpCodes.Not,
                gen => gen.Emit(OpCodes.Not),
                desc => desc.Stream.Add(OpCodeX.Not()));
            yield return CreateArgs(
                OpCodes.Conv_I1,
                gen => gen.Emit(OpCodes.Conv_I1),
                desc => desc.Stream.Add(OpCodeX.Conv_I1()));
            yield return CreateArgs(
                OpCodes.Conv_I2,
                gen => gen.Emit(OpCodes.Conv_I2),
                desc => desc.Stream.Add(OpCodeX.Conv_I2()));
            yield return CreateArgs(
                OpCodes.Conv_I4,
                gen => gen.Emit(OpCodes.Conv_I4),
                desc => desc.Stream.Add(OpCodeX.Conv_I4()));
            yield return CreateArgs(
                OpCodes.Conv_I8,
                gen => gen.Emit(OpCodes.Conv_I8),
                desc => desc.Stream.Add(OpCodeX.Conv_I8()));
            yield return CreateArgs(
                OpCodes.Conv_R4,
                gen => gen.Emit(OpCodes.Conv_R4),
                desc => desc.Stream.Add(OpCodeX.Conv_R4()));
            yield return CreateArgs(
                OpCodes.Conv_R8,
                gen => gen.Emit(OpCodes.Conv_R8),
                desc => desc.Stream.Add(OpCodeX.Conv_R8()));
            yield return CreateArgs(
                OpCodes.Conv_U4,
                gen => gen.Emit(OpCodes.Conv_U4),
                desc => desc.Stream.Add(OpCodeX.Conv_U4()));
            yield return CreateArgs(
                OpCodes.Conv_U8,
                gen => gen.Emit(OpCodes.Conv_U8),
                desc => desc.Stream.Add(OpCodeX.Conv_U8()));
            yield return CreateArgs(
                OpCodes.Callvirt,
                gen => gen.Emit(OpCodes.Callvirt, MockType.MethodInfo),
                desc => desc.Stream.Add(OpCodeX.Callvirt(MockType.MethodInfo)));
            yield return CreateArgs(
                OpCodes.Cpobj,
                gen => gen.Emit(OpCodes.Cpobj, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Cpobj(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Ldobj,
                gen => gen.Emit(OpCodes.Ldobj, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Ldobj(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Ldstr,
                gen => gen.Emit(OpCodes.Ldstr, string.Empty),
                desc => desc.Stream.Add(OpCodeX.Ldstr(string.Empty)));
            yield return CreateArgs(
                OpCodes.Newobj,
                gen => gen.Emit(OpCodes.Newobj, MockType.ConstructorInfo),
                desc => desc.Stream.Add(OpCodeX.Newobj(MockType.ConstructorInfo)));
            yield return CreateArgs(
                OpCodes.Castclass,
                gen => gen.Emit(OpCodes.Castclass, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Castclass(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Isinst,
                gen => gen.Emit(OpCodes.Isinst, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Isinst(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Conv_R_Un,
                gen => gen.Emit(OpCodes.Conv_R_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_R_Un()));
            yield return CreateArgs(
                OpCodes.Unbox,
                gen => gen.Emit(OpCodes.Unbox, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Unbox(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Throw,
                gen => gen.Emit(OpCodes.Throw),
                desc => desc.Stream.Add(OpCodeX.Throw()));
            yield return CreateArgs(
                OpCodes.Ldfld,
                gen => gen.Emit(OpCodes.Ldfld, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Ldfld(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Ldflda,
                gen => gen.Emit(OpCodes.Ldflda, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Ldflda(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Stfld,
                gen => gen.Emit(OpCodes.Stfld, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Stfld(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Ldsfld,
                gen => gen.Emit(OpCodes.Ldsfld, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Ldsfld(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Ldsflda,
                gen => gen.Emit(OpCodes.Ldsflda, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Ldsflda(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Stsfld,
                gen => gen.Emit(OpCodes.Stsfld, MockType.FieldInfo),
                desc => desc.Stream.Add(OpCodeX.Stsfld(MockType.FieldInfo)));
            yield return CreateArgs(
                OpCodes.Stobj,
                gen => gen.Emit(OpCodes.Stobj, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Stobj(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I1_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_I1_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I1_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I2_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_I2_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I2_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I4_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_I4_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I4_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I8_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_I8_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I8_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U1_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_U1_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U1_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U2_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_U2_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U2_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U4_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_U4_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U4_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U8_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_U8_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U8_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_I_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I_Un()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U_Un,
                gen => gen.Emit(OpCodes.Conv_Ovf_U_Un),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U_Un()));
            yield return CreateArgs(
                OpCodes.Box,
                gen => gen.Emit(OpCodes.Box, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Box(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Newarr,
                gen => gen.Emit(OpCodes.Newarr, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Newarr(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Ldlen,
                gen => gen.Emit(OpCodes.Ldlen),
                desc => desc.Stream.Add(OpCodeX.Ldlen()));
            yield return CreateArgs(
                OpCodes.Ldelema,
                gen => gen.Emit(OpCodes.Ldelema, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Ldelema(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Ldelem_I1,
                gen => gen.Emit(OpCodes.Ldelem_I1),
                desc => desc.Stream.Add(OpCodeX.Ldelem_I1()));
            yield return CreateArgs(
                OpCodes.Ldelem_U1,
                gen => gen.Emit(OpCodes.Ldelem_U1),
                desc => desc.Stream.Add(OpCodeX.Ldelem_U1()));
            yield return CreateArgs(
                OpCodes.Ldelem_I2,
                gen => gen.Emit(OpCodes.Ldelem_I2),
                desc => desc.Stream.Add(OpCodeX.Ldelem_I2()));
            yield return CreateArgs(
                OpCodes.Ldelem_U2,
                gen => gen.Emit(OpCodes.Ldelem_U2),
                desc => desc.Stream.Add(OpCodeX.Ldelem_U2()));
            yield return CreateArgs(
                OpCodes.Ldelem_I4,
                gen => gen.Emit(OpCodes.Ldelem_I4),
                desc => desc.Stream.Add(OpCodeX.Ldelem_I4()));
            yield return CreateArgs(
                OpCodes.Ldelem_U4,
                gen => gen.Emit(OpCodes.Ldelem_U4),
                desc => desc.Stream.Add(OpCodeX.Ldelem_U4()));
            yield return CreateArgs(
                OpCodes.Ldelem_I8,
                gen => gen.Emit(OpCodes.Ldelem_I8),
                desc => desc.Stream.Add(OpCodeX.Ldelem_I8()));
            yield return CreateArgs(
                OpCodes.Ldelem_I,
                gen => gen.Emit(OpCodes.Ldelem_I),
                desc => desc.Stream.Add(OpCodeX.Ldelem_I()));
            yield return CreateArgs(
                OpCodes.Ldelem_R4,
                gen => gen.Emit(OpCodes.Ldelem_R4),
                desc => desc.Stream.Add(OpCodeX.Ldelem_R4()));
            yield return CreateArgs(
                OpCodes.Ldelem_R8,
                gen => gen.Emit(OpCodes.Ldelem_R8),
                desc => desc.Stream.Add(OpCodeX.Ldelem_R8()));
            yield return CreateArgs(
                OpCodes.Ldelem_Ref,
                gen => gen.Emit(OpCodes.Ldelem_Ref),
                desc => desc.Stream.Add(OpCodeX.Ldelem_Ref()));
            yield return CreateArgs(
                OpCodes.Stelem_I,
                gen => gen.Emit(OpCodes.Stelem_I),
                desc => desc.Stream.Add(OpCodeX.Stelem_I()));
            yield return CreateArgs(
                OpCodes.Stelem_I1,
                gen => gen.Emit(OpCodes.Stelem_I1),
                desc => desc.Stream.Add(OpCodeX.Stelem_I1()));
            yield return CreateArgs(
                OpCodes.Stelem_I2,
                gen => gen.Emit(OpCodes.Stelem_I2),
                desc => desc.Stream.Add(OpCodeX.Stelem_I2()));
            yield return CreateArgs(
                OpCodes.Stelem_I4,
                gen => gen.Emit(OpCodes.Stelem_I4),
                desc => desc.Stream.Add(OpCodeX.Stelem_I4()));
            yield return CreateArgs(
                OpCodes.Stelem_I8,
                gen => gen.Emit(OpCodes.Stelem_I8),
                desc => desc.Stream.Add(OpCodeX.Stelem_I8()));
            yield return CreateArgs(
                OpCodes.Stelem_R4,
                gen => gen.Emit(OpCodes.Stelem_R4),
                desc => desc.Stream.Add(OpCodeX.Stelem_R4()));
            yield return CreateArgs(
                OpCodes.Stelem_R8,
                gen => gen.Emit(OpCodes.Stelem_R8),
                desc => desc.Stream.Add(OpCodeX.Stelem_R8()));
            yield return CreateArgs(
                OpCodes.Stelem_Ref,
                gen => gen.Emit(OpCodes.Stelem_Ref),
                desc => desc.Stream.Add(OpCodeX.Stelem_Ref()));
            yield return CreateArgs(
                OpCodes.Ldelem,
                gen => gen.Emit(OpCodes.Ldelem, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Ldelem(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Stelem,
                gen => gen.Emit(OpCodes.Stelem, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Stelem(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Unbox_Any,
                gen => gen.Emit(OpCodes.Unbox_Any, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Unbox_Any(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I1,
                gen => gen.Emit(OpCodes.Conv_Ovf_I1),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I1()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U1,
                gen => gen.Emit(OpCodes.Conv_Ovf_U1),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U1()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I2,
                gen => gen.Emit(OpCodes.Conv_Ovf_I2),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I2()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U2,
                gen => gen.Emit(OpCodes.Conv_Ovf_U2),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U2()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I4,
                gen => gen.Emit(OpCodes.Conv_Ovf_I4),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I4()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U4,
                gen => gen.Emit(OpCodes.Conv_Ovf_U4),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U4()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I8,
                gen => gen.Emit(OpCodes.Conv_Ovf_I8),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I8()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U8,
                gen => gen.Emit(OpCodes.Conv_Ovf_U8),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U8()));
            yield return CreateArgs(
                OpCodes.Refanyval,
                gen => gen.Emit(OpCodes.Refanyval, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Refanyval(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Ckfinite,
                gen => gen.Emit(OpCodes.Ckfinite),
                desc => desc.Stream.Add(OpCodeX.Ckfinite()));
            yield return CreateArgs(
                OpCodes.Mkrefany,
                gen => gen.Emit(OpCodes.Mkrefany, typeof(MockType)),
                desc => desc.Stream.Add(OpCodeX.Mkrefany(typeof(MockType))));
            yield return CreateArgs(
                OpCodes.Conv_U2,
                gen => gen.Emit(OpCodes.Conv_U2),
                desc => desc.Stream.Add(OpCodeX.Conv_U2()));
            yield return CreateArgs(
                OpCodes.Conv_U1,
                gen => gen.Emit(OpCodes.Conv_U1),
                desc => desc.Stream.Add(OpCodeX.Conv_U1()));
            yield return CreateArgs(
                OpCodes.Conv_I,
                gen => gen.Emit(OpCodes.Conv_I),
                desc => desc.Stream.Add(OpCodeX.Conv_I()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_I,
                gen => gen.Emit(OpCodes.Conv_Ovf_I),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_I()));
            yield return CreateArgs(
                OpCodes.Conv_Ovf_U,
                gen => gen.Emit(OpCodes.Conv_Ovf_U),
                desc => desc.Stream.Add(OpCodeX.Conv_Ovf_U()));
            yield return CreateArgs(
                OpCodes.Add_Ovf,
                gen => gen.Emit(OpCodes.Add_Ovf),
                desc => desc.Stream.Add(OpCodeX.Add_Ovf()));
            yield return CreateArgs(
                OpCodes.Add_Ovf_Un,
                gen => gen.Emit(OpCodes.Add_Ovf_Un),
                desc => desc.Stream.Add(OpCodeX.Add_Ovf_Un()));
            yield return CreateArgs(
                OpCodes.Mul_Ovf,
                gen => gen.Emit(OpCodes.Mul_Ovf),
                desc => desc.Stream.Add(OpCodeX.Mul_Ovf()));
            yield return CreateArgs(
                OpCodes.Mul_Ovf_Un,
                gen => gen.Emit(OpCodes.Mul_Ovf_Un),
                desc => desc.Stream.Add(OpCodeX.Mul_Ovf_Un()));
            yield return CreateArgs(
                OpCodes.Sub_Ovf,
                gen => gen.Emit(OpCodes.Sub_Ovf),
                desc => desc.Stream.Add(OpCodeX.Sub_Ovf()));
            yield return CreateArgs(
                OpCodes.Sub_Ovf_Un,
                gen => gen.Emit(OpCodes.Sub_Ovf_Un),
                desc => desc.Stream.Add(OpCodeX.Sub_Ovf_Un()));
            yield return CreateArgs(
                OpCodes.Endfinally,
                gen => gen.Emit(OpCodes.Endfinally),
                desc => desc.Stream.Add(OpCodeX.Endfinally()));
            yield return CreateArgs(
                OpCodes.Stind_I,
                gen => gen.Emit(OpCodes.Stind_I),
                desc => desc.Stream.Add(OpCodeX.Stind_I()));
            yield return CreateArgs(
                OpCodes.Conv_U,
                gen => gen.Emit(OpCodes.Conv_U),
                desc => desc.Stream.Add(OpCodeX.Conv_U()));
            yield break;
        }
    }
}
