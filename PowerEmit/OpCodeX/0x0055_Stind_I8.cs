using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stind.i8</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stind_I8()
            => new Emit_Stind_I8();


        private sealed class Emit_Stind_I8 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stind_I8;

            public Emit_Stind_I8()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
                => Emit_Stobj.ValidateStack(state, typeof(long));

            public override void Invoke(IILInvocationState state)
                => Emit_Stobj.Invoke(state, typeof(long));
        }
    }
}
