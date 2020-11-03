using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        [CLSCompliant(true)]
        public static IILStreamOpCode Ldarg_S(byte operand)
            => new Emit_Ldarg_S(operand);


        private sealed class Emit_Ldarg_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Ldarg_S;
            internal Emit_Ldarg_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldarga_S(byte operand)
            => new Emit_Ldarga_S(operand);


        private sealed class Emit_Ldarga_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Ldarga_S;
            internal Emit_Ldarga_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Starg_S(byte operand)
            => new Emit_Starg_S(operand);


        private sealed class Emit_Starg_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Starg_S;
            internal Emit_Starg_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldloc_S(byte operand)
            => new Emit_Ldloc_S(operand);


        private sealed class Emit_Ldloc_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Ldloc_S;
            internal Emit_Ldloc_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldloca_S(byte operand)
            => new Emit_Ldloca_S(operand);


        private sealed class Emit_Ldloca_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Ldloca_S;
            internal Emit_Ldloca_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stloc_S(byte operand)
            => new Emit_Stloc_S(operand);


        private sealed class Emit_Stloc_S : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Stloc_S;
            internal Emit_Stloc_S(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(false)]
        public static IILStreamOpCode Ldc_I4_S(sbyte operand)
            => new Emit_Ldc_I4_S(operand);


        private sealed class Emit_Ldc_I4_S : StatelessOperation<sbyte>
        {
            public override OpCode OpCode => OpCodes.Ldc_I4_S;
            internal Emit_Ldc_I4_S(sbyte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldc_I4(int operand)
            => new Emit_Ldc_I4(operand);


        private sealed class Emit_Ldc_I4 : StatelessOperation<int>
        {
            public override OpCode OpCode => OpCodes.Ldc_I4;
            internal Emit_Ldc_I4(int operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldc_I8(long operand)
            => new Emit_Ldc_I8(operand);


        private sealed class Emit_Ldc_I8 : StatelessOperation<long>
        {
            public override OpCode OpCode => OpCodes.Ldc_I8;
            internal Emit_Ldc_I8(long operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldc_R4(float operand)
            => new Emit_Ldc_R4(operand);


        private sealed class Emit_Ldc_R4 : StatelessOperation<float>
        {
            public override OpCode OpCode => OpCodes.Ldc_R4;
            internal Emit_Ldc_R4(float operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldc_R8(double operand)
            => new Emit_Ldc_R8(operand);


        private sealed class Emit_Ldc_R8 : StatelessOperation<double>
        {
            public override OpCode OpCode => OpCodes.Ldc_R8;
            internal Emit_Ldc_R8(double operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Jmp(MethodInfo operand)
            => new Emit_Jmp(operand);


        private sealed class Emit_Jmp : StatelessOperation<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Jmp;
            internal Emit_Jmp(MethodInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Cpobj(Type operand)
            => new Emit_Cpobj(operand);


        private sealed class Emit_Cpobj : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Cpobj;
            internal Emit_Cpobj(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldobj(Type operand)
            => new Emit_Ldobj(operand);


        private sealed class Emit_Ldobj : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Ldobj;
            internal Emit_Ldobj(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldstr(string operand)
            => new Emit_Ldstr(operand);


        private sealed class Emit_Ldstr : StatelessOperation<string>
        {
            public override OpCode OpCode => OpCodes.Ldstr;
            internal Emit_Ldstr(string operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Castclass(Type operand)
            => new Emit_Castclass(operand);


        private sealed class Emit_Castclass : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Castclass;
            internal Emit_Castclass(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Isinst(Type operand)
            => new Emit_Isinst(operand);


        private sealed class Emit_Isinst : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Isinst;
            internal Emit_Isinst(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Unbox(Type operand)
            => new Emit_Unbox(operand);


        private sealed class Emit_Unbox : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Unbox;
            internal Emit_Unbox(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldfld(FieldInfo operand)
            => new Emit_Ldfld(operand);


        private sealed class Emit_Ldfld : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldfld;
            internal Emit_Ldfld(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldflda(FieldInfo operand)
            => new Emit_Ldflda(operand);


        private sealed class Emit_Ldflda : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldflda;
            internal Emit_Ldflda(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stfld(FieldInfo operand)
            => new Emit_Stfld(operand);


        private sealed class Emit_Stfld : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Stfld;
            internal Emit_Stfld(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldsfld(FieldInfo operand)
            => new Emit_Ldsfld(operand);


        private sealed class Emit_Ldsfld : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldsfld;
            internal Emit_Ldsfld(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldsflda(FieldInfo operand)
            => new Emit_Ldsflda(operand);


        private sealed class Emit_Ldsflda : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Ldsflda;
            internal Emit_Ldsflda(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stsfld(FieldInfo operand)
            => new Emit_Stsfld(operand);


        private sealed class Emit_Stsfld : StatelessOperation<FieldInfo>
        {
            public override OpCode OpCode => OpCodes.Stsfld;
            internal Emit_Stsfld(FieldInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stobj(Type operand)
            => new Emit_Stobj(operand);


        private sealed class Emit_Stobj : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Stobj;
            internal Emit_Stobj(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Box(Type operand)
            => new Emit_Box(operand);


        private sealed class Emit_Box : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Box;
            internal Emit_Box(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Newarr(Type operand)
            => new Emit_Newarr(operand);


        private sealed class Emit_Newarr : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Newarr;
            internal Emit_Newarr(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldelema(Type operand)
            => new Emit_Ldelema(operand);


        private sealed class Emit_Ldelema : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Ldelema;
            internal Emit_Ldelema(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldelem(Type operand)
            => new Emit_Ldelem(operand);


        private sealed class Emit_Ldelem : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Ldelem;
            internal Emit_Ldelem(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stelem(Type operand)
            => new Emit_Stelem(operand);


        private sealed class Emit_Stelem : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Stelem;
            internal Emit_Stelem(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Unbox_Any(Type operand)
            => new Emit_Unbox_Any(operand);


        private sealed class Emit_Unbox_Any : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Unbox_Any;
            internal Emit_Unbox_Any(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Refanyval(Type operand)
            => new Emit_Refanyval(operand);


        private sealed class Emit_Refanyval : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Refanyval;
            internal Emit_Refanyval(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Mkrefany(Type operand)
            => new Emit_Mkrefany(operand);


        private sealed class Emit_Mkrefany : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Mkrefany;
            internal Emit_Mkrefany(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldftn(MethodInfo operand)
            => new Emit_Ldftn(operand);


        private sealed class Emit_Ldftn : StatelessOperation<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Ldftn;
            internal Emit_Ldftn(MethodInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldvirtftn(MethodInfo operand)
            => new Emit_Ldvirtftn(operand);


        private sealed class Emit_Ldvirtftn : StatelessOperation<MethodInfo>
        {
            public override OpCode OpCode => OpCodes.Ldvirtftn;
            internal Emit_Ldvirtftn(MethodInfo operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldarg(short operand)
            => new Emit_Ldarg(operand);


        private sealed class Emit_Ldarg : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Ldarg;
            internal Emit_Ldarg(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldarga(short operand)
            => new Emit_Ldarga(operand);


        private sealed class Emit_Ldarga : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Ldarga;
            internal Emit_Ldarga(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Starg(short operand)
            => new Emit_Starg(operand);


        private sealed class Emit_Starg : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Starg;
            internal Emit_Starg(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldloc(short operand)
            => new Emit_Ldloc(operand);


        private sealed class Emit_Ldloc : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Ldloc;
            internal Emit_Ldloc(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Ldloca(short operand)
            => new Emit_Ldloca(operand);


        private sealed class Emit_Ldloca : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Ldloca;
            internal Emit_Ldloca(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Stloc(short operand)
            => new Emit_Stloc(operand);


        private sealed class Emit_Stloc : StatelessOperation<short>
        {
            public override OpCode OpCode => OpCodes.Stloc;
            internal Emit_Stloc(short operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Initobj(Type operand)
            => new Emit_Initobj(operand);


        private sealed class Emit_Initobj : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Initobj;
            internal Emit_Initobj(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Unaligned(byte operand)
            => new Emit_Unaligned(operand);


        private sealed class Emit_Unaligned : StatelessOperation<byte>
        {
            public override OpCode OpCode => OpCodes.Unaligned;
            internal Emit_Unaligned(byte operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Constrained(Type operand)
            => new Emit_Constrained(operand);


        private sealed class Emit_Constrained : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Constrained;
            internal Emit_Constrained(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

        [CLSCompliant(true)]
        public static IILStreamOpCode Sizeof(Type operand)
            => new Emit_Sizeof(operand);


        private sealed class Emit_Sizeof : StatelessOperation<Type>
        {
            public override OpCode OpCode => OpCodes.Sizeof;
            internal Emit_Sizeof(Type operand) : base(operand) {}

            public override void Emit(ILGeneratorState state)
                => state.Generator.Emit(OpCode, Operand);
        }

    }
}
