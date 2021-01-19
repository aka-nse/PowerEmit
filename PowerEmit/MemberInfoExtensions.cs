using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PowerEmit
{
    /// <summary>
    /// Provides extension methods for <see cref="MemberInfo"/> or its subclasses.
    /// </summary>
    public static partial class MemberInfoExtensions
    {
        private static readonly (Type type, string name)[] _NamePredefinedTypesBase
        = new[]
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

        /// <summary>
        /// Gets the specified method by signature.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <param name="bindingFlags"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException">Several matching were found.</exception>
        public static MethodInfo? GetMethod(this Type type, string methodName, BindingFlags bindingFlags, Type[] parameterTypes)
            => type
            .GetMethods(bindingFlags)
            .Where(mi => mi.Name == methodName)
            .SingleOrDefault(mi => mi.GetParameters().Select(pi => pi.ParameterType).SequenceEqual(parameterTypes));


        /// <summary>
        /// Gets the full name of the member instance.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetFullName(this MemberInfo member)
            => member is Type type
                ? type.FullName
                : $"{member.DeclaringType.FullName}::{member.Name}";

        /// <summary>
        /// Gets a return type to be pushed to the evaluation stack.
        /// </summary>
        /// <param name="methodLike"></param>
        /// <returns></returns>
        public static Type GetReturnType(this MethodBase methodLike)
            => methodLike switch
            {
                MethodInfo method => method.ReturnType,
                ConstructorInfo ctor => ctor.DeclaringType,
                _ => typeof(void),
            };


        public static Type[] GetParameterTypesWithInstance(this MethodInfo member)
        {
            var parameterTypes = member.GetParameters().Select(pi => pi.ParameterType);
            if(member.IsStatic)
                return parameterTypes.ToArray();
            else
                return new[] { member.DeclaringType }.Concat(parameterTypes).ToArray();
        }
    }
}
