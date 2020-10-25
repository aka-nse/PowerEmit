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

        public Ldarg_Opt Push_Ldarg_Opt(CilArgument argument)
        {
            var result = new Ldarg_Opt(argument);
            _operations.Add(result);
            return result;
        }


        public Ldc_I4_Opt Push_Ldc_I4_Opt(int value)
        {
            var result = new Ldc_I4_Opt(value);
            _operations.Add(result);
            return result;
        }


        public Ldloc_Opt Push_Ldloc_Opt(CilLocal local)
        {
            var result = new Ldloc_Opt(local);
            _operations.Add(result);
            return result;
        }


        public Starg_Opt Push_Starg_Opt(CilArgument argument)
        {
            var result = new Starg_Opt(argument);
            _operations.Add(result);
            return result;
        }


        public Stloc_Opt Push_Stloc_Opt(CilLocal local)
        {
            var result = new Stloc_Opt(local);
            _operations.Add(result);
            return result;
        }


        public Br_Opt Push_Br_Opt(CilLabel label)
        {
            var result = new Br_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Brfalse_Opt Push_Brfalse_Opt(CilLabel label)
        {
            var result = new Brfalse_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Brtrue_Opt Push_Brtrue_Opt(CilLabel label)
        {
            var result = new Brtrue_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Beq_Opt Push_Beq_Opt(CilLabel label)
        {
            var result = new Beq_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Bge_Opt Push_Bge_Opt(CilLabel label)
        {
            var result = new Bge_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Bgt_Opt Push_Bgt_Opt(CilLabel label)
        {
            var result = new Bgt_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Ble_Opt Push_Ble_Opt(CilLabel label)
        {
            var result = new Ble_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Blt_Opt Push_Blt_Opt(CilLabel label)
        {
            var result = new Blt_Opt(label);
            _operations.Add(result);
            return result;
        }


        public Leave_Opt Push_Leave_Opt(CilLabel label)
        {
            var result = new Leave_Opt(label);
            _operations.Add(result);
            return result;
        }

    }
}
