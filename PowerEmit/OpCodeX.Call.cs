using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    partial class OpCodeX
    {
        public static IILStreamOpCode Call(MethodInfo operand)
            => new Emit_Call(operand);


        private class Emit_Call : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Call;

            public MethodInfo Operand { get; }

            public int ByteSize => 5;
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance
                => Operand.GetParameters().Length
                 + (Operand.ReturnType == typeof(void) ? 0 : -1);
            int? IILStreamAction.StackBalance => StackBalance;

            internal Emit_Call(MethodInfo operand)
            {
                Operand = operand;
            }

            public void Emit(ILGeneratorState state) => state.Generator.Emit(OpCode, Operand);
            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }


        public static IILStreamOpCode Callvirt(MethodInfo operand)
            => new Emit_Callvirt(operand);


        private class Emit_Callvirt : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Callvirt;

            public MethodInfo Operand { get; set; }

            public int ByteSize => 5;
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance
                => Operand.GetParameters().Length
                 + (Operand.ReturnType == typeof(void) ? 0 : -1);
            int? IILStreamAction.StackBalance => StackBalance;


            internal Emit_Callvirt(MethodInfo operand)
            {
                Operand = operand;
            }


            public void Emit(ILGeneratorState state) => state.Generator.Emit(OpCode, Operand);
            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }


        public static IILStreamOpCode Newobj(ConstructorInfo operand)
            => new Emit_Newobj(operand);


        private sealed class Emit_Newobj : IILStreamOpCode
        {
            public OpCode OpCode => OpCodes.Newobj;

            public ConstructorInfo Operand { get; set; }

            public int ByteSize => 5;
            int? IILStreamAction.ByteSize => ByteSize;

            public int StackBalance
                => Operand.GetParameters().Length - 1;
            int? IILStreamAction.StackBalance => StackBalance;


            internal Emit_Newobj(ConstructorInfo operand)
            {
                Operand = operand;
            }


            public void Emit(ILGeneratorState state) => state.Generator.Emit(OpCode, Operand);
            public int GetByteSize(ILGeneratorState state) => ByteSize;
            public int GetStackBalance(ILGeneratorState state) => StackBalance;
        }
    }
}