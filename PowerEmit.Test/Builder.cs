using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace PowerEmit
{
    public class Builder
    {
        private const MethodAttributes _methAttr
            = MethodAttributes.Public
            | MethodAttributes.Static;


        private static volatile int _index;


        private static string GetName(string prefix)
            => $"{prefix}_{Interlocked.Increment(ref _index):X08}";


        public AssemblyBuilder Assembly { get; }


        public ModuleBuilder Module { get; }


        public TypeBuilder Type { get; }


        public MethodBuilder Method { get; }


        public Type BuiltType
            => _builtType = _builtType ?? Type.CreateType()!;
        private Type? _builtType;


        public MethodInfo BuiltMethod
            => _builtMethod = _builtMethod ?? BuiltType.GetMethod(Method.Name, BindingFlags.Public | BindingFlags.Static)!;
        private MethodInfo? _builtMethod;


        public Builder(Type returnType, params Type[] parameterTypes)
        {
            var assmName = new AssemblyName(GetName("Assembly"));
            Assembly = AssemblyBuilder.DefineDynamicAssembly(assmName, AssemblyBuilderAccess.Run);

            Module = Assembly.DefineDynamicModule(GetName("Module"));
            Type = Module.DefineType(GetName("Type"),
                                      TypeAttributes.Public,
                                      typeof(object));

            Method = Type.DefineMethod(GetName("Method"), _methAttr, returnType, parameterTypes);
        }


        public byte[]? GetILBytes()
            => BuiltMethod
            ?.GetMethodBody()
            ?.GetILAsByteArray();
    }
}
