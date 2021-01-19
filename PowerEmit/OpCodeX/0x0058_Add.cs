using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace PowerEmit
{
    partial class OpCodeX
    {
        /// <summary> Creates new instruction item of <c>add</c>. </summary>
        /// <returns></returns>
        public static IILStreamInstruction Add()
            => new Emit_Add();


        private sealed class Emit_Add : ILStreamInstruction
        {
            public override OpCode OpCode => OpCodes.Add;

            public Emit_Add()
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
                    (StackType.Int32      , StackType.Int32      ) => StackType.Int32      .Instance,
                    (StackType.Int32      , StackType.NativeInt  ) => StackType.NativeInt  .Instance,
                    (StackType.Int32      , StackType.ManagedPtr  ) => StackType.ManagedPtr  .Instance,
                    (StackType.Int64      , StackType.Int64      ) => StackType.Int64      .Instance,
                    (StackType.NativeInt  , StackType.Int32      ) => StackType.NativeInt  .Instance,
                    (StackType.NativeInt  , StackType.NativeInt  ) => StackType.NativeInt  .Instance,
                    (StackType.NativeInt  , StackType.ManagedPtr  ) => StackType.ManagedPtr  .Instance,
                    (StackType.F, StackType.F) => StackType.F.Instance,
                    (StackType.ManagedPtr  , StackType.Int32      ) => StackType.ManagedPtr  .Instance,
                    (StackType.ManagedPtr  , StackType.NativeInt  ) => StackType.ManagedPtr  .Instance,
                    _ => throw new Exception(),
                };
                state.EvaluationStack.Push(resultType);
            }

            public override void Invoke(IILInvocationState state)
            {
                unchecked
                {
                    var values = state.EvaluationStack.Pop(2);
                    var resultValue = (values[1], values[0]) switch
                    {
                        (StackValue.Int32       x, StackValue.Int32       y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.Int32       x, StackValue.NativeInt   y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.Int32       x, StackValue.ManagedPtr   y) => StackValue.FromValue(ManagedPtrValue.Add(x.Value, y.Value)),
                        (StackValue.Int64       x, StackValue.Int64       y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.NativeInt   x, StackValue.Int32       y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.NativeInt   x, StackValue.NativeInt   y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.NativeInt   x, StackValue.ManagedPtr   y) => StackValue.FromValue(ManagedPtrValue.Add(x.Value, y.Value)),
                        (StackValue.F x, StackValue.F y) => StackValue.FromValue(x.Value + y.Value),
                        (StackValue.ManagedPtr   x, StackValue.Int32       y) => StackValue.FromValue(ManagedPtrValue.Add(x.Value, y.Value)),
                        (StackValue.ManagedPtr   x, StackValue.NativeInt   y) => StackValue.FromValue(ManagedPtrValue.Add(x.Value, y.Value)),
                        _ => throw new Exception(),
                    };
                    state.EvaluationStack.Push(resultValue);
                }
            }
        }
    }
}
