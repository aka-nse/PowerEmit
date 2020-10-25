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
            => Type
            ?.CreateType()
            ?.GetMethod(Method.Name)
            ?.GetMethodBody()
            ?.GetILAsByteArray();
    }
}
