using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace PowerEmit
{
    public class Call : ICilOperation
    {
        public OpCode OpCode => OpCodes.Call;

        public MethodInfo Operand { get; }

        public int ByteSize => 5;
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance
            => Operand.GetParameters().Length
             + (Operand.ReturnType == typeof(void) ? 0 : -1);
        int? ICilGeneratorAction.StackBalance => StackBalance;

        internal Call(MethodInfo operand)
        {
            Operand = operand;
        }

        public void Emit(CilGeneratorState state) => state.Generator.Emit(OpCode, Operand);
        public int GetByteSize(CilGeneratorState state) => ByteSize;
        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }


    public class Callvirt : ICilOperation
    {
        public OpCode OpCode => OpCodes.Callvirt;

        public MethodInfo Operand { get; set; }

        public int ByteSize => 5;
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance
            => Operand.GetParameters().Length
             + (Operand.ReturnType == typeof(void) ? 0 : -1);
        int? ICilGeneratorAction.StackBalance => StackBalance;


        internal Callvirt(MethodInfo operand)
        {
            Operand = operand;
        }


        public void Emit(CilGeneratorState state) => state.Generator.Emit(OpCode, Operand);
        public int GetByteSize(CilGeneratorState state) => ByteSize;
        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }


    public class Newobj : ICilOperation
    {
        public OpCode OpCode => OpCodes.Newobj;

        public ConstructorInfo Operand { get; set; }

        public int ByteSize => 5;
        int? ICilGeneratorAction.ByteSize => ByteSize;

        public int StackBalance
            => Operand.GetParameters().Length - 1;
        int? ICilGeneratorAction.StackBalance => StackBalance;


        internal Newobj(ConstructorInfo operand)
        {
            Operand = operand;
        }


        public void Emit(CilGeneratorState state) => state.Generator.Emit(OpCode, Operand);
        public int GetByteSize(CilGeneratorState state) => ByteSize;
        public int GetStackBalance(CilGeneratorState state) => StackBalance;
    }
}
