using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>stelem.i2</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Stelem_I2()
            => new Emit_Stelem_I2();


        private sealed class Emit_Stelem_I2 : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Stelem_I2;

            public Emit_Stelem_I2()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                static bool isAssignable(Type arrayType, IStackType value)
                    => value switch
                    {
                        StackType.IInt32
                            => true,
                        StackType.IUserValue uValue when uValue.DataSize == 4
                            => true,
                        _ => false,
                    };

                Emit_Stelem.ValidateStack(state, isAssignable);
            }

            public override void Invoke(IILInvocationState state)
            {
                static object? getAssigningValue(Array array, StackValue value)
                    => throw new NotImplementedException();

                Emit_Stelem.Invoke(state, getAssigningValue);
            }
        }
    }
}
