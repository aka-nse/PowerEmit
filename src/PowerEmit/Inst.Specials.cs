using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    public partial struct Inst
    {
        /// <summary> Gets emitter to emit call. </summary>
        /// <param name="operand"> The operand to emit. </param>
        /// <returns> The built emitter. </returns>
        public static Inst<(MethodInfo methodInfo, Type[]? optionalParameterTypes)> Call(MethodInfo methodInfo, Type[]? optionalParameterTypes)
            => new Inst<(MethodInfo methodInfo, Type[]? optionalParameterTypes)>(
                OpCodes.Call,
                (methodInfo, optionalParameterTypes),
                (generator, opcode, operand) => generator.EmitCall(opcode, operand.methodInfo, optionalParameterTypes));


        /// <summary> Gets emitter to emit callvirt. </summary>
        /// <param name="operand"> The operand to emit. </param>
        /// <returns> The built emitter. </returns>
        public static Inst<(MethodInfo methodInfo, Type[]? optionalParameterTypes)> Callvirt(MethodInfo methodInfo, Type[]? optionalParameterTypes)
            => new Inst<(MethodInfo methodInfo, Type[]? optionalParameterTypes)>(
                OpCodes.Callvirt,
                (methodInfo, optionalParameterTypes),
                (generator, opcode, operand) => generator.EmitCall(opcode, operand.methodInfo, optionalParameterTypes));

        #region

        // NOTE:
        //     Following factories are place holders for ILDisassembler auto-generated code.
        //     They never do nothing, so do not call them.

        internal static Inst<ConstructorInfo> Jmp(ConstructorInfo operand)
            => throw new NotSupportedException();

        internal static Inst<ConstructorInfo> Callvirt(ConstructorInfo operand)
            => throw new NotSupportedException();

        internal static Inst<MethodInfo> Newobj(MethodInfo operand)
            => throw new NotSupportedException();

        internal static Inst<ConstructorInfo> Ldftn(ConstructorInfo operand)
            => throw new NotSupportedException();

        internal static Inst<ConstructorInfo> Ldvirtftn(ConstructorInfo operand)
            => throw new NotSupportedException();

        #endregion
    }
}