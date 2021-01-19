using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>ldelem.i2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Ldelem_I2()
            => new Emit_Ldelem_I2();


        private sealed class Emit_Ldelem_I2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Ldelem_I2;

            public Emit_Ldelem_I2()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                throw new NotImplementedException();
            }

            public override void Invoke(IILInvocationState state)
            {
                throw new NotImplementedException();
            }
        }
    }
}
