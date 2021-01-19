using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>sub.ovf.un</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Sub_Ovf_Un()
            => new Emit_Sub_Ovf_Un();


        private sealed class Emit_Sub_Ovf_Un : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Sub_Ovf_Un;

            public Emit_Sub_Ovf_Un()
            {
            }

            public override void Emit(IILEmissionState state)
            {
                state.Generator.Emit(OpCode);
            }

            public override void ValidateStack(IILValidationState state)
            {
                var types = state.EvaluationStack.Pop(2);
                StackType resultType = (types[1], types[0]) switch
                {
                    (StackType.Int32    , StackType.Int32    ) => StackType.Int32      .Instance,
                    (StackType.Int32    , StackType.NativeInt) => StackType.NativeInt  .Instance,
                    (StackType.Int64    , StackType.Int64    ) => StackType.Int64      .Instance,
                    (StackType.NativeInt, StackType.Int32    ) => StackType.NativeInt  .Instance,
                    (StackType.NativeInt, StackType.NativeInt) => StackType.NativeInt  .Instance,
                    (StackType.ManagedPtr, StackType.Int32    ) => StackType.ManagedPtr  .Instance,
                    (StackType.ManagedPtr, StackType.NativeInt) => StackType.ManagedPtr  .Instance,
                    (StackType.ManagedPtr, StackType.ManagedPtr) => StackType.NativeInt  .Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                checked
                {
                    var values = state.EvaluationStack.Pop(2);
                    var resultValue = (values[1], values[0]) switch
                    {
                        (StackValue.Int32     x, StackValue.Int32     y) => StackValue.FromValue((uint) x.Value - (uint) y.Value),
                        (StackValue.Int32     x, StackValue.NativeInt y) => StackValue.FromValue((uint) x.Value - (nuint)y.Value),
                        (StackValue.Int64     x, StackValue.Int64     y) => StackValue.FromValue((ulong)x.Value - (ulong)y.Value),
                        (StackValue.NativeInt x, StackValue.Int32     y) => StackValue.FromValue((nuint)x.Value - (uint) y.Value),
                        (StackValue.NativeInt x, StackValue.NativeInt y) => StackValue.FromValue((nuint)x.Value - (nuint)y.Value),
                        (StackValue.ManagedPtr x, StackValue.Int32     y) => StackValue.FromValue(ManagedPtrValue.Sub_Ovf_Un(x.Value, y.Value)),
                        (StackValue.ManagedPtr x, StackValue.NativeInt y) => StackValue.FromValue(ManagedPtrValue.Sub_Ovf_Un(x.Value, y.Value)),
                        (StackValue.ManagedPtr x, StackValue.ManagedPtr y) => StackValue.FromValue(ManagedPtrValue.Sub_Ovf_Un(x.Value, y.Value)),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
