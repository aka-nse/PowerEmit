using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace PowerEmit
{
    [Flags]
    public enum PassByKind
    {
        Value = 0b01,
        Reference = 0b10,
        Instance = 0b11,
    }


    public interface IStackType
    {
        bool IsAssignableTo(Type variableType, PassByKind passByKind);
        bool IsAssignableTo(VariableDescriptor variableDescriptor);
    }


    /// <summary>
    /// Expresses types of element in the evaluation stack.
    /// See <a href="https://www.ecma-international.org/wp-content/uploads/ECMA-335_5th_edition_december_2010.pdf">ECMA-335 5th edition</a>
    /// section 12.3.2.1 The evaluation stack.
    /// </summary>
    public abstract class StackType : IStackType
    {
        public interface IThis : IStackType { }
        public interface IValue : IStackType { }

        public interface IInt32 : IValue { }
        private sealed class _Int32 : StackType, IInt32
        {
            public static _Int32 Instance { get; } = new _Int32();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
            {
                if(!passByKind.HasFlag(PassByKind.Value))
                    return false;

                if(variableType == typeof(sbyte))  return true;
                if(variableType == typeof(short))  return true;
                if(variableType == typeof(int))    return true;
                if(variableType == typeof(byte))   return true;
                if(variableType == typeof(ushort)) return true;
                if(variableType == typeof(uint))   return true;
                if(variableType == typeof(bool))   return true;
                if(variableType == typeof(char))   return true;
                return false;
            }
            private _Int32() { }
        }
        public static IInt32 Int32 => _Int32.Instance;


        public interface IInt64 : IValue { }
        private sealed class _Int64 : StackType, IInt64
        {
            public static _Int64 Instance { get; } = new _Int64();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
            {
                if(!passByKind.HasFlag(PassByKind.Value))
                    return false;

                if(variableType == typeof(long)) return true;
                if(variableType == typeof(ulong)) return true;
                return false;
            }
            private _Int64() { }
        }
        public static IInt64 Int64 => _Int64.Instance;


        public interface INativeInt : IValue, IThis { }
        private sealed class _NativeInt : StackType, INativeInt
        {
            public static _NativeInt Instance { get; } = new _NativeInt();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
            {
                if(variableType == typeof(nint)) return true;
                if(variableType == typeof(nuint)) return true;
                return false;
            }
            private _NativeInt() { }
        }
        public static INativeInt NativeInt => _NativeInt.Instance;


        public interface IFloat : IValue { }
        private sealed class _Float : StackType, IFloat
        {
            internal static _Float Instance { get; } = new _Float();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
            {
                if(!passByKind.HasFlag(PassByKind.Value))
                    return false;

                if(variableType == typeof(float)) return true;
                if(variableType == typeof(double)) return true;
                return false;
            }
            private _Float() { }
        }
        public static IFloat Float => _Float.Instance;


        public interface IObj : IThis, IValue
        {
            Type? Type { get; }
        }
        private sealed class _Obj : StackType, IObj
        {
            public Type? Type { get; }
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind) => variableType.IsNullableAssignableFrom(Type);
            internal _Obj(Type? type) => Type = type;
        }
        public static IObj Obj(Type? type) => new _Obj(type);


        public interface IManagedPtr : IThis { }
        private sealed class _ManagedPtr : StackType, IManagedPtr
        {
            public static _ManagedPtr Instance { get; } = new _ManagedPtr();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind) => true;
            internal _ManagedPtr()
            {
            }
        }
        public static IManagedPtr ManagedPtr => _ManagedPtr.Instance;


        public interface ITransientPtr : INativeInt, IManagedPtr { }
        private sealed class _TransientPtr : StackType, ITransientPtr
        {
            public static _TransientPtr Instance { get; } = new _TransientPtr();
            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
                => passByKind.HasFlag(PassByKind.Reference);
            private _TransientPtr() { }
        }
        public static ITransientPtr TransientPtr => _TransientPtr.Instance;


        public interface IUserValue : IValue
        {
            int DataSize { get; }
        }
        private sealed class _UserValue : StackType, IUserValue
        {
            private static readonly object _token = new object();
            private static readonly MethodInfo _sizeOf = typeof(Unsafe).GetMethod(nameof(Unsafe.SizeOf));
            private static Dictionary<Type, int> _dataSizes = new Dictionary<Type, int>();

            private static int GetDataSize(Type type)
            {
                var dataSizes = _dataSizes;
                if(dataSizes.TryGetValue(type, out var value))
                    return value;
                lock(_token)
                {
                    if(dataSizes.TryGetValue(type, out value))
                        return value;
                    value = (int)_sizeOf.MakeGenericMethod(type).Invoke(null, Array.Empty<object>());
                    dataSizes = new Dictionary<Type, int>(dataSizes);
                    dataSizes.Add(type, value);
                    _dataSizes = dataSizes;
                    return value;
                }
            }

            public int DataSize { get; }

            public override bool IsAssignableTo(Type variableType, PassByKind passByKind)
                => passByKind.HasFlag(PassByKind.Value) && GetDataSize(variableType) == DataSize;

            internal _UserValue(Type type) => DataSize = GetDataSize(type);
        }
        public static IUserValue UserValue(Type type) => new _UserValue(type);


        private static readonly Type[] _int32Types = new[]
        {
            typeof(sbyte),
            typeof(short),
            typeof(int),
            typeof(byte),
            typeof(ushort),
            typeof(uint),
            typeof(bool),
            typeof(char),
        };
        private static readonly Type[] _int64Types = new[]
        {
            typeof(long),
            typeof(ulong),
        };
        private static readonly Type[] _nativeIntTypes = new[]
        {
            typeof(nint),
            typeof(nuint),
        };
        private static readonly Type[] _nativeFloatTypes = new[]
        {
            typeof(float),
            typeof(double),
        };


        public abstract bool IsAssignableTo(Type variableType, PassByKind passByKind);
        public bool IsAssignableTo(VariableDescriptor variableDescriptor)
            => IsAssignableTo(variableDescriptor.VariableType, PassByKind.Value);

        private StackType() { }


        public static IStackType FromType(Type? type)
        {
            if(type is null)
                return Obj(type);
            if(Array.IndexOf(_int32Types, type) >= 0)
                return Int32;
            if(Array.IndexOf(_int64Types, type) >= 0)
                return Int64;
            if(Array.IndexOf(_nativeIntTypes, type) >= 0)
                return NativeInt;
            if(Array.IndexOf(_nativeFloatTypes, type) >= 0)
                return Float;
            if(type.IsValueType)
                return UserValue(type);
            if(type.IsByRef)
                return ManagedPtr;
            if(type.IsPointer)
                return TransientPtr;
            return Obj(type);
        }

        public static bool AreEquatable(IStackType x, IStackType y)
            => (x, y) switch
            {
                (IInt32     , IInt32     ) => true,
                (IInt32     , INativeInt ) => true,
                (IInt64     , IInt64     ) => true,
                (INativeInt , IInt32     ) => true,
                (INativeInt , INativeInt ) => true,
                (INativeInt , IManagedPtr) => true,
                (IFloat     , IFloat     ) => true,
                (IManagedPtr, INativeInt ) => true,
                (IManagedPtr, IManagedPtr) => true,
                (IObj       , IObj       ) => true,
                _ => false,
            };


        public static bool AreOrderable(IStackType x, IStackType y)
            => (x, y) switch
            {
                (IInt32     , IInt32     ) => true,
                (IInt32     , INativeInt ) => true,
                (IInt64     , IInt64     ) => true,
                (INativeInt , IInt32     ) => true,
                (INativeInt , INativeInt ) => true,
                (IFloat     , IFloat     ) => true,
                (IManagedPtr, IManagedPtr) => true,
                _ => false,
            };


        public static bool AreEquatable(IStackType[] types)
            => types.Length == 2
               ? AreEquatable(types[1], types[0])
               : throw new ArgumentException();


        public static bool AreOrderable(IStackType[] types)
            => types.Length == 2
               ? AreOrderable(types[1], types[0])
               : throw new ArgumentException();
    }

}
