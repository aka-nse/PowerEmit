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

    }
}
