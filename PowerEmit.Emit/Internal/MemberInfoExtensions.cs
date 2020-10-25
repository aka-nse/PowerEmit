using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PowerEmit.Emit
{
    internal static class MemberInfoExtensions
    {
        private static readonly (Type type, string name)[] _NamePredefinedTypesBase
            = new []
            {
                (typeof(void), "void"),
                (typeof(bool), "bool"),
                (typeof(sbyte) , "int8" ),
                (typeof(short) , "int16"),
                (typeof(int)   , "int32"),
                (typeof(long)  , "int64"),
                (typeof(byte)  , "uint8" ),
                (typeof(ushort), "uint16"),
                (typeof(uint)  , "uint32"),
                (typeof(ulong) , "uint64"),
                (typeof(float) , "float32"),
                (typeof(double), "float64"),
                (typeof(string), "object"),
                (typeof(string), "string"),
            };
        private static readonly IReadOnlyDictionary<Type, string> _NamePredefinedTypes
            = _NamePredefinedTypesBase
            .Concat(_NamePredefinedTypesBase.Select(tpl => (type: tpl.type.MakeByRefType(), name: tpl.name + "&")))
            .ToDictionary(tpl => tpl.type, tpl => tpl.name);


        public static string GetILTypeShortName(this Type type, Assembly baseAssembly)
            => _NamePredefinedTypes.TryGetValue(type, out var tname)
               ? tname
               : type.GetILTypeFullName(baseAssembly);


        public static string GetILTypeFullName(this Type type, Assembly baseAssembly)
            => (type.IsValueType ? "valuetype " : "class ")
             + (type.Assembly == baseAssembly ? "" : $"[{type.Assembly.GetName().Name}]")
             + $"{type.FullName}";


        public static string GetQualifiedName(this MethodInfo method)
            => $"[{method.DeclaringType.Assembly.GetName().Name}]{method.DeclaringType.FullName}::{method.Name}";


        public static string GetSignature(this MethodInfo method)
            => $"{(method.IsStatic ? "" : "instance")} "
             + $"{method.ReturnType.GetILTypeShortName(method.DeclaringType.Assembly)} "
             + $"{method.GetQualifiedName()}"
             + "("
             + string.Join(", ", method.GetParameters().Select(p => p.ParameterType.GetILTypeFullName(method.DeclaringType.Assembly)))
             + ")";
    }
}
