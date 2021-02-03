using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerEmit
{
    public interface IStackValue
    {
        IStackType StackType { get; }
        object? ObjectValue { get; }
        IMaybe<object?> TryToAssignable(Type variableType);
        IMaybe<object?> TryToAssignable(VariableDescriptor variableDescriptor);
        object? ToAssignable(Type variableType);
        object? ToAssignable(VariableDescriptor variableDescriptor);
    }


    public abstract class StackValue : IStackValue
    {
        public interface IInt32 : IStackValue
        {
            int Value { get; }
        }
        private sealed class _Int32 : StackValue, IInt32
        {
            public override IStackType StackType => PowerEmit.StackType.Int32;
            public override object? ObjectValue => Value;
            public int Value { get; }

            internal _Int32(int value) => Value = value;

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(sbyte) ) return Maybe.Just<object>((sbyte) Value);
                else if(variableType == typeof(short) ) return Maybe.Just<object>((short) Value);
                else if(variableType == typeof(int)   ) return Maybe.Just<object>((int)   Value);
                else if(variableType == typeof(byte)  ) return Maybe.Just<object>((byte)  Value);
                else if(variableType == typeof(ushort)) return Maybe.Just<object>((ushort)Value);
                else if(variableType == typeof(uint)  ) return Maybe.Just<object>((uint)  Value);
                else if(variableType == typeof(bool)  ) return Maybe.Just<object>(    Value > 0);
                else if(variableType == typeof(char)  ) return Maybe.Just<object>((char)  Value);
                return Maybe.None<object?>();
            }
        }
        public static IInt32 Int32(int value) => new _Int32(value);
        [CLSCompliant(false)]  public static IInt32 Int32(uint value) => new _Int32((int)value);


        public interface IInt64 : IStackValue
        {
            long Value { get; }
        }
        private sealed class _Int64 : StackValue, IInt64
        {
            public override IStackType StackType => PowerEmit.StackType.Int64;
            public override object? ObjectValue => Value;
            public long Value { get; }

            internal _Int64(long value) => Value = value;
        
            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(long))  return Maybe.Just<object>((long) Value);
                else if(variableType == typeof(ulong)) return Maybe.Just<object>((ulong)Value);
                return Maybe.None<object?>();
            }
        }
        public static IInt64 Int64(long value) => new _Int64(value);
        [CLSCompliant(false)] public static IInt64 Int64(ulong value) => new _Int64((long)value);


        public interface INativeInt : IStackValue
        {
            nint Value { get; }
        }
        private sealed class _NativeInt : StackValue, INativeInt
        {
            public override IStackType StackType => PowerEmit.StackType.NativeInt;
            public override object? ObjectValue => Value;
            public nint Value { get; }

            internal _NativeInt(nint value) => Value = value;

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(nint) ) return Maybe.Just<object>((nint) Value);
                else if(variableType == typeof(nuint)) return Maybe.Just<object>((nuint)Value);
                return Maybe.None<object?>();
            }
        }
        public static INativeInt NativeInt(nint value) => new _NativeInt(value);
        [CLSCompliant(false)] public static INativeInt NativeInt(nuint value) => new _NativeInt((nint)value);


        public interface IFloat : IStackValue
        {
            double Value { get; }
        }
        private sealed class _Float : StackValue, IFloat
        {
            public override IStackType StackType => PowerEmit.StackType.Float;
            public override object? ObjectValue => Value;
            public double Value { get; }

            internal _Float(double value) => Value = value;

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(float))  return Maybe.Just<object>((float) Value);
                else if(variableType == typeof(double)) return Maybe.Just<object>((double)Value);
                return Maybe.None<object?>();
            }
        }
        public static IFloat Float(double value) => new _Float(value);


        public interface IObj : IStackValue
        {
            object? Value { get; }
        }
        private sealed class _Obj : StackValue, IObj
        {
            public override IStackType StackType { get; }
            public override object? ObjectValue => Value;
            public object? Value { get; }

            internal _Obj(object? value)
            {
                StackType = PowerEmit.StackType.Obj(value?.GetType());
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if(variableType.IsNullableAssignableFrom(Value?.GetType()))
                    return Maybe.Just(Value);
                return Maybe.None<object?>();
            }
        }
        public static IObj Obj(object? value) => new _Obj(value);


        public interface IManagedPtr : IStackValue
        {
            ManagedPtrValue Value { get; }
        }
        private sealed class _ManagedPtr : StackValue, IManagedPtr
        {
            public override IStackType StackType => PowerEmit.StackType.ManagedPtr;
            public override object? ObjectValue => Value;
            public ManagedPtrValue Value { get; }

            internal _ManagedPtr(ManagedPtrValue value)
            {
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                return Maybe.Just(Value);
            }
        }
        public static IManagedPtr ManagedPtr(ManagedPtrValue value) => new _ManagedPtr(value);


        public interface ITransientPtr : IStackValue
        {
            ManagedPtrValue Value { get; } 
        }
        private sealed class _TransientPtr : StackValue, ITransientPtr
        {
            public override IStackType StackType => PowerEmit.StackType.TransientPtr;
            public override object? ObjectValue => Value;
            public ManagedPtrValue Value { get; }

            internal _TransientPtr(ManagedPtrValue value)
            {
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                return Maybe.Just(Value);
            }
        }
        public static ITransientPtr TransientPtr(ManagedPtrValue value) => new _TransientPtr(value);


        public interface IUserValue : IStackValue
        {
            object? Value { get; }
        }
        private sealed class _UserValue : StackValue, IUserValue
        {
            public override IStackType StackType { get; }
            public override object? ObjectValue => Value;
            public object? Value { get; }

            internal _UserValue(object value)
            {
                StackType = PowerEmit.StackType.UserValue(value.GetType());
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if(variableType.IsNullableAssignableFrom(Value?.GetType()))
                    return Maybe.Just(Value);
                return Maybe.None<object?>();
            }
        }
        public static IUserValue UserValue(object value) => new _UserValue(value);


        public abstract IStackType StackType { get; }
        public abstract object? ObjectValue { get; }
        public abstract IMaybe<object?> TryToAssignable(Type variableType);
        public IMaybe<object?> TryToAssignable(VariableDescriptor variableDescriptor)
            => TryToAssignable(variableDescriptor.VariableType);
        public object? ToAssignable(Type variableType)
            => TryToAssignable(variableType) is IJust<object?> just ? just.Value : throw new InvalidCastException();
        public object? ToAssignable(VariableDescriptor variableDescriptor)
            => TryToAssignable(variableDescriptor) is IJust<object?> just ? just.Value : throw new InvalidCastException();


        public static IStackValue FromValue(object? value)
            => unchecked(value switch
            {
                bool   x => Int32(x ? 1 : 0),
                sbyte  x => Int32((int)x),
                short  x => Int32((int)x),
                int    x => Int32((int)x),
                byte   x => Int32((int)x),
                ushort x => Int32((int)x),
                uint   x => Int32((int)x),
                char   x => Int32((int)x),

                long  x => Int64((long)x),
                ulong x => Int64((long)x),

                nint  x => NativeInt((nint)x),
                nuint x => NativeInt((nint)x),

                _ => Obj(value),
            });


        public static bool Equals(IStackValue x, IStackValue y)
        {
            return (x, y) switch
            {
                (IInt32      xx, IInt32      yy) => xx.Value == yy.Value,
                (IInt32      xx, INativeInt  yy) => xx.Value == yy.Value,
                (IInt64      xx, IInt64      yy) => xx.Value == yy.Value,
                (INativeInt  xx, IInt32      yy) => xx.Value == yy.Value,
                (INativeInt  xx, INativeInt  yy) => xx.Value == yy.Value,
                (INativeInt  xx, IManagedPtr yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (IFloat      xx, IFloat      yy) => xx.Value == yy.Value,
                (IManagedPtr xx, INativeInt  yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (IManagedPtr xx, IManagedPtr yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (IObj        xx, IObj        yy) => ReferenceEquals(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static bool Equals(IStackValue[] values)
            => Equals(values[1], values[0]);


        public static int Compare(IStackValue x, IStackValue y)
        {
            return (x, y) switch
            {
                (IInt32      xx, IInt32      yy) => Comparer<int>   .Default.Compare(xx.Value, yy.Value),
                (IInt32      xx, INativeInt  yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (IInt64      xx, IInt64      yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (INativeInt  xx, IInt32      yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (INativeInt  xx, INativeInt  yy) => Comparer<nint>  .Default.Compare((nint)xx.Value, (nint)yy.Value),
                (IFloat      xx, IFloat      yy) => Comparer<double>.Default.Compare(xx.Value, yy.Value),
                (IManagedPtr xx, IManagedPtr yy) => ManagedPtrValue.Compare(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static int Compare(IStackValue[] values)
            => Compare(values[1], values[0]);


        public static int Compare_Un(IStackValue x, IStackValue y)
        {
            return (x, y) switch
            {
#warning not implemented
                (IInt32       xx, IInt32        yy) => Comparer<uint> .Default.Compare((uint) xx.Value, (uint) yy.Value),
                (IInt32       xx, INativeInt    yy) => Comparer<ulong>.Default.Compare((ulong)xx.Value, (ulong)yy.Value),
                (IInt64       xx, IInt64        yy) => Comparer<ulong>.Default.Compare((ulong)xx.Value, (ulong)yy.Value),
                (INativeInt   xx, IInt32        yy) => Comparer<ulong>.Default.Compare((nuint)xx.Value, (uint) yy.Value),
                (INativeInt   xx, INativeInt    yy) => Comparer<nuint>.Default.Compare((nuint)xx.Value, (nuint)yy.Value),
                (IFloat       xx, IFloat        yy) => Comparer<double>.Default.Compare(xx.Value, yy.Value),
                (IManagedPtr  xx, IManagedPtr   yy) => ManagedPtrValue.CompareUnsigned(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static int Compare_Un(IStackValue[] values)
            => Compare_Un(values[1], values[0]);
    }
}
