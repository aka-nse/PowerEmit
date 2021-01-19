using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerEmit
{
    public abstract class StackValue
    {
        public sealed class Int32 : StackValue
        {
            public override StackType StackType => StackType.Int32.Instance;
            public override object? ObjectValue => Value;
            public int Value { get; }

            internal Int32(int value) => Value = value;

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


        public sealed class Int64 : StackValue
        {
            public override StackType StackType => StackType.Int64.Instance;
            public override object? ObjectValue => Value;
            public long Value { get; }

            internal Int64(long value) => Value = value;
        
            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(long))  return Maybe.Just<object>((long) Value);
                else if(variableType == typeof(ulong)) return Maybe.Just<object>((ulong)Value);
                return Maybe.None<object?>();
            }
        }


        public sealed class NativeInt : StackValue
        {
            public override StackType StackType => StackType.NativeInt.Instance;
            public override object? ObjectValue => Value;
            public nint Value { get; }

            internal NativeInt(nint value) => Value = value;

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(nint) ) return Maybe.Just<object>((nint) Value);
                else if(variableType == typeof(nuint)) return Maybe.Just<object>((nuint)Value);
                return Maybe.None<object?>();
            }
        }


        public sealed class F : StackValue
        {
            public override StackType StackType => StackType.F.Instance;
            public override object? ObjectValue => Value;
            public double Value { get; }

            internal F(double value) => Value = value;

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if     (variableType == typeof(float))  return Maybe.Just<object>((float) Value);
                else if(variableType == typeof(double)) return Maybe.Just<object>((double)Value);
                return Maybe.None<object?>();
            }
        }


        public sealed class O : StackValue
        {
            public override StackType StackType { get; }
            public override object? ObjectValue => Value;
            public object? Value { get; }

            internal O(object? value)
            {
                StackType = new StackType.O(value?.GetType());
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if(variableType.IsNullableAssignableFrom(Value?.GetType()))
                    return Maybe.Just(Value);
                return Maybe.None<object?>();
            }
        }


        public sealed class ManagedPtr : StackValue
        {
            public override StackType StackType => StackType.ManagedPtr.Instance;
            public override object? ObjectValue => Value;
            public PowerEmit.ManagedPtrValue Value { get; }

            internal ManagedPtr(PowerEmit.ManagedPtrValue value)
            {
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                return Maybe.Just(Value);
            }
        }


        public sealed class TransientPtr : StackValue
        {
            public override StackType StackType => StackType.TransientPtr.Instance;
            public override object? ObjectValue => Value;
            public PowerEmit.ManagedPtrValue Value { get; }

            internal TransientPtr(PowerEmit.ManagedPtrValue value)
            {
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                return Maybe.Just(Value);
            }
        }


        public sealed class UDValueType : StackValue
        {
            public override StackType StackType { get; }
            public override object? ObjectValue => Value;
            public object? Value { get; }

            internal UDValueType(object value)
            {
                StackType = new StackType.UDValueType(value.GetType());
                Value = value;
            }

            public override IMaybe<object?> TryToAssignable(Type variableType)
            {
                if(variableType.IsNullableAssignableFrom(Value?.GetType()))
                    return Maybe.Just(Value);
                return Maybe.None<object?>();
            }
        }


        public abstract StackType StackType { get; }
        public abstract object? ObjectValue { get; }
        public abstract IMaybe<object?> TryToAssignable(Type variableType);
        public IMaybe<object?> TryToAssignable(VariableDescriptor variableDescriptor)
            => TryToAssignable(variableDescriptor.VariableType);
        public object? ToAssignable(Type variableType)
            => TryToAssignable(variableType) is IJust<object?> just ? just.Value : throw new InvalidCastException();
        public object? ToAssignable(VariableDescriptor variableDescriptor)
            => TryToAssignable(variableDescriptor) is IJust<object?> just ? just.Value : throw new InvalidCastException();


        public static StackValue FromValue(object? value)
            => unchecked(value switch
            {
                bool   x => new Int32(x ? 1 : 0),
                sbyte  x => new Int32((int)x),
                short  x => new Int32((int)x),
                int    x => new Int32((int)x),
                byte   x => new Int32((int)x),
                ushort x => new Int32((int)x),
                uint   x => new Int32((int)x),
                char   x => new Int32((int)x),

                long  x => new Int64((long)x),
                ulong x => new Int64((long)x),

                nint  x => new NativeInt((nint)x),
                nuint x => new NativeInt((nint)x),

                _ => new O(value),
            });


        public static bool Equals(StackValue x, StackValue y)
        {
            return (x, y) switch
            {
                (Int32      xx, Int32      yy) => xx.Value == yy.Value,
                (Int32      xx, NativeInt  yy) => xx.Value == yy.Value,
                (Int64      xx, Int64      yy) => xx.Value == yy.Value,
                (NativeInt  xx, Int32      yy) => xx.Value == yy.Value,
                (NativeInt  xx, NativeInt  yy) => xx.Value == yy.Value,
                (NativeInt  xx, ManagedPtr yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (F          xx, F          yy) => xx.Value == yy.Value,
                (ManagedPtr xx, NativeInt  yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (ManagedPtr xx, ManagedPtr yy) => ManagedPtrValue.Equals(xx.Value, yy.Value),
                (O          xx, O          yy) => ReferenceEquals(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static bool Equals(StackValue[] values)
            => Equals(values[1], values[0]);


        public static int Compare(StackValue x, StackValue y)
        {
            return (x, y) switch
            {
                (Int32      xx, Int32      yy) => Comparer<int>   .Default.Compare(xx.Value, yy.Value),
                (Int32      xx, NativeInt  yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (Int64      xx, Int64      yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (NativeInt  xx, Int32      yy) => Comparer<long>  .Default.Compare(xx.Value, yy.Value),
                (NativeInt  xx, NativeInt  yy) => Comparer<nint>  .Default.Compare((nint)xx.Value, (nint)yy.Value),
                (F          xx, F          yy) => Comparer<double>.Default.Compare(xx.Value, yy.Value),
                (ManagedPtr xx, ManagedPtr yy) => ManagedPtrValue.Compare(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static int Compare(StackValue[] values)
            => Compare(values[1], values[0]);


        public static int Compare_Un(StackValue x, StackValue y)
        {
            return (x, y) switch
            {
#warning not implemented
                (Int32       xx, Int32        yy) => Comparer<uint> .Default.Compare((uint) xx.Value, (uint) yy.Value),
                (Int32       xx, NativeInt    yy) => Comparer<ulong>.Default.Compare((ulong)xx.Value, (ulong)yy.Value),
                (Int64       xx, Int64        yy) => Comparer<ulong>.Default.Compare((ulong)xx.Value, (ulong)yy.Value),
                (NativeInt   xx, Int32        yy) => Comparer<ulong>.Default.Compare((nuint)xx.Value, (uint) yy.Value),
                (NativeInt   xx, NativeInt    yy) => Comparer<nuint>.Default.Compare((nuint)xx.Value, (nuint)yy.Value),
                (F           xx, F            yy) => Comparer<double>.Default.Compare(xx.Value, yy.Value),
                (ManagedPtr  xx, ManagedPtr   yy) => ManagedPtrValue.CompareUnsigned(xx.Value, yy.Value),
                _ => throw new InvalidOperationException(),
            };
        }
        public static int Compare_Un(StackValue[] values)
            => Compare_Un(values[1], values[0]);
    }
}
