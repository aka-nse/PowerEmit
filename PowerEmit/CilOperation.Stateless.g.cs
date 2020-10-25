using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{

    [CLSCompliant(true)]
    public sealed class Ldarg_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Ldarg_S;
        internal Ldarg_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldarga_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Ldarga_S;
        internal Ldarga_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Starg_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Starg_S;
        internal Starg_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldloc_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Ldloc_S;
        internal Ldloc_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldloca_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Ldloca_S;
        internal Ldloca_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stloc_S : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Stloc_S;
        internal Stloc_S(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(false)]
    public sealed class Ldc_I4_S : StatelessOperation<sbyte>
    {
        public override OpCode OpCode => OpCodes.Ldc_I4_S;
        internal Ldc_I4_S(sbyte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldc_I4 : StatelessOperation<int>
    {
        public override OpCode OpCode => OpCodes.Ldc_I4;
        internal Ldc_I4(int operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldc_I8 : StatelessOperation<long>
    {
        public override OpCode OpCode => OpCodes.Ldc_I8;
        internal Ldc_I8(long operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldc_R4 : StatelessOperation<float>
    {
        public override OpCode OpCode => OpCodes.Ldc_R4;
        internal Ldc_R4(float operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldc_R8 : StatelessOperation<double>
    {
        public override OpCode OpCode => OpCodes.Ldc_R8;
        internal Ldc_R8(double operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Jmp : StatelessOperation<MethodInfo>
    {
        public override OpCode OpCode => OpCodes.Jmp;
        internal Jmp(MethodInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Cpobj : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Cpobj;
        internal Cpobj(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldobj : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Ldobj;
        internal Ldobj(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldstr : StatelessOperation<string>
    {
        public override OpCode OpCode => OpCodes.Ldstr;
        internal Ldstr(string operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Castclass : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Castclass;
        internal Castclass(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Isinst : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Isinst;
        internal Isinst(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Unbox : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Unbox;
        internal Unbox(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldfld : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Ldfld;
        internal Ldfld(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldflda : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Ldflda;
        internal Ldflda(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stfld : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Stfld;
        internal Stfld(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldsfld : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Ldsfld;
        internal Ldsfld(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldsflda : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Ldsflda;
        internal Ldsflda(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stsfld : StatelessOperation<FieldInfo>
    {
        public override OpCode OpCode => OpCodes.Stsfld;
        internal Stsfld(FieldInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stobj : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Stobj;
        internal Stobj(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Box : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Box;
        internal Box(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Newarr : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Newarr;
        internal Newarr(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldelema : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Ldelema;
        internal Ldelema(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldelem : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Ldelem;
        internal Ldelem(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stelem : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Stelem;
        internal Stelem(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Unbox_Any : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Unbox_Any;
        internal Unbox_Any(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Refanyval : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Refanyval;
        internal Refanyval(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Mkrefany : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Mkrefany;
        internal Mkrefany(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldftn : StatelessOperation<MethodInfo>
    {
        public override OpCode OpCode => OpCodes.Ldftn;
        internal Ldftn(MethodInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldvirtftn : StatelessOperation<MethodInfo>
    {
        public override OpCode OpCode => OpCodes.Ldvirtftn;
        internal Ldvirtftn(MethodInfo operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldarg : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Ldarg;
        internal Ldarg(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldarga : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Ldarga;
        internal Ldarga(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Starg : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Starg;
        internal Starg(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldloc : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Ldloc;
        internal Ldloc(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Ldloca : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Ldloca;
        internal Ldloca(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Stloc : StatelessOperation<short>
    {
        public override OpCode OpCode => OpCodes.Stloc;
        internal Stloc(short operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Initobj : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Initobj;
        internal Initobj(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Unaligned : StatelessOperation<byte>
    {
        public override OpCode OpCode => OpCodes.Unaligned;
        internal Unaligned(byte operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Constrained : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Constrained;
        internal Constrained(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }


    [CLSCompliant(true)]
    public sealed class Sizeof : StatelessOperation<Type>
    {
        public override OpCode OpCode => OpCodes.Sizeof;
        internal Sizeof(Type operand) : base(operand) {}

        public override void Emit(CilGeneratorState state)
            => state.Generator.Emit(OpCode, Operand);
    }

}
