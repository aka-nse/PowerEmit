using System;
using System.Collections.Generic;
using System.Text;

namespace PowerEmit
{
    /// <summary>
    /// Expresses types of element in the evaluation stack.
    /// See <a href="https://www.ecma-international.org/wp-content/uploads/ECMA-335_5th_edition_december_2010.pdf">ECMA-335 5th edition</a>
    /// section 12.3.2.1 The evaluation stack.
    /// </summary>
    public abstract class StackType
    {
        public sealed class Int32 : StackType
        {
            internal static Int32 Instance { get; } = new Int32();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType)
            {
                if(variableType == typeof(sbyte)) return true;
                if(variableType == typeof(short)) return true;
                if(variableType == typeof(int)) return true;
                if(variableType == typeof(byte)) return true;
                if(variableType == typeof(ushort)) return true;
                if(variableType == typeof(uint)) return true;
                if(variableType == typeof(bool)) return true;
                if(variableType == typeof(char)) return true;
                return false;
            }
            private Int32() { }
        }


        public sealed class Int64 : StackType
        {
            internal static Int64 Instance { get; } = new Int64();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType)
            {
                if(variableType == typeof(long)) return true;
                if(variableType == typeof(ulong)) return true;
                return false;
            }
            private Int64() { }
        }


        public sealed class NativeInt : StackType
        {
            internal static NativeInt Instance { get; } = new NativeInt();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType)
            {
                if(variableType == typeof(nint)) return true;
                if(variableType == typeof(nuint)) return true;
                return false;
            }
            private NativeInt() { }
        }


        public sealed class F : StackType
        {
            internal static F Instance { get; } = new F();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType)
            {
                if(variableType == typeof(float)) return true;
                if(variableType == typeof(double)) return true;
                return false;
            }
            private F() { }
        }


        public sealed class O : StackType
        {
            public override Type? Type { get; }
            public override bool IsAssignableTo(Type variableType) => variableType.IsNullableAssignableFrom(Type);
            internal O(Type? type) => Type = type;
        }


        public sealed class ManagedPtr : StackType
        {
            internal static ManagedPtr Instance { get; } = new ManagedPtr();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType) => variableType == typeof(PowerEmit.ManagedPtrValue);
            private ManagedPtr() { }
        }


        public sealed class TransientPtr : StackType
        {
            internal static TransientPtr Instance { get; } = new TransientPtr();
            public override Type? Type => null;
            public override bool IsAssignableTo(Type variableType) => variableType == typeof(PowerEmit.ManagedPtrValue);
            private TransientPtr() { }
        }


        public sealed class UDValueType : StackType
        {
            public override Type? Type { get; }
            public override bool IsAssignableTo(Type variableType) => variableType.IsNullableAssignableFrom(Type);
            internal UDValueType(Type? type) => Type = type;
        }


        private enum StackTypeKind
        {
            Int64,
            Int32,
            NativeInt,
            F,
            O,
            ManagedPtr,
            TransientPtr,
            UDValueType,
        }
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

        public abstract Type? Type { get; }
        public abstract bool IsAssignableTo(Type variableType);
        public bool IsAssignableTo(VariableDescriptor variableDescriptor)
            => IsAssignableTo(variableDescriptor.VariableType);

        private StackType() { }
        
        private static StackTypeKind GetKind(Type? type)
        {
            if(type is null)
                return StackTypeKind.O;
            if(Array.IndexOf(_int32Types, type) >= 0)
                return StackTypeKind.Int32;
            if(Array.IndexOf(_int64Types, type) >= 0)
                return StackTypeKind.Int64;
            if(Array.IndexOf(_nativeIntTypes, type) >= 0)
                return StackTypeKind.NativeInt;
            if(Array.IndexOf(_nativeFloatTypes, type) >= 0)
                return StackTypeKind.F;
            if(type.IsByRef || type.IsPointer)
                return StackTypeKind.ManagedPtr;
            return StackTypeKind.O;
        }


        public static StackType FromType(Type? type)
            => GetKind(type) switch
            {
                StackTypeKind.O          => new O(type),
                StackTypeKind.Int32      => Int32     .Instance,
                StackTypeKind.Int64      => Int64     .Instance,
                StackTypeKind.NativeInt  => NativeInt .Instance,
                StackTypeKind.F          => F         .Instance,
                StackTypeKind.ManagedPtr => ManagedPtr.Instance,
                _ => throw new ArgumentException(nameof(type)),
            };

        public static bool AreEquatable(StackType x, StackType y)
            => (x, y) switch
            {
                (Int32     , Int32     ) => true,
                (Int32     , NativeInt ) => true,
                (Int64     , Int64     ) => true,
                (NativeInt , Int32     ) => true,
                (NativeInt , NativeInt ) => true,
                (NativeInt , ManagedPtr) => true,
                (F         , F         ) => true,
                (ManagedPtr, NativeInt ) => true,
                (ManagedPtr, ManagedPtr) => true,
                (O         , O         ) => true,
                _ => false,
            };


        public static bool AreOrderable(StackType x, StackType y)
            => (x, y) switch
            {
                (Int32     , Int32     ) => true,
                (Int32     , NativeInt ) => true,
                (Int64     , Int64     ) => true,
                (NativeInt , Int32     ) => true,
                (NativeInt , NativeInt ) => true,
                (F         , F         ) => true,
                (ManagedPtr, ManagedPtr) => true,
                _ => false,
            };


        public static bool AreEquatable(StackType[] types)
            => types.Length == 2
               ? AreEquatable(types[1], types[0])
               : throw new ArgumentException();


        public static bool AreOrderable(StackType[] types)
            => types.Length == 2
               ? AreOrderable(types[1], types[0])
               : throw new ArgumentException();
    }

}
